using Microsoft.AspNetCore.Mvc;
using TransactionService.DTO;
using TransactionService.Servicos;

namespace TransactionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransacaoController : ControllerBase
    {
        private readonly IServTransacao _servTransacao;

        public TransacaoController(IServTransacao servTransacao)
        {
            _servTransacao = servTransacao;
        }

        [HttpPost]
        public IActionResult Criar(CriarTransacaoDTO dto)
        {
            var resultado = _servTransacao.Criar(dto);

            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_servTransacao.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var transacao = _servTransacao.BuscarPorId(id);

            if (transacao == null)
                return NotFound();

            return Ok(transacao);
        }
    }
}