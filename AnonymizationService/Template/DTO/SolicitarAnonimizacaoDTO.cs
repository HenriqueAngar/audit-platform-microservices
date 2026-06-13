namespace AnonymizationService.DTO;

public class SolicitarAnonimizacaoDTO
{
    public int ExtracaoId { get; set; }

    public List<string> CamposAnonimizados
    { get; set; } = new();

    public string DadosJson { get; set; }
        = string.Empty;
}