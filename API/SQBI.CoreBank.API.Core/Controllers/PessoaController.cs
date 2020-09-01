using Microsoft.AspNetCore.Mvc;
using SQBI.CoreBank.API.Core.Adaptadores;
using SQBI.CoreBank.API.Core.Models;
using System.Collections.Generic;

namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    public class PessoaController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/pessoa")]
        public ActionResult postPessoa([FromBody] MsgPessoa msgPessoa)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();

            MsgRetorno retorno = adaptador.AdaptarMsgRetorno(msgPessoa, listaErros);

            return Ok(retorno);
        }
    }
}
