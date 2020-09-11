using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
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

        
        public async Task<RetornoIntegracaoPessoa> AtualizarPessoa(ParametroIntegracaoPessoa param, string xml)
        {

            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            var ret = await ServiceClient.AtualizarAsync(parametrosLogin, xml);

            RetornoIntegracaoPessoa retorno = new RetornoIntegracaoPessoa();

            //retorno.CodigoFilial = ret.Result.CodigoFilial;
            //retorno.CodigoPessoa = ret.Result.CodigoPessoa;
            //retorno.CodigoContaRelacionamento = ret.Result.CodigoContaRelacionamento;
            //retorno.TipoPessoa = ret.Result.TipoPessoa;
            //retorno.Excecao = ret.Result.Excecao;
            //retorno.Xml = ret.Result.Xml;

            return retorno;



        }

        public async Task<RetornoIntegracaoPessoa> SelecionarCabecalho(ParametroIntegracaoPessoa param, string cod_pessoa, string cod_filial = null)
        {
            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            var ret = await ServiceClient.SelecionarCabecalhoAsync(parametrosLogin, cod_pessoa, cod_filial);
            
            RetornoIntegracaoPessoa retorno = new RetornoIntegracaoPessoa();

            //retorno.CodigoFilial = ret.Result.CodigoFilial;
            //retorno.CodigoPessoa = ret.Result.CodigoPessoa;
            //retorno.CodigoContaRelacionamento = ret.Result.CodigoContaRelacionamento;
            //retorno.TipoPessoa = ret.Result.TipoPessoa;
            //retorno.Excecao = ret.Result.Excecao;
            //retorno.Xml = ret.Result.Xml;

            return retorno;

        }


    }
}
