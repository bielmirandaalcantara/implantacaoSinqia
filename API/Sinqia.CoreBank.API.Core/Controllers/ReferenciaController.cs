using System;
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
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Microsoft.Extensions.Options;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ReferenciaController : ControllerBase
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
        public IOptions<ConfiguracaoBaseCUC> configuracaoCUC { get; set; }

        /// <summary>
        /// Cadastro de dados de referência de pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/referencia")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult postReferencia([FromRoute] string codPessoa,[FromBody] MsgReferencia msg)
        {
            AdaptadorReferencia adaptador = new AdaptadorReferencia();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
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
        /// Alteração de dados de referência de pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codPessoaReferencia">Código de referencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}/referencia/{codPessoaReferencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult putReferencia([FromRoute] string codPessoa, [FromRoute] string codPessoaReferencia, [FromBody] MsgReferencia msg)
        {
            AdaptadorReferencia adaptador = new AdaptadorReferencia();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {

                IntegracaoPessoaCUCService clientPessoa = new IntegracaoPessoaCUCService(configuracaoCUC);
                ParametroIntegracaoPessoa parm = new ParametroIntegracaoPessoa();

                parm.empresa = msg.header.empresa;
                parm.login = msg.header.usuario;
                parm.sigla = "BR";
                parm.dependencia = msg.header.dependencia;
                parm.token = ServiceAutenticacao.GetToken("att", "att");

                var retcabecalho = clientPessoa.SelecionarCabecalho(parm, codPessoa);

                MsgPessoaCompleto pessoaCompleto = new MsgPessoaCompleto();

                pessoaCompleto.body.RegistroPessoa.RegistroReferencia[0] = msg.body.RegistroReferencia;

                string xml = retcabecalho.Xml;
                var serializer = new XmlSerializer(typeof(DataSetPessoa));
                DataSetPessoa dataSetPessoa;

                using (TextReader reader = new StringReader(xml))
                {
                    dataSetPessoa = (DataSetPessoa)serializer.Deserialize(reader);
                }


                string stringXML = string.Empty;
                dataSetPessoa.RegistroReferencia = adaptador.AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(pessoaCompleto.body.RegistroPessoa.RegistroReferencia, listaErros);
                XmlSerializer x = new XmlSerializer(typeof(DataSetPessoa));

                using (StringWriter textWriter = new StringWriter())
                {
                    x.Serialize(textWriter, dataSetPessoa);
                    stringXML = textWriter.ToString();
                }

                var retPessoa = clientPessoa.AtualizarPessoa(parm, stringXML);

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
        /// Exclusão de dados de referência de pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <param name="codPessoaReferencia">Código de referencia</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}/referencia/{codPessoaReferencia}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult deleteReferencia([FromRoute] string codPessoa, [FromRoute] string codPessoaReferencia)
        {
            AdaptadorReferencia adaptador = new AdaptadorReferencia();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
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

    }
}