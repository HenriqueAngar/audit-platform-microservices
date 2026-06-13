namespace ExtractionService.DTO;

public class ResultadoExtracaoDTO
{
    public int RegistroExtracaoId { get; set; }

    public string Status { get; set; }
        = string.Empty;

    public string Resultado { get; set; }
        = string.Empty;
}