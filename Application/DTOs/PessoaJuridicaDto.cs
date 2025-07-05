

namespace Application.DTOs
{
    public class PessoaJuridicaDto
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string RepresentanteLegal { get; set; }
        public string CPFRepresentanteLegal { get; set; }
    }
}
