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

namespace Sinqia.CoreBank.DAO.Corporativo.Services.SqlServer
{
    internal class tb_dependenciaDaoSqlServer : IDao<tb_dependencia>
    {
        private const string _banco = "SQLSERVER";
        private SqlConnection _connection;
        private IDbTransaction _trans;
        private bool _conexaoExterna = false;

        public tb_dependenciaDaoSqlServer(ConfiguracaoBaseDataBase dataBaseConfig, IDaoTransacao transacao = null)
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

        public void Atualizar(tb_dependencia entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(tb_dependencia entidade, string where)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(tb_dependencia entidade, string[] campos, string where)
        {
            throw new NotImplementedException();
        }

        public tb_dependencia Inserir(tb_dependencia entidade)
        {
            throw new NotImplementedException();
        }

        public void InserirLote(IEnumerable<tb_dependencia> entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_dependencia> Obter()
        {
            if (!_conexaoExterna) _connection.Open();

            try
            {
                IEnumerable<tb_dependencia> dependencia;

                if(_trans != null)
                    dependencia = _connection.Query<tb_dependencia>("Select * from tb_dependencia", null, _trans);
                else
                    dependencia = _connection.Query<tb_dependencia>("Select * from tb_dependencia");

                return dependencia;
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

        public IEnumerable<tb_dependencia> Obter(string where)
        {
            throw new NotImplementedException();
        }

        public DataTable ObterDataTable()
        {
            throw new NotImplementedException();
        }

        public DataTable ObterDataTable(string where)
        {
            throw new NotImplementedException();
        }

        public void remover(tb_dependencia entidade)
        {
            throw new NotImplementedException();
        }

        public void remover(tb_dependencia entidade, string where)
        {
            throw new NotImplementedException();
        }

        public void remover()
        {
            throw new NotImplementedException();
        }
    }
}
