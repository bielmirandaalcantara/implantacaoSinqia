using Microsoft.AspNetCore.Mvc;
using SQBI.CoreBank.API.Core.Adaptadores;
using SQBI.CoreBank.API.Core.Models;
using System.Collections.Generic;

namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    public class PerfilController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/perfil")]
        public ActionResult postPerfil([FromBody] MsgPerfil msgPerfil)
        {
            AdaptadorPerfil adaptador = new AdaptadorPerfil();
            List<string> listaErros = new List<string>();

            MsgRetorno retorno = adaptador.AdaptarMsgRetorno(msgPerfil, listaErros);

            return Ok(retorno);
        }
    }
}
