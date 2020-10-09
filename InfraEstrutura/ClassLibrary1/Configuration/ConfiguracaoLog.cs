using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Configuracao.Configuration
{
    public class ConfiguracaoLog
    {
        public string HabilitarTrace { get; set; }
        public string HabilitarLog { get; set; }
        public string GerarPastaNaoEncontrada { get; set; }
        public string CaminhoArquivo { get; set; }
        public string NomeArquivo { get; set; }
    }
}
