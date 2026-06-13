namespace AccessManagementService.DTO;

public class CriarUsuarioDTO
{
    public string Nome { get; set; }
        = string.Empty;

    public string Login { get; set; }
        = string.Empty;

    public string Senha { get; set; }
        = string.Empty;

    public string TipoUsuario { get; set; }
        = string.Empty;
}