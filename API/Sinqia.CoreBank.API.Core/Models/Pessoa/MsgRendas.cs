using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models.Pessoa
{
    public class MsgRendas
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
        public MsgProdutoRendasBody body { get; set; }
    }

    public class MsgProdutoRendasBody
    {
        public MsgRegistroRendas RegistroRendas { get; set; }
    }

    public class MsgRegistroRendas
    {
        /// <summary>
        /// Código da Pessoa
        /// </summary>
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Número da renda
        /// </summary>
        public int? numeroRenda { get; set; }

        /// <summary>
        /// Valor dos rendimentos
        /// </summary>
        public decimal? valRenda { get; set; }

        /// <summary>
        /// Nome do empregador
        /// </summary>
        public string nomeEmpregador { get; set; }

        /// <summary>
        /// Cargo
        /// </summary>
        public string cargoEmpregador { get; set; }

        /// <summary>
        /// Tipo do logradouro
        /// </summary>
        public string tipoLogradouro { get; set; }

        /// <summary>
        /// Logradouro do trabalho
        /// </summary>
        public string logradouroTrabalho { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string complemento { get; set; }

        /// <summary>
        /// Bairro do trabalho
        /// </summary>
        public string bairroTrabalho { get; set; }

        /// <summary>
        /// CEP do trabalho
        /// </summary>
        public string cepTrabalho { get; set; }

        /// <summary>
        /// Periodicidade da renda
        /// </summary>
        public string periodicidadeRenda { get; set; }

        /// <summary>
        /// Data validade da renda
        /// </summary>
        public DateTime? dataValidadeRenda { get; set; }

        /// <summary>
        /// Observação da renda
        /// </summary>
        public string observacaoRenda { get; set; }

        /// <summary>
        /// Data de cadastramento
        /// </summary>
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime? dataAtualizacao { get; set; }

        /// <summary>
        /// Código do usuário da atualização
        /// </summary>
        public string codigoUsuarioAtualizacao { get; set; }

        /// <summary>
        /// Indicador situação
        /// </summary>
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Data da situação
        /// </summary>
        public DateTime? dataSituacao { get; set; }

        /// <summary>
        /// Tipo de renda
        /// </summary>
        public int? tipoRenda { get; set; }

        /// <summary>
        /// Código do município
        /// </summary>
        public int? codigoMunicipio { get; set; }

        /// <summary>
        /// Código do Índice
        /// </summary>
        public string codigoIndice { get; set; }

        /// <summary>
        /// Número do logradouro do empregador
        /// </summary>
        public string numeroLogradouroEmpregador { get; set; }

        /// <summary>
        /// Data de admissão
        /// </summary>
        public DateTime? dataAdmissao { get; set; }

        /// <summary>
        /// Data de demissão
        /// </summary>
        public DateTime? dataDemissao { get; set; }

        /// <summary>
        /// DDD empregador
        /// </summary>
        public string dddEmpregador { get; set; }

        /// <summary>
        /// Telefone empregador
        /// </summary>
        public string telefoneEmpregador { get; set; }

        /// <summary>
        /// Ramal empregador
        /// </summary>
        public string ramalEmpregador { get; set; }

        /// <summary>
        /// CNPJ do empregador
        /// </summary>
        public string cnpjEmpregador { get; set; }

        /// <summary>
        /// Tipo de Empresa
        /// </summary>
        public string tipoEmpresa { get; set; }

        /// <summary>
        /// Identificador de renda conjugue
        /// </summary>
        public string identificadorRendaConjugue { get; set; }

        /// <summary>
        /// Identifica a renda corresp. empregador
        /// </summary>
        public string identificaRendaCorrespEmpregador { get; set; }

    }
}
