using AnonymizationService.DTO;
using AnonymizationService.Infra.Entidades;
using AnonymizationService.Infra.Util;
using System.Security.Cryptography;

namespace AnonymizationService.Servicos
{
    public interface IServAnonimizacao
    {
        ResultadoAnonimizacaoDTO Processar(
            SolicitarAnonimizacaoDTO dto);

        RegistroAnonimizacao? BuscarLog(int id);
    }

    public class ServAnonimizacao : IServAnonimizacao
    {
        private readonly DataContext _dataContext;

        public ServAnonimizacao(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public ResultadoAnonimizacaoDTO Processar(
            SolicitarAnonimizacaoDTO dto)
        {
            using var aes = Aes.Create();

            aes.GenerateKey();
            aes.GenerateIV();

            var chave =
                Convert.ToBase64String(aes.Key);

            var iv =
                Convert.ToBase64String(aes.IV);

            var dadosAnonimizados =
                CriptografiaUtil.Criptografar(
                    dto.DadosJson,
                    aes.Key,
                    aes.IV);

            var registro =
                new RegistroAnonimizacao
                {
                    ExtracaoId = dto.ExtracaoId,

                    ChaveCriptografia = chave,

                    VetorInicializacao = iv,

                    CamposAnonimizados =
                        string.Join(",",
                            dto.CamposAnonimizados),

                    QuantidadeRegistros = 1,

                    DataProcessamento =
                        DateTime.Now
                };

            _dataContext
                .RegistrosAnonimizacao
                .Add(registro);

            _dataContext.SaveChanges();

            return new ResultadoAnonimizacaoDTO
            {
                RegistroAnonimizacaoId =
                    registro.Id,

                DadosAnonimizadosJson =
                    dadosAnonimizados
            };
        }

        public RegistroAnonimizacao? BuscarLog(int id)
        {
            return _dataContext
                .RegistrosAnonimizacao
                .FirstOrDefault(r => r.Id == id);
        }
    }
}