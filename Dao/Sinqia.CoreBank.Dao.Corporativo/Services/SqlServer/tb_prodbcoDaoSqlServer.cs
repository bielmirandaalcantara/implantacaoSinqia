﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Core.Configuration;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Sinqia.CoreBank.DAO.Core.Services.SqlServer;

namespace Sinqia.CoreBank.DAO.Corporativo.Services.SqlServer
{
    internal class tb_prodbcoDaoSqlServer : IDao<tb_prodbco>
    {
        private const string _banco = "SQLSERVER";
        private SqlConnection _connection;
        private IDbTransaction _trans;
        private bool _conexaoExterna = false;

        public tb_prodbcoDaoSqlServer(ConfiguracaoBaseDataBase dataBaseConfig, IDaoTransacao transacao = null)
        {
            PreencherConexao(dataBaseConfig, transacao);
        }

        private void PreencherConexao(ConfiguracaoBaseDataBase dataBaseConfig, IDaoTransacao transacao = null)
        {
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
        }

        public void Atualizar(tb_prodbco entidade, string where)
        {
            Atualizar(entidade, where, null);
        }

        public void Atualizar(tb_prodbco entidade, string where, List<string> campos)
        {
            if (!_conexaoExterna) _connection.Open();

            try
            {
                string query = Util.GerarQueryUpdate(entidade, where, campos);

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
        }

        public tb_prodbco Inserir(tb_prodbco entidade)
        {
            if (!_conexaoExterna) _connection.Open();

            try
            {
                string query = Util.GerarQueryInsert(entidade);

                if (_trans != null)
                    _connection.Execute(query, entidade, _trans);
                else
                    _connection.Execute(query, entidade);

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
        
        public IEnumerable<tb_prodbco> Obter()
        {
            return Obter(string.Empty);
        }

        public IEnumerable<tb_prodbco> Obter(string where)
        {
            if (!_conexaoExterna) _connection.Open();

            try
            {
                IEnumerable<tb_prodbco> lista;
                string query = Util.GerarQuerySelect(new tb_prodbco(), where);

                if (_trans != null)
                    lista = _connection.Query<tb_prodbco>(query, null, _trans);
                else
                    lista = _connection.Query<tb_prodbco>(query);

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

        public void Remover(tb_prodbco entidade, string where)
        {
            if (!_conexaoExterna) _connection.Open();

            try
            {
                string query = Util.GerarQueryDelete(entidade, where);

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
        }
    }
}
