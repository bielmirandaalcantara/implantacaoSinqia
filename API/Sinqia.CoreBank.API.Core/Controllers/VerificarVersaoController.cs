using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Models.Corporativo.Templates;
using Sinqia.CoreBank.ConstantesGerais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    public class VerificarVersaoController : ControllerBase
    {
        /// <summary>
        /// Busca a Versão da API
        /// </summary>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/verificarversao")]
        [ProducesResponseType(typeof(MsgOperadorTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgOperadorTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgOperadorTemplate), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult getVersao()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, ControleVersao.VersaoAPI + "/" + ControleVersao.VersaoCUC);
            }
            catch (ApplicationException appEx)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Não foi possível verificar a versão");
            }
        }
    }
}
