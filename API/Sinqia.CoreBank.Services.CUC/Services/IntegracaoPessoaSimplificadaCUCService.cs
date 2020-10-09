//using System;
//using System.Collections.Generic;
//using System.ServiceModel;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Options;
//using Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada;
//using Sinqia.CoreBank.Services.CUC.Models;
//using Sinqia.CoreBank.Configuracao.Configuration;
//using Sinqia.CoreBank.Services.CUC.Constantes;
//using System.Xml.Serialization;
//using System.IO;

//namespace Sinqia.CoreBank.Services.CUC.Services
//{
//    public class IntegracaoPessoaSimplificadaCUCService
//    {
//        public ConfiguracaoURICUC configuracaoURICUC { get; set; }

//        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

//        public IntegracaoPessoaSimplificadaCUCService(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
//        {
//            configuracaoCUC = _configuracaoCUC;
//            configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.CadastroPessoaSimplificada, configuracaoCUC);
//        }

//        private CucCluParametro GerarParametroCUC(ParametroIntegracaoPessoaSimplificada param)
//        {
//            CucCluParametro parametrosLogin = new CucCluParametro();
//            parametrosLogin.Empresa = param.empresa;
//            parametrosLogin.Dependencia = param.dependencia;
//            parametrosLogin.Login = param.login;
//            parametrosLogin.SiglaAplicacao = param.sigla;
//            parametrosLogin.Token = param.token;

//            return parametrosLogin;
//        }

//        private RetornoIntegracaoPessoaSimplificada GerarRetornoIntegracaoPessoaSimplificada(CucCluRetorno paramRetorno)
//        {
//            RetornoIntegracaoPessoaSimplificada retorno = new RetornoIntegracaoPessoaSimplificada();
//            retorno.CodigoFilial = paramRetorno.CodigoFilial;
//            retorno.CodigoPessoa = paramRetorno.CodigoPessoa;
//            retorno.CodigoContaRelacionamento = paramRetorno.CodigoContaRelacionamento;
//            retorno.TipoPessoa = paramRetorno.TipoPessoa;
//            retorno.Excecao = paramRetorno.Excecao;
//            retorno.Xml = paramRetorno.Xml;
//            return retorno;
//        }

//        public ParametroIntegracaoPessoaSimplificada CarregarParametrosCUCPessoaSimplificada(int empresa, int dependencia, string login, string sigla, string token)
//        {
//            ParametroIntegracaoPessoaSimplificada param = new ParametroIntegracaoPessoaSimplificada();
//            param.empresa = empresa;
//            param.login = login;
//            param.sigla = sigla;
//            param.dependencia = dependencia;
//            param.token = token;
//            return param;
//        }
//        public RetornoIntegracaoPessoaSimplificada AtualizarPessoaSimplificada(ParametroIntegracaoPessoaSimplificada param, DataSetPessoa dataSetPessoa)
//        {
//            string stringXML = string.Empty;
//            XmlSerializer x = new XmlSerializer(typeof(DataSetPessoa));

//            using (StringWriter textWriter = new StringWriter())
//            {
//                x.Serialize(textWriter, dataSetPessoa);
//                stringXML = textWriter.ToString();
//            }

//            return AtualizarPessoaSimplificada(param, stringXML);
//        }

//        private RetornoIntegracaoPessoaSimplificada AtualizarPessoaSimplificada(ParametroIntegracaoPessoaSimplificada param, string xml)
//        {
//            CucCluParametro parametrosLogin = GerarParametroCUC(param);

//            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
//            var client = new CucCliCadastroPessoaSimplificadaClient(CucCliCadastroPessoaSimplificadaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada, address);
//            try
//            {
//                _log.Trace($"Chamando o método CUC: {configuracaoURICUC.URI}");
//
//                var ret = client.Atualizar(parametrosLogin, xml);
//
//                _log.Trace($"Finalizando a chamada do método CUC: {configuracaoURICUC.URI}");

//                RetornoIntegracaoPessoaSimplificada retorno = GerarRetornoIntegracaoPessoaSimplificada(ret);

//                return retorno;

//            }
//            catch (TimeoutException timeoutEx)
//            {
//                client.Abort();
//                throw new Exception("Tempo de conexão expirado", timeoutEx);
//            }
//            catch (EndpointNotFoundException endPointEx)
//            {
//                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
//            }
//        }

//        public RetornoIntegracaoPessoaSimplificada ExcluirPessoaSimplificada(ParametroIntegracaoPessoaSimplificada param, string cod_pessoa)
//        {
//            CucCluParametro parametrosLogin = GerarParametroCUC(param);

//            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
//            CucCliCadastroPessoaSimplificadaClient client = new CucCliCadastroPessoaSimplificadaClient(CucCliCadastroPessoaSimplificadaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada, address);

//            try
//            {
//                var ret = client.Excluir(parametrosLogin, cod_pessoa);
//                RetornoIntegracaoPessoaSimplificada retorno = GerarRetornoIntegracaoPessoaSimplificada(ret);

//                return retorno;
//            }
//            catch (TimeoutException timeoutEx)
//            {
//                client.Abort();
//                throw new Exception("Tempo de conexão expirado", timeoutEx);
//            }
//            catch (EndpointNotFoundException endPointEx)
//            {
//                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
//            }
//        }

//        public DataSetPessoaSimplificada SelecionarPessoaSimplificada(ParametroIntegracaoPessoaSimplificada param, string cod_pessoa, string cod_filial = null)
//        {
//            CucCluParametro parametrosLogin = GerarParametroCUC(param);

//            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
//            CucCliCadastroPessoaSimplificadaClient client = new CucCliCadastroPessoaSimplificadaClient(CucCliCadastroPessoaSimplificadaClient.EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada, address);

//            try
//            {
//                var ret = client.Selecionar(parametrosLogin, cod_pessoa);
//                RetornoIntegracaoPessoaSimplificada retorno = GerarRetornoIntegracaoPessoaSimplificada(ret);

//                if (retorno.Excecao != null)
//                    throw new ApplicationException($"Retorno serviço CUC - {ret.Excecao.Mensagem}");

//                if (string.IsNullOrWhiteSpace(retorno.Xml))
//                    throw new ApplicationException("Dados não encontrados para os parâmetros informados");

//                XmlSerializer xmlSerialize = new XmlSerializer(typeof(DataSetPessoaSimplificada));

//                var valor_serealizado = new StringReader(retorno.Xml);

//                DataSetPessoaSimplificada dataSetPessoa = (DataSetPessoaSimplificada)xmlSerialize.Deserialize(valor_serealizado);

//                return dataSetPessoa;
//            }
//            catch (TimeoutException timeoutEx)
//            {
//                client.Abort();
//                throw new Exception("Tempo de conexão expirado", timeoutEx);
//            }
//            catch (EndpointNotFoundException endPointEx)
//            {
//                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
//            }
//        }
//    }
//}
