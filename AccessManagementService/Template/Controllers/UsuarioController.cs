using AccessManagementService.DTO;
using AccessManagementService.Servicos;
using Microsoft.AspNetCore.Mvc;

namespace AccessManagementService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IServUsuario _servico;

    public UsuarioController(IServUsuario servico)
    {
        _servico = servico;
    }

    /// <summary>
    /// Cria um novo usuário no sistema.
    /// </summary>
    [HttpPost]
    public IActionResult Criar([FromBody] CriarUsuarioDTO dto)
    {
        try
        {
            var usuario = _servico.Criar(dto);
            return Ok(usuario);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Realiza login e retorna validação do usuário.
    /// Chamado pelo ExtractionService para validar o solicitante.
    /// </summary>
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO dto)
    {
        try
        {
            var resultado = _servico.Login(dto);

            if (!resultado.Valido)
                return Unauthorized(new { mensagem = "Login ou senha inválidos." });

            if (!resultado.Autorizado)
                return Forbid();

            return Ok(resultado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Busca um usuário por ID e retorna se está autorizado.
    /// Chamado pelo ExtractionService antes de processar uma extração.
    /// </summary>
    [HttpGet("{id}")]
    public IActionResult Buscar(int id)
    {
        var usuario = _servico.Buscar(id);

        if (usuario == null)
            return NotFound(new { mensagem = $"Usuário {id} não encontrado." });

        return Ok(new
        {
            usuario.Id,
            usuario.Nome,
            usuario.TipoUsuario,
            usuario.Autorizado
        });
    }
}
