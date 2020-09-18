using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.InputOutput;
using System.Text;
using System.Diagnostics;

namespace Sinqia.CoreBank.API.Core.Logging
{
    public class LogApi
    {       
        private const string textoInformation = "Info";
        private const string textoError = "Erro";
        private const string textoTrace = "Trace";
        private const string formatoData = "dd-MM-yyyy HH:mm:ss";

        private IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI;
        private string caminho;
        private string nomeArquivo;
        private bool traceHabilitado = false;
        private bool logHabilitado = false;
        private bool gerarPastaNaoEncontrada = false;

        public LogApi(IOptions<ConfiguracaoBaseAPI> _configuracaoBaseAPI)
        {
            configuracaoBaseAPI = _configuracaoBaseAPI;
            BuscarConfiguracoesGlobais();
        }

        public void Information(string mensagem)
        {
            try
            {
                if (logHabilitado)
                {
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - {textoInformation} - {mensagem}";
                    GravarTextoArquivo(textoCompleto);

                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        public void TraceMethodStart()
        {
            try
            {
                if (traceHabilitado)
                {
                    var stack = new StackFrame(1);
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - [ENTROU] {stack.GetMethod()}";

                    GravarTextoArquivo(textoCompleto);
                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        public void TraceMethodEnd()
        {
            try
            {
                if (traceHabilitado)
                {
                    var stack = new StackFrame(1);
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - [SAIU] {stack.GetMethod()}";

                    GravarTextoArquivo(textoCompleto);
                }               
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }

        }


        public void Error(string mensagem)
        {
            try
            {
                if (logHabilitado)
                {
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - {textoError} - {mensagem}";

                    GravarTextoArquivo(textoCompleto);
                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        public void Error(string mensagem, Exception erro)
        {
            try
            {
                if (logHabilitado)
                {
                    StringBuilder textoCompleto = new StringBuilder();
                    textoCompleto.AppendLine($" {DateTime.Now.ToString(formatoData)} - {textoError} - {mensagem}");
                    textoCompleto.AppendLine($"Exception ------------------------");
                    textoCompleto.AppendLine(erro.Message);
                    textoCompleto.AppendLine($"StacTrace-------------------------");
                    textoCompleto.AppendLine(erro.StackTrace);

                    GravarTextoArquivo(textoCompleto.ToString());
                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        public void Error(Exception erro)
        {
            try
            {
                if (logHabilitado)
                {
                    StringBuilder textoCompleto = new StringBuilder();
                    textoCompleto.AppendLine($"Exception ------------------------");
                    textoCompleto.AppendLine(erro.Message);
                    textoCompleto.AppendLine($"StacTrace-------------------------");
                    textoCompleto.AppendLine(erro.StackTrace);

                    GravarTextoArquivo(textoCompleto.ToString());
                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        private void BuscarConfiguracoesGlobais()
        {
            if (configuracaoBaseAPI == null) throw new Exception("Configuração não encontrada - ConfiguracaoBaseAPI");
            if(configuracaoBaseAPI.Value.LogApi == null) throw new Exception("Configuração não encontrada - ConfiguracaoBaseAPI");
            ConfiguracaoLogAPI configApi = configuracaoBaseAPI.Value.LogApi;

            caminho = configApi.CaminhoArquivo;
            nomeArquivo = configApi.NomeArquivo;

            if(!string.IsNullOrWhiteSpace(configApi.HabilitarTrace))
                traceHabilitado = configApi.HabilitarTrace.ToUpper().Equals("TRUE");
            
            if (!string.IsNullOrWhiteSpace(configApi.HabilitarLog))
                logHabilitado = configApi.HabilitarLog.ToUpper().Equals("TRUE");

            if (!string.IsNullOrWhiteSpace(configApi.GerarPastaNaoEncontrada))
                gerarPastaNaoEncontrada = configApi.GerarPastaNaoEncontrada.ToUpper().Equals("TRUE");           
        }

        private void GravarTextoArquivo(string textoCompleto)
        {
            ArquivoTexto.InserirTexto(textoCompleto, caminho, nomeArquivo, gerarPastaNaoEncontrada);
        }
    }
}
