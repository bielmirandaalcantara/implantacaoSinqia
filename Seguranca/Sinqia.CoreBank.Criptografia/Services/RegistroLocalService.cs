using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using Sinqia.CoreBank.Criptografia.Constantes;

namespace Sinqia.CoreBank.Criptografia.Services
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
                chave = Environment.GetEnvironmentVariable(ConstantesVariavel.CHAVESINQIA, EnvironmentVariableTarget.Machine);

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

        private static string BuscarChaveRegistroWindows()
        {
            string chave = string.Empty;
            RegistryKey rk0 = null;
            RegistryKey rk3264 = null;
            RegistryKey rk1 = null;
            RegistryKey rk2 = null;
            RegistryKey chaveIntegracao = null;

            try
            {
                bool is64 = System.Environment.Is64BitOperatingSystem;

                rk0 = Registry.LocalMachine.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel0, true);
                if (rk0 == null)
                    throw new Exception("Chave level 0 não encontrada no registro do Windows.");

                rk3264 = null;
                if (is64)
                {
                    rk3264 = rk0.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel64Bit, true);
                    if (rk3264 == null)
                        throw new Exception("Chave level 32-64 não encontrada no registro do Windows.");
                }
                else rk3264 = rk0;

                rk1 = rk0.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel1, true);
                if (rk1 == null)
                    throw new Exception("Chave level 1 não encontrada no registro do Windows.");

                rk2 = rk1.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel2, true);
                if (rk2 == null)
                    throw new Exception("Chave level 2 não encontrada no registro do Windows.");

                chaveIntegracao = rk2.OpenSubKey(ConstantesRegistro.SubChaveIntegradorLevel3, true);
                if (chaveIntegracao == null)
                    throw new Exception("Chave integração não encontrada no registro do Windows.");

                chave = chaveIntegracao.GetValue(ConstantesRegistro.ChaveSelecao).ToString();

                return chave;
            }
            catch (UnauthorizedAccessException erro)
            {
                throw new Exception("Não tem permissão de acesso ao registro do windows: " + erro.Message);
            }
            catch (Exception erro)
            {
                throw new Exception("Erro ao buscar a chave do serviço. Ela pode não estar cadastrada no registro do windows ", erro);
            }
            finally
            {
                if (chaveIntegracao != null) chaveIntegracao.Close();
                if (rk2 != null) rk2.Close();
                if (rk1 != null) rk1.Close();
                if (rk3264 != null) rk3264.Close();
                if (rk0 != null) rk0.Close();
            }
        }
    }

    
}
