using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Sinqia.CoreBank.DAO.Core.Services.SqlServer;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.DAO.Corporativo.Services.SqlServer
{
    internal class tb_depopeDaoSqlServer : IDao<tb_depope>
    {
        private const string _banco = "SQLSERVER";
        private SqlConnection _connection;
        private IDbTransaction _trans;
        private bool _conexaoExterna = false;
        private LogService _log;

        public tb_depopeDaoSqlServer(ConfiguracaoBaseDataBase dataBaseConfig, LogService log, IDaoTransacao transacao = null)
        {
            _log = log;
            PreencherConexao(dataBaseConfig, transacao);
        }

        private void PreencherConexao(ConfiguracaoBaseDataBase dataBaseConfig, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            if (transacao != null && transacao.TemConexao())
            {
                _conexaoExterna = true;
                _connection = (SqlConnection)transacao.GetConnection();
                _trans = transacao.GetTransaction();
                
            }
            else
            {
                string conexao = ConfiguracaoService.BuscarConexao(dataBaseConfig, _banco);
                _connection = new SqlConnection(conexao);
            }

            _log.TraceMethodEnd();
        }

        public void Atualizar(tb_depope entidade, string where)
        {
            Atualizar(entidade, where, null);
        }

        public void Atualizar(tb_depope entidade, string where, List<string> campos)
        {
            _log.TraceMethodStart();

            if (!_conexaoExterna) _connection.Open();

            try
            {
                string query = Util.GerarQueryUpdate(entidade, where, campos);

                _log.Trace($"Query Gerada: {query} ");

                if (_trans != null)
                    _connection.Execute(query, entidade, _trans);
                else
                    _connection.Execute(query, entidade);
            }
            finally
            {
                if (!_conexaoExterna)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }

            }

            _log.TraceMethodEnd();
        }

        public tb_depope Inserir(tb_depope entidade)
        {
            _log.TraceMethodStart();

            if (!_conexaoExterna) _connection.Open();

            try
            {
                string query = Util.GerarQueryInsert(entidade);

                _log.Trace($"Query Gerada: {query} ");

                if (_trans != null)
                    _connection.Execute(query, entidade, _trans);
                else
                    _connection.Execute(query, entidade);

                _log.TraceMethodEnd();

                return entidade;
            }
            finally
            {
                if (!_conexaoExterna)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }

            }
        }
        


        public IEnumerable<tb_depope> Obter()
        {
            return Obter(string.Empty);
        }

        public IEnumerable<tb_depope> Obter(string where)
        {
            _log.TraceMethodStart();

            if (!_conexaoExterna) _connection.Open();

            try
            {
                IEnumerable<tb_depope> lista;
                string query = Util.GerarQuerySelect(new tb_depope(), where);

                _log.Trace($"Query Gerada: {query} ");

                if (_trans != null)
                    lista = _connection.Query<tb_depope>(query, null, _trans);
                else
                    lista = _connection.Query<tb_depope>(query);

                _log.TraceMethodEnd();

                return lista;
            }
            finally
            {
                if (!_conexaoExterna)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }

            }
        }

        public tb_depope ObterPrimeiro(string where)
        {
            _log.TraceMethodStart();

            if (!_conexaoExterna) _connection.Open();

            try
            {
                tb_depope retorno = null;
                IEnumerable<tb_depope> lista;
                string query = Util.GerarQuerySelect(new tb_depope(), where);

                _log.Trace($"Query Gerada: {query} ");

                if (_trans != null)
                    lista = _connection.Query<tb_depope>(query, null, _trans);
                else
                    lista = _connection.Query<tb_depope>(query);

                if (lista.Any())
                    retorno = lista.First();

                _log.TraceMethodEnd();

                return retorno;
            }
            finally
            {
                if (!_conexaoExterna)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }

            }
        }

        public void Remover(tb_depope entidade, string where)
        {
            _log.TraceMethodStart();

            if (!_conexaoExterna) _connection.Open();

            try
            {
                string query = Util.GerarQueryDelete(entidade, where);

                _log.Trace($"Query Gerada: {query} ");

                if (_trans != null)
                    _connection.Execute(query, null, _trans);
                else
                    _connection.Execute(query);

            }
            finally
            {
                if (!_conexaoExterna)
                {
                    if (_connection.State != ConnectionState.Closed)
                        _connection.Close();
                }

            }

            _log.TraceMethodEnd();
        }
    }
}
