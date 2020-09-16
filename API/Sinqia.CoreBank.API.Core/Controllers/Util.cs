using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using Sinqia.CoreBank.API.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using Sinqia.CoreBank.API.Core.Constantes;

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
            bool retorno = true;
            if (configuracaoBaseAPI != null && !string.IsNullOrWhiteSpace(configuracaoBaseAPI.Value.ApiKeyBase))
            {
                if (!request.Headers.TryGetValue(ConstantesIntegracao.ApiKey, out var key))
                    throw new ApplicationException("Necessária chave de autenticação");

                return key.Equals(configuracaoBaseAPI.Value.ApiKeyBase);
            }               

            return retorno;
        }
    }
}
