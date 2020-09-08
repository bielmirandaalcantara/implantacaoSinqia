using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgPessoa
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
        public MsgRegistroPessoaBody body { get; set; }
    }

    public class MsgRegistroPessoaBody
    {
        public MsgRegistropessoa RegistroPessoa { get; set; }
    }

    public class MsgRegistroPessoaBodyLista
    {
        public MsgRegistropessoa[] RegistroPessoa { get; set; }
    }
    /// <summary>
    /// Possibilita o cadastramento de dados referentes às informações mínimas necessárias para se cadastrar pessoas físicas e jurídicas. 
    /// </summary>
    public class MsgRegistropessoa
    {
        /// <summary>
        /// Código
        /// </summary>
        [Required]
        public string codigoPessoa { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required]
        public string nomePessoa { get; set; }

        /// <summary>
        /// Abreviação
        /// </summary>
        [Required]
        public string nomeAbvPessoa { get; set; }

        /// <summary>
        /// Setor Atividade
        /// </summary>
        [Required]
        public string setorAtividade { get; set; }

        /// <summary>
        /// Profissão
        /// </summary>
        public string descricaoProfissao { get; set; }

        /// <summary>
        /// Estado Civil
        /// </summary>
        public string estadoCivil { get; set; }

        /// <summary>
        /// Regime Comunhão
        /// </summary>
        public string regimeComunhao { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        public string sexoPessoa { get; set; }

        /// <summary>
        /// Grau de Instrução
        /// </summary>
        public string grauInstrucao { get; set; }

        /// <summary>
        /// Pai
        /// </summary>
        public string nomePai { get; set; }

        /// <summary>
        /// Mãe
        /// </summary>
        public string nomeMae { get; set; }

        /// <summary>
        /// Dependentes
        /// </summary>
        public int qtdeDependentes { get; set; }

        /// <summary>
        /// Data Cadastro
        /// </summary>
        [Required]
        public DateTime dataCadastro { get; set; }

        /// <summary>
        /// Usuário Última Atualização
        /// </summary>
        [Required]
        public string usuarioAtualizacao { get; set; }

        /// <summary>
        /// Data Atualização
        /// </summary>
        [Required]
        public DateTime dataAtualizacao { get; set; }

        /// <summary>
        /// Data Nascimento/Fundação
        /// </summary>
        [Required]
        public DateTime dataFundacao { get; set; }

        /// <summary>
        /// Ativ. Class. Gerencial
        /// </summary>
        public int codigoAtividade { get; set; }

        /// <summary>
        /// Grupo Empresarial
        /// </summary>
        public int codigoGrupoEmpresarial { get; set; }

        /// <summary>
        /// Natural De
        /// </summary>
        public decimal codigoMunicipio { get; set; }

        /// <summary>
        /// Natural De
        /// </summary>
        public string descricaoMunicipio { get; set; }

        /// <summary>
        /// Nacionalidade
        /// </summary>
        public string descricaoNacionalidade { get; set; }

        /// <summary>
        /// Data Naturalização
        /// </summary>
        public DateTime dataNaturalizacao { get; set; }

        /// <summary>
        /// Profissão Class. CBO
        /// </summary>
        public string codigoCbo { get; set; }

        /// <summary>
        /// Ativ. Class. CNAE
        /// </summary>
        public int codigoSetor { get; set; }

        /// <summary>
        /// Ativ. Class. CNAE
        /// </summary>
        public int codigoSubsetor { get; set; }

        /// <summary>
        /// Ativ. Class. CNAE
        /// </summary>
        public int codigoRamo { get; set; }

        /// <summary>
        /// Ativ. Class. CNAE
        /// </summary>
        public int codigoRamoAtiv { get; set; }

        /// <summary>
        /// Constituição
        /// </summary>
        public string indicadorConstituicao { get; set; }

        /// <summary>
        /// Nível Risco
        /// </summary>
        public string nivelRisco { get; set; }

        /// <summary>
        /// Funcionário
        /// </summary>
        public string indicadorfuncionario { get; set; }

        /// <summary>
        /// Segmento
        /// </summary>
        public string codigoSegmento { get; set; }

        /// <summary>
        /// Sub Segmento
        /// </summary>
        public string codigoSubsegmento { get; set; }

        /// <summary>
        /// Classe
        /// </summary>
        public string codigoClasse { get; set; }

        /// <summary>
        /// Renovação
        /// </summary>
        public DateTime dataRenovacao { get; set; }

        /// <summary>
        /// Vencimento
        /// </summary>
        public DateTime dataVencimento { get; set; }

        /// <summary>
        /// Tipo
        /// </summary>
        public int codigoTipo { get; set; }

        /// <summary>
        /// Classificação Legal
        /// </summary>
        public int codigoclassificacaoLegal { get; set; }

        /// <summary>
        /// Estrangeiro
        /// </summary>
        public string indicadorEstrangeiro { get; set; }

        /// <summary>
        /// Telefone Para Contato (DDD)
        /// </summary>
        public string codigoDddContato { get; set; }

        /// <summary>
        /// Telefone Para Contato
        /// </summary>
        public string telefoneContato { get; set; }

        /// <summary>
        /// Ramal
        /// </summary>
        public string numeroRamalContato { get; set; }

        /// <summary>
        /// Idc. Cons. Risco
        /// </summary>
        public string indicadorConsRisco { get; set; }

        /// <summary>
        /// Classificação CVM
        /// </summary>
        public string codigoCvm { get; set; }

        /// <summary>
        /// Classificação ANBID
        /// </summary>
        public string codigoAnbid { get; set; }

        /// <summary>
        /// Tipo Pessoa
        /// </summary>
        public string tipoPessoa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacionalidade { get; set; }

        /// <summary>
        /// Situação Cadastral CPF
        /// </summary>
        public string indicadorSituacaoCadastral { get; set; }

        /// <summary>
        /// Impedido de Operar
        /// </summary>
        public string indicadorImpedidoOperar { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorCnpjCpfVerificado { get; set; }

        /// <summary>
        /// Data Consulta
        /// </summary>
        public DateTime dataConsulta { get; set; }

        /// <summary>
        /// Número Procuração
        /// </summary>
        public int numeroProcuracao { get; set; }

        /// <summary>
        /// Nome Divergente
        /// </summary>
        public string nomeDivergente { get; set; }

        /// <summary>
        /// Usuário
        /// </summary>
        public string usuarioCadastro { get; set; }

        /// <summary>
        /// PIS/PASEP
        /// </summary>
        public int codigoPisPasep { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal valorTotalBens { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal valorRendaMensal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorPosuiRenda { get; set; }

        /// <summary>
        /// Pessoa Ligada
        /// </summary>
        public string pessoaLigada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorCobrancaIOf { get; set; }

        /// <summary>
        /// Filial
        /// </summary>
        public string codigoFilial { get; set; }

        /// <summary>
        /// CPF/CNPJ (Base)
        /// </summary>
        [Required]
        public string codigoCpfCnpjBase { get; set; }

        /// <summary>
        /// CPF/CNPJ (Filial)
        /// </summary>
        [Required]
        public string codigoCpfCnpjFilial { get; set; }

        /// <summary>
        /// CPF/CNPJ (Dígito)
        /// </summary>
        [Required]
        public string codigoCpfCnpjDigito { get; set; }

        /// <summary>
        /// Tipo Pessoa
        /// </summary>
        public string tipoPessoaFilial { get; set; }

        /// <summary>
        /// Isento CPF
        /// </summary>
        public string indicadorIsencaoCpf { get; set; }

        /// <summary>
        /// Titularidade
        /// </summary>
        public string CpfTitular { get; set; }

        /// <summary>
        /// Inscrição Estadual
        /// </summary>
        public string inscricaoEstadualTitular { get; set; }

        /// <summary>
        /// Inscrição Municipal
        /// </summary>
        public string inscricaoMunicipalTitular { get; set; }

        /// <summary>
        /// Idc Dependente
        /// </summary>
        public string indicadorDependente { get; set; }

        /// <summary>
        /// Idc Fornecedor
        /// </summary>
        public string indicadorFornecedor { get; set; }

        /// <summary>
        /// Idc Cliente
        /// </summary>
        public string indicadorCliente { get; set; }

        /// <summary>
        /// Situação
        /// </summary>
        [Required]
        public string indicadorSituacaoFilial { get; set; }

        /// <summary>
        /// Data Cadastro
        /// </summary>
        [Required]
        public DateTime dataCadastro1 { get; set; }

        /// <summary>
        /// Usuário Atualização
        /// </summary>
        [Required]
        public string usuarioAtualizacao1 { get; set; }

        /// <summary>
        /// Data Atualização
        /// </summary>
        [Required]
        public DateTime dataAtualizacao1 { get; set; }

        /// <summary>
        /// Data Situação
        /// </summary>
        [Required]
        public DateTime dataSituacao { get; set; }

        /// <summary>
        /// Gerente
        /// </summary>
        [Required]
        public int codigoEmpresa { get; set; }

        /// <summary>
        /// Gerente
        /// </summary>
        [Required]
        public int codigoDependente { get; set; }

        /// <summary>
        /// Gerente
        /// </summary>
        [Required]
        public int codigoOperador { get; set; }

        /// <summary>
        /// Data Início Gerente
        /// </summary>
        [Required]
        public DateTime dataInicialGerente { get; set; }

        /// <summary>
        /// Código Cliente
        /// </summary>
        [Required]
        public int codigoCliente { get; set; }

        /// <summary>
        /// Porte
        /// </summary>
        public int codigoPorte { get; set; }

        /// <summary>
        /// Quantidade Assinaturas
        /// </summary>
        public int qtdAssinaturas { get; set; }

        /// <summary>
        /// Home Page
        /// </summary>
        public string enderecoHomePage { get; set; }

        /// <summary>
        /// E-mail 1
        /// </summary>
        public string email1 { get; set; }

        /// <summary>
        /// E-mail 2
        /// </summary>
        public string email2 { get; set; }

        /// <summary>
        /// E-mail 3
        /// </summary>
        public string email3 { get; set; }

        /// <summary>
        /// E-mail 4
        /// </summary>
        public string email4 { get; set; }

        /// <summary>
        /// E-mail 5
        /// </summary>
        public string email5 { get; set; }

        /// <summary>
        /// Isento IR
        /// </summary>
        public string indicadorIsencaoIr { get; set; }

        /// <summary>
        /// Indicado Por
        /// </summary>
        public int codigoEmpresaIndic { get; set; }

        /// <summary>
        /// Indicado Por
        /// </summary>
        public int codigoOperIndic { get; set; }

        /// <summary>
        /// Código Sistema Origem
        /// </summary>
        public string codigoSistemaOrigem { get; set; }

        /// <summary>
        /// observacao
        /// </summary>
        public string obs { get; set; }

        /// <summary>
        /// Cod. ISPB
        /// </summary>
        public string codigoIspb { get; set; }

        /// <summary>
        /// Sequência CNPJ
        /// </summary>
        public int sequencialCnpjDuplicado { get; set; }

        /// <summary>
        /// Envio Carnê Agência
        /// </summary>
        public string indicadorCorrespAgencia { get; set; }

        /// <summary>
        /// Data SFN
        /// </summary>
        public DateTime dataInicioSfn { get; set; }

 
        //public string CpfConjugue { get; set; }

      
        //public string nomeConjugue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorNaoResidente { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorRes2686 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNovaNacionalidade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataSaídaPais { get; set; }

        //public int codigoNatureza { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int tipoImunidade { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataRegistroRbf { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroProcesso { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string numeroVara { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataInicio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime dataFim { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorSituacaoRegistro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoCnae2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorClienteFatca { get; set; }

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
        public int codigoDomicilio1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilio2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilio3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoDomicilio4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int sUnid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string apelido1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string apelido2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string apelido3 { get; set; }

        /// <summary>
        /// Optante Simples
        /// </summary>
        public string indicadorOptanteSimples { get; set; }

        //public string CpfFormatado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string situacaoBeneficiario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorOperaContaPropria { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorTransmissaoProcurador { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoDeclarado { get; set; }

 
       //public string indicadorClienteEstrangeiro { get; set; }

        //public string tipoDocumentoEstrangeiro { get; set; }

        //public string numeroDocumentoEstrangeiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoJustificativa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorAtivo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string pesjustificativa { get; set; }

        /// <summary>
        /// 
        /// </summary>
        //public string cpfCnpj { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nomeContato { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoCargo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorDeclaracaoFatca1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorDeclaracaoFatca2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string indicadorDomicilioExterno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int numeroFuncionarios { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoNacCapital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal valorCapitalEstrangeiro { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal valorCapitalNacional { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string tipoCapital { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoClasseEconomicaCetip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string codigoIdentificadorRacial { get; set; }

        //public string codigoDdi { get; set; }

        /*
        /// <summary>
        /// NomeSocial
        /// </summary>
        public string nomeSocialPessoa { get; set; }
        */

        /*
        /// <summary>
        /// Isento Inscricao Estadual
        /// </summary>
        public string indicadorIsencaoInscricaoEstadual { get; set; }
        */

        /// <summary>
        /// 
        /// </summary>
        public string codigoSubgrupoEmpresarial { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string nivelRiscoPld { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string observacaoPld { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int codigoGerente { get; set; }

        /// <summary>
        /// Indicador de cobrança de IOF Adicional 
        /// </summary>
        public string indicadorCobrancaIofAdicional { get; set; }

        /// <summary>
        /// Centro de Resultado 
        /// </summary>
        public int codigoCestroResultado { get; set; }

        /// <summary>
        /// CPF ou CNPJ Formatado 
        /// </summary>
        public string cpfCnpjFormatado { get; set; }

    }
}