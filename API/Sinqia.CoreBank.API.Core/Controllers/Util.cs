using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
