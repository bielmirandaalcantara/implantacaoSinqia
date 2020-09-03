using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgDocumento
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
        public MsgRegistroDocumentoBody body { get; set; }
    }

    public class MsgRegistroDocumentoBody
    {
        public MsgRegistrodocumento RegistroDocumento { get; set; }
    }

    /// <summary>
    /// Armazena dados de endereços de pessoas físicas e jurídicas. - tb_doc
    /// </summary>
    public class MsgRegistrodocumento
    {
        /// <summary>
        /// Pessoa
        /// </summary>
        [Required]
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Nº Documento
        /// </summary>
        [Required]
        public string numeroDocumento { get; set; }

        /// <summary>
        /// Data Expedição
        /// </summary>
        [Required]
        public DateTime dataExpedicao { get; set; }

        /// <summary>
        /// Orgão Expedidor
        /// </summary>
        [Required]
        public string orgaoExpedidor { get; set; }

        /// <summary>
        /// observacao
        /// </summary>
        [Required]
        public string observacao { get; set; }

        /// <summary>
        /// Data Cadastro
        /// </summary>
        [Required]
        public DateTime dataCadastro { get; set; }

        /// <summary>
        /// Usuário Última Atualização
        /// </summary>
        [Required]
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data Atualização
        /// </summary>
        [Required]
        public DateTime dataAtualizacao { get; set; }

        /// <summary>
        /// Situação
        /// </summary>
        [Required]
        public string IndicadorSituacao { get; set; }

        /// <summary>
        /// Data Situação
        /// </summary>
        [Required]
        public DateTime dataSituacao { get; set; }

        /// <summary>
        /// Tipo Documento
        /// </summary>
        [Required]
        public string tipoDocumento { get; set; }

        /// <summary>
        /// UF Expedição
        /// </summary>
        [Required]
        public string ufExpedicao { get; set; }

        /// <summary>
        /// Doc. Identif. Talão de Cheques
        /// </summary>
        public string documentoCheque { get; set; }

        /// <summary>
        /// Idc. Micro Empresa
        /// </summary>
        public string indicadorMicroEmpresa { get; set; }

        /// <summary>
        /// Idc. Comprovado
        /// </summary>
        public string IndicadorComprovado { get; set; }

        /// <summary>
        /// Tipo de Comprovação de Renda
        /// </summary>
        public int tipoComprovacaoRenda { get; set; }

        /// <summary>
        /// Idc. Preposto
        /// </summary>
        public string indicadorPreposto { get; set; }

        /// <summary>
        /// Data Vencimento
        /// </summary>
        public DateTime dataVencimento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacionalidade { get; set; }

    }
}