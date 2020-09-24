using System;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Adaptadores.Pessoa;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Pessoa;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Sinqia.CoreBank.Services.CUC.Services;
using Sinqia.CoreBank.Services.CUC.Models;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using System.Linq;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.API.Core.Configuration;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.API.Core.Controllers.Pessoa
{
    [ApiController]
    [Produces("application/json")]
    public class EnderecoController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseCUC> _configuracaoCUC;
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorEndereco _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private IntegracaoPessoaCUCService _clientPessoa;

        public EnderecoController(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _configuracaoCUC = configuracaoCUC;
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorEndereco(_log);
            _ServiceAutenticacao = new AutenticacaoCUCService(_configuracaoCUC, _log);
            _clientPessoa = new IntegracaoPessoaCUCService(_configuracaoCUC, _log);            
        }

        /// <summary>
        /// Cadastro de dados de documentos de pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/endereco")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postEndereco([FromRoute] string codPessoa, [FromBody] MsgEndereco msg)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                if (string.IsNullOrWhiteSpace(msg.header.identificadorEnvio))
                    msg.header.identificadorEnvio = Util.GerarIdentificadorUnico();

                _log.Information($"Iniciando o processamento da mensagem [post] com o identificador {msg.header.identificadorEnvio}");
                _log.SetIdentificador(msg.header.identificadorEnvio);

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, _configuracaoCUC.Value.AcessoCUC.userServico,  _configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroEndereco> registros = new List<DataSetPessoaRegistroEndereco>();
                registros.Add(_adaptador.AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(msg.body.RegistroEndereco, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros));
                dataSetPessoa.RegistroEndereco = registros.ToArray();

                var retPessoa = _clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
        }

        /// <summary>
        /// Alteracação de dados de documentos de pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codEndereco">Código do endereço</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}/endereco/{codEndereco}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putEndereco([FromRoute] string codPessoa, [FromRoute] string codEndereco, [FromBody] MsgEndereco msg)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                if (string.IsNullOrWhiteSpace(msg.header.identificadorEnvio))
                    msg.header.identificadorEnvio = Util.GerarIdentificadorUnico();

                _log.Information($"Iniciando o processamento da mensagem [put] com o identificador {msg.header.identificadorEnvio}");
                _log.SetIdentificador(msg.header.identificadorEnvio);

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, _configuracaoCUC.Value.AcessoCUC.userServico,  _configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarCabecalho(parm, codPessoa);


                List<DataSetPessoaRegistroEndereco> registros = new List<DataSetPessoaRegistroEndereco>();
                registros.Add(_adaptador.AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(msg.body.RegistroEndereco, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros));
                dataSetPessoa.RegistroEndereco = registros.ToArray();

                var retPessoa = _clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
        }

        /// <summary>
        /// Exclusão de dados de documentos de pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codEndereco">Código do endereço</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}/endereco/{codEndereco}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteEndereco([FromRoute] string codPessoa, [FromRoute] int codEndereco, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;

            try
            {
                _log.TraceMethodStart();

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [delete] com o identificador {identificador}");
                _log.SetIdentificador(identificador);

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, _configuracaoCUC.Value.AcessoCUC.userServico, _configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarCabecalho(parm, codPessoa);

                dataSetPessoa.RegistroEndereco = _adaptador.AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoaExclusao(codPessoa, codEndereco, dataSetPessoa.RegistroPessoa[0].cod_fil, listaErros);
                
                var retPessoa = _clientPessoa.AtualizarPessoa(parm, dataSetPessoa);
                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

                retorno = _adaptador.AdaptarMsgRetorno(listaErros, identificador);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros, identificador);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros, identificador);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros, identificador);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
        }
    }
}