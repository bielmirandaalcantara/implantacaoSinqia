//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Sinqia.CoreBank.API.Core.Models
//{

//    public class MsgPessoaSimplificada
//    {
//        /// <summary>
//        /// header da mensagem
//        /// erros será nulo em retornos http 200
//        /// identificador será nulo ou em branco caso seja uma requisição GET
//        /// </summary>
//        public MsgHeader header { get; set; }

//        /// <summary>
//        /// corpo da mensagem
//        /// body será nulo ou vazio caso retornos http 400 e 500
//        /// </summary>
//        public MsgRegistroPessoaSimplificadaBody body { get; set; }
//    }

//    public class MsgRegistroPessoaSimplificadaBody
//    {
//        public MsgRegistroPessoaSimplificada RegistroPessoaSimplificada { get; set; }
//    }

//    /// <summary>
//    /// Armazena dados de pessoas simplificadas - tb_pes_simp
//    /// </summary>
//    public class MsgRegistroPessoaSimplificada
//    {

//        /// <summary>
//        /// 
//        /// </summary>
//        [Required(ErrorMessage ="Campo obrigatório")]
//        public string codigo { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string nome { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string codigoDddFone1 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string codigoDddFone2 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroTelefone1 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroTelefone2 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroRamal1 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroRamal2 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string situacaoTelefone1 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string situacaoTelefone2 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public DateTime? dataNascimento { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string observacao { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string tipoReferencia { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        [Required(ErrorMessage ="Campo obrigatório")]
//        public DateTime? dataCadastramento { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        [Required(ErrorMessage ="Campo obrigatório")]
//        public string usuarioUltimaAtualizacao { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        [Required(ErrorMessage ="Campo obrigatório")]
//        public DateTime? dataAtualizacao { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoMunicipio { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string descricaoMunicipio { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string tipoLogradouro { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string descricicaoLogradouro { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroEndereco { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string complementoLogradouro { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string nomeBairro { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string tipoEndereco { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string uf { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string pais { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroCep { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string estadoCivil { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string regimeComunhao { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string nomeConjugue { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string indicadorAvalista { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        [Required(ErrorMessage ="Campo obrigatório")]
//        public string CpfCnpjSimplificado { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string tipoPessoa { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string identificadorIsentoCpf { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string codigoSistemaOrigem { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string CpfConjugue { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string CodCbo { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? CodAtividade { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? CodAtividadeCbo { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string indicadorClienteFatca { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroRg { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroIdentificadorFiscal { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoNacionalidade1 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoNacionalidade2 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoNacionalidade3 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoNacionalidade4 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoDomicilioFiscal1 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoDomicilioFiscal2 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoDomicilioFiscal3 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int? codigoDomicilioFiscal4 { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string codigoDddCelular { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroCelular { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string email { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string indicadorClienteEstrangeiro { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string tipoDocumentoEstrangeiro { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string numeroDocumentoEstrangeiro { get; set; }

//        /// <summary>
//        /// Possibilita o armazenamento de informações da renda de pessoas físicas. 
//        /// </summary>
//        public MsgRegistroVinculo[] RegistroVinculo { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string nomeSocial { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string nivelRiscoPld { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string observacaoPld { get; set; }

//        /*
//        /// <summary>
//        /// Código Atividade 
//        /// </summary>
//        public string CodigoAtividadeCbo { get; set; }
//        */
//        /*
//        /// <summary>
//        /// 
//        /// </summary>
//        public int? CodigoAtividade { get; set; }
//        */
//    }
//}
