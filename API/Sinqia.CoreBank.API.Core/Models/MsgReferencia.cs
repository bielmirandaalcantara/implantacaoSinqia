using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgReferencia
    {
        public MsgHeader header { get; set; }
        public MsgRegistroReferenciaBody body { get; set; }
    }

    public class MsgRegistroReferenciaBody
    {
        public MsgRegistroreferencia RegistroPessoa { get; set; }
    }

    public class MsgRegistroreferencia
    {
        /// <summary>
        /// 
        /// </summary>
        public string codigoPessoaTitular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoFilialTitular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int sequencial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string observacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int numeroCartao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int valorLimite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataInicioEmprego { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataFinalEmprego { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataCadastro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataAtualizacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataSituacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoCartao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoSeguradora { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoPessoaReferencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoFilialReferencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoPessoaSimplificada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataVencimentoSeguroCartao { get; set; }

    }
}