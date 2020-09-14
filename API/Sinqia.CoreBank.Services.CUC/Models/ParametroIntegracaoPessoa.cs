using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Models
{
    public class ParametroIntegracaoPessoa
    {
        public int? empresa { get; set; }

        public int? dependencia { get; set; }

        public string login { get; set; }

        public string sigla { get; set; }

        public string token { get; set; }

    }
}
