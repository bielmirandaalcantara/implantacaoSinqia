using Sinqia.CoreBank.Services.CUC.WCF.Negocios;
using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Constantes;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Extensions.Options;
using System.ServiceModel;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class IntegracaoNegociosCUCService
    {

        private CucClwCadastroNegocioOutrosBancosClient _ServiceClient;
        public CucClwCadastroNegocioOutrosBancosClient ServiceClient
        {
            get
            {
                if (_ServiceClient == null) _ServiceClient = new CucClwCadastroNegocioOutrosBancosClient();
                return _ServiceClient;
            }
        }

        public ConfiguracaoURICUC configuracaoURICUC { get; set; }

        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

        public IntegracaoNegociosCUCService(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
        {
            configuracaoCUC = _configuracaoCUC;
            configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroNegocios, configuracaoCUC);
        }

        public ParametroIntegracaoPessoa CarregarParametrosCUCNegocios(int empresa, int dependencia, string login, string sigla, string token)
        {
            ParametroIntegracaoPessoa param = new ParametroIntegracaoPessoa();
            param.empresa = empresa;
            param.login = login;
            param.sigla = sigla;
            param.dependencia = dependencia;
            param.token = token;
            return param;
        }

        public RetornoIntegracaoNegocios AtualizarNegocios(ParametroIntegracaoPessoa param, DataSetNegocioOutrosBancos dataSetNegocios)
        {
            string stringXML = string.Empty;
            XmlSerializer x = new XmlSerializer(typeof(DataSetNegocioOutrosBancos));

            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, dataSetNegocios);
                stringXML = textWriter.ToString();
            }

            return AtualizarNegocios(param, stringXML);
        }

        private RetornoIntegracaoNegocios AtualizarNegocios(ParametroIntegracaoPessoa param, string xml)
        {
            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucClwCadastroNegocioOutrosBancosClient client = new CucClwCadastroNegocioOutrosBancosClient(CucClwCadastroNegocioOutrosBancosClient.EndpointConfiguration.BasicHttpBinding_ICucClwCadastroNegocioOutrosBancos, address);

            try
            {
                var ret = client.Atualizar(parametrosLogin, xml);

                RetornoIntegracaoNegocios retorno = GerarRetornoIntegracaoNegocios(ret);
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

        private RetornoIntegracaoNegocios GerarRetornoIntegracaoNegocios(CucCluRetorno paramRetorno)
        {
            RetornoIntegracaoNegocios retorno = new RetornoIntegracaoNegocios();
            retorno.CodigoFilial = paramRetorno.CodigoFilial;
            retorno.CodigoPessoa = paramRetorno.CodigoPessoa;
            retorno.CodigoContaRelacionamento = paramRetorno.CodigoContaRelacionamento;
            retorno.TipoPessoa = paramRetorno.TipoPessoa;
            retorno.Excecao = paramRetorno.Excecao;
            retorno.Xml = paramRetorno.Xml;
            return retorno;
        }

    }
}
