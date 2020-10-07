using System;
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
    public class tb_grpempDaoSqlServer : IDao<tb_grpemp>
    {
        private const string _banco = "SQLSERVER";
        private SqlConnection _connection;
        private IDbTransaction _trans;
        private bool _conexaoExterna = false;

        public tb_grpempDaoSqlServer(ConfiguracaoBaseDataBase dataBaseConfig, IDaoTransacao transacao = null)
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

        public void Atualizar(tb_grpemp entidade)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(tb_grpemp entidade, string where)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(tb_grpemp entidade, string[] campos, string where)
        {
            throw new NotImplementedException();
        }

        public tb_grpemp Inserir(tb_grpemp entidade)
        {
            string query = "insert into tb_grpemp (cod_grpemp, abv_grpemp, des_grpemp, cod_empresa, cod_depend) values (@cod_grpemp, @abv_grpemp, @des_grpemp, @cod_empresa, @cod_depend)";

            if(_trans != null)
                 _connection.Execute(query, entidade,_trans);
            else
                _connection.Execute(query, entidade);

            return entidade;
        }

        public void InserirLote(IEnumerable<tb_grpemp> entidade)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_grpemp> Obter()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<tb_grpemp> Obter(string where)
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

        public void remover(tb_grpemp entidade)
        {
            throw new NotImplementedException();
        }

        public void remover(tb_grpemp entidade, string where)
        {
            throw new NotImplementedException();
        }

        public void remover()
        {
            throw new NotImplementedException();
        }
    }
}
