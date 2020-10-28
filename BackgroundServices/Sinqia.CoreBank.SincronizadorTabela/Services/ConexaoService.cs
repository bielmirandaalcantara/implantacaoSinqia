using Quartz;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;
using Sinqia.CoreBank.SincronizadorTabela.DataBases;
using Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces;
using Sinqia.CoreBank.SincronizadorTabela.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.SincronizadorTabela.Services
{
    [DisallowConcurrentExecution]
    public class ConexaoService : IJob
    {
        private LogService _log;
        private ConfiguracaoConexao _configConexao;
        private FactoryConector _factory;
        
        public ConexaoService(LogService log, ConfiguracaoConexao configConexao)
        {
            _log = log;
            _configConexao = configConexao;
            _factory = new FactoryConector(_configConexao);
        }

        public ConexaoService()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            _log = (LogService)dataMap["log"];
            _configConexao = (ConfiguracaoConexao)dataMap["conexao"];
            _factory = new FactoryConector(_configConexao);            

            SincronizarTabelas();

            return null;
        }

        public void SincronizarTabelas()
        {
            IConector conectorDe = _factory.GetConector(_configConexao.NomeBancoDe);
            IConector conectorPara = _factory.GetConector(_configConexao.NomeBancoPara);

            foreach(var tabela in _configConexao.ListaTabelas)
            {
                DataTable data = conectorDe.BuscarDadosTabela(tabela);

                foreach (DataRow row in data.Rows)
                {
                    string guid = Guid.NewGuid().ToString();
                    int qtdeTentativas = row[ColunasConfiguracao.QTDETENTATIVA].Equals(DBNull.Value) ? 0 : (int)row[ColunasConfiguracao.QTDETENTATIVA];
                    qtdeTentativas++;
                    conectorDe.IniciarSincronizacao(guid, data, row);
                    conectorPara.EnviarDadosTabela(guid, data, row);
                    conectorPara.AtualizarSincronizacao(guid, data, row, qtdeTentativas, StatusIntegracao.Finalizado);
                }
            }
        }


    }
}
