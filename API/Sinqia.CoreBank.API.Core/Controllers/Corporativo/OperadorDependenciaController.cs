using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Configuration;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.API.Core.Models.Corporativo.Templates;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Controllers.Corporativo
{
    [ApiController]
    [Produces("application/json")]
    public class OperadorDependenciaController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseCUC> _configuracaoCUC;
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AutenticacaoCUCService _ServiceAutenticacao;

        public OperadorDependenciaController(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _configuracaoCUC = configuracaoCUC;
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _ServiceAutenticacao = new AutenticacaoCUCService(_configuracaoCUC, _log);
        }
        /// <summary>
        /// Cadastro de Operador dependencia
        /// </summary>
        /// <param name="codOperadorDependencia">Código do Operador dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/corporativo/OperadorDependencia/{codOperadorDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postOperadorDependencia([FromRoute] string codOperadorDependencia, [FromBody] MsgOperadorDependencia msg)
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

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                _log.TraceMethodEnd();

                return StatusCode((int)HttpStatusCode.OK);

            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Alteração de dados do operador dependencia
        /// </summary>
        /// <param name="codOperadorDependencia">Código do operador dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/corporativo/OperadorDependencia/{codOperadorDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putOperadorDependencia([FromRoute] string codOperadorDependencia, [FromBody] MsgOperadorDependencia msg)
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

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                _log.TraceMethodEnd();

                return StatusCode((int)HttpStatusCode.OK);

            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Exclusão de dados de operador dependencia
        /// </summary>
        /// <param name="codOperadorDependencia">Código do operador dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/corporativo/OperadorDependencia/{codOperadorDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteOperadorDependencia([FromRoute] string codOperadorDependencia)
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

                _log.TraceMethodEnd();

                return StatusCode((int)HttpStatusCode.OK);

            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

        /// <summary>
        /// Exclusão de dados de OperadorDependencia
        /// </summary>
        /// <param name="codOperadorDependencia">Código da OperadorDependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/corporativo/OperadorDependencia/{codOperadorDependencia}")]
        [ProducesResponseType(typeof(MsgOperadorDependenciaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgOperadorDependenciaTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgOperadorDependenciaTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getOperadorDependencia([FromRoute] string codOperadorDependencia)
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

                if (string.IsNullOrWhiteSpace(codOperadorDependencia))
                    throw new ApplicationException("Parâmetro codOperadorDependencia obrigatório");

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                _log.TraceMethodEnd();

                return StatusCode((int)HttpStatusCode.OK);

            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }

        }

    }
}