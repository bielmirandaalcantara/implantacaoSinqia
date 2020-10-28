using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.SqlServer;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.MySql;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases
{
    public class FactoryConector
    {
        private ConfiguracaoConexao _conexaoConf;

        public FactoryConector(ConfiguracaoConexao conexaoConf)
        {
            _conexaoConf = conexaoConf;
        }

        public IConector GetConector(string nomeBanco)
        {
            IConector conector = null;

            switch (nomeBanco)
            {
                case Banco.SQLSERVER:
                    conector = new ConectorSQLService(_conexaoConf);
                    break;
                case Banco.MYSQL:
                    conector = new ConectorMySql(_conexaoConf);
                    break;
            }

            return conector;
        }
    }
}
