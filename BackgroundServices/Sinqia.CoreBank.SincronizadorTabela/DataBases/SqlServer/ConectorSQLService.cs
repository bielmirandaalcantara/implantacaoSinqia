using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases.SqlServer
{
    public class ConectorSQLService : IConector
    {
        public const string TipoBanco = "SQLSERVER";
        ConfiguracaoConexao _conexaoConf;

        public ConectorSQLService(ConfiguracaoConexao conexaoConf)
        {
            _conexaoConf = conexaoConf;
        }

        public DataTable BuscarDadosTabela(string tabela)
        {
            string tabelaControle = string.Concat(tabela, _conexaoConf.PrefixoTabelaControle);
            string strConn = _conexaoConf.ConexaoDe;

            string query = $" select * from {tabelaControle}";
            query += $" where {ColunasConfiguracao.STATUSINTEGRACAO} in ('{StatusIntegracao.Novo}', '{StatusIntegracao.Atualizando}')";
            query += $" and {ColunasConfiguracao.DATAINTEGRACAO} >= @dataLimite ";

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter
            {
                ParameterName = "dataLimite",
                Value = DateTime.Now.AddDays(_conexaoConf.LimiteDiasSincronizacao * -1)
            });

            DataTable data = RetornarDataTableQuery(query, strConn,parameters);

            return data;
        }

        public void IniciarSincronizacao(string chave, DataTable data, DataRow row)
        {
            string strConn = _conexaoConf.ConexaoPara;
            List<SqlParameter> parameters = SQLServerUtil.GerarParametrosFromDataTable(data, row);

            string statusIntegracaoAnterior = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.STATUSINTEGRACAO].ToString();

            string nomeTabela = data.TableName;
            string query = $" update dbo.{nomeTabela} set {ColunasConfiguracao.CHAVEINTEGRACAO} = @chaveIntegracaoAtual , {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracaoAtual ";
            query += $" where {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracaoAnterior ";

            parameters.Add(new SqlParameter
            {
                ParameterName = "statusIntegracaoAnterior",
                Value = statusIntegracaoAnterior
            });

            parameters.Add(new SqlParameter
            {
                ParameterName = "chaveIntegracaoAtual",
                Value = chave
            });

            parameters.Add(new SqlParameter
            {
                ParameterName = "statusIntegracaoAtual",
                Value = StatusIntegracao.Atualizando
            });

            foreach (DataColumn column in data.Columns)
            {
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.CHAVEINTEGRACAO)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.QTDETENTATIVA)) continue;
                if (column.ColumnName.ToUpper().Equals(ColunasConfiguracao.STATUSINTEGRACAO)) continue;

                parameters.Add(new SqlParameter
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
            List<SqlParameter> parameters = SQLServerUtil.GerarParametrosFromDataTable(data, row);

            string statusIntegracaoAnterior = row[ColunasConfiguracao.STATUSINTEGRACAO].Equals(DBNull.Value) ? string.Empty : row[ColunasConfiguracao.STATUSINTEGRACAO].ToString();

            string nomeTabela = data.TableName;
            string query = $" update dbo.{nomeTabela} set {ColunasConfiguracao.STATUSINTEGRACAO} = @statusIntegracao , {ColunasConfiguracao.QTDETENTATIVA} = @qtdTentativas ";
            query += $" where {ColunasConfiguracao.CHAVEINTEGRACAO} = @chaveIntegracao ";

            parameters.Add(new SqlParameter
            {
                ParameterName = "chaveIntegracao",
                Value = chave
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "statusIntegracao", 
                Value = statusIntegracao
            });
            parameters.Add(new SqlParameter
            {
                ParameterName = "qtdTentativas",
                Value = qtdTentativas
            });

            ExecutarQuerySemRetorno(query, strConn, parameters);

        }

        public void EnviarDadosTabela(string chave, DataTable data, DataRow row)
        {
            string strConn = _conexaoConf.ConexaoPara;            
            List<SqlParameter> parameters = SQLServerUtil.GerarParametrosFromDataTable(data, row);

            string queryBusca = SQLServerUtil.GerarSelectFromDataTable(data);
            DataTable dataBusca = RetornarDataTableQuery(queryBusca, strConn, parameters);
            if (dataBusca.HasErrors)
                throw new ApplicationException($"Dados já existentes no banco de dados de destino, chave: {chave}");

            string query = SQLServerUtil.GerarInsertFromDataTable(data);

            ExecutarQuerySemRetorno(query, strConn, parameters);
        }

        private void ExecutarQuerySemRetorno(string query, string strConn, List<SqlParameter> parameters = null)
        {
            SqlConnection connection = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand(query, connection);

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

        private DataTable RetornarDataTableQuery(string query, string strConn, List<SqlParameter> parameters = null)
        {
            DataTable data = new DataTable();
            SqlConnection connection = new SqlConnection(strConn);
            SqlDataAdapter da = new SqlDataAdapter(query, connection);

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
