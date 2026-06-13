namespace AnonymizationService.DTO;

public class SolicitarAnonimizacaoDTO
{
    public int ExtracaoId { get; set; }

    public List<string> CamposAnonimizados { get; set; } = [];

    public string DadosJson { get; set; } = string.Empty;
}

public class ResultadoAnonimizacaoDTO
{
    public int RegistroAnonimizacaoId { get; set; }

    public string DadosAnonimizados { get; set; } = string.Empty;
}