using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Sinqia.CoreBank.Services.CUC.WCF.Autenticacao;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class AutenticacaoCUCService
    {
        private CucCliAutenticacaoClient _ServiceClient;
        public CucCliAutenticacaoClient ServiceClient { get
            {
                if (_ServiceClient == null) _ServiceClient = new CucCliAutenticacaoClient();
                return _ServiceClient;
            }
        }

    
        public string GetToken(string login, string senha)
        {
            string token = string.Empty;

            try
            {
                CucCluRetornoAutenticacao dadosRetorno = ServiceClient.Autenticar(login, senha);
  
                token = dadosRetorno.Token;

                return token;
            }
            catch (TimeoutException timeout)
            {
                ServiceClient.Abort();
                throw;
            }
            catch (CommunicationException commException)
            {
                ServiceClient.Abort();
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}
