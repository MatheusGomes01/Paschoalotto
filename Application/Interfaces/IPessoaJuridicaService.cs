using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IPessoaJuridicaService
    {
        Task<PessoaJuridica> CadastrarAsync(PessoaJuridicaDto dto, IFormFile logotipo);
        IEnumerable<PessoaJuridica> Listar();
    }
}
