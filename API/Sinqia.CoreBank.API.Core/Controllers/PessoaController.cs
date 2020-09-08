﻿using System;
using Microsoft.AspNetCore.Mvc;
using Sinqia.CoreBank.API.Core.Adaptadores;
using Sinqia.CoreBank.API.Core.Models;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Sinqia.CoreBank.API.Core.Models.Templates;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class PessoaController : ControllerBase
    {
        /// <summary>
        /// Cadastro de pessoa - Possibilita o cadastramento de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <returns>MsgRetorno</returns>
        [HttpPost]
        [Route("api/core/cadastros/pessoa")]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno),StatusCodes.Status500InternalServerError)]
        public ActionResult postPessoa([FromBody] MsgPessoaCompleto msg)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch(ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetorno(msg, listaErros);                
                return StatusCode((int)HttpStatusCode.InternalServerError,retorno);
            }

        }

        /// <summary>
        /// Alteração de pessoa - Possibilita alteração dos dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpPut]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult putPessoa([FromRoute] string codPessoa, [FromBody] MsgPessoa msg)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
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

        /// <summary>
        /// Exclusão de pessoa - Possibilita a exclusão de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpDelete]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgRetorno), StatusCodes.Status500InternalServerError)]
        public ActionResult deletePessoa([FromRoute] string codPessoa)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetorno retorno;

            try
            {
                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetorno(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }

        /// <summary>
        /// Consulta os dados de pessoa simplificada
        /// </summary>
        /// <param name="codPessoa">Código da pessoa</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoa/{codPessoa}")]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgPessoaCompletoTemplate), StatusCodes.Status500InternalServerError)]
        public ActionResult getPessoa([FromRoute] string codPessoa)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            MsgRegistropessoaCompleto msgRegistropessoaCompleto;

            try
            {
                msgRegistropessoaCompleto = adaptador.AdaptarMsgRegistropessoaCompleto();
                retorno = adaptador.AdaptarMsgRetornoGet(msgRegistropessoaCompleto, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }

        /// <summary>
        /// Consulta os dados de pessoa simplificada por nome e CPF
        /// </summary>
        /// <param name="nome">Nome da pessa ou pessoas a serem consultadas</param>
        /// <param name="cpf">Documento da pessoa a ser consultada</param>
        /// <param name="pageSkip">Retornar consulta após x registros</param>
        /// <param name="pageTake">Quantidade de registros a ser retornado nessa consulta</param>
        /// <returns>MsgRetorno</returns>
        [HttpGet]
        [Route("api/core/cadastros/pessoa/")]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(MsgPessoaCompletoListaTemplate), StatusCodes.Status500InternalServerError)]
        public ActionResult getPessoaLista([FromQuery] string nome, [FromQuery] string cpf, [FromQuery] int pageSkip, [FromQuery] int pageTake)
        {
            AdaptadorPessoa adaptador = new AdaptadorPessoa();
            List<string> listaErros = new List<string>();
            MsgRetornoGet retorno;
            IList<MsgRegistropessoaCompleto> msgRegistropessoaConsulta;

            try
            {
                msgRegistropessoaConsulta = adaptador.AdaptarMsgRegistropessoaCompletoLista();
                retorno = adaptador.AdaptarMsgRetornoGet(msgRegistropessoaConsulta, listaErros);
                return StatusCode((int)HttpStatusCode.OK, retorno);
            }
            catch (ApplicationException appEx)
            {

                listaErros.Add(appEx.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.BadRequest, retorno);
            }
            catch (Exception ex)
            {
                listaErros.Add(ex.Message);
                retorno = adaptador.AdaptarMsgRetornoGet(listaErros);
                return StatusCode((int)HttpStatusCode.InternalServerError, retorno);
            }

        }
    }
}
