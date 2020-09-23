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
using Sinqia.CoreBank.Logging.Services;

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

        private IOptions<ConfiguracaoBaseCUC> _configuracaoCUC;
        private LogService _log;

        public IntegracaoPessoaCUCService(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, LogService log)
        {
            _configuracaoCUC = configuracaoCUC;
            _log = log;
        }

        private CucCluParametro GerarParametroCUC(ParametroIntegracaoPessoa param)
        {
            _log.TraceMethodStart();

            CucCluParametro parametrosLogin = new CucCluParametro();
            parametrosLogin.Empresa = param.empresa;
            parametrosLogin.Dependencia = param.dependencia;
            parametrosLogin.Login = param.login;
            parametrosLogin.SiglaAplicacao = param.sigla;
            parametrosLogin.Token = param.token;

            _log.TraceMethodEnd();

            return parametrosLogin;
        }

        private RetornoIntegracaoPessoa GerarRetornoIntegracaoPessoa(CucCluRetorno paramRetorno)
        {
            _log.TraceMethodStart();

            RetornoIntegracaoPessoa retorno = new RetornoIntegracaoPessoa();
            retorno.CodigoFilial = paramRetorno.CodigoFilial;
            retorno.CodigoPessoa = paramRetorno.CodigoPessoa;
            retorno.CodigoContaRelacionamento = paramRetorno.CodigoContaRelacionamento;
            retorno.TipoPessoa = paramRetorno.TipoPessoa;
            retorno.Excecao = paramRetorno.Excecao;
            retorno.Xml = paramRetorno.Xml;

            _log.TraceMethodEnd();

            return retorno;
        }

        public ParametroIntegracaoPessoa CarregarParametrosCUCPessoa(int empresa, int dependencia, string login, string sigla, string token)
        {
            _log.TraceMethodStart();

            ParametroIntegracaoPessoa param = new ParametroIntegracaoPessoa();
            param.empresa = empresa;
            param.login = login;
            param.sigla = sigla;
            param.dependencia = dependencia;
            param.token = token;

            _log.TraceMethodEnd();

            return param;
        }

        public RetornoIntegracaoPessoa AtualizarPessoa(ParametroIntegracaoPessoa param, DataSetPessoa dataSetPessoa)
        {
            _log.TraceMethodStart();

            string stringXML = string.Empty;
            XmlSerializer x = new XmlSerializer(typeof(DataSetPessoa));

            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, dataSetPessoa);
                stringXML = textWriter.ToString();
            }

            _log.TraceMethodEnd();

            _log.Trace("XML Gerado: " + stringXML);

            return AtualizarPessoa(param, stringXML);
        }

        private RetornoIntegracaoPessoa AtualizarPessoa(ParametroIntegracaoPessoa param, string xml)
        {
            _log.TraceMethodStart();

            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            ConfiguracaoURICUC configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoa, _configuracaoCUC);
            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.Atualizar(parametrosLogin, xml);

                RetornoIntegracaoPessoa retorno = GerarRetornoIntegracaoPessoa(ret);

                _log.TraceMethodEnd();

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
            _log.TraceMethodStart();

            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            ConfiguracaoURICUC configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoa, _configuracaoCUC);
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

                if (dataSetPessoa.RegistroPessoa[0].cod_pessoa == null)
                    throw new ApplicationException($"Retorno serviço CUC - Codigo da pessoa não encontrado");

                _log.TraceMethodEnd();

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
            _log.TraceMethodStart();

            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            ConfiguracaoURICUC configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoa, _configuracaoCUC);
            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliCadastroPessoaClient client = new CucCliCadastroPessoaClient(CucCliCadastroPessoaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoa, address);

            try
            {
                var ret = client.Excluir(parametrosLogin, cod_pessoa, cod_filial);
                RetornoIntegracaoPessoa retorno = GerarRetornoIntegracaoPessoa(ret);

                _log.TraceMethodEnd();

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
            _log.TraceMethodStart();

            CucCluParametro parametrosLogin = GerarParametroCUC(param);

            ConfiguracaoURICUC configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoa, _configuracaoCUC);
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

                _log.TraceMethodEnd();

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
