namespace Domain.Entities;

public class PessoaFisica : Pessoa
{
    public string NomeCompleto { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Genero { get; set; } = string.Empty;
}