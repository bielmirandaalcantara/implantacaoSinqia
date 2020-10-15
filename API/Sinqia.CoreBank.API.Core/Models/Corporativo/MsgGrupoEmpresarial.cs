using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgGrupoEmpresarial
    {
        public MsgHeader header { get; set; }

        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroGrupoEmpresarialBody body { get; set; }
    }

    public class MsgRegistroGrupoEmpresarialBody
    {
        public MsgRegistroGrupoEmpresarial RegistroGrupoEmpresarial { get; set; }
    }

    public class MsgRegistroGrupoEmpresarial
    {
        /// <summary>
        /// Código do Grupo Empresarial
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? codigoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Nome abreviado do Grupo Empresarial
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(18, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string nomeAbreviadoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Nome do Grupo Empresarial
        /// </summary>
        [MaxLength(40, ErrorMessage = "Tamanho limite excedido para o campo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string nomedoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Código Empresa Sisbacen
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? codigoEmpresaSisbacen { get; set; }

        /// <summary>
        /// Código Dependência Sisbacen
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? codigoDependenciaSisbacen { get; set; }
    }
}
