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
        public static IDao BuscarDaoCorporativo()
        {

        }
        */
    }
}
