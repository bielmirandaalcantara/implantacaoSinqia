using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgOutrosBancos
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
        public MsgRegistroOutrosBancosBody body { get; set; }
    }

    public class MsgRegistroOutrosBancosBody
    {
        public MsgRegistroOutrosBancos RegistroOutrosBancos { get; set; }
    }

    /// <summary>
    /// Possibilita o armazenamento de informações referente às contas do cliente em outros bancos
    /// </summary>
    public class MsgRegistroOutrosBancos
    {
        /// <summary>
        /// Código de pessoa 
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Código de filial
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string codigoFilial { get; set; }

        /// <summary>
        /// Sequencial negócio
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? sequencial { get; set; }

        /// <summary>
        /// Código da agência
        /// </summary>
        public int? codigoAgencia { get; set; }

        /// <summary>
        /// Número da conta
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string numeroConta { get; set; }

        /// <summary>
        /// Valor do limite
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal? valorLimite { get; set; }

        /// <summary>
        /// Saldo devedor
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal? valdoDevedor { get; set; }

        /// <summary>
        /// Data de inicio da operação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataInicio { get; set; }

        /// <summary>
        /// Data de fim da operação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataFim { get; set; }

        /// <summary>
        /// Data de cadastramento
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Último usuário de atualização
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data da última atualização
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// Data da situação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataSituacao { get; set; }

        /// <summary>
        /// Identificador de situação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string identificadorSituacao { get; set; }

        /// <summary>
        /// Código Empresa 
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? codigoEmpresa { get; set; }

        /// <summary>
        /// Código do produto bancário
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? codigoProdutoBancario { get; set; }

        /// <summary>
        /// Código do Banco
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? codigoBanco { get; set; }

        /// <summary>
        /// Código do banco do negócio 
        /// </summary>
        public int? codigoBancoNegocio { get; set; }

        /// <summary>
        /// Conta de Crédito para Resgate
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string contaCreditoResgate { get; set; }

        /// <summary>
        /// Situação do Registro
        /// </summary>
        public string SituacaoRegistro { get; set; }

        /// <summary>
        /// Indica se é Banco ou Instituição de Pagamento
        /// </summary>
        public string IndicadorBancoOuInstPagamento { get; set; }

        /// <summary>
        /// Código ISPB do banco
        /// </summary>
        public string codigoIspb { get; set; }

        /// <summary>
        /// Código de Instituição de Pagamento
        /// </summary>
        public decimal? codigoInstPagamento { get; set; }

        /// <summary>
        /// Indica se é Conta Padrão ou não - S - sim / N - não
        /// </summary>
        public string indicadorContaPadrao { get; set; }

    }
}
