namespace TransactionService.Infra.Entidades;

public class Transacao
{
    public int Id { get; set; }

    public int ContaOrigemId { get; set; }

    public int ContaDestinoId { get; set; }

    public int BancoOrigemId { get; set; }

    public int BancoDestinoId { get; set; }

    public int AgenciaOrigemId { get; set; }

    public int AgenciaDestinoId { get; set; }

    public decimal Valor { get; set; }

    public DateTime DataHora { get; set; }

    public string Status { get; set; }

    public decimal LatitudeOrigem { get; set; }

    public decimal LongitudeOrigem { get; set; }

    public decimal LatitudeDestino { get; set; }

    public decimal LongitudeDestino { get; set; }
}