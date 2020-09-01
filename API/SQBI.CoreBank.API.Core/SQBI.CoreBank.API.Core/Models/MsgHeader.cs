using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgHeader
    {
        public string identificadorEnvio { get; set; }
        public DateTime? dataHoraEnvio { get; set; }
    }
}