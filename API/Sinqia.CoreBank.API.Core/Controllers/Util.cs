using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Criptografia.Services;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.API.Core.Models;

namespace Sinqia.CoreBank.API.Core.Controllers
{
    public static class Util
    {
        public static List<string> ValidarModel(ModelStateDictionary ModelState)
        {
            List<string> listaErros = new List<string>();
            if (!ModelState.IsValid)
            {
                ModelState.ToList().ForEach(s =>
                {
                    for (int ind = 0; ind < s.Value.Errors.Count; ind++)
                    {
                        if (!string.IsNullOrWhiteSpace(s.Value.Errors[ind].ErrorMessage))
                            listaErros.Add(s.Key + " - " + s.Value.Errors[ind].ErrorMessage);

                        if (s.Value.Errors[ind].Exception != null)
                            listaErros.Add(s.Key + " - " + s.Value.Errors[ind].Exception.Message);
                    }
                });
            }

            return listaErros;
        }

        public static bool ValidarApiKey(HttpRequest request, IOptions<ConfiguracaoBaseAPI> configuracaoBaseAPI)
        {
            bool retorno = false;
            if (configuracaoBaseAPI != null && !string.IsNullOrWhiteSpace(configuracaoBaseAPI.Value.ApiKeyBase))
            {
                if (request.Headers.TryGetValue(ConstantesIntegracao.ApiKey, out var key))
                    retorno = (key.Equals(configuracaoBaseAPI.Value.ApiKeyBase));
                else
                    retorno = false; //client não enviou chave               
            }
            else
                retorno = true; //não foi adicionado uma chave para validação

            return retorno;
        }

        public static string GerarIdentificadorUnico()
        {            
            return Guid.NewGuid().ToString();
        }
    }
}
