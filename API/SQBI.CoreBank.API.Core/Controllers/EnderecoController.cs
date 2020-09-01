using Microsoft.AspNetCore.Mvc;
using SQBI.CoreBank.API.Core.Adaptadores;
using SQBI.CoreBank.API.Core.Models;
using System.Collections.Generic;

namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/endereco")]
        public ActionResult postEndereco([FromBody] MsgEndereco msgEndereco)
        {
            AdaptadorEndereco adaptador = new AdaptadorEndereco();
            List<string> listaErros = new List<string>();

            MsgRetorno retorno = adaptador.AdaptarMsgRetorno(msgEndereco, listaErros);

            return Ok(retorno);
        }
    }
}