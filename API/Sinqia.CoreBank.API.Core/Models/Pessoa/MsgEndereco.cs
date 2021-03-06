﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Pessoa
{

    public class MsgEndereco
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
        public MsgRegistroEnderecoBody body { get; set; }
    }

    public class MsgRegistroEnderecoBody
    {
        public MsgRegistroendereco RegistroEndereco { get; set; }
    }

    /// <summary>
    /// Armazena dados de endereços de pessoas físicas e jurídicas - tb_end
    /// </summary>
    public class MsgRegistroendereco
    {
        /// <summary>
        /// Código Pessoa
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Filial
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public string codigoFilial { get; set; }

        /// <summary>
        /// Código
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public int? codigoEndereco { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public string tipoEndereco { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string tipoLogradouro { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public string nomeLogradouro { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string complementoLogradouro { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        public string nomeBairro { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public string Cep { get; set; }

        /// <summary>
        /// Fone 1 (DDD)
        /// </summary>
        public string codigoDddFone1 { get; set; }

        /// <summary>
        /// Fone 2 (DDD)
        /// </summary>
        public string codigoDddFone2 { get; set; }

        /// <summary>
        /// Fone 3 (DDD)
        /// </summary>
        public string codigoDddFone3 { get; set; }

        /// <summary>
        /// Fone 4 (DDD)
        /// </summary>
        public string codigoDddFone4 { get; set; }

        /// <summary>
        /// Fone 1
        /// </summary>
        public string numeroTelefone1 { get; set; }

        /// <summary>
        /// Fone 2
        /// </summary>
        public string numeroTelefone2 { get; set; }

        /// <summary>
        /// Fone 3
        /// </summary>
        public string numeroTelefone3 { get; set; }

        /// <summary>
        /// Fone 4
        /// </summary>
        public string numeroTelefone4 { get; set; }

        /// <summary>
        /// Ramal 1
        /// </summary>
        public string numeroRamal1 { get; set; }

        /// <summary>
        /// Ramal 2
        /// </summary>
        public string numeroRamal2 { get; set; }

        /// <summary>
        /// Ramal 3
        /// </summary>
        public string numeroRamal3 { get; set; }

        /// <summary>
        /// Ramal 4
        /// </summary>
        public string numeroRamal4 { get; set; }

        /// <summary>
        /// Situação (Fone 1)
        /// </summary>
        public string situacaoTelefone1 { get; set; }

        /// <summary>
        /// Situação (Fone 2)
        /// </summary>
        public string situacaoTelefone2 { get; set; }

        /// <summary>
        /// Situação (Fone 3)
        /// </summary>
        public string situacaoTelefone3 { get; set; }

        /// <summary>
        /// Situação (Fone 4)
        /// </summary>
        public string situacaoTelefone4 { get; set; }

        /// <summary>
        /// Fax 1 (DDD)
        /// </summary>
        public string codigoDddFax1 { get; set; }

        /// <summary>
        /// Fax 2 (DDD)
        /// </summary>
        public string codigoDddFax2 { get; set; }

        /// <summary>
        /// Fax 3 (DDD)
        /// </summary>
        public string codigoDddFax3 { get; set; }

        /// <summary>
        /// Fax 1
        /// </summary>
        public string numeroFax1 { get; set; }

        /// <summary>
        /// Fax 2
        /// </summary>
        public string numeroFax2 { get; set; }

        /// <summary>
        /// Fax 3
        /// </summary>
        public string numeroFax3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Situação Residência
        /// </summary>
        public string indicadorSituacaoResidencia { get; set; }

        /// <summary>
        /// Corresp.
        /// </summary>
       [Required(ErrorMessage ="Campo obrigatório")]
        public string indicadorCorrespondencia { get; set; }

        /// <summary>
        /// Data Início
        /// </summary>
        public DateTime? dataInicial { get; set; }

        /// <summary>
        /// Data Fim
        /// </summary>
        public DateTime? dataFinal { get; set; }

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
        /// Município
        /// </summary>
        public int? codigoMunicipio { get; set; }

        /// <summary>
        /// Município
        /// </summary>
        public string descricaoMunicipio { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public string numeroEndereco { get; set; }

        /// <summary>
        /// Envio de Correspondência
        /// </summary>
        public string indicadorEnvioCorrespondencia { get; set; }

        /// <summary>
        /// Motivo
        /// </summary>
        public string codigoMotivo { get; set; }

        /// <summary>
        /// Situação Registro
        /// </summary>
        public string indicadorSituacaoRegistro { get; set; }

        /// <summary>
        /// Endereço Fora do País
        /// </summary>
        public string enderecoEstrangeiro { get; set; }

        /// <summary>
        /// País FATCA
        /// </summary>
        public int? codigoPais { get; set; }

        /*
        /// <summary>
        /// 
        /// </summary>
        public string codigoDdiFone1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoDdiFone2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoDdiFone3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoDdiFone4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string descricaoMunicipiointernacional { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string descricaoEstadointernacional { get; set; }
        */

    }
}