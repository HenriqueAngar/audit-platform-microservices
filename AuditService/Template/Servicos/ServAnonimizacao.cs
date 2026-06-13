using AnonymizationService.DTO;
using AnonymizationService.Infra.Entidades;
using Exemplo;

public interface IServAnonimizacao
{
    RegistroAnonimizacao Criar(CriarAnonimizacaoDTO dto);

    List<RegistroAnonimizacao> Listar();

    RegistroAnonimizacao? BuscarPorId(int id);
}


public class ServAnonimizacao : IServAnonimizacao
{
    private readonly DataContext _dataContext;

    public ServAnonimizacao(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public RegistroAnonimizacao Criar(CriarAnonimizacaoDTO dto)
    {
        var chave = Guid.NewGuid().ToString();

        var anonimizado =
            Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(dto.Dados)
            );

        var registro = new RegistroAnonimizacao
        {
            SolicitacaoId = dto.SolicitacaoId,
            DadosOriginais = dto.Dados,
            DadosAnonimizados = anonimizado,
            Chave = chave,
            DataProcessamento = DateTime.Now
        };

        _dataContext.RegistrosAnonimizacao.Add(registro);
        _dataContext.SaveChanges();

        return registro;
    }

    public List<RegistroAnonimizacao> Listar()
    {
        return _dataContext.RegistrosAnonimizacao.ToList();
    }

    public RegistroAnonimizacao? BuscarPorId(int id)
    {
        return _dataContext.RegistrosAnonimizacao
            .FirstOrDefault(r => r.Id == id);
    }
}