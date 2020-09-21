using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.WCF.Autenticacao;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class AutenticacaoCUCService
    {
        private IOptions<ConfiguracaoBaseCUC> _configuracaoCUC;
        private LogService _log;

        public AutenticacaoCUCService(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, LogService log)
        {
            _configuracaoCUC = configuracaoCUC;
            _log = log;
        }

        public string GetToken(string login, string senha)
        {
            _log.TraceMethodStart();

            string token = string.Empty;

            ConfiguracaoURICUC configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.Autenticacao, _configuracaoCUC);
            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliAutenticacaoClient client = new CucCliAutenticacaoClient(CucCliAutenticacaoClient.EndpointConfiguration.BasicHttpBinding_ICucCliAutenticacao, address);

            try
            {
                CucCluRetornoAutenticacao dadosRetorno = client.Autenticar(login, senha);
                token = dadosRetorno.Token;

                _log.TraceMethodEnd();

                return token;
            }
            catch (TimeoutException timeoutEx)
            {
                client.Abort();
                throw new Exception("Tempo de conexão expirado", timeoutEx);                
            }
            catch(EndpointNotFoundException endPointEx)
            {
                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
