using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgPerfil
    {
        /// <summary>
        /// header da mensagem
        /// </summary>
        public MsgHeader header { get; set; }
        /// <summary>
        /// corpo da mensagem
        /// </summary>
        public MsgRegistroPerfilBody body { get; set; }
    }

    public class MsgRegistroPerfilBody
    {
        public MsgRegistroperfil RegistroPerfil { get; set; }
    }
    public class MsgRegistroperfil
    {
        /// <summary>
        /// Código Pessoa
        /// </summary>
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Perfil
        /// </summary>
        public string codigoPerfil { get; set; }
    }
}