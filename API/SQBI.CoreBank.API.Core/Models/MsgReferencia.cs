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
        public string codigoPessoaTitular { get; set; }
        public string codigoFilialTitular { get; set; }
        public float sequencial { get; set; }
        public string tipo { get; set; }
        public string observacao { get; set; }
        public float numeroCartao { get; set; }
        public float valorLimite { get; set; }
        public string dataInicioEmprego { get; set; }
        public string dataFinalEmprego { get; set; }
        public string dataCadastro { get; set; }
        public string usuarioUltimaAtualizacao { get; set; }
        public string dataAtualizacao { get; set; }
        public string indicadorSituacao { get; set; }
        public string dataSituacao { get; set; }
        public float codigoCartao { get; set; }
        public float codigoSeguradora { get; set; }
        public string codigoPessoaReferencia { get; set; }
        public string codigoFilialReferencia { get; set; }
        public string codigoPessoaSimplificada { get; set; }
        public string dataVencimentoSeguroCartao { get; set; }
    }
}