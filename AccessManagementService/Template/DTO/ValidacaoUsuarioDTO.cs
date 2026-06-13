namespace AccessManagementService.DTO;

public class ValidacaoUsuarioDTO
{
    public bool Valido { get; set; }

    public bool Autorizado { get; set; }

    public int UsuarioId { get; set; }
}