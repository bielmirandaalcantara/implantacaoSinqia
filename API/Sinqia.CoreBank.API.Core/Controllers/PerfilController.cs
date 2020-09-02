﻿using System;
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
    public class PerfilController : ControllerBase
    {
        [HttpPost]
        [Route("api/core/cadastros/pessoa/{codPessoa}/perfil")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult postPerfil([FromRoute] string codPessoa, [FromBody] MsgPerfil msg)
        {
            AdaptadorPerfil adaptador = new AdaptadorPerfil();
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

        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}/perfil/{codPerfil}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult putPerfil([FromRoute] string codPessoa, [FromRoute] string codPerfil, [FromBody] MsgPerfil msg)
        {
            AdaptadorPerfil adaptador = new AdaptadorPerfil();
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

    }
}
