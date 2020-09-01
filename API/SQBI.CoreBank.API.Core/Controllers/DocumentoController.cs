using Microsoft.AspNetCore.Mvc;
using SQBI.CoreBank.API.Core.Adaptadores;
using SQBI.CoreBank.API.Core.Models;
using System.Collections.Generic;

namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/Documento")]
        public ActionResult postDocumento([FromBody] MsgDocumento msgDocumento)
        {
            AdaptadorDocumento adaptador = new AdaptadorDocumento();
            List<string> listaErros = new List<string>();

            MsgRetorno retorno = adaptador.AdaptarMsgRetorno(msgDocumento, listaErros);

            return Ok(retorno);
        }
    }
}