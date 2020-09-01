using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgPessoa
    {
        public MsgHeader header { get; set; }
        public MsgRegistroPessoaBody body { get; set; }
    }

    public class MsgRegistroPessoaBody
    {
        public MsgRegistropessoa RegistroPessoa { get; set; }
    }

    public class MsgRegistropessoa
    {
        public string codigoPessoa { get; set; }
        public string nomePessoa { get; set; }
        public string nomeAbvPessoa { get; set; }
        public string setorAtividade { get; set; }
        public string descricaoProfissao { get; set; }
        public string estadoCivil { get; set; }
        public string regimeComunhao { get; set; }
        public string sexoPessoa { get; set; }
        public string grauInstrucao { get; set; }
        public string nomePai { get; set; }
        public string nomeMae { get; set; }
        public int qtdeDependentes { get; set; }
        public string dataCadastro { get; set; }
        public string usuarioAtualizacao { get; set; }
        public string dataAtualizacao { get; set; }
        public string dataFundacao { get; set; }
        public int codigoAtividade { get; set; }
        public int codigoGrupoEmpresarial { get; set; }
        public float codigoMunicipio { get; set; }
        public string descricaoMunicipio { get; set; }
        public string descricaoNacionalidade { get; set; }
        public string dataNaturalizacao { get; set; }
        public string codigoCbo { get; set; }
        public float codigoSetor { get; set; }
        public float codigoSubsetor { get; set; }
        public float codigoRamo { get; set; }
        public float codigoRamoAtiv { get; set; }
        public string indicadorConstituicao { get; set; }
        public string nivelRisco { get; set; }
        public string indicadorfuncionario { get; set; }
        public string codigoSegmento { get; set; }
        public string codigoSubsegmento { get; set; }
        public string codigoClasse { get; set; }
        public string dataRenovacao { get; set; }
        public string dataVencimento { get; set; }
        public float codigoTipo { get; set; }
        public float codigoclassificacaoLegal { get; set; }
        public string indicadorEstrangeiro { get; set; }
        public string codigoDddContato { get; set; }
        public string telefoneContato { get; set; }
        public string numeroRamalContato { get; set; }
        public string indicadorConsRisco { get; set; }
        public string codigoCvm { get; set; }
        public string codigoAnbid { get; set; }
        public string tipoPessoa { get; set; }
        public float codigoNacionalidade { get; set; }
        public string indicadorSituacaoCadastral { get; set; }
        public string indicadorImpedidoOperar { get; set; }
        public string indicadorCnpjCpfVerificado { get; set; }
        public string dataConsulta { get; set; }
        public float numeroProcuracao { get; set; }
        public string nomeDivergente { get; set; }
        public string usuarioCadastro { get; set; }
        public float codigoPisPasep { get; set; }
        public float valorTotalBens { get; set; }
        public float valorRendaMensal { get; set; }
        public string indicadorPosuiRenda { get; set; }
        public string pessoaLigada { get; set; }
        public string indicadorCobrancaIOf { get; set; }
        public string codigoFilial { get; set; }
        public string codigoCpfCnpjBase { get; set; }
        public string codigoCpfCnpjFilial { get; set; }
        public string codigoCpfCnpjDigito { get; set; }
        public string tipoPessoaFilial { get; set; }
        public string indicadorIsencaoCpf { get; set; }
        public string CpfTitular { get; set; }
        public string inscricaoEstadualTitular { get; set; }
        public string inscricaoMunicipalTitular { get; set; }
        public string indicadorDependente { get; set; }
        public string indicadorFornecedor { get; set; }
        public string indicadorCliente { get; set; }
        public string indicadorSituacaoFilial { get; set; }
        public string dataCadastro1 { get; set; }
        public string usuarioAtualizacao1 { get; set; }
        public string dataAtualizacao1 { get; set; }
        public string dataSituacao { get; set; }
        public float codigoEmpresa { get; set; }
        public float codigoDependente { get; set; }
        public float codigoOperador { get; set; }
        public string dataInicialGerente { get; set; }
        public float codigoCliente { get; set; }
        public float codigoPorte { get; set; }
        public int qtdAssinaturas { get; set; }
        public string enderecoHomePage { get; set; }
        public string email1 { get; set; }
        public string email2 { get; set; }
        public string email3 { get; set; }
        public string email4 { get; set; }
        public string email5 { get; set; }
        public string indicadorIsencaoIr { get; set; }
        public float codigoEmpresaIndic { get; set; }
        public float codigoOperIndic { get; set; }
        public string codigoSistemaOrigem { get; set; }
        public string obs { get; set; }
        public string codigoIspb { get; set; }
        public float sequencialCnpjDuplicado { get; set; }
        public string indicadorCorrespAgencia { get; set; }
        public string dataInicioSfn { get; set; }
        public string CpfConjugue { get; set; }
        public string nomeConjugue { get; set; }
        public string indicadorNaoResidente { get; set; }
        public string indicadorRes2686 { get; set; }
        public int codigoNovaNacionalidade { get; set; }
        public string dataSaídaPais { get; set; }
        public float codigoNatureza { get; set; }
        public float tipoImunidade { get; set; }
        public string dataRegistroRbf { get; set; }
        public string numeroProcesso { get; set; }
        public string numeroVara { get; set; }
        public string dataInicio { get; set; }
        public string dataFim { get; set; }
        public string indicadorSituacaoRegistro { get; set; }
        public float codigoCnae2 { get; set; }
        public string indicadorClienteFatca { get; set; }
        public float codigoNacionalidade1 { get; set; }
        public float codigoNacionalidade2 { get; set; }
        public float codigoNacionalidade3 { get; set; }
        public float codigoNacionalidade4 { get; set; }
        public float codigoDomicilio1 { get; set; }
        public float codigoDomicilio2 { get; set; }
        public float codigoDomicilio3 { get; set; }
        public float codigoDomicilio4 { get; set; }
        public float sUnid { get; set; }
        public string apelido1 { get; set; }
        public string apelido2 { get; set; }
        public string apelido3 { get; set; }
        public string indicadorOptanteSimples { get; set; }
        public string CpfFormatado { get; set; }
        public string situacaoBeneficiario { get; set; }
        public string indicadorOperaContaPropria { get; set; }
        public string indicadorTransmissaoProcurador { get; set; }
        public string tipoDeclarado { get; set; }
        public string indicadorClienteEstrangeiro { get; set; }
        public string tipoDocumentoEstrangeiro { get; set; }
        public string numeroDocumentoEstrangeiro { get; set; }
        public int codigoJustificativa { get; set; }
        public string indicadorAtivo { get; set; }
        public string pesjustificativa { get; set; }
        public string CpfCnpj { get; set; }
        public string nomeContato { get; set; }
        public float codigoCargo { get; set; }
        public string indicadorDeclaracaoFatca1 { get; set; }
        public string indicadorDeclaracaoFatca2 { get; set; }
        public string indicadorDomicilioExterno { get; set; }
        public float numeroFuncionarios { get; set; }
        public float codigoNacCapital { get; set; }
        public float valorCapitalEstrangeiro { get; set; }
        public float valorCapitalNacional { get; set; }
        public string tipoCapital { get; set; }
        public string codigoClasseEconomicaCetip { get; set; }
        public string codigoIdentificadorRacial { get; set; }
        public string codigoDdi { get; set; }
        public string nomeSocialPessoa { get; set; }
        public string indicadorIsencaoInscricaoEstadual { get; set; }
        public string codigoSubgrupoEmpresarial { get; set; }
        public string nivelRiscoPld { get; set; }
        public string observacaoPld { get; set; }
        public float codigoGerente { get; set; }
        public MsgRegistroperfil[] RegistroPerfil { get; set; }
        public MsgRegistrodocumento[] RegistroDocumento { get; set; }
        public MsgRegistroendereco[] RegistroEndereco { get; set; }
        public MsgRegistroreferencia[] RegistroReferencia { get; set; }
    }
}