using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Sinqia.CoreBank.Services.CUC.CadastroPessoa;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class IntegracaoPessoa
    {
        private CucCliCadastroPessoaClient _ServiceClient;
        public CucCliCadastroPessoaClient ServiceClient
        {
            get
            {
                if (_ServiceClient == null) _ServiceClient = new CucCliCadastroPessoaClient();
                return _ServiceClient;
            }
        }

        /*
        public CucCluRetorno AtualizarPessoa(ParametroIntegracaoPessoa param, DataSetPessoa pessoa)
        {

            ServiceClient.AtualizarAsync()
        }
        */
    }
}
