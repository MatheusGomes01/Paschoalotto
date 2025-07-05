namespace Domain.Entities;

public class PessoaJuridica : Pessoa
{
    public string RazaoSocial { get; set; } = string.Empty;
    public string NomeFantasia { get; set; } = string.Empty;
    public string CNPJ { get; set; } = string.Empty;
    public string? InscricaoEstadual { get; set; }
    public string? InscricaoMunicipal { get; set; }
    public string RepresentanteLegal { get; set; } = string.Empty;
    public string CPFRepresentanteLegal { get; set; } = string.Empty;
}