using AnonymizationService.DTO;
using AnonymizationService.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace AnonymizationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnonimizacaoController : ControllerBase
{
    private readonly IServAnonimizacao _servico;

    public AnonimizacaoController(IServAnonimizacao servico)
    {
        _servico = servico;
    }

    /// <summary>
    /// Recebe dados JSON e retorna a versão anonimizada com AES.
    /// Chamado pelo ExtractionService quando AnonimizarResultado = true.
    /// </summary>
    [HttpPost]
    public IActionResult Processar([FromBody] SolicitarAnonimizacaoDTO dto)
    {
        try
        {
            var resultado = _servico.Processar(dto);
            return Ok(resultado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Busca o log de uma anonimização pelo ID do registro.
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult BuscarLog(int id)
    {
        var registro = _servico.BuscarLog(id);

        if (registro == null)
            return NotFound(new { mensagem = $"Registro de anonimização {id} não encontrado." });

        return Ok(registro);
    }
}
