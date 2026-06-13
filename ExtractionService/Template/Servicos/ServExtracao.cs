using ExtractionService.DTO;
using ExtractionService.Infra.Entidades;
using System.Linq;

namespace ExtractionService.Servicos;

public interface IServExtracao
{
    ResultadoExtracaoDTO Processar(
        SolicitarExtracaoDTO dto);

    RegistroExtracao? Buscar(int id);
}

public class ServExtracao : IServExtracao
{
    private readonly DataContext _dataContext;

    public ServExtracao(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public ResultadoExtracaoDTO Processar(
        SolicitarExtracaoDTO dto)
    {
        var registro = new RegistroExtracao
        {
            SolicitanteId = dto.SolicitanteId,

            TipoOperacao = dto.TipoOperacao,

            ParametrosConsulta =
                dto.ParametrosConsulta,

            AnonimizarResultado =
                dto.AnonimizarResultado,

            DataSolicitacao =
                DateTime.Now,

            Status = "CONCLUIDA"
        };

        _dataContext
            .RegistrosExtracao
            .Add(registro);

        _dataContext
            .SaveChanges();

        return new ResultadoExtracaoDTO
        {
            RegistroExtracaoId =
                registro.Id,

            Status =
                registro.Status,

            Resultado =
                "Extração registrada"
        };
    }

    public RegistroExtracao? Buscar(int id)
    {
        return _dataContext
            .RegistrosExtracao
            .FirstOrDefault(r => r.Id == id);
    }
}