using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Configuration;
using Sinqia.CoreBank.API.Core.Logging;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class OutrosBancosController : ControllerBase
    {
        private AutenticacaoCUCService _ServiceAutenticacao;
        public AutenticacaoCUCService ServiceAutenticacao
        {
            get
            {
                if (_ServiceAutenticacao == null) _ServiceAutenticacao = new AutenticacaoCUCService(configuracaoCUC);
                return _ServiceAutenticacao;
            }
        }
        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC;
        public IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI;

        public OutrosBancosController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoCUC = _configuracaoCUC;
        }

        /// <summary>
        /// cadastro das contas do cliente em outros bancos
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/outrosbancos")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postOutrosBancos([FromRoute] string codPessoa, [FromBody] MsgOutrosBancos msg)
        {
            AdaptadorOutrosBancos adaptador = new AdaptadorOutrosBancos();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                /*
                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario, configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroDocumento> registros = new List<DataSetPessoaRegistroDocumento>();
                registros.Add(adaptador.AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(msg.body.RegistroDocumento, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros));
                dataSetPessoa.RegistroDocumento = registros.ToArray();

                var retPessoa = clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");
                */

                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg,listaErros);

                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
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
        [Route("api/core/cadastros/pessoa/{codPessoa}/outrosbancos/{sequencial}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putOutrosBancos([FromRoute] string codPessoa, [FromRoute] int sequencial, [FromBody] MsgOutrosBancos msg)
        {
            AdaptadorOutrosBancos adaptador = new AdaptadorOutrosBancos();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())
                {
                    retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);
                /*
                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario,  configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroDocumento> registros = new List<DataSetPessoaRegistroDocumento>();
                registros.Add(adaptador.AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(msg.body.RegistroDocumento, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros));
                dataSetPessoa.RegistroDocumento = registros.ToArray();

                var retPessoa = clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");
               */
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);

                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
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
        [Route("api/core/cadastros/pessoa/{codPessoa}/outrosbancos/{sequencial}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deleteOutrosBancos([FromRoute] string codPessoa, [FromRoute] int sequencial, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            AdaptadorOutrosBancos adaptador = new AdaptadorOutrosBancos();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = ServiceAutenticacao.GetToken("att", "att");

                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(listaErros);

                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
        }

    }
}