using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Core.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Services.SqlServer
{
    public class TransacaoDaoSqlServer : IDaoTransacao
    {
        private const string _banco = "SQLSERVER";
        private SqlConnection _connection;
        private SqlTransaction _trans;

        public TransacaoDaoSqlServer(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            string conexao = ConfiguracaoService.BuscarConexao(dataBaseConfig, _banco);
            _connection = new SqlConnection(conexao);
        }

        public bool TemConexao()
        {
            return (_connection != null);
        }

        public IDbConnection GetConnection()
        {
            return _connection;
        }

        public IDbTransaction GetTransaction()
        {
            return _trans;
        }
        public void BeginTransaction()
        {
            _connection.Open();
            _trans = _connection.BeginTransaction();
        }

        public void Rollback()
        {
            _trans.Rollback();

            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }

        public void Commit()
        {
            _trans.Commit();

            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }

        public void Dispose()
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }
    }
}
