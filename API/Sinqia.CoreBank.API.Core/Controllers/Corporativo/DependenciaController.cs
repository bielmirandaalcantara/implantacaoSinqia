using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores.Corporativo;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.API.Core.Models.Corporativo.Templates;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Services.CUC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Sinqia.CoreBank.BLL.Corporativo.Services;
using Sinqia.CoreBank.Configuracao.Configuration;


namespace Sinqia.CoreBank.API.Core.Controllers.Corporativo
{
    [ApiController]
    [Produces("application/json")]
    public class DependenciaController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseCUC> _configuracaoCUC;
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorDependencia _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private tb_dependenciaService _ServiceDependencia;

        public DependenciaController(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI, IOptions<ConfiguracaoBaseDataBase> configuracaoDataBase)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _configuracaoCUC = configuracaoCUC;
            _adaptador = new AdaptadorDependencia(_log);
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _ServiceAutenticacao = new AutenticacaoCUCService(_configuracaoCUC, _log);
            _ServiceDependencia = new tb_dependenciaService(configuracaoDataBase);
        }

        /// <summary>
        /// Cadastro de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/corporativo/dependencia/{codDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postDependencia([FromRoute] string codDependencia, [FromBody] MsgDependencia msg)
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

                tb_dependencia tb_dependencia = _adaptador.AdaptarMsgDependenciaToModeltb_dependencia(msg.body.RegistroDependencia);

                _ServiceDependencia.GravarDependencia(tb_dependencia);

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

                if (string.IsNullOrWhiteSpace(msg.header.identificadorEnvio))
                    msg.header.identificadorEnvio = Util.GerarIdentificadorUnico();

                _log.Information($"Iniciando o processamento da mensagem [post] com o identificador {msg.header.identificadorEnvio}");
                _log.SetIdentificador(msg.header.identificadorEnvio);

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                ConfiguracaoAcessoCUC acessoCUC = _configuracaoCUC.Value.AcessoCUC;
                if (acessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
                string token = _ServiceAutenticacao.GetToken(acessoCUC);

                tb_dependencia tb_dependencia = _adaptador.AdaptarMsgDependenciaToModeltb_dependencia(msg.body.RegistroDependencia);

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
        /// Exclusão de dados de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/corporativo/dependencia/{codDependencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteDependencia([FromRoute] string codDependencia)
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
        /// Exclusão de dados de dependencia
        /// </summary>
        /// <param name="codDependencia">Código da dependencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/corporativo/dependencia/{codDependencia}")]
        [ProducesResponseType(typeof(MsgDependenciaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgDependenciaTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgDependenciaTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getDependencia([FromRoute] string codDependencia)
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

                if (string.IsNullOrWhiteSpace(codDependencia))
                    throw new ApplicationException("Parâmetro codDependencia obrigatório");

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
