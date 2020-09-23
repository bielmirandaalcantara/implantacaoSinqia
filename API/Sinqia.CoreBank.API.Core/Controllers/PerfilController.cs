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
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PerfilController : ControllerBase
    {
        private IOptions<ConfiguracaoBaseCUC> configuracaoCUC;
        private IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI;
        private LogService _log;
        private AdaptadorPerfil _adaptador;
        private AutenticacaoCUCService _ServiceAutenticacao;
        private IntegracaoPessoaCUCService _clientPessoa;

        public PerfilController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC, IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoBaseAPI = _configuracaoBaseAPI;
            configuracaoCUC = _configuracaoCUC;
            _log = new LogService(configuracaoBaseAPI.Value.Log ?? null);
            _configuracaoCUC.Value.AcessoCUC = Util.DescriptografarUsuarioServico(_configuracaoCUC.Value.AcessoCUC);
            _adaptador = new AdaptadorPerfil(_log);
            _ServiceAutenticacao = new AutenticacaoCUCService(configuracaoCUC, _log);
            _clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC, _log);            
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

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroPerfil> registros = new List<DataSetPessoaRegistroPerfil>();
                registros.Add(_adaptador.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(msg.body.RegistroPerfil, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros));
                dataSetPessoa.RegistroPerfil = registros.ToArray();

                var retPessoa = _clientPessoa.AtualizarPessoa(parm, dataSetPessoa);
                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

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
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (msg == null) throw new ApplicationException("Mensagem inválida");
                if (msg.header == null) throw new ApplicationException("Mensagem inválida - chave header não informada");
                if (msg.body == null) throw new ApplicationException("Mensagem inválida - chave body não informada");

                listaErros = Util.ValidarModel(ModelState);
                if (listaErros.Any())                {
                    
                    retorno = _adaptador.AdaptarMsgRetorno(msg, listaErros);

                    _log.TraceMethodEnd();
                    return StatusCode((int)HttpStatusCode.BadRequest, retorno);
                }


                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarCabecalho(parm, codPessoa);

                List<DataSetPessoaRegistroPerfil> registros = new List<DataSetPessoaRegistroPerfil>();
                registros.Add(_adaptador.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(msg.body.RegistroPerfil, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros));
                dataSetPessoa.RegistroPerfil = registros.ToArray();

                var retPessoa = _clientPessoa.AtualizarPessoa(parm, dataSetPessoa);


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
        /// Exclusão de perfis para uma pessoa
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codPerfil">Código do perfil</param>
        /// <param name="empresa">Empresa referente a consulta</param>
        /// <param name="dependencia">Dependência referente a consulta</param>
        /// <param name="usuario">usuário responsável pela consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}/perfil/{codPerfil}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult deletePerfil([FromRoute] string codPessoa, [FromRoute] string codPerfil, [FromQuery] ParametroBaseQuery parametrosBase)
        {
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                _log.TraceMethodStart();

                if (!Util.ValidarApiKey(Request, configuracaoBaseAPI)) return StatusCode((int)HttpStatusCode.Unauthorized);

                string token = _ServiceAutenticacao.GetToken(configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.AcessoCUC.passServico);

                ParametroIntegracaoPessoa parm = _clientPessoa.CarregarParametrosCUCPessoa(parametrosBase.empresa.Value, parametrosBase.dependencia.Value, configuracaoCUC.Value.AcessoCUC.userServico, configuracaoCUC.Value.SiglaSistema, token);
                DataSetPessoa dataSetPessoa = _clientPessoa.SelecionarCabecalho(parm, codPessoa);

                dataSetPessoa.RegistroPerfil = _adaptador.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfilExclusao(codPessoa, codPerfil, listaErros);

                var retPessoa = _clientPessoa.AtualizarPessoa(parm, dataSetPessoa);
                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Retorno serviço CUC - {retPessoa.Excecao.Mensagem}");

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

    }
}
