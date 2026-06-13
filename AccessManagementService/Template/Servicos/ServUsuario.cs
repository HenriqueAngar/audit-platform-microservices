using AccessManagementService.DTO;
using AccessManagementService.Infra.Entidades;
using System.Linq;

namespace AccessManagementService.Servicos;

public interface IServUsuario
{
    Usuario Criar(
        CriarUsuarioDTO dto);

    ValidacaoUsuarioDTO Login(
        LoginDTO dto);

    Usuario? Buscar(int id);
}

public class ServUsuario : IServUsuario
{
    private readonly DataContext _dataContext;

    public ServUsuario(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public Usuario Criar(
        CriarUsuarioDTO dto)
    {
        var usuario = new Usuario
        {
            Nome = dto.Nome,
            Login = dto.Login,
            Senha = dto.Senha,
            TipoUsuario = dto.TipoUsuario,
            Autorizado = true
        };

        _dataContext
            .Usuarios
            .Add(usuario);

        _dataContext
            .SaveChanges();

        return usuario;
    }

    public ValidacaoUsuarioDTO Login(
        LoginDTO dto)
    {
        var usuario =
            _dataContext.Usuarios
                .FirstOrDefault(u =>
                    u.Login == dto.Login &&
                    u.Senha == dto.Senha);

        if (usuario == null)
        {
            return new ValidacaoUsuarioDTO
            {
                Valido = false,
                Autorizado = false,
                UsuarioId = 0
            };
        }

        return new ValidacaoUsuarioDTO
        {
            Valido = true,
            Autorizado = usuario.Autorizado,
            UsuarioId = usuario.Id
        };
    }

    public Usuario? Buscar(int id)
    {
        return _dataContext
            .Usuarios
            .FirstOrDefault(u => u.Id == id);
    }
}