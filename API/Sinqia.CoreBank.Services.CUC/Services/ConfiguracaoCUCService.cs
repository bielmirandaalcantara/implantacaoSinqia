using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Services.CUC.Models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Services
{
    public static class ConfiguracaoCUCService
    {
        public static ConfiguracaoURICUC BuscarURI(string nomeURI, IOptions<ConfiguracaoBaseCUC> configuracaoCUC)
        {
            if (configuracaoCUC.Value == null) throw new Exception("Configuração não aplicada para o serviço de integração - favor verificar o arquivo appSettings - ConfiguracaoBaseCUC");

            var configURICUCs = configuracaoCUC.Value.ConfiguracaoURICUC;

            if (configURICUCs == null) throw new Exception("Configuração não aplicada para o serviço de integração - favor verificar o arquivo appSettings - ServicesURICUC");

            var configURICUC = configURICUCs.FirstOrDefault(c=>c.Nome.ToUpper().Equals(nomeURI.ToUpper()));

            if (configURICUC == null) throw new Exception($"Nenhuma URI foi encontrada para o nome {nomeURI} configurado no appSettings");

            return configURICUC;

        }
    }
}
