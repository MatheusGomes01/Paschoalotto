using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;

        public AppDbContext(DbContextOptions<AppDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        public override int SaveChanges()
        {
            AddAuditLogs();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddAuditLogs();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddAuditLogs()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added
                         || e.State == EntityState.Modified
                         || e.State == EntityState.Deleted)
                .ToList();

            var username = _currentUserService.GetCurrentUsername();
            var now = DateTime.UtcNow;

            foreach (var entry in entries)
            {
                var audit = new AuditLog
                {
                    TableName = entry.Entity.GetType().Name,
                    DateTime = now,
                    UserId = username,
                    Action = entry.State.ToString()
                };

                var keyNames = entry.Metadata.FindPrimaryKey()?.Properties.Select(p => p.Name) ?? Enumerable.Empty<string>();
                var keyValues = new Dictionary<string, object>();
                foreach (var keyName in keyNames)
                {
                    keyValues[keyName] = entry.Property(keyName).CurrentValue!;
                }
                audit.KeyValues = System.Text.Json.JsonSerializer.Serialize(keyValues);

                if (entry.State == EntityState.Added)
                {
                    audit.NewValues = System.Text.Json.JsonSerializer.Serialize(entry.CurrentValues.ToObject());
                }
                else if (entry.State == EntityState.Deleted)
                {
                    audit.OldValues = System.Text.Json.JsonSerializer.Serialize(entry.OriginalValues.ToObject());
                }
                else if (entry.State == EntityState.Modified)
                {
                    audit.OldValues = System.Text.Json.JsonSerializer.Serialize(entry.OriginalValues.ToObject());
                    audit.NewValues = System.Text.Json.JsonSerializer.Serialize(entry.CurrentValues.ToObject());
                }

                AuditLogs.Add(audit);
            }
        }
    }
}
