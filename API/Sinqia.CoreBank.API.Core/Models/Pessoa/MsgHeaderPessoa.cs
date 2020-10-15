using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Pessoa
{
    /// <summary>
    /// Classe responsável pelo header das mensagens 
    /// </summary>
    public class MsgHeaderPessoa : MsgHeader
    {
        /// <summary>
        /// Dependencia
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? dependencia { get; set; }
        /// <summary>
        /// Empresa
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? empresa { get; set; }
    }
}