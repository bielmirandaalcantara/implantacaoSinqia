using System;
using System.ServiceModel;
using Microsoft.Extensions.Options;
using Microsoft.Win32;
using Sinqia.CoreBank.Criptografia.Services;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using Sinqia.CoreBank.Services.CUC.WCF.Autenticacao;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public class AutenticacaoCUCService
    {
        private IOptions<ConfiguracaoBaseCUC> _configuracaoCUC;
        private LogService _log;

        public AutenticacaoCUCService(IOptions<ConfiguracaoBaseCUC> configuracaoCUC, LogService log)
        {
            _configuracaoCUC = configuracaoCUC;
            _log = log;
        }

        public string GetToken(ConfiguracaoAcessoCUC configuracaoAcessoCUC)
        {
            _log.TraceMethodStart();

            if (configuracaoAcessoCUC == null) throw new Exception("Configuração de acesso não parametrizado no arquivo de configuração - AcessoCUC");
            if (string.IsNullOrWhiteSpace(configuracaoAcessoCUC.userServico)) throw new ApplicationException("usuario do serviço deve ser parametrizada");
            if (string.IsNullOrWhiteSpace(configuracaoAcessoCUC.passServico)) throw new ApplicationException("Senha do serviço deve ser parametrizada");
            if (string.IsNullOrWhiteSpace(configuracaoAcessoCUC.chaveServico)) throw new ApplicationException("Chave de criptografia do serviço deve ser parametrizada");

            string token = string.Empty;
            string login = configuracaoAcessoCUC.userServico;
            string senha = configuracaoAcessoCUC.passServico;
            string chave = BuscarChaveServico();

            senha = DescriptografarSenhaServico(senha, chave);

            ConfiguracaoURICUC configuracaoURICUC = ConfiguracaoCUCService.BuscarURI(ConstantesInegracao.URLConfiguracao.Autenticacao, _configuracaoCUC);
            EndpointAddress address = new EndpointAddress(configuracaoURICUC.URI);
            CucCliAutenticacaoClient client = new CucCliAutenticacaoClient(CucCliAutenticacaoClient.EndpointConfiguration.BasicHttpBinding_ICucCliAutenticacao, address);

            try
            {
                CucCluRetornoAutenticacao dadosRetorno = client.Autenticar(login, senha);
                token = dadosRetorno.Token;

                _log.TraceMethodEnd();

                return token;
            }
            catch (TimeoutException timeoutEx)
            {
                client.Abort();
                throw new Exception("Tempo de conexão expirado", timeoutEx);                
            }
            catch(EndpointNotFoundException endPointEx)
            {
                throw new Exception("Caminho do serviço não disponível ou inválido", endPointEx);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private string DescriptografarSenhaServico(string senha, string chave)
        {
            _log.TraceMethodStart();

            string senhaDescriptografada = string.Empty;
            CriptografiaServices criptografia = new CriptografiaServices();
            criptografia.Key = chave;
            senhaDescriptografada = criptografia.Decrypt(senha);

            _log.TraceMethodEnd();
            return senhaDescriptografada;
        }

        private string BuscarChaveServico()
        {
            try
            {
                // cria uma referêcnia para a chave de registro Software
                RegistryKey rk = Registry.CurrentUser.OpenSubKey("Sinqia.CoreBank.Registro", true);
                // realiza a leitura do registro
                var chave = rk.OpenSubKey("chaveIntegrador", true).GetValue("Chave").ToString();
                return chave;
            }
            catch (UnauthorizedAccessException erro)
            {
                throw new Exception("Não tem permissão de acesso: " + erro.Message);
            }
            catch (Exception erro)
            {
                throw new Exception("Erroao buscar a chave do serviço", erro);
            }
            
        }
    }
}
