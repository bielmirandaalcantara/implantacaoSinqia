using Sinqia.CoreBank.InputOutput.Services;
using Sinqia.CoreBank.Logging.Configuration;
using System;
using System.Diagnostics;
using System.Text;

namespace Sinqia.CoreBank.Logging.Services
{
    public class LogService
    {       
        private const string textoInformation = "Info";
        private const string textoError = "Erro";
        private const string textoTrace = "Trace";
        private const string formatoData = "dd-MM-yyyy HH:mm:ss";

        private ConfiguracaoLog _configLog;
        private string caminho;
        private string nomeArquivo;
        private bool traceHabilitado = false;
        private bool logHabilitado = false;
        private bool gerarPastaNaoEncontrada = false;

        public LogService(ConfiguracaoLog configLog)
        {
            _configLog = configLog;
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

        public void Trace(string mensagem)
        {
            try
            {
                if (traceHabilitado)
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
                    textoCompleto.AppendLine($"Exception -----------------------------------------------------------------------------");
                    textoCompleto.AppendLine(erro.Message);
                    textoCompleto.AppendLine($"StacTrace------------------------------------------------------------------------------");
                    textoCompleto.AppendLine(erro.StackTrace);
                    textoCompleto.AppendLine($"---------------------------------------------------------------------------------------");

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
                    textoCompleto.AppendLine($"Exception -----------------------------------------------------------------------------");
                    textoCompleto.AppendLine(erro.Message);
                    textoCompleto.AppendLine($"StacTrace------------------------------------------------------------------------------");
                    textoCompleto.AppendLine(erro.StackTrace);
                    textoCompleto.AppendLine($"---------------------------------------------------------------------------------------");

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
            if (_configLog == null) throw new Exception("Configuração não encontrada - ConfiguracaoLog");

            caminho = _configLog.CaminhoArquivo;
            nomeArquivo = _configLog.NomeArquivo;

            if(!string.IsNullOrWhiteSpace(_configLog.HabilitarTrace))
                traceHabilitado = _configLog.HabilitarTrace.ToUpper().Equals("TRUE");
            
            if (!string.IsNullOrWhiteSpace(_configLog.HabilitarLog))
                logHabilitado = _configLog.HabilitarLog.ToUpper().Equals("TRUE");

            if (!string.IsNullOrWhiteSpace(_configLog.GerarPastaNaoEncontrada))
                gerarPastaNaoEncontrada = _configLog.GerarPastaNaoEncontrada.ToUpper().Equals("TRUE");           
        }

        private void GravarTextoArquivo(string textoCompleto)
        {
            ArquivoTexto.InserirTexto(textoCompleto, caminho, nomeArquivo, gerarPastaNaoEncontrada);
        }
    }
}
