using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dao.Core.Configuration
{
    public class ConfiguracaoBaseDataBase
    {
        public string BancoUtilizado { get; set; }
        public ConfiguracaoConnectionStrings[] ConnectionStrings { get; set; }
    }

    public class ConfiguracaoConnectionStrings
    {
        public string Banco { get; set; }
        public string Conexao { get; set; }
    }
}
