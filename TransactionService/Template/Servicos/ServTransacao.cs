using TransactionService.DTO;
using TransactionService.Infra.Entidades;

namespace TransactionService.Servicos
{
    public interface IServTransacao
    {
        Transacao Criar(CriarTransacaoDTO dto);

        List<Transacao> Listar();

        Transacao? BuscarPorId(int id);
    }

    public class ServTransacao : IServTransacao
    {
        private readonly DataContext _dataContext;

        public ServTransacao(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Transacao Criar(CriarTransacaoDTO dto)
        {
            var transacao = new Transacao
            {
                ContaOrigemId = dto.ContaOrigemId,
                ContaDestinoId = dto.ContaDestinoId,
                BancoOrigemId = dto.BancoOrigemId,
                BancoDestinoId = dto.BancoDestinoId,
                AgenciaOrigemId = dto.AgenciaOrigemId,
                AgenciaDestinoId = dto.AgenciaDestinoId,
                Valor = dto.Valor,
                Status = dto.Status,
                LatitudeOrigem = dto.LatitudeOrigem,
                LongitudeOrigem = dto.LongitudeOrigem,
                LatitudeDestino = dto.LatitudeDestino,
                LongitudeDestino = dto.LongitudeDestino,
                DataHora = DateTime.Now
            };

            _dataContext.Transacoes.Add(transacao);
            _dataContext.SaveChanges();

            return transacao;
        }

        public List<Transacao> Listar()
        {
            return _dataContext.Transacoes.ToList();
        }

        public Transacao? BuscarPorId(int id)
        {
            return _dataContext.Transacoes.FirstOrDefault(t => t.Id == id);
        }
    }
}