using ExtractionService.DTO;
using ExtractionService.Infra.Entidades;
using System.Net.Http.Json;
using System.Text.Json;

namespace ExtractionService.Servicos;

public interface IServExtracao
{
    Task<ResultadoExtracaoDTO> Processar(SolicitarExtracaoDTO dto);
    RegistroExtracao? Buscar(int id);
}

public class ServExtracao : IServExtracao
{
    private readonly DataContext _dataContext;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public ServExtracao(
        DataContext dataContext,
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration)
    {
        _dataContext = dataContext;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
    }

    public async Task<ResultadoExtracaoDTO> Processar(SolicitarExtracaoDTO dto)
    {
        // ── INTEGRAÇÃO 1: valida o solicitante no AccessManagementService ──
        var usuarioAutorizado = await ValidarSolicitante(dto.SolicitanteId);

        if (!usuarioAutorizado)
        {
            return new ResultadoExtracaoDTO
            {
                RegistroExtracaoId = 0,
                Status = "NEGADA",
                Resultado = $"Solicitante {dto.SolicitanteId} não encontrado ou não autorizado."
            };
        }

        // Simula dados extraídos (em produção viria de uma fonte real)
        var dadosExtraidos = JsonSerializer.Serialize(new
        {
            SolicitanteId = dto.SolicitanteId,
            TipoOperacao = dto.TipoOperacao,
            Parametros = dto.ParametrosConsulta,
            DataExtracao = DateTime.Now
        });

        int? registroAnonimizacaoId = null;
        var resultado = dadosExtraidos;

        // ── INTEGRAÇÃO 2: envia para anonimização se solicitado ──
        if (dto.AnonimizarResultado)
        {
            var resultadoAnonimizacao = await AnonimizarDados(dadosExtraidos);

            if (resultadoAnonimizacao != null)
            {
                registroAnonimizacaoId = resultadoAnonimizacao.RegistroAnonimizacaoId;
                resultado = resultadoAnonimizacao.DadosAnonimizadosJson;
            }
        }

        // Persiste o registro de extração
        var registro = new RegistroExtracao
        {
            SolicitanteId = dto.SolicitanteId,
            TipoOperacao = dto.TipoOperacao,
            ParametrosConsulta = dto.ParametrosConsulta,
            AnonimizarResultado = dto.AnonimizarResultado,
            DataSolicitacao = DateTime.Now,
            Status = "CONCLUIDA",
            RegistroAnonimizacaoId = registroAnonimizacaoId
        };

        _dataContext.RegistrosExtracao.Add(registro);
        _dataContext.SaveChanges();

        return new ResultadoExtracaoDTO
        {
            RegistroExtracaoId = registro.Id,
            Status = registro.Status,
            Resultado = resultado
        };
    }

    public RegistroExtracao? Buscar(int id)
    {
        return _dataContext
            .RegistrosExtracao
            .FirstOrDefault(r => r.Id == id);
    }

    // ── Chamada ao AccessManagementService ──────────────────────────────
    private async Task<bool> ValidarSolicitante(int solicitanteId)
    {
        try
        {
            var baseUrl = _configuration["Servicos:AccessManagement"];
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"{baseUrl}/api/Usuario/{solicitanteId}");

            if (!response.IsSuccessStatusCode)
                return false;

            var usuario = await response.Content
                .ReadFromJsonAsync<UsuarioRespostaDTO>();

            return usuario?.Autorizado == true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ExtractionService] Erro ao validar solicitante: {ex.Message}");
            return false;
        }
    }

    // ── Chamada ao AnonymizationService ─────────────────────────────────
    private async Task<ResultadoAnonimizacaoDTO?> AnonimizarDados(string dadosJson)
    {
        try
        {
            var baseUrl = _configuration["Servicos:Anonymization"];
            var client = _httpClientFactory.CreateClient();

            var payload = new
            {
                ExtracaoId = 0, // será atualizado após salvar o registro
                CamposAnonimizados = new[] { "SolicitanteId", "Parametros" },
                DadosJson = dadosJson
            };

            var response = await client.PostAsJsonAsync(
                $"{baseUrl}/api/Anonimizacao", payload);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content
                .ReadFromJsonAsync<ResultadoAnonimizacaoDTO>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ExtractionService] Erro ao anonimizar: {ex.Message}");
            return null;
        }
    }
}

// DTOs de resposta das chamadas externas
internal class UsuarioRespostaDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string TipoUsuario { get; set; } = string.Empty;
    public bool Autorizado { get; set; }
}

internal class ResultadoAnonimizacaoDTO
{
    public int RegistroAnonimizacaoId { get; set; }
    public string DadosAnonimizadosJson { get; set; } = string.Empty;
}
