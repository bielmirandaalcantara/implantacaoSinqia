using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Constantes;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Core.Services.SqlServer;

namespace Sinqia.CoreBank.DAO.Core.Services
{
    public class CoreDaoFactory
    {
        protected ConfiguracaoBaseDataBase _dataBaseConfig;

        public CoreDaoFactory(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _dataBaseConfig = dataBaseConfig;
        }

        public IDaoTransacao GetTransacao()
        {
            if (string.IsNullOrWhiteSpace(_dataBaseConfig.BancoUtilizado)) throw new Exception("Chave necessária no arquivo de configuração - BancoUtilizado");
            string bancoReferencia = _dataBaseConfig.BancoUtilizado;

            if (bancoReferencia.ToUpper().Equals(ConstantesDao.BancoUtilizado.SQLSERVER))
                return new TransacaoDaoSqlServer(_dataBaseConfig);
            else if (bancoReferencia.ToUpper().Equals(ConstantesDao.BancoUtilizado.ORACLE))
            {
                throw new NotImplementedException();
            }
            else
                throw new Exception("Chave não reconhecida no arquivo de configuração - BancoUtilizado");
        }

    }
}
