using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class ParametroBalancoQuery : ParametroBaseQuery
    {
        /// <summary>
        /// Disponibiliza o código de detalhe para requisição do serviço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string detalhe { get; set; }

        /// <summary>
        /// Disponibiliza o ano do balanço para requisição do serviço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? ano { get; set; }
    }
}
