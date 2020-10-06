using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Sinqia.CoreBank.Dao.Core.Interfaces;
using Sinqia.CoreBank.Dao.Core.Configuration;
using Sinqia.CoreBank.Dao.Core.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System.Data.SqlClient;
using System.Linq;

namespace Sinqia.CoreBank.Dao.Corporativo.Services.SqlServer
{
    internal class tb_dependenciaDaoSqlServer : IDao<tb_dependencia>
    {
        private const string _banco = "SQLSERVER";
        private SqlConnection _connection;        

        public tb_dependenciaDaoSqlServer(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            string conexao = ConfiguracaoService.BuscarConexao(dataBaseConfig, _banco);
            _connection = new SqlConnection(conexao);
        }

        public void Atualizar(tb_dependencia entidade, IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(tb_dependencia entidade, string where, IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(tb_dependencia entidade, string[] campos, string where, IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public tb_dependencia Inserir(tb_dependencia entidade, IDbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public void InserirLote(IEnumerable<tb_dependencia> entidade, IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_dependencia> Obter(IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_dependencia> Obter(string where, IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public DataTable ObterDataTable(IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public DataTable ObterDataTable(string where, IDbTransaction trans = null)
        {
            throw new NotImplementedException();
        }

        public void remover(tb_dependencia entidade, IDbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public void remover(tb_dependencia entidade, string where, IDbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public void remover(IDbTransaction trans)
        {
            throw new NotImplementedException();
        }
    }
}
