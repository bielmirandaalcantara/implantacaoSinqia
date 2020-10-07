using Sinqia.CoreBank.DAO.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Services
{
    public class ConfiguracaoService
    {
        public static string BuscarConexao(ConfiguracaoBaseDataBase dataBaseConfig,string bancoReferencia)
        {
            if (dataBaseConfig == null) throw new Exception("Dados de banco de dados não foram inseridos no arquivo de configuração - ConfiguracaoBaseDataBase");
            if (dataBaseConfig.ConnectionStrings == null || !dataBaseConfig.ConnectionStrings.Any()) throw new Exception("Dados de banco de dados não foram inseridos no arquivo de configuração - ConnectionStrings");
            var ConnectionString = dataBaseConfig.ConnectionStrings.FirstOrDefault(c => c.Banco.Equals(bancoReferencia));
            if (ConnectionString == null) throw new Exception("String de conexão para SQL Server não configurada no arquivo de configuração - ConnectionStrings");
            if (string.IsNullOrWhiteSpace(ConnectionString.Conexao)) throw new Exception("String de conexão inválida ou não informada no arquivo de configuração - ConnectionStrings");
            return ConnectionString.Conexao;
        }
    }
}
