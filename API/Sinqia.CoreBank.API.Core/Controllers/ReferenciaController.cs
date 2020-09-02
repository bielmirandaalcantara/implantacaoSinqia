using System;
using Microsoft.AspNetCore.Mvc;
using SQBI.CoreBank.API.Core.Adaptadores;
using SQBI.CoreBank.API.Core.Models;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;


namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ReferenciaController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/referencia")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status201Created)]
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
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
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
    }
}