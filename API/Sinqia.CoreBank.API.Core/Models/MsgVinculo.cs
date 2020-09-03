﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgVinculo
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
        public MsgRegistroVinculoBody body { get; set; }
    }

    public class MsgRegistroVinculoBody
    {
        public MsgRegistroperfil RegistroVinculo { get; set; }
    }

    /// <summary>
    /// Possibilita o armazenamento de informações da renda de pessoas físicas - tb_fisjur 
    /// </summary>
    public class MsgRegistroVinculo
    {
        /// <summary>
        /// Código Pessoa
        /// </summary>
        [Required]
        public string codigoPessoaJuridica { get; set; }

        /// <summary>
        /// Filial
        /// </summary>
        [Required]
        public string codigoFilialPessoaJuridica { get; set; }

        /// <summary>
        /// Código
        /// </summary>
        [Required]
        public string codigoPessoaFisica { get; set; }

        /// <summary>
        /// Filial
        /// </summary>
        [Required]
        public string codigoFilialPessoaFisica { get; set; }

        /// <summary>
        /// Sequência
        /// </summary>
        [Required]
        public int numeroSequencia { get; set; }

        /// <summary>
        /// Idc. Participação
        /// </summary>
        [Required]
        public string indicadorParticipacao { get; set; }

        /// <summary>
        /// Pct. Participação
        /// </summary>
        public decimal percentualParticipacao { get; set; }

        /// <summary>
        /// Data Início
        /// </summary>
        public DateTime dataPosse { get; set; }

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
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Data Situação
        /// </summary>
        [Required]
        public DateTime dataSituacao { get; set; }

        /// <summary>
        /// Função Cargo
        /// </summary>
        public int codigoCargo { get; set; }

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
        public DateTime dataFim { get; set; }

        /// <summary>
        /// Vínculo
        /// </summary>
        public string codigoVinculo { get; set; }

        /// <summary>
        /// Data Vencto. Procuração
        /// </summary>
        public DateTime dataVencimentoProcuracao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime tempoMandato1 { get; set; }

        /// <summary>
        /// Data Fim
        /// </summary>
        public DateTime dataFimMandato { get; set; }

        /// <summary>
        /// Pessoa
        /// </summary>
        [Required]
        public string nomePessoa { get; set; }

        /// <summary>
        /// Tipo Pessoa
        /// </summary>
        [Required]
        public string tipoPesoa { get; set; }
    }
}
