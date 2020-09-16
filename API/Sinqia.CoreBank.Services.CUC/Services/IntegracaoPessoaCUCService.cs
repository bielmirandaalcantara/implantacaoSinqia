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
using System.Xml.Serialization;
using System.IO;

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

        public ParametroIntegracaoPessoa CarregarParametrosCUCPessoa(int empresa, int dependencia, string login, string sigla, string token)
        {
            ParametroIntegracaoPessoa param = new ParametroIntegracaoPessoa();
            param.empresa = empresa;
            param.login = login;
            param.sigla = sigla;
            param.dependencia = dependencia;
            param.token = token;
            return param;
        }

        public RetornoIntegracaoPessoa AtualizarPessoa(ParametroIntegracaoPessoa param, DataSetPessoa dataSetPessoa)
        {
            string stringXML = string.Empty;
            XmlSerializer x = new XmlSerializer(typeof(DataSetPessoa));

            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, dataSetPessoa);
                stringXML = textWriter.ToString();
            }

            return AtualizarPessoa(param, stringXML);
        }

        private RetornoIntegracaoPessoa AtualizarPessoa(ParametroIntegracaoPessoa param, string xml)
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

        public DataSetPessoa SelecionarCabecalho(ParametroIntegracaoPessoa param, string cod_pessoa, string cod_filial = null)
        {
            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.SelecionarCabecalho(parametrosLogin, cod_pessoa, cod_filial);
                RetornoIntegracaoPessoa retorno = GerarRetornoIntegracaoPessoa(ret);

                if (retorno.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {ret.Excecao.Mensagem}");

                if (string.IsNullOrWhiteSpace(retorno.Xml))
                    throw new ApplicationException("Dados não encontrados para a pessoa informada");
                
                XmlSerializer xmlSerialize = new XmlSerializer(typeof(DataSetPessoa));

                var valor_serealizado = new StringReader(retorno.Xml);

                DataSetPessoa dataSetPessoa = (DataSetPessoa)xmlSerialize.Deserialize(valor_serealizado);

                return dataSetPessoa;
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

        public RetornoIntegracaoPessoa ExcluirPessoa(ParametroIntegracaoPessoa param, string cod_pessoa, string cod_filial = null)
        {
            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.Excluir(parametrosLogin, cod_pessoa, cod_filial);
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

        public DataSetPessoa SelecionarPessoa(ParametroIntegracaoPessoa param, string cod_pessoa, string cod_filial = null)
        {
            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.Selecionar(parametrosLogin, cod_pessoa, cod_filial);
                RetornoIntegracaoPessoa retorno = GerarRetornoIntegracaoPessoa(ret);

                if (retorno.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {ret.Excecao.Mensagem}");

                if (string.IsNullOrWhiteSpace(retorno.Xml))
                    throw new ApplicationException("Dados não encontrados para os parâmetros informados");

                XmlSerializer xmlSerialize = new XmlSerializer(typeof(DataSetPessoa));

                var valor_serealizado = new StringReader(retorno.Xml);

                DataSetPessoa dataSetPessoa = (DataSetPessoa)xmlSerialize.Deserialize(valor_serealizado);

                return dataSetPessoa;
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
