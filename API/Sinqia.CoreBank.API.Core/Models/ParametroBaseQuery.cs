using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class ParametroBaseQuery
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? empresa { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? dependencia { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        public string usuario { get; set; }
    }
}
