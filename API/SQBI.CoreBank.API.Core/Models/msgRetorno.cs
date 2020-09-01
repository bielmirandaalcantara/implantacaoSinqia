using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgRetorno
    {
        public MsgHeaderRetorno header { get; set; }
    }

    public class MsgHeaderRetorno
    {
        public string identificador { get; set; }
        public DateTime dataHoraEnvio { get; set; }
        public DateTime dataHoraRetorno { get; set; }
        public string status { get; set; }
        public string[] erros { get; set; }
    }
}