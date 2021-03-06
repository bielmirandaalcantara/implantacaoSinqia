﻿using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Constantes;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Corporativo.Services.SqlServer;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.DAO.Corporativo.Services
{
    public class CorporativoDaoFactory : CoreDaoFactory
    {
        private LogService _log;

        public CorporativoDaoFactory(ConfiguracaoBaseDataBase dataBaseConfig, LogService log) : base(dataBaseConfig)
        {
            _log = log;
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
                    return (IDao<T>) new tb_dependenciaDaoSqlServer(_dataBaseConfig,_log, transacao);

                if (typeof(T) == typeof(tb_depope))
                    return (IDao<T>)new tb_depopeDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_gerente))
                    return (IDao<T>)new tb_gerenteDaoSqlServer(_dataBaseConfig, _log, transacao);

                if(typeof(T) == typeof(tb_grpemp))
                    return (IDao<T>)new tb_grpempDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_operador))
                    return (IDao<T>)new tb_operadorDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_prodbco))
                    return (IDao<T>)new tb_prodbcoDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_empresa))
                    return (IDao<T>)new tb_empresaDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_municipio))
                    return (IDao<T>)new tb_municipioDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_tpdepend))
                    return (IDao<T>)new tb_tpdependDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_camara))
                    return (IDao<T>)new tb_camaraDaoSqlServer(_dataBaseConfig, _log, transacao);

                if (typeof(T) == typeof(tb_grproduto))
                    return (IDao<T>)new tb_grprodutoDaoSqlServer(_dataBaseConfig, _log, transacao);
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
