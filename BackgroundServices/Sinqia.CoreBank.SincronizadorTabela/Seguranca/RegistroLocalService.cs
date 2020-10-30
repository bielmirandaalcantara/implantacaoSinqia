using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Sinqia.CoreBank.SincronizadorTabela.Constantes;

namespace Sinqia.CoreBank.SincronizadorTabela.Seguranca
{
    public class RegistroLocalService
    {
        public static string BuscarChaveServico()
        {
            return BuscarChaveVariavelAmbiente();
        }

        private static string BuscarChaveVariavelAmbiente()
        {
            string chave = string.Empty;

            try
            {
                chave = Environment.GetEnvironmentVariable(SegurancaConstantes.CHAVESINQIA, EnvironmentVariableTarget.Machine);

                if (string.IsNullOrWhiteSpace(chave))
                    throw new Exception("Chave não cadastrada no ambiente - verifique pelo aplicativo de criptografia");
            }
            catch (UnauthorizedAccessException erro)
            {
                throw new Exception("Não tem permissão de acesso as variáveis de ambiente " + erro.Message);
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar a chave do serviço. Ela pode não estar cadastrada no servidor ", erro);
            }            

            return chave;
        }       
    }    
}
