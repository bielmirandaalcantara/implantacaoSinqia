using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.Services.CUC.Models.Configuration
{
    public class ConfiguracaoBaseCUC 
    {
        public string SiglaSistema { get; set; }
        public ConfiguracaoAcessoCUC AcessoCUC { get; set; }
        public ConfiguracaoURICUC[] ConfiguracaoURICUC { get; set; }        
    }

    public class ConfiguracaoURICUC
    {
        public string Nome { get; set; }
        public string URI { get; set; }
        public int Timeout { get; set; }
    }

    public class ConfiguracaoAcessoCUC
    {
        public string userServico { get; set; }
        public string passServico { get; set; }
    }
}
