namespace ExtractionService.Infra.Entidades;

public class RegistroExtracao
{
    public int Id { get; set; }

    public int SolicitanteId { get; set; }

    public string TipoOperacao { get; set; }
        = string.Empty;

    public string ParametrosConsulta { get; set; }
        = string.Empty;

    public bool AnonimizarResultado { get; set; }

    public DateTime DataSolicitacao { get; set; }

    public string Status { get; set; }
        = string.Empty;

    public int? RegistroAnonimizacaoId { get; set; }
}