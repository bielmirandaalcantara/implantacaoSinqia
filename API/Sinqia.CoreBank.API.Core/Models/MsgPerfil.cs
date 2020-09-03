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