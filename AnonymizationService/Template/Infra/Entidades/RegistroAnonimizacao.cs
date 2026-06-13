public class RegistroAnonimizacao
{
    public int Id { get; set; }

    public int ExtracaoId { get; set; }

    public string ChaveCriptografia { get; set; }
        = string.Empty;

    public string VetorInicializacao { get; set; }
        = string.Empty;

    public string CamposAnonimizados { get; set; }
        = string.Empty;

    public int QuantidadeRegistros { get; set; }

    public DateTime DataProcessamento { get; set; }
}