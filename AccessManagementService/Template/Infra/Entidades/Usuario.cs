namespace AccessManagementService.Infra.Entidades;

public class Usuario
{
    public int Id { get; set; }

    public string Nome { get; set; }
        = string.Empty;

    public string Login { get; set; }
        = string.Empty;

    public string Senha { get; set; }
        = string.Empty;

    public bool Autorizado { get; set; }

    public string TipoUsuario { get; set; }
        = string.Empty;
}