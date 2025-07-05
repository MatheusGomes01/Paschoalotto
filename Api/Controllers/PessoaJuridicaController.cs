using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/pessoas-juridicas")]
public class PessoaJuridicaController : ControllerBase
{
    private readonly IPessoaJuridicaService _service;

    public PessoaJuridicaController(IPessoaJuridicaService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Cadastrar([FromForm] PessoaJuridicaDto dto, IFormFile logotipo)
    {
        var pessoa = await _service.CadastrarAsync(dto, logotipo);
        return Ok(pessoa);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Listar() => Ok(_service.Listar());
}

