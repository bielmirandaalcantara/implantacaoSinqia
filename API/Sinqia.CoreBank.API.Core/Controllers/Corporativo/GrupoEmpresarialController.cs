﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores.Corporativo;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.API.Core.Models.Corporativo.Templates;
using Sinqia.CoreBank.BLL.Corporativo.Services;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Services.CUC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Sinqia.CoreBank.API.Core.Controllers.Corporativo
{
    [ApiController]
    [Produces("application/json")]
    public class GrupoEmpresarialController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorGrupoEmpresarial _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private tb_grpempService _ServiceGrupoEmpresarial;

        public GrupoEmpresarialController(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI, IOptions<ConfiguracaoBaseDataBase> configuracaoDataBase)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorGrupoEmpresarial(_log);
            _ServiceGrupoEmpresarial = new tb_grpempService(configuracaoDataBase);
        }

        /// <summary>
        /// Cadastro de grupo empresarial
        /// </summary>
        /// <param name="codGrupoEmpresarial">Código da grupo empresarial</param>_ServiceGrupoEmpresarial
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/corporativo/GrupoEmpresarial/{codGrupoEmpresarial}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postGrupoEmpresarial([FromRoute] string codGrupoEmpresarial, [FromBody] MsgGrupoEmpresarial msg)
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

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                    _log.TraceMethodEnd();

                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                tb_grpemp tb_grpemp = _adaptador.AdaptarMsgGrupoEmpresarialToModeltb_grpemp(msg.body.RegistroGrupoEmpresarial);

                _ServiceGrupoEmpresarial.GravarGrupoEmpresarial(tb_grpemp);

                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

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
        /// Alteração de dados de grupo empresarial
        /// </summary>
        /// <param name="codGrupoEmpresarial">Código da grupo empresarial</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/corporativo/GrupoEmpresarial/{codGrupoEmpresarial}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putGrupoEmpresarial([FromRoute] string codGrupoEmpresarial, [FromBody] MsgGrupoEmpresarial msg)
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
                               
                tb_grpemp tb_grpemp = _adaptador.AdaptarMsgGrupoEmpresarialToModeltb_grpemp(msg.body.RegistroGrupoEmpresarial);

                _ServiceGrupoEmpresarial.EditarGrupoEmpresarial(tb_grpemp);

                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);

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
        /// Exclusão de dados de grupo empresarial
        /// </summary>
        /// <param name="codGrupoEmpresarial">Código da grupo wmpresarial</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/corporativo/GrupoEmpresarial/{codGrupoEmpresarial}/empresa/{codigoEmpresa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteGrupoEmpresarial([FromRoute] int? codGrupoEmpresarial, [FromQuery] int? codigoEmpresa)
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

                _ServiceGrupoEmpresarial.ExcluirGrupoEmpresarial(codigoEmpresa.Value, codGrupoEmpresarial.Value);

                retorno = _adaptador.AdaptarMsgRetorno(listaErros, identificador);

                _log.TraceMethodEnd();
                return StatusCode((int)HttpStatusCode.OK, retorno);

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
        /// Exclusão de dados de grupo empresarial
        /// </summary>
        /// <param name="codGrupoEmpresarial">Código da grupo empresarial</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/corporativo/GrupoEmpresarial/{codGrupoEmpresarial}/empresa/{codigoEmpresa}")]
        [ProducesResponseType(typeof(MsgGrupoEmpresarialTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgGrupoEmpresarialTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgGrupoEmpresarialTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getGrupoEmpresarial([FromRoute] int? codGrupoEmpresarial, [FromQuery] int? codigoEmpresa)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;
            MsgRegistroGrupoEmpresarialBody body = new MsgRegistroGrupoEmpresarialBody();

            try
            {
                _log.TraceMethodStart();

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [delete] com o identificador {identificador}");
                _log.SetIdentificador(identificador);

                if (codigoEmpresa == null)
                    throw new ApplicationException("Parâmetro codigoEmpresa obrigatório");

                if (codGrupoEmpresarial == null)
                    throw new ApplicationException("Parâmetro codGrupoEmpresarial obrigatório");

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                var grupoEmpresarial = _ServiceGrupoEmpresarial.BuscarGrupoEmpresarial(codigoEmpresa.Value, codGrupoEmpresarial.Value);

                if (grupoEmpresarial != null && grupoEmpresarial.Any())
                    body.RegistroGrupoEmpresarial = _adaptador.tb_grpempToMsgGrupoEmpresarial(grupoEmpresarial.First());

                retorno = _adaptador.AdaptarMsgRetornoGet(body, listaErros, identificador);

                _log.TraceMethodEnd();

                return StatusCode((int)HttpStatusCode.OK, retorno);

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
