using Sinqia.CoreBank.Dao.Core.Configuration;
using Sinqia.CoreBank.Dao.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dao.Corporativo.Services
{
    public class DaoCorporativoFactory
    {
        private ConfiguracaoBaseDataBase _dataBaseConfig;
        
        public DaoCorporativoFactory(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _dataBaseConfig = dataBaseConfig;
        }
        /*
        public IDao BuscarDaoCorporativo<T>() where T : new()
        {
            if (string.IsNullOrWhiteSpace(_dataBaseConfig.BancoUtilizado)) throw new Exception("Chave necessária no arquivo de configuração - BancoUtilizado");

            
        }
        */
        
    }
}
