using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Configuration;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Templates;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Criptografia.Services;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PessoaController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC;
        public IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorPessoa _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private IntegracaoPessoaCUCService _clientPessoa;

        public PessoaController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoBaseAPI = _configuracaoBaseAPI;
            configuracaoCUC = _configuracaoCUC;
            _log = new LogService(configuracaoBaseAPI.Value.Log ?? null);
            _configuracaoCUC.Value.AcessoCUC = Util.DescriptografarUsuarioServico(_configuracaoCUC.Value.AcessoCUC);
            _adaptador = new AdaptadorPessoa(_log);
            _ServiceAutenticacao = new AutenticacaoCUCService(configuracaoCUC,_log);
            _clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC, _log);           
            
        }

        /// <summary>
        /// Cadastro de pessoa - Possibilita o cadastramento de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa")]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postPessoa([FromBody] MsgPessoaCompleto msg)
        {            
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
                    
                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                var dataSetPessoa = _adaptador.AdaptarMsgPessoaCompletoToDataSetPessoa(msg, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico,  configuracaoCUC.Value.SiglaSistema, token);
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
                return StatusCode((int)HttpStatusCode.InternalServerError,retorno);
            }

        }

        /// <summary>
        /// Alteração de pessoa - Possibilita alteração dos dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putPessoa([FromRoute] string codPessoa, [FromBody] MsgPessoa msg)
        {
            List<string> listaErros = new List<string>();
            DataSetPessoa dataSetPessoa = new DataSetPessoa();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");
                if (msg.body.RegistroPessoa == null) throw new ApplicationException("Mensagem inválida - chave RegistroPessoa não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico,  configuracaoCUC.Value.SiglaSistema, token);
                dataSetPessoa.RegistroPessoa = _adaptador.AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(new MsgRegistropessoa[] { msg.body.RegistroPessoa }, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros);
                
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
                retorno = _adaptador.AdaptarMsgRetorno(msg,listaErros);
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
        /// Exclusão de pessoa - Possibilita a exclusão de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deletePessoa([FromRoute] string codPessoa, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (string.IsNullOrWhiteSpace(codPessoa))
                    throw new ApplicationException("Parâmetro codPessoa obrigatório");

                if (parametrosBase.empresa == null || parametrosBase.empresa.Value.Equals(0))
                    throw new ApplicationException("Parâmetro empresa obrigatório");

                if (parametrosBase.dependencia == null || parametrosBase.dependencia.Value.Equals(0))
                    throw new ApplicationException("Parâmetro dependencia obrigatório");
                
                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico,  configuracaoCUC.Value.SiglaSistema, token);

                RetornoIntegracaoPessoa retClient = _clientPessoa.ExcluirPessoa(parm, codPessoa);

                if (retClient.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retClient.Excecao.Mensagem}");

                retorno = _adaptador.AdaptarMsgRetorno(listaErros);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {
                listaErros.Add(appEx.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
        }

        /// <summary>
        /// Consulta os dados de pessoa simplificada
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getPessoa([FromRoute] string codPessoa, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            MsgRegistroPessoaCompletoBody body = new MsgRegistroPessoaCompletoBody();

            try
            {
                _log.TraceMethodStart();

                if (string.IsNullOrWhiteSpace(codPessoa))
                    throw new ApplicationException("Parâmetro codPessoa obrigatório");

                if (parametrosBase.empresa == null || parametrosBase.empresa.Value.Equals(0))
                    throw new ApplicationException("Parâmetro empresa obrigatório");

                if (parametrosBase.dependencia == null || parametrosBase.dependencia.Value.Equals(0))
                    throw new ApplicationException("Parâmetro dependencia obrigatório");

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico,  configuracaoCUC.Value.SiglaSistema, token);

                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarPessoa(parm, codPessoa);

                body.RegistroPessoa = _adaptador.AdaptaDataSetPessoaToMsgPessoaCompleto(dataSetPessoa, listaErros);
                
                retorno = _adaptador.AdaptarMsgRetornoGet(body, listaErros);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {
                listaErros.Add(appEx.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }
    }
}
