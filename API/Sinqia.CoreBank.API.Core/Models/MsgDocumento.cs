using System;
using System.Collections.Generic;
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
    public class MsgRegistrodocumento
    {
        /// <summary>
        /// Pessoa
        /// </summary>
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Nº Documento
        /// </summary>
        public string numeroDocumento { get; set; }

        /// <summary>
        /// Data Expedição
        /// </summary>
        public DateTime dataExpedicao { get; set; }

        /// <summary>
        /// Orgão Expedidor
        /// </summary>
        public string orgaoExpedidor { get; set; }

        /// <summary>
        /// observacao
        /// </summary>
        public string observacao { get; set; }

        /// <summary>
        /// Data Cadastro
        /// </summary>
        public DateTime dataCadastro { get; set; }

        /// <summary>
        /// Usuário Última Atualização
        /// </summary>
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data Atualização
        /// </summary>
        public DateTime dataAtualizacao { get; set; }

        /// <summary>
        /// Situação
        /// </summary>
        public string IndicadorSituacao { get; set; }

        /// <summary>
        /// Data Situação
        /// </summary>
        public DateTime dataSituacao { get; set; }

        /// <summary>
        /// Tipo Documento
        /// </summary>
        public string tipoDocumento { get; set; }

        /// <summary>
        /// UF Expedição
        /// </summary>
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