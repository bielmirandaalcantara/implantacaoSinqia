using System;
using System.Collections.Generic;
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
        public DateTime? dataHoraEnvio { get; set; }
        /// <summary>
        /// Dependencia
        /// </summary>
        public int dependencia { get; set; }
        /// <summary>
        /// Empresa
        /// </summary>
        public int empresa { get; set; }
        /// <summary>
        /// Usuário do Sistema
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Senha do Sistema
        /// </summary>
        public string senha { get; set; }
    }
}