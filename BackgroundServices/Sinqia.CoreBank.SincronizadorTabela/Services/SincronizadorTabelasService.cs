using Quartz;
using Quartz.Impl;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;
using Sinqia.CoreBank.SincronizadorTabela.Logging;
using System;
using System.ServiceProcess;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;

namespace Sinqia.CoreBank.SincronizadorTabela.Services
{
    public class SincronizadorTabelasService : ServiceBase
    {
        private ConfiguracaoService _configurationService;
        private LogService _log;
        private int _intervalo;
        private ConfiguracaoSincronizadorTabela _config;
        private IScheduler _scheduler;
        private bool _isService;

        public SincronizadorTabelasService(bool isService)
        {
            ServiceName = ServiceConstantes.ServiceName;
            _configurationService = new ConfiguracaoService();
            _isService = isService;
        }

        public void StopJobs()
        {
            _scheduler.Shutdown().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public void OnStartConsole(string[] args)
        {
            try
            {
                _config = _configurationService.BuscarConfiguracaoServico();
                _configurationService.ValidarArquivoConfiguracao(_config);

                _log = new LogService(_config.Log);

                _log.Information("............................ Iniciando log Serviço ............................");
                _log.Information(" Modo: Console");
                _log.Information($" Versão Service: {ControleVersaoConstantes.VersaoService}");
                _log.Information("...............................................................................");

                _intervalo = _config.IntervaloSegundos;              

                foreach (var conexao in _config.Conexoes)
                {
                    ConexaoService conexaoService = new ConexaoService(_log,conexao);
                    conexaoService.SincronizarTabelas();
                }

            }
            catch (LogErrorException logEx)
            {
                throw;
            }
            catch (Exception ex)
            {
                _log.Error($"Erro na inicialização do serviço", ex);
            }
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            
            try
            {
                _config = _configurationService.BuscarConfiguracaoServico();
                _configurationService.ValidarArquivoConfiguracao(_config);

                _log = new LogService(_config.Log);

                 _log.Information("............................ Iniciando log Serviço ............................");
                _log.Information(" Modo: Service");
                _log.Information($" Versão Service: {ControleVersaoConstantes.VersaoService}");
                _log.Information("...............................................................................");

                _intervalo = _config.IntervaloSegundos;

                _log.Information("Configurando estrutura agendamento");

                _scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();

                foreach (var conexao in _config.Conexoes)
                {
                    JobDataMap map = new JobDataMap();
                    map.Add("conexao", conexao);
                    map.Add("nomeConexao", conexao.NomeConexao);
                    map.Add("log", _log);

                    IJobDetail jobConexao = JobBuilder.Create<ConexaoService>()
                                .WithIdentity(conexao.NomeConexao, "Sincro")
                                .SetJobData(map)
                                .Build();


                    ITrigger triggerConexao = TriggerBuilder.Create()
                            .WithIdentity("trigger" + conexao.NomeConexao, "Sincro")
                            .StartNow()
                            .WithSimpleSchedule(x => x
                                .WithIntervalInSeconds(_intervalo)
                                .RepeatForever())
                            .Build();

                    //Agendar
                    _scheduler.ScheduleJob(jobConexao, triggerConexao);
                }

                _log.Information("Iniciando agendamentos");
                _scheduler.Start();

            }
            catch (LogErrorException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _log?.Error($"Erro na inicialização do serviço", ex);
            }            
        }

        protected override void OnStop()
        {            
            try
            {
                _log?.Information($"Serviço Parado");
                StopJobs();
            }
            finally
            {   
                base.OnStop();
            }            
        }
    }
}
