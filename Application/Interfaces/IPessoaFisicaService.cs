using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces;

public interface IPessoaFisicaService
{
    Task<PessoaFisica> CadastrarAsync(PessoaFisicaDto dto, IFormFile foto);
    IEnumerable<PessoaFisica> Listar();
}

