﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sinqia.CoreBank.API.Core.Models;

namespace Sinqia.CoreBank.API.Core.Models.Templates
{
    public class MsgPessoaCompletoTemplate
    {
        /// <summary>
        /// header da mensagem
        /// erros será nulo em retornos http 200
        /// identificador será nulo ou em branco caso seja uma requisição GET
        /// </summary>
        public MsgHeaderRetorno header { get; set; }
        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroPessoaBody body { get; set; }
    }

   
}