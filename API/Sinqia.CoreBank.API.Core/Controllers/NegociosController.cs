﻿using System;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Models;
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

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class NegociosController : ControllerBase
    {
        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC;
        public IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI;
        public LogService _log;
        private AdaptadorNegocios _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private IntegracaoNegociosCUCService  _clientNegocio;

        public NegociosController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoBaseAPI = _configuracaoBaseAPI;
            configuracaoCUC = _configuracaoCUC;
            _log = new LogService(configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorNegocios(_log);
            _ServiceAutenticacao = new AutenticacaoCUCService(configuracaoCUC, _log);
            _clientNegocio = new IntegracaoNegociosCUCService(configuracaoCUC, _log);
        }

        /// <summary>
        /// cadastro das contas do cliente em outros bancos
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/negocios")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postNegocios([FromRoute] string codPessoa, [FromBody] MsgNegocios msg)
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

                ParametroIntegracaoPessoa parm = _clientNegocio.CarregarParametrosCUCNegocios(msg.header.empresa.Value, msg.header.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);
                DataSetNegocioOutrosBancos dataSetNegocios = new DataSetNegocioOutrosBancos();

                List<DataSetNegocioRegistroOutrosBancos> registros = new List<DataSetNegocioRegistroOutrosBancos>();
                registros.Add(_adaptador.AdaptarMsgRegistroNegocioToDataSetNegocioRegistroNegocio(msg.body.RegistroNegocios, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros));
                dataSetNegocios.RegistroNegocioOutrosBancos = registros.ToArray();

                var retNegocios = _clientNegocio.AtualizarNegocios(parm, dataSetNegocios);

                if (retNegocios.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retNegocios.Excecao.Mensagem}");

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
        /// Alteração das contas do cliente em outros bancos
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="sequencial">numero do sequencial da conta</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}/negocios/{sequencial}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putNegocios([FromRoute] string codPessoa, [FromRoute] int sequencial, [FromBody] MsgNegocios msg)
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

                ParametroIntegracaoPessoa parm = _clientNegocio.CarregarParametrosCUCNegocios(msg.header.empresa.Value, msg.header.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);
                DataSetNegocioOutrosBancos dataSetNegocios = new DataSetNegocioOutrosBancos();

                List<DataSetNegocioRegistroOutrosBancos> registros = new List<DataSetNegocioRegistroOutrosBancos>();
                registros.Add(_adaptador.AdaptarMsgRegistroNegocioToDataSetNegocioRegistroNegocio(msg.body.RegistroNegocios, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros));
                dataSetNegocios.RegistroNegocioOutrosBancos = registros.ToArray();

                var retNegocios = _clientNegocio.AtualizarNegocios(parm, dataSetNegocios);

                if (retNegocios.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retNegocios.Excecao.Mensagem}");

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
        /// Exclusão das contas do cliente em outros bancos
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="sequencial">numero do sequencial da conta</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}/negocios/{sequencial}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteNegocios([FromRoute] string codPessoa, [FromRoute] int sequencial, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                ParametroIntegracaoPessoa parm = _clientNegocio.CarregarParametrosCUCNegocios(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);
                DataSetNegocioOutrosBancos dataSetNegocios = new DataSetNegocioOutrosBancos();

                dataSetNegocios.RegistroNegocioOutrosBancos = _adaptador.AdaptarMsgRegistronegociosToDataSetNegocioRegistroMegociosExclusao(codPessoa, sequencial, dataSetNegocios.RegistroNegocioOutrosBancos[0].cod_fil, listaErros);

                var retNegocios = _clientNegocio.AtualizarNegocios(parm, dataSetNegocios);

                if (retNegocios.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retNegocios.Excecao.Mensagem}");

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
        /// Consulta os dados do cliente em outros bancos
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoa/{codPessoa}/negocios")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getNegocio([FromRoute] string codPessoa, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            MsgRegistroNegociosBody body = new MsgRegistroNegociosBody();

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

                ParametroIntegracaoPessoa parm = _clientNegocio.CarregarParametrosCUCNegocios(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);

                DataSetNegocioOutrosBancos dataSetNegocio = _clientNegocio.SelecionarNegocios(parm, codPessoa);
                body.RegistroNegocios = _adaptador.AdaptaDataSetNegocioToMsgNegocio(dataSetNegocio, listaErros);

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