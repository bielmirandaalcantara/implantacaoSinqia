using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgDependencia
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
        public MsgRegistroDependenciaBody body { get; set; }
    }

    public class MsgRegistroDependenciaBody
    {
        public MsgRegistroDependencia RegistroDependencia { get; set; }
    }

    /// <summary>
    /// Possibilita o cadastramento das Dependências da Empresa. 
    /// São consideradas Dependências da Empresa as suas Agências, Escritórios, Postos de Serviços, Filiais, etc - TB_DEPENDENCIA
    /// </summary>
    public class MsgRegistroDependencia
    {
        /// <summary>
        /// Tipo de Dependência
        /// </summary>
        public string tipoDependencia { get; set; }

        /// <summary>
        /// Código Câmara compensação
        /// </summary>
        public int codigoCamaraCompensacao { get; set; }

        /// <summary>
        /// Numero Logradouro Dependencia
        /// </summary>
        public string numeroLogradouro { get; set; }

        /// <summary>
        /// Data de Roll out
        /// </summary>
        public DateTime dataRollOut { get; set; }

        /// <summary>
        /// Data da situação
        /// </summary>
        public DateTime dataSituacao { get; set; }
    }
}