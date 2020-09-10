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

        
        public CucCluRetorno AtualizarPessoa(ParametroIntegracaoPessoa param, DataSetPessoa pessoa)
        {
            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            var ret = ServiceClient.AtualizarAsync(parametrosLogin, pessoa.ToString());

            CucCluRetorno retorno = new CucCluRetorno();

            retorno.CodigoFilial = ret.Result.CodigoFilial;
            retorno.CodigoPessoa = ret.Result.CodigoPessoa;
            retorno.CodigoContaRelacionamento = ret.Result.CodigoContaRelacionamento;
            retorno.TipoPessoa = ret.Result.TipoPessoa;
            retorno.Excecao = ret.Result.Excecao;
            retorno.Xml = ret.Result.Xml;

            return retorno;



        }
        
    }
}
