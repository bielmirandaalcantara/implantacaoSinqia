using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoa;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Constantes;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class IntegracaoPessoaCUCService
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

        public IntegracaoPessoaCUCService(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
        {
            configuracaoCUC = _configuracaoCUC;
            configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoa, configuracaoCUC);
        }

        private CucCluParametro GerarParametroCUC(ParametroIntegracaoPessoa param)
        {
            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            return parametrosLogin;
        }

        private RetornoIntegracaoPessoa GerarRetornoIntegracaoPessoa(CucCluRetorno paramRetorno)
        {
            RetornoIntegracaoPessoa retorno = new RetornoIntegracaoPessoa();
            retorno.CodigoFilial = paramRetorno.CodigoFilial;
            retorno.CodigoPessoa = paramRetorno.CodigoPessoa;
            retorno.CodigoContaRelacionamento = paramRetorno.CodigoContaRelacionamento;
            retorno.TipoPessoa = paramRetorno.TipoPessoa;
            retorno.Excecao = paramRetorno.Excecao;
            retorno.Xml = paramRetorno.Xml;
            return retorno;
        }

        public RetornoIntegracaoPessoa AtualizarPessoa(ParametroIntegracaoPessoa param, string xml)
        {
            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.Atualizar(parametrosLogin, xml);

                RetornoIntegracaoPessoa retorno = GerarRetornoIntegracaoPessoa(ret);
                return retorno;
            }
            catch (TimeoutException timeoutEx)
            {
                client.Abort();
                throw new Exception("Tempo de conexão expirado", timeoutEx);
            }
            catch (EndpointNotFoundException endPointEx)
            {
                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
            }
        }

        public RetornoIntegracaoPessoa SelecionarCabecalho(ParametroIntegracaoPessoa param, string cod_pessoa, string cod_filial = null)
        {

            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.SelecionarCabecalho(parametrosLogin, cod_pessoa, cod_filial);

                RetornoIntegracaoPessoa retorno = GerarRetornoIntegracaoPessoa(ret);

                return retorno;
            }
            catch (TimeoutException timeoutEx)
            {
                client.Abort();
                throw new Exception("Tempo de conexão expirado", timeoutEx);
            }
            catch (EndpointNotFoundException endPointEx)
            {
                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
            }
        }
    }
}
