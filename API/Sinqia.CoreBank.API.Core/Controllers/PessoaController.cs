using System;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Models;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Sinqia.CoreBank.API.Core.Models.Templates;
using Sinqia.CoreBank.Services.CUC.WCF.Autenticacao;
using Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoa;
using Sinqia.CoreBank.Services.CUC.Services;
using Sinqia.CoreBank.Services.CUC.Models;
using System.Xml.Serialization;
using System.IO;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Microsoft.Extensions.Options;
using System.Linq;
using Sinqia.CoreBank.Services.CUC.Constantes;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PessoaController : ControllerBase
    {
        private AutenticacaoCUCService _ServiceAutenticacao;
        public AutenticacaoCUCService ServiceAutenticacao { get
            {
                if (_ServiceAutenticacao == null) _ServiceAutenticacao = new AutenticacaoCUCService(configuracaoCUC);
                return _ServiceAutenticacao;
            }
        }

        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

        public PessoaController(IOptions<ConfiguracaoBaseCUC> _configuracaoCUC)
        {
            configuracaoCUC = _configuracaoCUC;
        }

        /// <summary>
        /// Cadastro de pessoa - Possibilita o cadastramento de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa")]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status500InternalServerError)]
        public ActionResult postPessoa([FromBody] MsgPessoaCompleto msg)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
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

                string token = ServiceAutenticacao.GetToken("att", "att");

                var dataSetPessoa = adaptador.AdaptarMsgPessoaCompletoToDataSetPessoa(msg, ConstantesInegracao.StatusLinhaCUC.Insercao, listaErros);

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario, "BR", token);
                var retPessoa = clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Ocorreu erro no serviço CUC - {retPessoa.Excecao.Mensagem}");

                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch(ApplicationException appEx)
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
        /// Alteração de pessoa - Possibilita alteração dos dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult putPessoa([FromRoute] string codPessoa, [FromBody] MsgPessoa msg)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
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

                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoa.CarregarParametrosCUCPessoa(msg.header.empresa.Value, msg.header.dependencia.Value, msg.header.usuario, "BR", token);
                dataSetPessoa.RegistroPessoa = adaptador.AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(msg.body.RegistroPessoa, ConstantesInegracao.StatusLinhaCUC.Atualizacao, listaErros);
                
                var retPessoa = clientPessoa.AtualizarPessoa(parm, dataSetPessoa);

                if (retPessoa.Excecao != null)
                    throw new ApplicationException($"Ocorreu erro no serviço CUC - {retPessoa.Excecao.Mensagem}");

                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
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
        /// Exclusão de pessoa - Possibilita a exclusão de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult deletePessoa([FromRoute] string codPessoa, [FromQuery] int empresa, [FromQuery] int dependencia, [FromQuery] string usuario)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                if (string.IsNullOrWhiteSpace(codPessoa))
                    throw new ApplicationException("Parâmetro codPessoa obrigatório");

                if (empresa.Equals(0))
                    throw new ApplicationException("Parâmetro empresa obrigatório");

                if (dependencia.Equals(0))
                    throw new ApplicationException("Parâmetro dependencia obrigatório");

                if (string.IsNullOrWhiteSpace(usuario))
                    throw new ApplicationException("Parâmetro usuario obrigatório");

                string token = ServiceAutenticacao.GetToken("att", "att");

                IntegracaoPessoaCUCService clientPessoaSimplificada = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = clientPessoaSimplificada.CarregarParametrosCUCPessoa(empresa, dependencia, usuario, "BR", token);

                RetornoIntegracaoPessoa retClient = clientPessoaSimplificada.ExcluirPessoa(parm, codPessoa);

                if (retClient.Excecao != null)
                    throw new ApplicationException($"Ocorreu erro no serviço CUC - {retClient.Excecao.Mensagem}");

                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
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
        /// Consulta os dados de pessoa simplificada
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status500InternalServerError)]
        public ActionResult getPessoa([FromRoute] string codPessoa)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            MsgRegistropessoaCompleto msgRegistropessoaCompleto;

            try
            {
                msgRegistropessoaCompleto = adaptador.AdaptarMsgRegistropessoaCompleto();
                retorno = adaptador.AdaptarMsgRetornoGet(msgRegistropessoaCompleto, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
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

        /// <summary>
        /// Consulta os dados de pessoa simplificada por nome e CPF
        /// </summary>
        /// <param name="nome">Nome da pessa ou pessoas a serem consultadas</param>
        /// <param name="cpf">Documento da pessoa a ser consultada</param>
        /// <param name="pageSkip">Retornar consulta após x registros</param>
        /// <param name="pageTake">Quantidade de registros a ser retornado nessa consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoa/")]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status500InternalServerError)]
        public ActionResult getPessoaLista([FromQuery] string nome, [FromQuery] string cpf, [FromQuery] int pageSkip, [FromQuery] int pageTake)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            IList<MsgRegistropessoaCompleto> msgRegistropessoaConsulta;

            try
            {
                msgRegistropessoaConsulta = adaptador.AdaptarMsgRegistropessoaCompletoLista();
                retorno = adaptador.AdaptarMsgRetornoGet(msgRegistropessoaConsulta, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
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
