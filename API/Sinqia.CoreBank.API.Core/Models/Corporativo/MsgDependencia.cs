using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgDependencia
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
        public MsgRegistroDependenciaBody body { get; set; }
    }

    public class MsgRegistroDependenciaBody
    {
        public MsgRegistroDependencia RegistroDependencia { get; set; }
    }

    /// <summary>
    /// Possibilita o cadastramento das Dependências da Empresa. 
    /// São consideradas Dependências da Empresa as suas Agências, Escritórios, Postos de Serviços, Filiais, etc - TB_DEPENDENCIA
    /// </summary>
    public class MsgRegistroDependencia
    {

        /// <summary>
        /// Código Empresa Sisbacen
        /// </summary>        
        [Required(ErrorMessage ="Campo obrigatório")]
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? codigoEmpresa { get; set; }

        /// <summary>
        /// Código Dependência Sisbacen
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? codigoDependência { get; set; }

        /// <summary>
        /// Código do Município
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [Range(1, 999999999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public long? codigoMunicipio { get; set; }

        /// <summary>
        /// Nome abreviado da Dependência
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(18, ErrorMessage ="Tamanho limite excedido para o campo")]
        public string nomeAbreviado { get; set; }

        /// <summary>
        /// Nome completo da Dependência
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string nomeCompleto { get; set; }

        /// <summary>
        /// CGC base da Dependência
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(9, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string cgcBase { get; set; }

        /// <summary>
        /// CGC Filial da dependecia
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string cgcFilial { get; set; }

        /// <summary>
        /// CGC Digito da dependencia
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(2, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string cgccDigito { get; set; }

        /// <summary>
        /// Tipo de logradouro da dependencia
        /// </summary>
        [MaxLength(10, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string tipoLogradouro { get; set; }

        /// <summary>
        /// Logradouro da Dependência
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(65, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string logradouro { get; set; }

        /// <summary>
        /// Complemento logradouro da dependencia
        /// </summary>
        [MaxLength(20, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string complementoLogradouro { get; set; }

        /// <summary>
        /// Bairro da dependência
        /// </summary>
        [MaxLength(20, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string descricaoBairro { get; set; }

        /// <summary>
        /// CEP da Dependência
        /// </summary>
        [MaxLength(10, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string cep { get; set; }

        /// <summary>
        /// DDD telefone
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddTelefone { get; set; }

        /// <summary>
        /// DDD telefone 2
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddTelefone2 { get; set; }

        /// <summary>
        /// DDD telefone 3
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddTelefone3 { get; set; }

        /// <summary>
        /// DDD telefone 4
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddTelefone4 { get; set; }

        /// <summary>
        /// Telefone da dependencia
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroTelefone { get; set; }

        /// <summary>
        /// Telefone 2 da dependencia
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroTelefone2 { get; set; }

        /// <summary>
        /// Telefone 3 da dependencia
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroTelefone3 { get; set; }

        /// <summary>
        /// Telefone 4 da dependencia
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroTelefone4 { get; set; }

        /// <summary>
        /// Ramal Dependencia
        /// </summary>
        [MaxLength(6, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroRamal { get; set; }

        /// <summary>
        /// Ramal 2
        /// </summary>
        [MaxLength(6, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroRamal2 { get; set; }

        /// <summary>
        /// Ramal 3
        /// </summary>
        [MaxLength(6, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroRamal3 { get; set; }

        /// <summary>
        /// Ramal 4
        /// </summary>
        [MaxLength(6, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroRamal4 { get; set; }

        /// <summary>
        /// DDD Fax Dependencia
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddFax { get; set; }

        /// <summary>
        /// DDD Fax 2
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddFax2 { get; set; }

        /// <summary>
        /// DDD Fax 3
        /// </summary>
        [MaxLength(4, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string dddFax3 { get; set; }

        /// <summary>
        /// Fax Dependencia
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroFax { get; set; }

        /// <summary>
        /// Fax 2
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroFax2 { get; set; }

        /// <summary>
        /// Fax 3
        /// </summary>
        [MaxLength(8, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroFax3 { get; set; }

        /// <summary>
        /// Email da Dependência
        /// </summary>
        [MaxLength(100, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string email { get; set; }

        /// <summary>
        /// Inscrição estadual da Dependência
        /// </summary>
        [MaxLength(25, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string inscricaoEstadual { get; set; }

        /// <summary>
        /// Inscrição municipal da Dependência
        /// </summary>
        [MaxLength(25, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string inscricaoMunicipal { get; set; }

        /// <summary>
        /// Nível hierárquico Superior
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico { get; set; }

        /// <summary>
        /// Nivel 1 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico1 { get; set; }

        /// <summary>
        /// Nivel 2 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico2 { get; set; }

        /// <summary>
        /// Nivel 3 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico3 { get; set; }

        /// <summary>
        /// Nivel 4 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico4 { get; set; }

        /// <summary>
        /// Nivel 5 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico5 { get; set; }

        /// <summary>
        /// Nivel 6 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico6 { get; set; }

        /// <summary>
        /// Nivel 7 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico7 { get; set; }

        /// <summary>
        /// Nivel 8 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico8 { get; set; }

        /// <summary>
        /// Nivel 9 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico9 { get; set; }

        /// <summary>
        /// Nivel 10 Dependencia
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? nivelHierarquico10 { get; set; }

        /// <summary>
        /// Início de operação da Dependência
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime? dataInicioOperacao { get; set; }

        /// <summary>
        /// Fim de operação da Dependência
        /// </summary>
        public DateTime? dataFimOperacao { get; set; }

        /// <summary>
        /// Data de cadastramento
        /// </summary>
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Código do usuário da atualização
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(40, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// Indicador de Situação
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(1, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Tipo de Dependência
        /// </summary>
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(1, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string tipoDependencia { get; set; }

        /// <summary>
        /// Código Câmara compensação
        /// </summary>
        [Range(0, 99999, ErrorMessage = "Tamanho limite excedido para o campo")]
        public int? codigoCamaraCompensacao { get; set; }

        /// <summary>
        /// Numero Logradouro Dependencia
        /// </summary>
        [MaxLength(10, ErrorMessage = "Tamanho limite excedido para o campo")]
        public string numeroLogradouro { get; set; }

        /// <summary>
        /// Data de Roll out
        /// </summary>
        public DateTime? dataRollOut { get; set; }

        /// <summary>
        /// Data da situação
        /// </summary>
        public DateTime? dataSituacao { get; set; }

    }
}