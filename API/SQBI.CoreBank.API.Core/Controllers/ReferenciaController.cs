using Microsoft.AspNetCore.Mvc;
using SQBI.CoreBank.API.Core.Adaptadores;
using SQBI.CoreBank.API.Core.Models;
using System.Collections.Generic;

namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    public class ReferenciaController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/referencia")]
        public ActionResult postReferencia([FromBody] MsgReferencia msgReferencia)
        {
            AdaptadorReferencia adaptador = new AdaptadorReferencia();
            List<string> listaErros = new List<string>();

            MsgRetorno retorno = adaptador.AdaptarMsgRetorno(msgReferencia, listaErros);

            return Ok(retorno);
        }
    }
}