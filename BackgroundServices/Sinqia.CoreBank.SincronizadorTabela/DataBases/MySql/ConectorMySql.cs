﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;
using Sinqia.CoreBank.SincronizadorTabela.Seguranca;
using System.Linq;
using Sinqia.CoreBank.SincronizadorTabela.Logging;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases.MySql
{
    public class ConectorMySql : IConector
    {
        private string _stringConexaoDe;
        private string _stringConexaoPara;
        public const string TipoBanco = "MYSQL";
        private ConfiguracaoConexao _conexaoConf;
        private LogService _log;

        public ConectorMySql(ConfiguracaoConexao conexaoConf, LogService log)
        {
            _conexaoConf = conexaoConf;
            _log = log;
            DescriptografarStringConexao();
        }

        private void DescriptografarStringConexao()
        {
            CriptografiaServices cripto = new CriptografiaServices();

            _stringConexaoDe = cripto.Decrypt(_conexaoConf.ConexaoDe);
            _stringConexaoPara = cripto.Decrypt(_conexaoConf.ConexaoPara);
        }

        public DataTable BuscarDadosTabela(string tabela)
        {
            _log.TraceMethodStart();

            string tabelaControle = string.Concat(tabela, _conexaoConf.SufixoTabelaControle);
            string strConn = _stringConexaoDe;

            string query = $" select * from {tabelaControle} ";
            query += $" where {ColunasConfiguracao.STATUSINTEGRACAO} in ('{StatusIntegracao.Novo}', '{StatusIntegracao.Atualizando}')";
            query += $" and {ColunasConfiguracao.DATAINTEGRACAO} >= @dataLimite ";

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            parameters.Add(new MySqlParameter
            {
                ParameterName = "dataLimite",
                Value = DateTime.Now.AddDays(_conexaoConf.LimiteDiasSincronizacao * -1)
            });

            DataTable data = RetornarDataTableQuery(query, strConn, parameters);

            _log.TraceMethodEnd();

            return data;
        }

        public void IniciarSincronizacao(string chave, string tabela, DataTable data, DataRow row)
        {

            _log.TraceMethodStart();

            string tabelaControle = string.Concat(tabela, _conexaoConf.SufixoTabelaControle);
            string strConn = _stringConexaoDe;
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string statusIntegracaoAnterior = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.STATUSINTEGRACAO].ToString();

            string query = $" update {tabelaControle} set {ColunasConfiguracao.CHAVEINTEGRACAO} = @chaveIntegracaoAtual , {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracaoAtual ";
            query += $" where {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracaoAnterior ";

            parameters.Add(new MySqlParameter
            {
                ParameterName = "statusIntegracaoAnterior",
                Value = statusIntegracaoAnterior
            });

            parameters.Add(new MySqlParameter
            {
                ParameterName = "chaveIntegracaoAtual",
                Value = chave
            });

            parameters.Add(new MySqlParameter
            {
                ParameterName = "statusIntegracaoAtual",
                Value = StatusIntegracao.Atualizando
            });

            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.CHAVEINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.QTDETENTATIVA)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.STATUSINTEGRACAO)) continue;

                parameters.Add(new MySqlParameter
                {
                    ParameterName = column.ColumnName,
                    Value = row[column]
                });

                query += $" and {column.ColumnName} = @{column.ColumnName} ";
            }

            ExecutarQuerySemRetorno(query, strConn, parameters);

            _log.TraceMethodEnd();
        }

        public void AtualizarSincronizacao(string chave, string tabela, DataTable data, DataRow row, int qtdTentativas, string statusIntegracao)
        {
            _log.TraceMethodStart();

            string tabelaControle = string.Concat(tabela, _conexaoConf.SufixoTabelaControle);
            string strConn = _stringConexaoDe;
            List<MySqlParameter> parameters = new List<MySqlParameter>();

            string statusIntegracaoAnterior = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.STATUSINTEGRACAO].ToString();

            string query = $" update {tabelaControle} set {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracao , {ColunasConfiguracao.QTDETENTATIVA} = @qtdTentativas ";
            query += $" where {ColunasConfiguracao.CHAVEINTEGRACAO} = @chaveIntegracao ";

            parameters.Add(new MySqlParameter
            {
                ParameterName = "chaveIntegracao",
                Value = chave
            });
            parameters.Add(new MySqlParameter
            {
                ParameterName = "statusIntegracao",
                Value = statusIntegracao
            });
            parameters.Add(new MySqlParameter
            {
                ParameterName = "qtdTentativas",
                Value = qtdTentativas
            });

            ExecutarQuerySemRetorno(query, strConn, parameters);

            _log.TraceMethodEnd();
        }

        public void EnviarComandosTabela(string chave, string tabela, DataTable data, DataRow row)
        {
            _log.TraceMethodStart();

            string metodo = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.METODO].ToString();

            switch (metodo)
            {
                case Metodo.Inclusao:
                    EnviarInsertTabela(chave, tabela, data, row);
                    break;
                case Metodo.Exclusao:
                    EnviarDeleteTabela(chave, tabela, data, row);
                    break;
            }

            _log.TraceMethodEnd();
        }

        public void EnviarInsertTabela(string chave, string tabela, DataTable data, DataRow row)
        {
            _log.TraceMethodStart();

            string strConn = _stringConexaoPara;

            VerificarSeTabelaExiste(chave, tabela, data, row);

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            List<string> listaColunas = new List<string>();
            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.CHAVEINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.QTDETENTATIVA)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.METODO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.STATUSINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.DATAINTEGRACAO)) continue;

                parameters.Add(new MySqlParameter
                {
                    ParameterName = column.ColumnName,
                    Value = row[column]
                });
                listaColunas.Add(column.ColumnName);
            };

            string query = $" insert into {tabela} ({string.Join(",", listaColunas.Select(c => c))}) values ({string.Join(",", listaColunas.Select(c => string.Format("@{0}", c)))})";

            ExecutarQuerySemRetorno(query, strConn, parameters);

            _log.TraceMethodEnd();
        }

        public void EnviarDeleteTabela(string chave, string tabela, DataTable data, DataRow row)
        {
            _log.TraceMethodStart();

            string strConn = _stringConexaoPara;

            List<MySqlParameter> parameters = new List<MySqlParameter>();
            string query = $" delete {tabela} where 1=1 ";
            bool temColunaSelecionada = false;
            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.CHAVEINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.QTDETENTATIVA)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.METODO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.STATUSINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.DATAINTEGRACAO)) continue;

                parameters.Add(new MySqlParameter
                {
                    ParameterName = column.ColumnName,
                    Value = row[column]
                });
                query += $" and {column.ColumnName} = @{column.ColumnName} ";
                temColunaSelecionada = true;
            };

            if (!temColunaSelecionada) throw new ApplicationException("Não foi encontrada colunas para deleção da tabela");            

            ExecutarQuerySemRetorno(query, strConn, parameters);

            _log.TraceMethodEnd();
        }

        private void VerificarSeTabelaExiste(string chave, string tabela, DataTable data, DataRow row)
        {
            _log.TraceMethodStart();

            string strConn = _stringConexaoPara;
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            string queryBusca = $" select * from {tabela} where 1=1 ";
            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.CHAVEINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.QTDETENTATIVA)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.METODO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.STATUSINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.DATAINTEGRACAO)) continue;

                parameters.Add(new MySqlParameter
                {
                    ParameterName = column.ColumnName,
                    Value = row[column]
                });
                queryBusca += $" and {column.ColumnName} = @{column.ColumnName} ";
            };


            DataTable dataBusca = RetornarDataTableQuery(queryBusca, strConn, parameters);
            if (dataBusca.Rows.Count == 0)
                throw new ApplicationException($"Dados já existentes no banco de dados de destino, chave: {chave}");

            _log.TraceMethodEnd();
        }

        private void ExecutarQuerySemRetorno(string query, string strConn, List<MySqlParameter> parameters = null)
        {
            _log.TraceMethodStart();

            MySqlConnection connection = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand(query, connection);

            if (parameters != null)
                cmd.Parameters.AddRange(parameters.ToArray());

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            _log.TraceMethodEnd();
        }

        private DataTable RetornarDataTableQuery(string query, string strConn, List<MySqlParameter> parameters = null)
        {
            _log.TraceMethodStart();

            _log.Trace($"Query gerada: {query}");

            DataTable data = new DataTable();
            MySqlConnection connection = new MySqlConnection(strConn);
            MySqlDataAdapter da = new MySqlDataAdapter(query, connection);

            if (parameters != null)
                da.SelectCommand.Parameters.AddRange(parameters.ToArray());

            try
            {   
                connection.Open();
                da.Fill(data);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

            _log.TraceMethodEnd();

            return data;

        }
    }
}
