using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores.Corporativo;
using Sinqia.CoreBank.API.Core.Constantes;
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
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Controllers.Corporativo
{
    [ApiController]
    [Produces("application/json")]
    public class OperadorDependenciaController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorOperadorDependencia _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private tb_depopeService _ServiceOperadorDependencia;

        public OperadorDependenciaController(IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI, IOptions<ConfiguracaoBaseDataBase> configuracaoDataBase)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorOperadorDependencia(_log);
            _ServiceOperadorDependencia = new tb_depopeService(configuracaoDataBase.Value, _log);
        }      

        /// <summary>
        /// Busca de dados de OperadorDependencia
        /// </summary>
        /// <param name="codOperador">Código da Operador</param>
        /// <param name="codDependencia">Código da Dependência</param>
        /// <param name="codEmpresa">Código da empresa</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/corporativo/OperadorDependencia")]
        [ProducesResponseType(typeof(MsgOperadorDependenciaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgOperadorDependenciaTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgOperadorDependenciaTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getOperadorDependencia([FromQuery] int? codOperador, [FromQuery] int? codDependencia, [FromQuery] int? codEmpresa)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;
            MsgRegistroOperadorDependenciaBody body = new MsgRegistroOperadorDependenciaBody();

            try
            {
                _log.TraceMethodStart();

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [get] com o identificador {identificador}");
                _log.SetIdentificador(identificador);                

                if (codEmpresa == null)
                    throw new ApplicationException("Parâmetro codEmpresa obrigatório");

                if (codOperador == null && codDependencia == null)
                    throw new ApplicationException("Obrigatório parametro codDependencia ou codOperador");

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                var OperadorDependencia = _ServiceOperadorDependencia.BuscarOperadorDependencia(codEmpresa, codOperador, codDependencia);

                if (OperadorDependencia != null && OperadorDependencia.Any())
                    body.RegistroOperadorDependencia = _adaptador.tb_depopeToMsgOperadorDependencia(OperadorDependencia.First());

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