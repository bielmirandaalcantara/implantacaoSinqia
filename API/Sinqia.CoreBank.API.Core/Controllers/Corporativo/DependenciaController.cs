using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores.Corporativo;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.API.Core.Models.Corporativo.Templates;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sinqia.CoreBank.BLL.Corporativo.Services;
using Sinqia.CoreBank.Configuracao.Configuration;


namespace Sinqia.CoreBank.API.Core.Controllers.Corporativo
{
    [ApiController]
    [Produces("application/json")]
    public class DependenciaController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorDependencia _adaptador;
        private tb_dependenciaService _ServiceDependencia;

        public DependenciaController(IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI, IOptions<ConfiguracaoBaseDataBase> configuracaoDataBase)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorDependencia(_log);
            _ServiceDependencia = new tb_dependenciaService(configuracaoDataBase.Value, _log);
        }

        /// <summary>
        /// Cadastro de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/corporativo/dependencia")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postDependencia([FromBody] MsgDependencia msg)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");
                if (msg.body.RegistroDependencia == null) throw new ApplicationException("Mensagem inválida - corpo da mensagem não informado");

                if (string.IsNullOrWhiteSpace(msg.header.identificadorEnvio))
                    msg.header.identificadorEnvio = Util.GerarIdentificadorUnico();

                _log.Information($"Iniciando o processamento da mensagem [post] com o identificador {msg.header.identificadorEnvio}");
                _log.SetIdentificador(msg.header.identificadorEnvio);

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                tb_dependencia tb_dependencia = _adaptador.AdaptarMsgDependenciaTotb_dependencia(msg.body.RegistroDependencia);

                _ServiceDependencia.GravarDependencia(tb_dependencia);

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
        /// Alteração de dados de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/corporativo/dependencia/{codDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putDependencia([FromRoute] string codDependencia, [FromBody] MsgDependencia msg)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");
                if (msg.body.RegistroDependencia == null) throw new ApplicationException("Mensagem inválida - corpo da mensagem não informado");

                if (string.IsNullOrWhiteSpace(msg.header.identificadorEnvio))
                    msg.header.identificadorEnvio = Util.GerarIdentificadorUnico();

                _log.Information($"Iniciando o processamento da mensagem [post] com o identificador {msg.header.identificadorEnvio}");
                _log.SetIdentificador(msg.header.identificadorEnvio);

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                tb_dependencia tb_dependencia = _adaptador.AdaptarMsgDependenciaTotb_dependencia(msg.body.RegistroDependencia);

                _ServiceDependencia.EditarDependencia(tb_dependencia);

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
        /// Exclusão de dados de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <param name="codigoEmpresa">Código da empresa</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/corporativo/dependencia/{codDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteDependencia([FromRoute] int? codDependencia, [FromQuery] int? codigoEmpresa)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;

            try
            {
                _log.TraceMethodStart();

                if (codigoEmpresa == null)
                    throw new ApplicationException("Parâmetro codigoEmpresa obrigatório");

                if (codDependencia == null)
                    throw new ApplicationException("Parâmetro codDependencia obrigatório");

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [delete] com o identificador {identificador}");
                _log.SetIdentificador(identificador);

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                _ServiceDependencia.ExcluirDependencia(codigoEmpresa.Value, codDependencia.Value);

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

        /// <summary>
        /// Exclusão de dados de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <param name="codigoEmpresa">Código da empresa</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/corporativo/dependencia/{codDependencia}")]
        [ProducesResponseType(typeof(MsgDependenciaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgDependenciaTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgDependenciaTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getDependencia([FromRoute] int? codDependencia, [FromQuery] int? codigoEmpresa)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;
            MsgRegistroDependenciaBody body = new MsgRegistroDependenciaBody();

            try
            {
                _log.TraceMethodStart();

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [get] com o identificador {identificador}");
                _log.SetIdentificador(identificador);

                if (codigoEmpresa == null)
                    throw new ApplicationException("Parâmetro codigoEmpresa obrigatório");

                if (codDependencia == null)
                    throw new ApplicationException("Parâmetro codDependencia obrigatório");

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                var dependencias = _ServiceDependencia.BuscarDependencias(codigoEmpresa.Value, codDependencia.Value);

                if (dependencias != null && dependencias.Any())
                    body.RegistroDependencia = _adaptador.tb_depndenciaToMsgDependencia(dependencias.First());

                retorno = _adaptador.AdaptarMsgRetornoGet(body, listaErros, identificador);

                _log.TraceMethodEnd();

                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros, identificador);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {
                listaErros.Add(appEx.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros, identificador);

                _log.Error(appEx);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros, identificador);

                _log.Error(ex);
                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }

    }
}
