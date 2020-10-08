using Sinqia.CoreBank.DAO.Core.Configuration;
using Sinqia.CoreBank.DAO.Core.Constantes;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Corporativo.Services.SqlServer;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinqia.CoreBank.DAO.Core.Services;

namespace Sinqia.CoreBank.DAO.Corporativo.Services
{
    public class CorporativoDaoFactory : CoreDaoFactory
    {
        public CorporativoDaoFactory(ConfiguracaoBaseDataBase dataBaseConfig) : base(dataBaseConfig)
        {
            
        }

        public IDao<T> GetDaoCorporativo<T>() where T : new()
        {
            return GetDaoCorporativo<T>(null);
        }

        public IDao<T> GetDaoCorporativo<T>(IDaoTransacao transacao) where T : new()
        {
            if (string.IsNullOrWhiteSpace(_dataBaseConfig.BancoUtilizado)) throw new Exception("Chave necessária no arquivo de configuração - BancoUtilizado");
            string bancoReferencia = _dataBaseConfig.BancoUtilizado;

            if (bancoReferencia.ToUpper().Equals(ConstantesDao.BancoUtilizado.SQLSERVER))
            {
                if(typeof(T) == typeof(tb_dependencia))
                    return (IDao<T>) new tb_dependenciaDaoSqlServer(_dataBaseConfig, transacao);

                if (typeof(T) == typeof(tb_depope))
                    return (IDao<T>)new tb_depopeDaoSqlServer(_dataBaseConfig, transacao);

                if (typeof(T) == typeof(tb_gerente))
                    return (IDao<T>)new tb_gerenteDaoSqlServer(_dataBaseConfig, transacao);

                if(typeof(T) == typeof(tb_grpemp))
                    return (IDao<T>)new tb_grpempDaoSqlServer(_dataBaseConfig, transacao);

                if (typeof(T) == typeof(tb_operador))
                    return (IDao<T>)new tb_operadorDaoSqlServer(_dataBaseConfig, transacao);

                if (typeof(T) == typeof(tb_prodbco))
                    return (IDao<T>)new tb_prodbcoDaoSqlServer(_dataBaseConfig, transacao);
            }
            else if (bancoReferencia.ToUpper().Equals(ConstantesDao.BancoUtilizado.ORACLE))
            {
                throw new NotImplementedException();
            }
            else
                throw new Exception("Chave não reconhecida no arquivo de configuração - BancoUtilizado");

            return null;
        }

        public IDaoRead<T> GetDaoCorporativoLeitura<T>() where T : new()
        {
            return GetDaoCorporativoLeitura<T>(null);
        }

        public IDaoRead<T> GetDaoCorporativoLeitura<T>(IDaoTransacao transacao) where T : new()
        {
            return GetDaoCorporativo<T>(transacao);
        }

    }
}
