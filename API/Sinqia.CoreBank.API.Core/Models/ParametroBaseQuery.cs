using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class ParametroBaseQuery
    {
        /// <summary>
        /// Disponibiliza o código da empresa para requisição do serviço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? empresa { get; set; }

        /// <summary>
        /// Disponibiliza o código da dependência para requisição do serviço. 
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? dependencia { get; set; }
    }
}
