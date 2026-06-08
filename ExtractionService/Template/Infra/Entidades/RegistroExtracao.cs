namespace ExtractionService.Infra.Entidades;

public class RegistroExtracao
{
    public int Id { get; set; }

    public int SolicitanteId { get; set; }

    public decimal? ValorMinimo { get; set; }

    public decimal? ValorMaximo { get; set; }

    public DateTime? DataInicial { get; set; }

    public DateTime? DataFinal { get; set; }

    public int? BancoOrigemId { get; set; }

    public int? BancoDestinoId { get; set; }

    public bool AnonimizarResultado { get; set; }

    public DateTime DataSolicitacao { get; set; }

    public string Status { get; set; } = string.Empty;

    public int? RegistroAnonimizacaoId { get; set; }
}