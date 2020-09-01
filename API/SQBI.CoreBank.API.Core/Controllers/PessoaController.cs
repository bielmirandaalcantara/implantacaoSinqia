using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SQBI.CoreBank.API.Core.Models;
using SQBI.CoreBank.API.Core.Adaptadores;

namespace SQBI.CoreBank.API.Core.Controllers
{
    public class PessoaController : ApiController
    {
        [HttpPost]
        [Route("api/core/cadastros/pessoa")]
        public HttpResponseMessage postPessoa([FromBody]MsgPessoa msgPessoa)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();

            MsgRetorno retorno = adaptador.AdaptarMsgRetorno(msgPessoa, listaErros);

            return Request.CreateResponse(HttpStatusCode.OK, retorno, "application/json");
        }
    }
}
