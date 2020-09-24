using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Pessoa
{
    public class MsgReferencia
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
        public MsgRegistroReferenciaBody body { get; set; }
    }

    public class MsgRegistroReferenciaBody
    {
        public MsgRegistroreferencia RegistroReferencia { get; set; }
    }

    /// <summary>
    /// Armazena informações de referências para pessoas físicas e jurídicas. - tb_ref
    /// </summary>
    public class MsgRegistroreferencia
    {
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoPessoaTitular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoFilialTitular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public int? sequencial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string tipo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string observacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? numeroCartao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? valorLimite { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? dataInicioEmprego { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? dataFinalEmprego { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? dataSituacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? codigoCartao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? codigoSeguradora { get; set; }

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
        public DateTime? dataVencimentoSeguroCartao { get; set; }

    }
}