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
        private string _nomeConexao;
        
        public ConexaoService(LogService log, ConfiguracaoConexao configConexao)
        {
            _log = log;
            _configConexao = configConexao;
            _factory = new FactoryConector(_configConexao, _log);
        }

        public ConexaoService()
        {

        }

        public Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.JobDetail.JobDataMap;
            _log = (LogService)dataMap["log"];
            _nomeConexao = dataMap["nomeConexao"].ToString(); 
            _configConexao = (ConfiguracaoConexao)dataMap["conexao"];

            _log.TraceMethodStart();

            try
            {
                _log.Information($"=> Iniciando Ciclo da conexão: {_nomeConexao} - Service Versão: {ControleVersaoConstantes.VersaoService}");

                _factory = new FactoryConector(_configConexao, _log);
                if (_factory == null) throw new ApplicationException($"Nome do Banco da conexão {_nomeConexao} não encontrado na lista de bancos configuráveis");

                SincronizarTabelas();
            }
            catch (Exception ex)
            {
                _log.Error($"Erro no ciclo da conexão: {_nomeConexao}", ex); ;
            }

            _log.Information($"=> Finalizando ciclo da conexão: {_nomeConexao}");

            _log.TraceMethodEnd();

            return null;
        }

        public void SincronizarTabelas()
        {
            _log.TraceMethodStart();
            _log.Information($"Iniciando Sincronização de tabelas para a conexão: {_configConexao.NomeConexao}");

            IConector conectorDe = _factory.GetConector(_configConexao.NomeBancoDe);
            IConector conectorPara = _factory.GetConector(_configConexao.NomeBancoPara);

            foreach(var tabela in _configConexao.ListaTabelas)
            {
                try
                {
                    DataTable data = conectorDe.BuscarDadosTabela(tabela);

                    if (data.Rows.Count > 0)
                        _log.Information("Encontrado dados para Sincronização");

                    foreach (DataRow row in data.Rows)
                    {
                        string guid = row[ColunasConfiguracao.CHAVEINTEGRACAO].Equals(DBNull.Value) ? Guid.NewGuid().ToString() :  row[ColunasConfiguracao.CHAVEINTEGRACAO].ToString();
                        int qtdeTentativas = row[ColunasConfiguracao.QTDETENTATIVA].Equals(DBNull.Value) ? 0 : (int)row[ColunasConfiguracao.QTDETENTATIVA];
                        string statusIntegracao = string.Empty;

                        _log.Trace($"Iniciando sincronização com o GUID: {guid} ");
                        _log.SetIdentificador(guid);

                        qtdeTentativas++;

                        conectorDe.IniciarSincronizacao(guid, tabela, data, row);
                        statusIntegracao = StatusIntegracao.Atualizando;

                        try
                        {
                            conectorPara.EnviarComandosTabela(guid, tabela, data, row);
                            statusIntegracao = StatusIntegracao.Finalizado;
                        }
                        catch (Exception ex)
                        {
                            _log.Error("Erro no processo de envio ao banco de dados de destino: ", ex);
                        }

                        if (statusIntegracao.Equals(StatusIntegracao.Atualizando))
                        {
                            if (qtdeTentativas >= _configConexao.QuantidadeMaximaTentativas)
                                statusIntegracao = StatusIntegracao.Erro;
                        }

                        conectorDe.AtualizarSincronizacao(guid, tabela, data, row, qtdeTentativas, statusIntegracao);

                        _log.SetIdentificador(string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    _log.Error("Erro no processo de busca ao banco de dados de envio: ", ex);
                }
                
            }
            _log.Information($"Finalizando Sincronização de tabelas para a conexão: {_configConexao.NomeConexao}");
            _log.TraceMethodEnd();
        }
    }
}
