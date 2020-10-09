using Sinqia.CoreBank.InputOutput.Services;
using Sinqia.CoreBank.Configuracao.Configuration;
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
        private string identificador = string.Empty;

        /// <summary>
        /// inclusão de log, trace e erros no arquivo de texto
        /// </summary>
        /// <param name="configLog">Objeto do arquivo de configuração - sessão log</param>       
        public LogService(ConfiguracaoLog configLog)
        {
            _configLog = configLog;
            BuscarConfiguracoesGlobais();
        }
        /// <summary>
        /// inclusão de log, trace e erros no arquivo de texto
        /// </summary>
        /// <param name="configLog">Objeto do arquivo de configuração - sessão log</param>
        /// <param name="identificadorExterno">identificador para rastreio da mensagem</param>
        public LogService(ConfiguracaoLog configLog, string identificadorExterno)
        {
            identificador = identificadorExterno;
            _configLog = configLog;
            BuscarConfiguracoesGlobais();
        }

        /// <summary>
        /// usado para inclusão de um rastreio nos logs para fácil identificação
        /// </summary>
        /// <param name="identificadorExterno"></param>
        public void SetIdentificador(string identificadorExterno)
        {
            identificador = identificadorExterno;
        }

        /// <summary>
        /// indicador de informação no log - apenas para necessidades pontuais 
        /// </summary>
        /// <param name="mensagem"></param>
        public void Information(string mensagem)
        {
            try
            {
                if (logHabilitado)
                {
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - {identificador} - {textoInformation} - {mensagem}";
                    GravarTextoArquivo(textoCompleto);

                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        /// <summary>
        /// Usado quando o parâmetro trace está ativo.
        /// Escreve no arquivo de log a entrada do método
        /// </summary>
        public void TraceMethodStart()
        {
            try
            {
                if (traceHabilitado)
                {
                    var stack = new StackFrame(1);
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - {identificador} - [ENTROU] {stack.GetMethod()}";

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
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)}  - {identificador} - {textoInformation} - {mensagem}";
                    GravarTextoArquivo(textoCompleto);

                }
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Usado quando o parâmetro trace está ativo.
        /// Escreve no arquivo de log a saída do método
        /// </summary>
        public void TraceMethodEnd()
        {
            try
            {
                if (traceHabilitado)
                {
                    var stack = new StackFrame(1);
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - {identificador}  - [SAIU] {stack.GetMethod()}";

                    GravarTextoArquivo(textoCompleto);
                }               
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }

        }

        /// <summary>
        /// loga no arquvo como erro
        /// </summary>
        /// <param name="mensagem"></param>
        public void Error(string mensagem)
        {
            try
            {
                if (logHabilitado)
                {
                    string textoCompleto = $" {DateTime.Now.ToString(formatoData)} - {identificador}  - {textoError} - {mensagem}";

                    GravarTextoArquivo(textoCompleto);
                }                
            }
            catch (Exception ex)
            {
                throw new LogErrorException(ex.Message, ex);
            }            
        }

        /// <summary>
        /// loga no arquvo como erro
        /// </summary>
        /// <param name="mensagem"></param>
        /// <param name="erro">Exceção para escrever no log</param>
        public void Error(string mensagem, Exception erro)
        {
            try
            {
                if (logHabilitado)
                {
                    StringBuilder textoCompleto = new StringBuilder();
                    textoCompleto.AppendLine($" {DateTime.Now.ToString(formatoData)}  - {identificador} - {textoError} - {mensagem}");
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

        /// <summary>
        /// loga no arquvo como erro
        /// </summary>
        /// <param name="erro">Exceção para escrever no log</param>
        public void Error(Exception erro)
        {
            try
            {
                if (logHabilitado)
                {
                    StringBuilder textoCompleto = new StringBuilder();
                    textoCompleto.AppendLine($" {DateTime.Now.ToString(formatoData)}  - {identificador} - {textoError}");
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
