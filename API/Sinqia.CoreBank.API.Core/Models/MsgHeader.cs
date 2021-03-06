﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    /// <summary>
    /// Classe responsável pelo header das mensagens 
    /// </summary>
    public class MsgHeader
    {
        /// <summary>
        /// Identificador da mensagem para localização (caso exista)
        /// </summary>
        public string identificadorEnvio { get; set; }
        /// <summary>
        /// Data e hora que foi enviado a mensagem
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataHoraEnvio { get; set; }

    }
}