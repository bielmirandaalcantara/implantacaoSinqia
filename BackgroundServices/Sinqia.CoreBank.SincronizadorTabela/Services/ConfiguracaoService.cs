using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using Microsoft.Extensions.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Logging;

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

        public void ValidarArquivoConfiguracao(ConfiguracaoSincronizadorTabela config)
        {
            if(config.IntervaloSegundos <= 0)
                throw new ApplicationException("Configuração inválida, intervalo em segundos inválido.");

            if (config.Conexoes == null || !config.Conexoes.Any())
                throw new ApplicationException("Configuração inválida, conexões não encontradas.");
            
            if(config.Log == null)
                throw new LogErrorException("Configuração inválida, Dados de log não encontrados.");

            ValidarConexoes(config.Conexoes);
            ValidarLog(config.Log);
        }

        public void ValidarLog(ConfiguracaoLog log)
        {
            if (string.IsNullOrWhiteSpace(log.CaminhoArquivo))
                throw new LogErrorException("Configuração inválida, caminho do log não encontrado");            

            if (string.IsNullOrWhiteSpace(log.CaminhoArquivo))
                throw new LogErrorException("Configuração inválida, caminho do log não encontrado");
        }
        
        public void ValidarConexoes(List<ConfiguracaoConexao> Conexoes)
        {
            foreach(var conexao in Conexoes)
            {
                if (string.IsNullOrWhiteSpace(conexao.NomeConexao))
                    throw new ApplicationException("Configuração inválida, Nome da conexão não encontrado");

                if (string.IsNullOrWhiteSpace(conexao.NomeBancoDe))
                    throw new ApplicationException("Configuração inválida, nome do banco rementente não encontrado");

                if (string.IsNullOrWhiteSpace(conexao.NomeBancoPara))
                    throw new ApplicationException("Configuração inválida, nome do banco destinatário não encontado");

                if (string.IsNullOrWhiteSpace(conexao.ConexaoDe))
                    throw new ApplicationException("Configuração inválida, conexão do banco rementente não encontrado");

                if (string.IsNullOrWhiteSpace(conexao.ConexaoPara))
                    throw new ApplicationException("Configuração inválida, conexão do banco destinatário não encontado");

                if (string.IsNullOrWhiteSpace(conexao.SufixoTabelaControle))
                    throw new ApplicationException("Configuração inválida, prefixo não eoncontrado");
            }
        }
    }
}
