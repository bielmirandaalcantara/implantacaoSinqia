using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Sinqia.CoreBank.InputOutput.Services
{
    public class ArquivoTexto
    {
        public static void InserirTexto(string texto, string caminho, string nomeArquivo, bool gerarPastaNaoEncontrada = false)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(caminho))
                    throw new Exception("Caminho não encontrado para a geração de arquivos de log");

                if (!Directory.Exists(caminho))
                {
                    if (!gerarPastaNaoEncontrada)
                        throw new Exception("Caminho não encontrado para a geração de arquivos de log");
                    else
                        Directory.CreateDirectory(caminho);
                }

                nomeArquivo = string.Concat(nomeArquivo, DateTime.Now.Date.ToString("yyyyMMdd"), ".txt");

                string caminhoCompleto = Path.Combine(caminho, nomeArquivo);

                using (StreamWriter writer = new StreamWriter(caminhoCompleto, true))
                {
                    writer.WriteLine(texto);
                }               
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception($"Sem permissão de acesso para armazenar logs na pasta: {caminho}");
            }
        }
    }
}
