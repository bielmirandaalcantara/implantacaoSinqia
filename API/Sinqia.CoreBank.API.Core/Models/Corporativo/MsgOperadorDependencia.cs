using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgOperadorDependencia
    {
        /// <summary>
        /// header da mensagem
        /// erros será nulo em retornos http 200
        /// identificador será nulo ou em branco caso seja uma requisição GET
        /// </summary>
        public MsgHeader header { get; set; }

        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroOperadorDependenciaBody body { get; set; }
    }

    public class MsgRegistroOperadorDependenciaBody
    {
        public MsgRegistroOperadorDependencia RegistroOperadorDependencia { get; set; }
    }

    /// <summary>
    /// Possibilita o cadastramento de Associação de Operador com Dependência - TB_DEPOPE
    /// </summary>
    public class MsgRegistroOperadorDependencia
    {
        /// <summary>
        /// Código da Empresa
        /// </summary>
        public int? codigoEmpresa { get; set; }

        /// <summary>
        /// Código da dependencia
        /// </summary>
        public int? codigoDependencia { get; set; }

        /// <summary>
        /// Código do Operador
        /// </summary>
        public int? codigoOperador { get; set; }
    }
}