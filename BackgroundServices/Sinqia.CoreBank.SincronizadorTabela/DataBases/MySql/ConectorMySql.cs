using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases.MySql
{
    public class ConectorMySql : IConector
    {
        public const string TipoBanco = "MYSQL";
        ConfiguracaoConexao _conexaoConf;

        public ConectorMySql(ConfiguracaoConexao conexaoConf)
        {
            _conexaoConf = conexaoConf;
        }

        public DataTable BuscarDadosTabela(string tabela)
        {
            string tabelaControle = string.Concat(tabela, _conexaoConf.PrefixoTabelaControle);
            string strConn = _conexaoConf.ConexaoDe;

            string query = $" select * from {tabelaControle} ";

            DataTable data = RetornarDataTableQuery(query, strConn);

            return data;
        }

        public void IniciarSincronizacao(string chave, DataTable data, DataRow row)
        {
            string strConn = _conexaoConf.ConexaoPara;
            List<OleDbParameter> parameters = new List<OleDbParameter>();

            string statusIntegracaoAnterior = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.STATUSINTEGRACAO].ToString();

            string nomeTabela = data.TableName;
            string query = $" update {nomeTabela} set {ColunasConfiguracao.CHAVEINTEGRACAO} = @chaveIntegracaoAtual , {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracaoAtual ";
            query += $" where {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracaoAnterior ";

            parameters.Add(new OleDbParameter
            {
                ParameterName = "statusIntegracaoAnterior",
                Value = statusIntegracaoAnterior
            });

            parameters.Add(new OleDbParameter
            {
                ParameterName = "chaveIntegracaoAtual",
                Value = chave
            });

            parameters.Add(new OleDbParameter
            {
                ParameterName = "statusIntegracaoAtual",
                Value = StatusIntegracao.Atualizando
            });

            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.CHAVEINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.QTDETENTATIVA)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.STATUSINTEGRACAO)) continue;

                parameters.Add(new OleDbParameter
                {
                    ParameterName = column.ColumnName,
                    Value = row[column]
                });

                query += $" and {column.ColumnName} = @{column.ColumnName} ";
            }

            ExecutarQuerySemRetorno(query, strConn, parameters);

        }

        public void AtualizarSincronizacao(string chave, DataTable data, DataRow row, int qtdTentativas, string statusIntegracao)
        {
            string strConn = _conexaoConf.ConexaoPara;
            List<OleDbParameter> parameters = new List<OleDbParameter>();

            string statusIntegracaoAnterior = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.STATUSINTEGRACAO].ToString();

            string nomeTabela = data.TableName;
            string query = $" update {nomeTabela} set {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracao , {ColunasConfiguracao.QTDETENTATIVA} = @qtdTentativas ";
            query += $" where {ColunasConfiguracao.CHAVEINTEGRACAO} = @chaveIntegracao ";

            parameters.Add(new OleDbParameter
            {
                ParameterName = "chaveIntegracao",
                Value = chave
            });
            parameters.Add(new OleDbParameter
            {
                ParameterName = "statusIntegracao",
                Value = statusIntegracao
            });
            parameters.Add(new OleDbParameter
            {
                ParameterName = "qtdTentativas",
                Value = qtdTentativas
            });

            ExecutarQuerySemRetorno(query, strConn, parameters);

        }

        public void EnviarDadosTabela(string chave, DataTable data, DataRow row)
        {
            string strConn = _conexaoConf.ConexaoPara;            
            List<OleDbParameter> parameters = MySqlUtil.GerarParametrosFromDataTable(data, row);


            string queryBusca = MySqlUtil.GerarSelectFromDataTable(data);
            DataTable dataBusca = RetornarDataTableQuery(queryBusca, strConn, parameters);
            if (dataBusca.HasErrors)
                throw new ApplicationException($"Dados já existentes no banco de dados de destino, chave: {chave}");

            string query = MySqlUtil.GerarInsertFromDataTable(data);

            ExecutarQuerySemRetorno(query, strConn, parameters);
        }

        private void ExecutarQuerySemRetorno(string query, string strConn, List<OleDbParameter> parameters = null)
        {
            OleDbConnection connection = new OleDbConnection(strConn);
            OleDbCommand cmd = new OleDbCommand(query, connection);

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
        }

        private DataTable RetornarDataTableQuery(string query, string strConn, List<OleDbParameter> parameters = null)
        {
            DataTable data = new DataTable();
            OleDbConnection connection = new OleDbConnection(strConn);
            OleDbDataAdapter da = new OleDbDataAdapter(query, connection);

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

            return data;

        }
    }
}
