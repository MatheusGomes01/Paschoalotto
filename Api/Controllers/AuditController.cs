using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/audit")]
    [Authorize] // Requer autenticação
    public class AuditController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuditController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            int page = 1,
            int pageSize = 20,
            string? tableName = null,
            string? userId = null)
        {
            var query = _context.AuditLogs.AsQueryable();

            if (!string.IsNullOrEmpty(tableName))
                query = query.Where(a => a.TableName == tableName);

            if (!string.IsNullOrEmpty(userId))
                query = query.Where(a => a.UserId == userId);

            var total = await query.CountAsync();

            var logs = await query
                .OrderByDescending(a => a.DateTime)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                total,
                page,
                pageSize,
                data = logs
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var log = await _context.AuditLogs.FindAsync(id);

            if (log == null)
                return NotFound();

            return Ok(log);
        }
    }
}
