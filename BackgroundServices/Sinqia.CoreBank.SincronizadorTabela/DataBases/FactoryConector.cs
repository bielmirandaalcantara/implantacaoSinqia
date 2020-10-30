using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.SqlServer;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.MySql;
using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.SincronizadorTabela.Logging;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases
{
    public class FactoryConector
    {
        private ConfiguracaoConexao _conexaoConf;
        private LogService _log;

        public FactoryConector(ConfiguracaoConexao conexaoConf, LogService log)
        {
            _conexaoConf = conexaoConf;
            _log = log;
        }

        public IConector GetConector(string nomeBanco)
        {     
            IConector conector = null;

            switch (nomeBanco)
            {
                case Banco.SQLSERVER:
                    conector = new ConectorSQLService(_conexaoConf, _log);
                    break;
                case Banco.MYSQL:
                    conector = new ConectorMySql(_conexaoConf, _log);
                    break;
                case Banco.SYBASE:
                    conector = new ConectorSyBase(_conexaoConf, _log);
                    break;
            }

            return conector;
        }
    }
}
