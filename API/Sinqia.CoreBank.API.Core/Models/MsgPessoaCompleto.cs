using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgPessoaCompleto
    {
        /// <summary>
        /// header da mensagem
        /// </summary>
        public MsgHeader header { get; set; }
        /// <summary>
        /// corpo da mensagem
        /// </summary>
        public MsgRegistroPessoaCompletoBody body { get; set; }
    }

    public class MsgRegistroPessoaCompletoBody
    {
        public MsgRegistropessoaCompleto RegistroPessoa { get; set; }
    }

    public class MsgRegistropessoaCompleto: MsgRegistropessoa
    {
        /// <summary>
        /// inclusão de perfil
        /// </summary>
        public MsgRegistroperfil[] RegistroPerfil { get; set; }
        /// <summary>
        /// Inclusão de documentos
        /// </summary>
        public MsgRegistrodocumento[] RegistroDocumento { get; set; }
        /// <summary>
        /// Inclusão de endereços
        /// </summary>
        public MsgRegistroendereco[] RegistroEndereco { get; set; }
        /// <summary>
        /// Inclusão de referências da pessoa
        /// </summary>
        public MsgRegistroreferencia[] RegistroReferencia { get; set; }
    }
}