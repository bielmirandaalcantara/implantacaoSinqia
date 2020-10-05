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
        public int? codigoEmpresa { get; set; }

        /// <summary>
        /// Código Dependência Sisbacen
        /// </summary>
        public int? codigoDependência { get; set; }

        /// <summary>
        /// Código do Município
        /// </summary>
        public int? codigoMunicipio { get; set; }

        /// <summary>
        /// Nome abreviado da Dependência
        /// </summary>
        public string nomeAbreviado { get; set; }

        /// <summary>
        /// Nome completo da Dependência
        /// </summary>
        public string nomeCompleto { get; set; }

        /// <summary>
        /// CGC base da Dependência
        /// </summary>
        public string cgcBase { get; set; }

        /// <summary>
        /// CGC Filial da dependecia
        /// </summary>
        public string cgcFilial { get; set; }

        /// <summary>
        /// CGC Digito da dependencia
        /// </summary>
        public string cgccDigito { get; set; }

        /// <summary>
        /// Tipo de logradouro da dependencia
        /// </summary>
        public string tipoLogradouro { get; set; }

        /// <summary>
        /// Logradouro da Dependência
        /// </summary>
        public string logradouro { get; set; }

        /// <summary>
        /// Complemento logradouro da dependencia
        /// </summary>
        public string complementoLogradouro { get; set; }

        /// <summary>
        /// Bairro da dependência
        /// </summary>
        public string descricaoBairro { get; set; }

        /// <summary>
        /// CEP da Dependência
        /// </summary>
        public string cep { get; set; }

        /// <summary>
        /// DDD telefone
        /// </summary>
        public string dddTelefone { get; set; }

        /// <summary>
        /// DDD telefone 2
        /// </summary>
        public string dddTelefone2 { get; set; }

        /// <summary>
        /// DDD telefone 3
        /// </summary>
        public string dddTelefone3 { get; set; }

        /// <summary>
        /// DDD telefone 4
        /// </summary>
        public string dddTelefone4 { get; set; }

        /// <summary>
        /// Telefone da dependencia
        /// </summary>
        public string numeroTelefone { get; set; }

        /// <summary>
        /// Telefone 2 da dependencia
        /// </summary>
        public string numeroTelefone2 { get; set; }

        /// <summary>
        /// Telefone 3 da dependencia
        /// </summary>
        public string numeroTelefone3 { get; set; }

        /// <summary>
        /// Telefone 4 da dependencia
        /// </summary>
        public string numeroTelefone4 { get; set; }

        /// <summary>
        /// Ramal Dependencia
        /// </summary>
        public string numeroRamal { get; set; }

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
        /// DDD Fax Dependencia
        /// </summary>
        public string dddFax { get; set; }

        /// <summary>
        /// DDD Fax 2
        /// </summary>
        public string dddFax2 { get; set; }

        /// <summary>
        /// DDD Fax 3
        /// </summary>
        public string dddFax3 { get; set; }

        /// <summary>
        /// Fax Dependencia
        /// </summary>
        public string numeroFax { get; set; }

        /// <summary>
        /// Fax 2
        /// </summary>
        public string numeroFax2 { get; set; }

        /// <summary>
        /// Fax 3
        /// </summary>
        public string numeroFax3 { get; set; }

        /// <summary>
        /// Email da Dependência
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Inscrição estadual da Dependência
        /// </summary>
        public string inscricaoEstadual { get; set; }

        /// <summary>
        /// Inscrição municipal da Dependência
        /// </summary>
        public string inscricaoMunicipal { get; set; }

        /// <summary>
        /// Nível hierárquico Superior
        /// </summary>
        public int? nivelHierarquico { get; set; }

        /// <summary>
        /// Nivel 1 Dependencia
        /// </summary>
        public int? nivelHierarquico1 { get; set; }

        /// <summary>
        /// Nivel 2 Dependencia
        /// </summary>
        public int? nivelHierarquico2 { get; set; }

        /// <summary>
        /// Nivel 3 Dependencia
        /// </summary>
        public int? nivelHierarquico3 { get; set; }

        /// <summary>
        /// Nivel 4 Dependencia
        /// </summary>
        public int? nivelHierarquico4 { get; set; }

        /// <summary>
        /// Nivel 5 Dependencia
        /// </summary>
        public int? nivelHierarquico5 { get; set; }

        /// <summary>
        /// Nivel 6 Dependencia
        /// </summary>
        public int? nivelHierarquico6 { get; set; }

        /// <summary>
        /// Nivel 7 Dependencia
        /// </summary>
        public int? nivelHierarquico7 { get; set; }

        /// <summary>
        /// Nivel 8 Dependencia
        /// </summary>
        public int? nivelHierarquico8 { get; set; }

        /// <summary>
        /// Nivel 9 Dependencia
        /// </summary>
        public int? nivelHierarquico9 { get; set; }

        /// <summary>
        /// Nivel 10 Dependencia
        /// </summary>
        public int? nivelHierarquico10 { get; set; }

        /// <summary>
        /// Início de operação da Dependência
        /// </summary>
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
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// Indicador de Situação
        /// </summary>
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Tipo de Dependência
        /// </summary>
        public string tipoDependencia { get; set; }

        /// <summary>
        /// Código Câmara compensação
        /// </summary>
        public int? codigoCamaraCompensacao { get; set; }

        /// <summary>
        /// Numero Logradouro Dependencia
        /// </summary>
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