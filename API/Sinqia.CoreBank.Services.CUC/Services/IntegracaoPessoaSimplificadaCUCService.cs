using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Constantes;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class IntegracaoPessoaSimplificadaCUCService
    {
        public ConfiguracaoURICUC configuracaoURICUC { get; set; }

        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

        public IntegracaoPessoaSimplificadaCUCService(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
        {
            configuracaoCUC = _configuracaoCUC;
            configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoaSimplificada, configuracaoCUC);
        }

        private CucCluParametro GerarParametroCUC(ParametroIntegracaoPessoaSimplificada param)
        {
            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            return parametrosLogin;
        }

        private RetornoIntegracaoPessoaSimplificada GerarRetornoIntegracaoPessoa(CucCluRetorno paramRetorno)
        {
            RetornoIntegracaoPessoaSimplificada retorno = new RetornoIntegracaoPessoaSimplificada();
            retorno.CodigoFilial = paramRetorno.CodigoFilial;
            retorno.CodigoPessoa = paramRetorno.CodigoPessoa;
            retorno.CodigoContaRelacionamento = paramRetorno.CodigoContaRelacionamento;
            retorno.TipoPessoa = paramRetorno.TipoPessoa;
            retorno.Excecao = paramRetorno.Excecao;
            retorno.Xml = paramRetorno.Xml;
            return retorno;
        }

        public RetornoIntegracaoPessoaSimplificada AtualizarPessoaSimplificada(ParametroIntegracaoPessoaSimplificada param, string xml)
        {
            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            var client = new CucCliCadastroPessoaSimplificadaClient(CucCliCadastroPessoaSimplificadaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada, address);
            try
            {
                var ret = client.Atualizar(parametrosLogin, xml);

                RetornoIntegracaoPessoaSimplificada retorno = GerarRetornoIntegracaoPessoa(ret);

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
