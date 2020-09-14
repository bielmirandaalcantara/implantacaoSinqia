using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.WCF.Autenticacao;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class AutenticacaoCUCService
    {
        public ConfiguracaoURICUC configuracaoURICUC { get; set; }

        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

        public AutenticacaoCUCService(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
        {
            configuracaoCUC = _configuracaoCUC;
            configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.Autenticacao, configuracaoCUC);
        }

        public string GetToken(string login, string senha)
        {
            string token = string.Empty;
            
            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliAutenticacaoClient client = new CucCliAutenticacaoClient(CucCliAutenticacaoClient.EndpointConfiguration.BasicHttpBinding_ICucCliAutenticacao, address);

            try
            {
                CucCluRetornoAutenticacao dadosRetorno = client.Autenticar(login, senha);
                token = dadosRetorno.Token;
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
