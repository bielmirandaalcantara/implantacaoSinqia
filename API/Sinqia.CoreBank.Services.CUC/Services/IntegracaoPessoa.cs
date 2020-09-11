using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.CadastroPessoa;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Constantes;

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

        public ConfiguracaoURICUC configuracaoURICUC { get; set; }

        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

        public IntegracaoPessoa(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
        {
            configuracaoCUC = _configuracaoCUC;
            configuracaoURICUC = ConfiguracaoCUCServico.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoa, configuracaoCUC);
        }

        
        public async Task<RetornoIntegracaoPessoa> AtualizarPessoa(ParametroIntegracaoPessoa param, string xml)
        {
            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);


            //client.Endpoint.Address = eab.ToEndpointAddress();
            //client.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 2, 0);
            //client.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 2, 0);
            //client.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            //client.Endpoint.Binding.SendTimeout = new TimeSpan(0, 0, configuracaoURICUC.Timeout);

            var ret = await client.AtualizarAsync(parametrosLogin, xml);

            RetornoIntegracaoPessoa retorno = new RetornoIntegracaoPessoa();

            /*
            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            ServiceClient.Endpoint.Address = new EndpointAddress(configuracaoURICUC.URI);

            var ret = await ServiceClient.AtualizarAsync(parametrosLogin, xml);

            RetornoIntegracaoPessoa retorno = new RetornoIntegracaoPessoa();

            //retorno.CodigoFilial = ret.Result.CodigoFilial;
            //retorno.CodigoPessoa = ret.Result.CodigoPessoa;
            //retorno.CodigoContaRelacionamento = ret.Result.CodigoContaRelacionamento;
            //retorno.TipoPessoa = ret.Result.TipoPessoa;
            //retorno.Excecao = ret.Result.Excecao;
            //retorno.Xml = ret.Result.Xml;
            */

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
