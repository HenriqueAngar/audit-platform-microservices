namespace AnonymizationService.Infra.Entidades;

public class RegistroAnonimizacao
{
    public int Id { get; set; }

    public int SolicitanteId { get; set; }

    public string TipoSolicitante { get; set; } = string.Empty;

    public string ParametrosExtracao { get; set; } = string.Empty;

    public string ChaveCriptografia { get; set; } = string.Empty;

    public DateTime DataSolicitacao { get; set; }

    public bool PermiteDescriptografia { get; set; }

    public string Status { get; set; } = string.Empty;
}