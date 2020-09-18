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
using Sinqia.CoreBank.API.Core.Logging;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PessoaSimplificadaController : ControllerBase
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

        public PessoaSimplificadaController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoCUC = _configuracaoCUC;
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
            AdaptadorPessoaSimplificada adaptador = new AdaptadorPessoaSimplificada();
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
                    retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = ServiceAutenticacao.GetToken("att", "att");

                dataSetPessoa = adaptador.AdaptarMsgPessoaSimplificadaToDataSetPessoa(msg, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros);

                IntegracaoPessoaSimplificadaCUCService clientPessoaSimplificada = new IntegracaoPessoaSimplificadaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoaSimplificada parm = clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario,  configuracaoCUC.Value.SiglaSistema, token);

                var retPessoa = clientPessoaSimplificada.AtualizarPessoaSimplificada(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

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
            AdaptadorPessoaSimplificada adaptador = new AdaptadorPessoaSimplificada();
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
                    retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = ServiceAutenticacao.GetToken("att", "att");

                dataSetPessoa = adaptador.AdaptarMsgPessoaSimplificadaToDataSetPessoa(msg, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros);

                IntegracaoPessoaSimplificadaCUCService clientPessoaSimplificada = new IntegracaoPessoaSimplificadaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoaSimplificada parm = clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario,  configuracaoCUC.Value.SiglaSistema, token);

                var retPessoa = clientPessoaSimplificada.AtualizarPessoaSimplificada(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");


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
            AdaptadorPessoaSimplificada adaptador = new AdaptadorPessoaSimplificada();
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

                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaSimplificadaCUCService clientPessoaSimplificada = new IntegracaoPessoaSimplificadaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoaSimplificada parm = clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, parametrosBase.usuario,  configuracaoCUC.Value.SiglaSistema, token);

                RetornoIntegracaoPessoaSimplificada retClient = clientPessoaSimplificada.ExcluirPessoaSimplificada(parm, codPessoa);

                if (retClient.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retClient.Excecao.Mensagem}");

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
            AdaptadorPessoaSimplificada adaptador = new AdaptadorPessoaSimplificada();
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

                if (string.IsNullOrWhiteSpace(parametrosBase.usuario))
                    throw new ApplicationException("Parâmetro usuario obrigatório");


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaSimplificadaCUCService clientPessoaSimplificada = new IntegracaoPessoaSimplificadaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoaSimplificada parm = clientPessoaSimplificada.CarregarParametrosCUCPessoaSimplificada(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, parametrosBase.usuario,  configuracaoCUC.Value.SiglaSistema, token);

                DataSetPessoaSimplificada dataSetPessoa = clientPessoaSimplificada.SelecionarPessoaSimplificada(parm, codPessoa);

                body.RegistroPessoaSimplificada = adaptador.AdaptarDataSetPessoaSimplificadaPessoaSimplificadaToMsgRegistroPessoaSimplificada(dataSetPessoa.RegistroPessoaSimplificada, listaErros);
                retorno = adaptador.AdaptarMsgRetornoGet(body, listaErros);

                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (LogErrorException LogEx)
            {
                listaErros.Add(LogEx.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);

                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }
            catch (ApplicationException appEx)
            {
                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }
    }
}
