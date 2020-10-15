using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sinqia.CoreBank.API.Core.Models.Pessoa
{
    public class MsgVinculo
    {
        /// <summary>
        /// header da mensagem
        /// erros será nulo em retornos http 200
        /// identificador será nulo ou em branco caso seja uma requisição GET
        /// </summary>
        public MsgHeaderPessoa header { get; set; }
        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroVinculoBody body { get; set; }
    }

    public class MsgRegistroVinculoBody
    {
        public MsgRegistroVinculo RegistroVinculo { get; set; }
    }

    /// <summary>
    /// Possibilita o armazenamento de informações da renda de pessoas físicas - tb_fisjur 
    /// </summary>
    public class MsgRegistroVinculo
    {
        /// <summary>
        /// I - Inclusão A - Atualização
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public string statusLinha { get; set; }
        /// <summary>
        /// Código Pessoa
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoPessoaJuridica { get; set; }

        /// <summary>
        /// Filial
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoFilialPessoaJuridica { get; set; }

        /// <summary>
        /// Código
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoPessoaFisica { get; set; }

        /// <summary>
        /// Filial
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoFilialPessoaFisica { get; set; }

        /// <summary>
        /// Sequência
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public int? numeroSequencia { get; set; }

        /// <summary>
        /// Idc. Participação
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string indicadorParticipacao { get; set; }

        /// <summary>
        /// Pct. Participação
        /// </summary>
        public decimal? percentualParticipacao { get; set; }

        /// <summary>
        /// Data Início
        /// </summary>
        public DateTime? dataPosse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tempoMandato { get; set; }

        /// <summary>
        /// observacao
        /// </summary>
        public string observacao { get; set; }

        /// <summary>
        /// Data Cadastro
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Usuário Última Atualização
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data Atualização
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// Situação
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Data Situação
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public DateTime? dataSituacao { get; set; }

        /// <summary>
        /// Função Cargo
        /// </summary>
        public int? codigoCargo { get; set; }

        /// <summary>
        /// Assina Pela Empresa
        /// </summary>
        public string indicadorAssinaEmpresa { get; set; }

        /// <summary>
        /// Contato
        /// </summary>
        public string indicadorContato { get; set; }

        /// <summary>
        /// Data Fim
        /// </summary>
        public DateTime? dataFim { get; set; }

        /// <summary>
        /// Vínculo
        /// </summary>
        public string codigoVinculo { get; set; }

        /// <summary>
        /// Data Vencto. Procuração
        /// </summary>
        public DateTime? dataVencimentoProcuracao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? tempoMandato1 { get; set; }

        /// <summary>
        /// Data Fim
        /// </summary>
        public DateTime? dataFimMandato { get; set; }

        /// <summary>
        /// Pessoa
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string nomePessoa { get; set; }

        /// <summary>
        /// Tipo Pessoa
        /// </summary>
        [Required(ErrorMessage ="Campo obrigatório")]
        public string tipoPesoa { get; set; }

        /// <summary>
        /// Emite Duplicata
        /// </summary>
        public string indicadorEmiteDuplicata { get; set; }

        /// <summary>
        /// Assina por Endosso
        /// </summary>
        public string indicadorAssinaEndosso { get; set; }

        /// <summary>
        /// Assina Termo de Cessão
        /// </summary>
        public string indicadorAssinaCessao { get; set; }

        /// <summary>
        /// Assina em Conjunto
        /// </summary>
        public string indicadorAssinaIsoladamente { get; set; }

        /// <summary>
        /// Código
        /// </summary>
        public string codigoPessoaAssina1 { get; set; }

        /// <summary>
        /// Código
        /// </summary>
        public string codigoPessoaAssina2 { get; set; }

        /// <summary>
        /// Código
        /// </summary>
        public string codigoPessoaAssina3 { get; set; }

        /// <summary>
        /// Assinante 1
        /// </summary>
        public string nomeAssina1 { get; set; }

        /// <summary>
        /// Assinante 2
        /// </summary>
        public string nomeAssina2 { get; set; }

        /// <summary>
        /// Assinante 3
        /// </summary>
        public string nomeAssina3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string emailVinculo { get; set; }
    }
}
