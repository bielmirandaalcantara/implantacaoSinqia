using System;
using System.Collections.Generic;
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
        public int codigoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Nome abreviado do Grupo Empresarial
        /// </summary>
        public string nomeAbreviadoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Nome do Grupo Empresarial
        /// </summary>
        public string nomedoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Código Empresa Sisbacen
        /// </summary>
        public int codigoEmpresaSisbacen { get; set; }

        /// <summary>
        /// Código Dependência Sisbacen
        /// </summary>
        public int codigoDependenciaSisbacen { get; set; }

        /// <summary>
        /// Código CRK
        /// </summary>
        public string codigoCRK { get; set; }

        /// <summary>
        /// Identifica se a empresa líder é brasileira
        /// </summary>
        public string identificaEmpresaLiderBrasileira { get; set; }

        /// <summary>
        /// CNPJ da empresa líder
        /// </summary>
        public string cnpjEmpresaLider { get; set; }

        /// <summary>
        /// Código da Nascionalidade
        /// </summary>
        public int codigoNascionalidade { get; set; }
    }
}
