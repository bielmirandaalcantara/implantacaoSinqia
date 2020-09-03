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
        /// erros será nulo em retornos http 200
        /// identificador será nulo ou em branco caso seja uma requisição GET
        /// </summary>
        public MsgHeader header { get; set; }
        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroPessoaCompletoBody body { get; set; }
    }

    public class MsgRegistroPessoaCompletoBody
    {
        public MsgRegistropessoaCompleto RegistroPessoa { get; set; }
    }

    /// <summary>
    /// Possibilita o cadastramento de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas - tb_pes
    /// </summary>
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