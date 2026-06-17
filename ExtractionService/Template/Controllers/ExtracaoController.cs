using ExtractionService.DTO;
using ExtractionService.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace ExtractionService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExtracaoController : ControllerBase
{
    private readonly IServExtracao _servico;

    public ExtracaoController(IServExtracao servico)
    {
        _servico = servico;
    }

    /// <summary>
    /// Processa uma extração de dados.
    /// Valida o solicitante no AccessManagementService (integração 1).
    /// Se AnonimizarResultado = true, chama o AnonymizationService (integração 2).
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Processar([FromBody] SolicitarExtracaoDTO dto)
    {
        try
        {
            var resultado = await _servico.Processar(dto);

            if (resultado.Status == "NEGADA")
                return Unauthorized(resultado);

            return Ok(resultado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Busca um registro de extração pelo ID.
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Buscar(int id)
    {
        var resultado = _servico.Buscar(id);

        if (resultado == null)
            return NotFound(new { mensagem = $"Extração {id} não encontrada." });

        return Ok(resultado);
    }
}
