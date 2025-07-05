using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class PessoaFisicaService : IPessoaFisicaService
{
    private readonly AppDbContext _context;

    public PessoaFisicaService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PessoaFisica> CadastrarAsync(PessoaFisicaDto dto, IFormFile foto)
    {
        using var memoryStream = new MemoryStream();
        await foto.CopyToAsync(memoryStream);
        var imageBytes = memoryStream.ToArray();

        var pessoa = new PessoaFisica
        {
            NomeCompleto = dto.NomeCompleto,
            CPF = dto.CPF,
            DataNascimento = dto.DataNascimento,
            Genero = dto.Genero,
            Endereco = dto.Endereco,
            Telefone = dto.Telefone,
            Email = dto.Email,
            Imagem = imageBytes
        };

        _context.PessoasFisicas.Add(pessoa);
        await _context.SaveChangesAsync();

        return pessoa;
    }

    public IEnumerable<PessoaFisica> Listar() => _context.PessoasFisicas.ToList();
}
