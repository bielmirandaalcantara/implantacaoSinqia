﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgPerfil
    {
        /// <summary>
        /// header da mensagem
        /// erros será nulo em retornos http 200
        /// identificador será nulo ou em branco caso seja uma requisição GET
        /// </summary>
        public MsgHeader header { get; set; }
        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroPerfilBody body { get; set; }
    }

    public class MsgRegistroPerfilBody
    {
        public MsgRegistroperfil RegistroPerfil { get; set; }
    }

    /// <summary>
    /// Possibilita a vinculação de perfis para uma pessoa - tb_perfpes
    /// </summary>
    public class MsgRegistroperfil
    {
        /// <summary>
        /// Código Pessoa
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Perfil
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoPerfil { get; set; }
    }
}