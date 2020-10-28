using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Data.OleDb;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases.MySql
{
    public class MySqlUtil
    {
        public static string GerarInsertFromDataTable(DataTable data)
        {
            string nomeTabela = data.TableName;
            string colunas = string.Join(",", data.Columns.Cast<DataColumn>().Select(c => c.ColumnName));
            string valores = string.Join(",", data.Columns.Cast<DataColumn>().Select(c => string.Format("@{0}", c.ColumnName)));
            return $" insert into {nomeTabela} ({colunas}) values ({valores})";            
        }

        public static string GerarSelectFromDataTable(DataTable data)
        {
            string nomeTabela = data.TableName;

            string query = $" select * from {nomeTabela} where 1=1 and ";

            foreach (DataColumn column in data.Columns)
                query += $" and {column.ColumnName} = @{column.ColumnName} ";

            return query;
        }

        public static List<OleDbParameter> GerarParametrosFromDataTable(DataTable data, DataRow row)
        {
            List<OleDbParameter> parameters = new List<OleDbParameter>();

            foreach (DataColumn column in data.Columns)
            {
                parameters.Add(new OleDbParameter
                {
                    ParameterName = column.ColumnName
                    , Value = row[column]
                });
            }
            return parameters;
        }
    }
}
