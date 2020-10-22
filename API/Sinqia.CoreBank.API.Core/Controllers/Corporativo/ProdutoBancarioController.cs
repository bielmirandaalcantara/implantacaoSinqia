using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores.Corporativo;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.API.Core.Models.Corporativo.Templates;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Configuracao.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Sinqia.CoreBank.Services.CUC.Services;
using Sinqia.CoreBank.BLL.Corporativo.Services;
using Sinqia.CoreBank.API.Core.Constantes;

namespace Sinqia.CoreBank.API.Core.Controllers.Corporativo
{
    [ApiController]
    [Produces("application/json")]
    public class ProdutoBancarioController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorProdutoBancario _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private tb_prodbcoService _ServiceProdutoBancario;

        public ProdutoBancarioController(IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI, IOptions<ConfiguracaoBaseDataBase> configuracaoDataBase)
        {
            _configuracaoBaseAPI = configuracaoBaseAPI;
            _log = new LogService(_configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorProdutoBancario(_log);
            _ServiceProdutoBancario = new tb_prodbcoService(configuracaoDataBase.Value, _log);
        }
        /// <summary>
        /// Cadastro de produto bancario
        /// </summary>
        /// <param name="codProdutoBancario">Código do produto bancario</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/corporativo/produtoBancario")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postProdutoBancario([FromBody] MsgProdutoBancario msg)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");
                if (msg.body.RegistroProdutoBancario == null) throw new ApplicationException("Mensagem inválida - corpo da mensagem não informado");

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

                tb_prodbco tb_prodbco = _adaptador.AdaptarMsgProdutoBancarioToModeltb_prodbco(msg.body.RegistroProdutoBancario, ConstantesIntegracao.ModoIntegracao.ModoInclusao);

                _ServiceProdutoBancario.GravarProdutoBancario(tb_prodbco);

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
        /// Alteração de dados de produto bancario
        /// </summary>
        /// <param name="codProdutoBancario">Código do produto bancario</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/corporativo/produtoBancario/{codProdutoBancario}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putProdutoBancario([FromRoute] string codProdutoBancario, [FromBody] MsgProdutoBancario msg)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");
                if (msg.body.RegistroProdutoBancario == null) throw new ApplicationException("Mensagem inválida - corpo da mensagem não informado");

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

                tb_prodbco tb_prodbco = _adaptador.AdaptarMsgProdutoBancarioToModeltb_prodbco(msg.body.RegistroProdutoBancario, ConstantesIntegracao.ModoIntegracao.ModoAlteracao);

                _ServiceProdutoBancario.EditarProdutoBancario(tb_prodbco);

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
        /// Exclusão de dados de produto bancario
        /// </summary>
        /// <param name="codProdutoBancario">Código do produto bancario</param>codProdutoBancario
        /// <param name="codEmpresa">Código da empresa</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/corporativo/produtoBancario/{codProdutoBancario}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteProdutoBancario([FromRoute] int? codProdutoBancario, [FromQuery] int? codEmpresa)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;

            try
            {
                _log.TraceMethodStart();

                if (codEmpresa == null)
                    throw new ApplicationException("Parâmetro codEmpresa obrigatório");

                if (codProdutoBancario == null)
                    throw new ApplicationException("Parâmetro codProdutoBancario obrigatório");

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [delete] com o identificador {identificador}");
                _log.SetIdentificador(identificador);

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                _ServiceProdutoBancario.ExcluirProdutoBancario(codEmpresa.Value, codProdutoBancario.Value);

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
        /// Busca de dados de produto bancario
        /// </summary>
        /// <param name="codProdutoBancario">Código do produto bancario</param>
        /// <param name="codEmpresa">Código da empresa</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/corporativo/ProdutoBancario/{codProdutoBancario}")]
        [ProducesResponseType(typeof(MsgProdutoBancarioTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgProdutoBancarioTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgProdutoBancarioTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getProdutoBancario([FromRoute] int? codProdutoBancario, [FromQuery] int? codEmpresa)
        {

            List<string> listaErros = new List<string>();
            MsgRetorno retorno;
            string identificador = string.Empty;
            MsgProdutoBancarioBody body = new MsgProdutoBancarioBody();

            try
            {
                _log.TraceMethodStart();

                identificador = Util.GerarIdentificadorUnico();
                _log.Information($"Iniciando processamento [get] com o identificador {identificador}");
                _log.SetIdentificador(identificador);

                if (codEmpresa == null)
                    throw new ApplicationException("Parâmetro codEmpresa obrigatório");

                if (codProdutoBancario == null)
                    throw new ApplicationException("Parâmetro codProdutoBancario obrigatório");

                if (!Util.ValidarApiKey(Request, _configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                var produtoBancario = _ServiceProdutoBancario.BuscarProdutoBancario(codEmpresa.Value, codProdutoBancario.Value);

                if (produtoBancario != null && produtoBancario.Any())
                    body.RegistroProdutoBancario = _adaptador.tb_prodbcoToMsgProdutoBancario(produtoBancario.First());

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