namespace AnonymizationService.DTO;

public class ResultadoAnonimizacaoDTO
{
    public int RegistroAnonimizacaoId { get; set; }

    public string DadosAnonimizadosJson
    { get; set; } = string.Empty;
}