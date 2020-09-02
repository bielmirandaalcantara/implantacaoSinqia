using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgPerfil
    {
        public MsgHeader header { get; set; }
        public MsgRegistroPerfilBody body { get; set; }
    }

    public class MsgRegistroPerfilBody
    {
        public MsgRegistroperfil RegistroPerfil { get; set; }
    }
    public class MsgRegistroperfil
    {
        public string codigoPessoa { get; set; }
        public string codigoPerfil { get; set; }
    }
}