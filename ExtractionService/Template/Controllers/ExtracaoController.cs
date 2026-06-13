using Microsoft.AspNetCore.Mvc;
using ExtractionService.DTO;
using ExtractionService.Servicos;

namespace ExtractionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtracaoController : ControllerBase
{
    private readonly IServExtracao _servico;

    public ExtracaoController(
        IServExtracao servico)
    {
        _servico = servico;
    }

    [HttpPost]
    public IActionResult Processar(
        SolicitarExtracaoDTO dto)
    {
        return Ok(
            _servico.Processar(dto)
        );
    }

    [HttpGet("{id}")]
    public IActionResult Buscar(
        int id)
    {
        var resultado =
            _servico.Buscar(id);

        if (resultado == null)
            return NotFound();

        return Ok(resultado);
    }
}