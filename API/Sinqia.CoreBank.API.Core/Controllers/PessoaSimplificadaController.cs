/*
using System;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Templates;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Sinqia.CoreBank.Services.CUC.Models;
using System.Linq;
using Sinqia.CoreBank.Services.CUC.Services;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.API.Core.Configuration;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PessoaSimplificadaController : ControllerBase
    {
        private IOptions<ConfiguracaoBaseCUC> configuracaoCUC;
        private IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI;
        private LogService _log;
        private AdaptadorPessoaSimplificada _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private IntegracaoPessoaCUCService _clientPessoaSimplificada;

        public PessoaSimplificadaController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoBaseAPI = _configuracaoBaseAPI;
            configuracaoCUC = _configuracaoCUC;
            _log = new LogService(configuracaoBaseAPI.Value.Log ?? null);
            _adaptador = new AdaptadorPessoaSimplificada(_log);
            _ServiceAutenticacao = new AutenticacaoCUCService(configuracaoCUC, _log);
            _clientPessoaSimplificada = new IntegracaoPessoaCUCService(configuracaoCUC, _log);
        }

        /// <summary>
        /// Armazena os dados de pessoa simplificada
        /// </summary>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoaSimplificada")]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status200OK)] 
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postPessoaSimplificada([FromBody] MsgPessoaSimplificada msg)
        {
            List<string> listaErros = new List<string>();
            DataSetPessoa dataSetPessoa = new DataSetPessoa();
            MsgRetorno retorno;

            try
            {
                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken("att", "att");

                dataSetPessoa = _adaptador.AdaptarMsgPessoaSimplificadaToDataSetPessoa(msg, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros);

                ParametroIntegracaoPessoaSimplificada parm = _clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(msg.header.empresa.Value, msg.header.dependencia.Value, "att",  configuracaoCUC.Value.SiglaSistema, token);

                var retPessoa = _clientPessoaSimplificada.AtualizarPessoaSimplificada(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
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
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);                
                return StatusCode((int)HttpStatusCode.InternalServerError,retorno);
            }

        }

        /// <summary>
        /// Alterar os dados de pessoa simplificada
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoaSimplificada/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putPessoaSimplificada([FromRoute] string codPessoa, [FromBody] MsgPessoaSimplificada msg)
        {
            List<string> listaErros = new List<string>();
            DataSetPessoa dataSetPessoa = new DataSetPessoa();
            MsgRetorno retorno;

            try
            {
                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken("att", "att");

                dataSetPessoa = _adaptador.AdaptarMsgPessoaSimplificadaToDataSetPessoa(msg, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros);

                ParametroIntegracaoPessoaSimplificada parm = _clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(msg.header.empresa.Value, msg.header.dependencia.Value, "att",  configuracaoCUC.Value.SiglaSistema, token);

                var retPessoa = _clientPessoaSimplificada.AtualizarPessoaSimplificada(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");


                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
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
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }

        /// <summary>
        /// Excluir os dados de pessoa simplificada
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoaSimplificada/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deletePessoaSimplificada([FromRoute] string codPessoa, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {                
                if (string.IsNullOrWhiteSpace(codPessoa))
                    throw new ApplicationException("Parâmetro codPessoa obrigatório");

                if (parametrosBase.empresa == null || parametrosBase.empresa.Value.Equals(0))
                    throw new ApplicationException("Parâmetro empresa obrigatório");

                if (parametrosBase.dependencia == null || parametrosBase.dependencia.Value.Equals(0))
                    throw new ApplicationException("Parâmetro dependencia obrigatório");

                if (string.IsNullOrWhiteSpace(parametrosBase.usuario))
                    throw new ApplicationException("Parâmetro usuario obrigatório");


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken("att", "att");

                ParametroIntegracaoPessoaSimplificada parm = _clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, "att",  configuracaoCUC.Value.SiglaSistema, token);

                RetornoIntegracaoPessoaSimplificada retClient = _clientPessoaSimplificada.ExcluirPessoaSimplificada(parm, codPessoa);

                if (retClient.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retClient.Excecao.Mensagem}");

                retorno = _adaptador.AdaptarMsgRetorno(listaErros);
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
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }

        /// <summary>
        /// Consulta de pessoa - Possibilita a consulta de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoaSimplificada/{codPessoa}")]
        [ProducesResponseType(typeof(MsgPessoaSimplificadaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgPessoaSimplificadaTemplate), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgPessoaSimplificadaTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult getPessoaSimplificada([FromRoute] string codPessoa, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            MsgRegistroPessoaSimplificadaBody body = new MsgRegistroPessoaSimplificadaBody();

            try
            {
                if (string.IsNullOrWhiteSpace(codPessoa))
                    throw new ApplicationException("Parâmetro codPessoa obrigatório");

                if (parametrosBase.empresa == null || parametrosBase.empresa.Value.Equals(0))
                    throw new ApplicationException("Parâmetro empresa obrigatório");

                if (parametrosBase.dependencia == null || parametrosBase.dependencia.Value.Equals(0))
                    throw new ApplicationException("Parâmetro dependencia obrigatório");


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken("att", "att");

                ParametroIntegracaoPessoaSimplificada parm = _clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, "att",  configuracaoCUC.Value.SiglaSistema, token);

                DataSetPessoaSimplificada dataSetPessoa = _clientPessoaSimplificada.SelecionarPessoaSimplificada(parm, codPessoa);

                body.RegistroPessoaSimplificada = _adaptador.AdaptarDataSetPessoaSimplificadaPessoaSimplificadaToMsgRegistroPessoaSimplificada(dataSetPessoa.RegistroPessoaSimplificada, listaErros);
                retorno = _adaptador.AdaptarMsgRetornoGet(body, listaErros);

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
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = _adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }
    }
}
*/