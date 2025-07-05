using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PessoaJuridicaService : IPessoaJuridicaService
    {
        private readonly AppDbContext _context;

        public PessoaJuridicaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PessoaJuridica> CadastrarAsync(PessoaJuridicaDto dto, IFormFile logotipo)
        {
            using var memoryStream = new MemoryStream();
            await logotipo.CopyToAsync(memoryStream);
            var imageBytes = memoryStream.ToArray();

            var pessoa = new PessoaJuridica
            {
                RazaoSocial = dto.RazaoSocial,
                NomeFantasia = dto.NomeFantasia,
                CNPJ = dto.CNPJ,
                InscricaoEstadual = dto.InscricaoEstadual,
                InscricaoMunicipal = dto.InscricaoMunicipal,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone,
                Email = dto.Email,
                RepresentanteLegal = dto.RepresentanteLegal,
                CPFRepresentanteLegal = dto.CPFRepresentanteLegal,
                Imagem = imageBytes
            };

            _context.PessoasJuridicas.Add(pessoa);
            await _context.SaveChangesAsync();

            return pessoa;
        }

        public IEnumerable<PessoaJuridica> Listar() => _context.PessoasJuridicas.ToList();
    }
}
