using System;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Models;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Linq;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.Services;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.API.Core.Configuration;
using Sinqia.CoreBank.API.Core.Logging;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PerfilController : ControllerBase
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

        public PerfilController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoCUC = _configuracaoCUC;
        }

        /// <summary>
        /// Vinculação de perfis para uma pessoa
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/perfil")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult postPerfil([FromRoute] string codPessoa, [FromBody] MsgPerfil msg)
        {
            AdaptadorPerfil adaptador = new AdaptadorPerfil();
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

                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario, configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroPerfil> registros = new List<DataSetPessoaRegistroPerfil>();
                registros.Add(adaptador.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(msg.body.RegistroPerfil, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros));
                dataSetPessoa.RegistroPerfil = registros.ToArray();

                var retPessoa = clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

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
        /// Alteração de perfis para uma pessoa
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codPerfil">Código do perfil</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}/perfil/{codPerfil}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult putPerfil([FromRoute] string codPessoa, [FromRoute] string codPerfil, [FromBody] MsgPerfil msg)
        {
            AdaptadorPerfil adaptador = new AdaptadorPerfil();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())                {
                    
                    retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario, configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroPerfil> registros = new List<DataSetPessoaRegistroPerfil>();
                registros.Add(adaptador.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(msg.body.RegistroPerfil, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros));
                dataSetPessoa.RegistroPerfil = registros.ToArray();

                var retPessoa = clientPessoa.AtualizarPessoa(parm, dataSetPessoa);


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
        /// Exclusão de perfis para uma pessoa
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codPerfil">Código do perfil</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}/perfil/{codPerfil}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deletePerfil([FromRoute] string codPessoa, [FromRoute] string codPerfil)
        {
            AdaptadorPerfil adaptador = new AdaptadorPerfil();
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
