using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.SincronizadorTabela.Configuration
{
    public class ConfiguracaoSincronizadorTabela
    {
        public static string nomeSessao = "ConfiguracaoSincronizadorTabela";

        public int IntervaloSegundos { get; set; }

        public List<ConfiguracaoConexao> Conexoes { get; set; }

        public ConfiguracaoLog Log { get; set; }
    }   
}
