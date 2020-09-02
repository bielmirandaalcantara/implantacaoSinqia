using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgPessoaCompleto
    {
        public MsgHeader header { get; set; }
        public MsgRegistroPessoaCompletoBody body { get; set; }
    }

    public class MsgRegistroPessoaCompletoBody
    {
        public MsgRegistropessoaCompleto RegistroPessoa { get; set; }
    }

    public class MsgRegistropessoaCompleto: MsgRegistropessoa
    {      
        public MsgRegistroperfil[] RegistroPerfil { get; set; }
        public MsgRegistrodocumento[] RegistroDocumento { get; set; }
        public MsgRegistroendereco[] RegistroEndereco { get; set; }
        public MsgRegistroreferencia[] RegistroReferencia { get; set; }
    }
}