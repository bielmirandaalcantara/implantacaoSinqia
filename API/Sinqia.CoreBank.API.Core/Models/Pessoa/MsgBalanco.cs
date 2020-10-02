using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models.Pessoa
{
    public class MsgBalanco
    {
        public MsgHeader header { get; set; }

        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroBalancoBody body { get; set; }
    }

    public class MsgRegistroBalancoBody
    {
        public MsgRegistroBalanco RegistroBalanco { get; set; }
    }

    public class MsgRegistroBalanco
    {
        /// <summary>
        /// Código Pessoa
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Ano Balanço
        /// </summary>
         [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? anoBalanco { get; set; }

        /// <summary>
        /// Sequencial Balanço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? sequencialBalanco { get; set; }

        /// <summary>
        /// Data início Balanço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataInicioBalanco { get; set; }

        /// <summary>
        /// Data fim Balanço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataFimBalanco { get; set; }

        /// <summary>
        /// Descrição Balanço
        /// </summary>
        public string descricaoBalanco { get; set; }

        /// <summary>
        /// Data de cadastramento
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Código do usuário da atualização
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoUsuarioAtualizacao { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// Indicador de situação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Data da situação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataSituacao { get; set; }

        /// <summary>
        /// Código do Índice
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoIndice { get; set; }

        /// <summary>
        /// Código do Detalhe – Linha Balanço
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoDetalheLinhaBalanco { get; set; }

        /// <summary>
        /// Valor Analisado
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal? valorAnalisado { get; set; }


    }

}
