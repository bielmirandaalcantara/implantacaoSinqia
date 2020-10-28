using System;
using System.IO;
using System.ServiceProcess;
using Microsoft.Extensions.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Services;

namespace Sinqia.CoreBank.SincronizadorTabela.Services
{
    public class ConfiguracaoService
    {
        private const string NomeArquivoConfiguracao = "Sinqia.CoreBank.SincronizadorTabelaSettings.json";

        private IConfigurationRoot _config = null;

        public ConfiguracaoService()
        {
            _config = GerarConfiguracaoServico();
        }

        public IConfigurationRoot GerarConfiguracaoServico()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(NomeArquivoConfiguracao);

                return builder.Build();                
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Arquivo de configuração não identificado");
            }
        }


        public ConfiguracaoSincronizadorTabela BuscarConfiguracaoServico()
        {
            ConfiguracaoSincronizadorTabela configBase = _config.Get<ConfiguracaoSincronizadorTabela>();
            return configBase;
        }
    }
}
