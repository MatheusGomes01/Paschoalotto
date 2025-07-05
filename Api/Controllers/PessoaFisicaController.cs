using Application.DTOs;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/pessoas-fisicas")]
public class PessoaFisicaController : ControllerBase
{
    private readonly IPessoaFisicaService _service;

    public PessoaFisicaController(IPessoaFisicaService service)
    {
        _service = service;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Cadastrar([FromForm] PessoaFisicaDto dto, IFormFile foto)
    {
        var pessoa = await _service.CadastrarAsync(dto, foto);
        return Ok(pessoa);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Listar() => Ok(_service.Listar());
}
