using System;
namespace Domain.Entities
{
    public abstract class Pessoa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Endereco { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[]? Imagem { get; set; } // Armazenamento da imagem em Base64
    }
}
