using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SQBI.CoreBank.API.Core.Controllers
{
    [ApiController]
    public class AcessoController : ControllerBase
    {
        [HttpGet]
        [Route("api/core/acesso/token")]
        public IActionResult getToken()
        {
            return Ok();
        }
    }
}