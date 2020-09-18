using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Configuration
{
    public class ConfiguracaoBaseAPI
    {
        public string ApiKeyBase { get; set; }

        public ConfiguracaoLogAPI LogApi { get; set; }
    }
    public partial class ConfiguracaoLogAPI
    {
        public string HabilitarTrace { get; set; }
        public string HabilitarLog { get; set; }
        public string GerarPastaNaoEncontrada { get; set; }
        public string CaminhoArquivo { get; set; }
        public string NomeArquivo { get; set; }
    }
}
