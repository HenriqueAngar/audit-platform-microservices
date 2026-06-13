namespace ExtractionService.DTO;

public class SolicitarExtracaoDTO
{
    public int SolicitanteId { get; set; }

    public string TipoOperacao { get; set; }
        = string.Empty;

    public string ParametrosConsulta { get; set; }
        = string.Empty;

    public bool AnonimizarResultado { get; set; }
}