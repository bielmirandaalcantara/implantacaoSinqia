using Sinqia.CoreBank.Dao.Core.Configuration;
using Sinqia.CoreBank.Dao.Core.Constantes;
using Sinqia.CoreBank.Dao.Core.Interfaces;
using Sinqia.CoreBank.Dao.Corporativo.Services.SqlServer;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IDao<T> BuscarDaoCorporativo<T>() where T : new()
        {
            if (string.IsNullOrWhiteSpace(_dataBaseConfig.BancoUtilizado)) throw new Exception("Chave necessária no arquivo de configuração - BancoUtilizado");
            string bancoReferencia = _dataBaseConfig.BancoUtilizado;

            if (bancoReferencia.ToUpper().Equals(ConstantesDao.BancoUtilizado.SQLSERVER))
            {
                if(typeof(T) == typeof(tb_dependencia))
                        return (IDao<T>) new tb_dependenciaDaoSqlServer(_dataBaseConfig);

            }
            else if (bancoReferencia.ToUpper().Equals(ConstantesDao.BancoUtilizado.ORACLE))
            {

            }
            else
                throw new Exception("Chave não reconhecida no arquivo de configuração - BancoUtilizado");

            return null;
        }

    }
}
