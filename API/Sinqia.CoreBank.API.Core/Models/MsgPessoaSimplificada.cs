﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models
{

    public class MsgPessoaSimplificada
    {
        public MsgHeader header { get; set; }
        public MsgRegistroPessoaSimplificadaBody body { get; set; }
    }

    public class MsgRegistroPessoaSimplificadaBody
    {
        public MsgRegistroPessoaSimplificada RegistroPessoa { get; set; }
    }

    public class MsgRegistroPessoaSimplificada
    {

        /// <summary>
        /// 
        /// </summary>
        public string codigo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoDddFone1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoDddFone2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroTelefone1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroTelefone2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroRamal1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroRamal2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string situacaoTelefone1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string situacaoTelefone2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataNascimento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string observacao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoReferencia { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataCadastramento { get; set; }

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
        public int codigoMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string descricaoMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoLogradouro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string descricicaoLogradouro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroEndereco { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string complementoLogradouro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nomeBairro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoEndereco { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string uf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pais { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroCep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string estadoCivil { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string regimeComunhao { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nomeConjugue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorAvalista { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CpfCnpjSimplificado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoPessoa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string identificadorIsentoCpf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoSistemaOrigem { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CpfConjugue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorClienteFatca { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroRg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroIdentificadorFiscal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacionalidade1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacionalidade2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacionalidade3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacionalidade4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilioFiscal1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilioFiscal2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilioFiscal3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilioFiscal4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoDddCelular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroCelular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorClienteEstrangeiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoDocumentoEstrangeiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroDocumentoEstrangeiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nomeSocial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nivelRiscoPld { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string observacaoPld { get; set; }

    }
}
