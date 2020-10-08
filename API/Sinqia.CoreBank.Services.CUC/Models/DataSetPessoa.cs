using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sinqia.CoreBank.Services.CUC.Models
{    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/DataSetPessoa.xsd", IsNullable = false)]
    public class DataSetPessoa
    {
        [System.Xml.Serialization.XmlElementAttribute("RegistroPessoa")]
        public DataSetPessoaRegistroPessoa[] RegistroPessoa { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroEndereco")]
        public DataSetPessoaRegistroEndereco[] RegistroEndereco { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroDocumento")]
        public DataSetPessoaRegistroDocumento[] RegistroDocumento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroPerfil")]
        public DataSetPessoaRegistroPerfil[] RegistroPerfil { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroReferencia")]
        public DataSetPessoaRegistroReferencia[] RegistroReferencia { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroPessoaSimplificada")]
        public DataSetPessoaRegistroPessoaSimplificada[] RegistroPessoaSimplificada { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroVinculo")]
        public DataSetPessoaRegistroVinculo[] RegistroVinculo { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroBalanco")]
        public DataSetPessoaRegistroBalanco[] RegistroBalanco { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroRenda")]
        public DataSetPessoaRegistroRendas[] RegistroRendas { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroNegocioBanco")]
        public DataSetNegocioRegistroOutrosBancos[] RegistroNegocioBanco { get; set; }

    }

    public class DataSetPessoaRegistroPessoa
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_abv_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string set_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string des_profissao { get; set; }
        [XmlElement(IsNullable = false)]
        public string est_civil { get; set; }
        [XmlElement(IsNullable = false)]
        public string com_bens { get; set; }
        [XmlElement(IsNullable = false)]
        public string sex_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string gra_instrucao { get; set; }
        [XmlElement(IsNullable = false)]
        public string fil_paterna { get; set; }
        [XmlElement(IsNullable = false)]
        public string fil_materna { get; set; }
        public int? num_dep { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool num_depSpecified { get { return this.num_dep != null; } }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        public DateTime? dat_fundacao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fundacaoSpecified { get { return this.dat_fundacao != null; } }
        public int? cod_atividade { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_atividadeSpecified { get { return this.cod_atividade != null; } }
        public int? cod_grpemp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_grpempSpecified { get { return this.cod_grpemp != null; } }
        public int? cod_municipio { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_municipioSpecified { get { return this.cod_municipio != null; } }
        [XmlElement(IsNullable = false)]
        public string des_municipio { get; set; }
        [XmlElement(IsNullable = false)]
        public string des_nacionalidade { get; set; }
        public DateTime? dat_naturalizacao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_naturalizacaoSpecified { get { return this.dat_naturalizacao != null; } }
        [XmlElement(IsNullable = false)]
        public string cod_cbo { get; set; }
        public int? cod_setor { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_setorSpecified { get { return this.cod_setor != null; } }
        public int? cod_subsetor { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_subsetorSpecified { get { return this.cod_subsetor != null; } }
        public int? cod_ramo { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_ramoSpecified { get { return this.cod_ramo != null; } }
        public int? cod_ramo_ativ { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_ramo_ativSpecified { get { return this.cod_ramo_ativ != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_constituicao { get; set; }
        [XmlElement(IsNullable = false)]
        public string niv_risco { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_func { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_segmento { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_subsegmento { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_classe { get; set; }
        public DateTime? dat_ren_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ren_cadSpecified { get { return this.dat_ren_cad != null; } }
        public DateTime? dat_ven_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ven_cadSpecified { get { return this.dat_ven_cad != null; } }
        public int? cod_tip { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_tipSpecified { get { return this.cod_tip != null; } }
        public int? cod_leg { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_legSpecified { get { return this.cod_leg != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_estrang { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_contato { get; set; }
        [XmlElement(IsNullable = false)]
        public string tel_contato { get; set; }
        [XmlElement(IsNullable = false)]
        public string ramal_contato { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_cons_risco { get; set; }
        [XmlElement(IsNullable = false)]
        public string cvmcod { get; set; }
        [XmlElement(IsNullable = false)]
        public string anbcod { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_pes { get; set; }
        public int? naccod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool naccodSpecified { get { return this.naccod != null; } }
        [XmlElement(IsNullable = false)]
        public string pessta { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidcimpedido { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidcpro { get; set; }
        public DateTime? pesdatsta { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pesdatstaSpecified { get { return this.pesdatsta != null; } }
        public int? rcfcodpro { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool rcfcodproSpecified { get { return this.rcfcodpro != null; } }
        [XmlElement(IsNullable = false)]
        public string pesstanom { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidcusucad { get; set; }
        public int? pescodPisPasep { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pescodPisPasepSpecified { get { return this.pescodPisPasep != null; } }
        public decimal? pestotvlrben { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pestotvlrbenSpecified { get { return this.pestotvlrben != null; } }
        public decimal? pesvalmedmen { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pesvalmedmenSpecified { get { return this.pesvalmedmen != null; } }
        [XmlElement(IsNullable = false)]
        public string pesidcposren { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidtlig { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidciof { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil { get; set; }
        [XmlElement(IsNullable = false)]
        public string bas_cgccpf { get; set; }
        [XmlElement(IsNullable = false)]
        public string fil_cgccpf { get; set; }
        [XmlElement(IsNullable = false)]
        public string dig_cgccpf { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_fil { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_isen_cgccpf { get; set; }
        [XmlElement(IsNullable = false)]
        public string til_Cpf { get; set; }
        [XmlElement(IsNullable = false)]
        public string ins_est { get; set; }
        [XmlElement(IsNullable = false)]
        public string ins_mun { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_dep { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_for { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_cli { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_sit_fil { get; set; }
        public DateTime? dat_cad1 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cad1Specified { get { return this.dat_cad1 != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu1 { get; set; }
        public DateTime? dat_atu1 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atu1Specified { get { return this.dat_atu1 != null; } }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        public int? cod_empresa { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_empresaSpecified { get { return this.cod_empresa != null; } }
        public int? cod_depend { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_dependSpecified { get { return this.cod_depend != null; } }
        public int? cod_oper { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_operSpecified { get { return this.cod_oper != null; } }
        public DateTime? dat_ini_gerente { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ini_gerenteSpecified { get { return this.dat_ini_gerente != null; } }
        public int? cli_cod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cli_codSpecified { get { return this.cli_cod != null; } }
        public int? cod_porte { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_porteSpecified { get { return this.cod_porte != null; } }
        public int? qtd_assinatura { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool qtd_assinaturaSpecified { get { return this.qtd_assinatura != null; } }
        [XmlElement(IsNullable = false)]
        public string end_home_page { get; set; }
        [XmlElement(IsNullable = false)]
        public string eml_fil_1 { get; set; }
        [XmlElement(IsNullable = false)]
        public string eml_fil_2 { get; set; }
        [XmlElement(IsNullable = false)]
        public string eml_fil_3 { get; set; }
        [XmlElement(IsNullable = false)]
        public string eml_fil_4 { get; set; }
        [XmlElement(IsNullable = false)]
        public string eml_fil_5 { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_isen_ir { get; set; }
        public int? cod_empresa_indic { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_empresa_indicSpecified { get { return this.cod_empresa_indic != null; } }
        public int? cod_oper_indic { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_oper_indicSpecified { get { return this.cod_oper_indic != null; } }
        [XmlElement(IsNullable = false)]
        public string cod_sist_origem { get; set; }
        [XmlElement(IsNullable = false)]
        public string observ { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_ispb { get; set; }
        public int? seq_Cnpj { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool seq_CnpjSpecified { get { return this.seq_Cnpj != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_corresp_age { get; set; }
        public DateTime? fildatsfn { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool fildatsfnSpecified { get { return this.fildatsfn != null; } }
        //[XmlElement(IsNullable = false)]
        //public string Cpf_conjuge { get; set; }
        //[XmlElement(IsNullable = false)]
        //public string nome_conjuge { get; set; }
        [XmlElement(IsNullable = false)]
        public string FILIDTNAORESIDE { get; set; }
        [XmlElement(IsNullable = false)]
        public string FILIDTRES2686 { get; set; }
        public int? FILCODNOVONAC { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool FILCODNOVONACSpecified { get { return this.FILCODNOVONAC != null; } }
        public DateTime? FILDATSAIDAPAIS { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool FILDATSAIDAPAISSpecified { get { return this.FILDATSAIDAPAIS != null; } }
        public int? natcod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool natcodSpecified { get { return this.natcod != null; } }
        public int? tip_imunidade { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool tip_imunidadeSpecified { get { return this.tip_imunidade != null; } }
        public DateTime? dat_reg_rbf { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_reg_rbfSpecified { get { return this.dat_reg_rbf != null; } }
        [XmlElement(IsNullable = false)]
        public string num_processo { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_vara { get; set; }
        public DateTime? dat_inicio { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_inicioSpecified { get { return this.dat_inicio != null; } }
        public DateTime? dat_fim { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fimSpecified { get { return this.dat_fim != null; } }
        [XmlElement(IsNullable = false)]
        public string STA_REGISTRO { get; set; }
        public int? cnaseq { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cnaseqSpecified { get { return this.cnaseq != null; } }
        [XmlElement(IsNullable = false)]
        public string pesidcFatca { get; set; }
        public int? PESNACIONALIDADE1 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESNACIONALIDADE1Specified { get { return this.PESNACIONALIDADE1 != null; } }
        public int? PESNACIONALIDADE2 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESNACIONALIDADE2Specified { get { return this.PESNACIONALIDADE2 != null; } }
        public int? PESNACIONALIDADE3 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESNACIONALIDADE3Specified { get { return this.PESNACIONALIDADE3 != null; } }
        public int? PESNACIONALIDADE4 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESNACIONALIDADE4Specified { get { return this.PESNACIONALIDADE4 != null; } }
        public int? PESDOMICILIO1 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESDOMICILIO1Specified { get { return this.PESDOMICILIO1 != null; } }
        public int? PESDOMICILIO2 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESDOMICILIO2Specified { get { return this.PESDOMICILIO2 != null; } }
        public int? PESDOMICILIO3 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESDOMICILIO3Specified { get { return this.PESDOMICILIO3 != null; } }
        public int? PESDOMICILIO4 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool PESDOMICILIO4Specified { get { return this.PESDOMICILIO4 != null; } }
        public int? SUNID { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool SUNIDSpecified { get { return this.SUNID != null; } }
        [XmlElement(IsNullable = false)]
        public string APELIDO1 { get; set; }
        [XmlElement(IsNullable = false)]
        public string APELIDO2 { get; set; }
        [XmlElement(IsNullable = false)]
        public string APELIDO3 { get; set; }
        [XmlElement(IsNullable = false)]
        public string IDC_SIMP { get; set; }
        [XmlElement(IsNullable = false)]
        public string CGCCpf_FORMATADO { get; set; }
        [XmlElement(IsNullable = false)]
        public string SIT_BEN { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_ope_pro { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_aut_tra { get; set; }
        [XmlElement(IsNullable = false)]
        public string pestipdec { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_cli_est { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_doc_est { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_doc_est { get; set; }
        public int? juscod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool juscodSpecified { get { return this.juscod != null; } }
        [XmlElement(IsNullable = false)]
        public string pesidcativoprob { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesjustificativa { get; set; }
        [XmlElement(IsNullable = false)]
        public string Cpf_Cnpj { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesnomcontato { get; set; }
        public int? pescodcargo { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pescodcargoSpecified { get { return this.pescodcargo != null; } }
        [XmlElement(IsNullable = false)]
        public string pesidcdeclarFatca1 { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidcdeclarFatca2 { get; set; }
        [XmlElement(IsNullable = false)]
        public string pesidcdomicilioext { get; set; }
        public int? pesnumfuncionarios { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pesnumfuncionariosSpecified { get { return this.pesnumfuncionarios != null; } }
        public int? pescodnaccapital { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pescodnaccapitalSpecified { get { return this.pescodnaccapital != null; } }
        public decimal? pesvalcapitalestr { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pesvalcapitalestrSpecified { get { return this.pesvalcapitalestr != null; } }
        public decimal? pesvalcapitalnac { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pesvalcapitalnacSpecified { get { return this.pesvalcapitalnac != null; } }
        [XmlElement(IsNullable = false)]
        public string pestipcapital { get; set; }
        public int? pescodatvcetip { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pescodatvcetipSpecified { get { return this.pescodatvcetip != null; } }
        [XmlElement(IsNullable = false)]
        public string circod { get; set; }
        [XmlElement(IsNullable = false)]
        public string pescoDDdi { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_social_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_isen_insc_estadual { get; set; }
        [XmlElement(IsNullable = false)]
        public string sgecod { get; set; }
        [XmlElement(IsNullable = false)]
        public string Pld_pes { get; set; }
        [XmlElement(IsNullable = false)]
        public string obs_Pld { get; set; }
        public int? cod_oper_ger { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_oper_gerSpecified { get { return this.cod_oper_ger != null; } }
        [XmlElement(IsNullable = false)]
        public string pesidciofadic { get; set; }
        public int? fil_rescod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool fil_rescodSpecified { get { return this.fil_rescod != null; } }
        [XmlElement(IsNullable = false)]
        public string cgccpf_formatado { get; set; }
        [XmlElement(IsNullable = false)]
        public string USU_ATU_IMU { get; set; }

    }

    public class DataSetPessoaRegistroEndereco
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil { get; set; }
        public int? cod_end { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_endSpecified { get { return this.cod_end != null; } }
        [XmlElement(IsNullable = false)]
        public string tip_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_log_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_log_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string cpl_log_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string bai_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string cep_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fone_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fone2_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fone3_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fone4_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string tel_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string tel_2_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string tel_3_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string tel_4_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_2_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_3_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_4_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_tel { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_tel2 { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_tel3 { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_tel4 { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fax_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fax2_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string Ddd_fax3_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string fax_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string fax_2_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string fax_3_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string eml_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_residencia { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_corresp { get; set; }
        public DateTime? dat_ini_end { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ini_endSpecified { get { return this.dat_ini_end != null; } }
        public DateTime? dat_fim_end { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fim_endSpecified { get { return this.dat_fim_end != null; } }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        public int? cod_municipio { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_municipioSpecified { get { return this.cod_municipio != null; } }
        [XmlElement(IsNullable = false)]
        public string des_municipio { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_log_end { get; set; }
        [XmlElement(IsNullable = false)]
        public string idt_naocorresp { get; set; }
        [XmlElement(IsNullable = false)]
        public string motcod { get; set; }
        [XmlElement(IsNullable = false)]
        public string sta_registro { get; set; }
        [XmlElement(IsNullable = false)]
        public string endidcestrang { get; set; }
        public int? endcodpais { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool endcodpaisSpecified { get { return this.endcodpais != null; } }

    }

    public class DataSetPessoaRegistroDocumento
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_doc { get; set; }
        public DateTime? dat_expedicao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_expedicaoSpecified { get { return this.dat_expedicao != null; } }
        [XmlElement(IsNullable = false)]
        public string org_expedidor { get; set; }
        [XmlElement(IsNullable = false)]
        public string obs_doc { get; set; }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        [XmlElement(IsNullable = false)]
        public string tip_doc { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_federacao { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_imp_cheque { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_microemp { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_comprovado { get; set; }
        public int? crecod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dcrecodSpecified { get { return this.crecod != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_preposto { get; set; }
        public DateTime? dat_venc { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_vencSpecified { get { return this.dat_venc != null; } }
        public int? naccod { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool naccodSpecified { get { return this.naccod != null; } }
    }

    public class DataSetPessoaRegistroPerfil
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_perfil { get; set; }

    }

    public class DataSetPessoaRegistroReferencia
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_tit { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil_tit { get; set; }
        public int? seq_ref { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool seq_refSpecified { get { return this.seq_ref != null; } }
        [XmlElement(IsNullable = false)]
        public string tip_ref { get; set; }
        [XmlElement(IsNullable = false)]
        public string obs_ref { get; set; }
        public decimal? num_cartao_ref { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool num_cartao_refSpecified { get { return this.num_cartao_ref != null; } }
        public decimal? val_lim_ref { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool val_lim_refSpecified { get { return this.val_lim_ref != null; } }
        public DateTime? dat_ini_emprego { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ini_empregoSpecified { get { return this.dat_ini_emprego != null; } }
        public DateTime? dat_fim_emprego { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fim_empregoSpecified { get { return this.dat_fim_emprego != null; } }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        public int? cod_cartao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_cartaoSpecified { get { return this.cod_cartao != null; } }
        public int? cod_segur { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_segurSpecified { get { return this.cod_segur != null; } }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_ref { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil_ref { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_simp { get; set; }
        public DateTime? dat_venc_seg_cartao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_venc_seg_cartaoSpecified { get { return this.dat_venc_seg_cartao != null; } }

    }

    public class DataSetPessoaRegistroPessoaSimplificada
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string ddd_fone_1_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string ddd_fone_2_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone_1_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone_2_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_fone_1_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_fone_2_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_fone_1_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string sit_fone_2_simp { get; set; }
        public DateTime? dat_nasc_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_nasc_simpSpecified { get { return this.dat_nasc_simp != null; } }
        [XmlElement(IsNullable = false)]
        public string obs_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_simp { get; set; }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        public int? cod_mun_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_mun_simpSpecified { get { return this.cod_mun_simp != null; } }
        [XmlElement(IsNullable = false)]
        public string des_mun_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_log_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string des_log_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string cpl_end_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string bai_end_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_end_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string uf_end_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string pais_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string cep_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string est_civ_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string reg_com_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_conj_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_ava_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string cpf_cnpj_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_pes_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_isen_cpf_cnpf_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string pescodsisorigem { get; set; }
        [XmlElement(IsNullable = false)]
        public string pescpfconj { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_fatca { get; set; }
        [XmlElement(IsNullable = false)]
        public string rg_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string nif_simp { get; set; }
        public int? nac1_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool nac1_simpSpecified { get { return this.nac1_simp != null; } }
        public int? nac2_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool nac2_simpSpecified { get { return this.nac2_simp != null; } }
        public int? nac3_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool nac3_simpSpecified { get { return this.nac3_simp != null; } }
        public int? nac4_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool nac4_simpSpecified { get { return this.nac4_simp != null; } }
        public int? dom_fis1_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dom_fis1_simpSpecified { get { return this.dom_fis1_simp != null; } }
        public int? dom_fis2_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dom_fis2_simpSpecified { get { return this.dom_fis2_simp != null; } }
        public int? dom_fis3_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dom_fis3_simpSpecified { get { return this.dom_fis3_simp != null; } }
        public int? dom_fis4_simp { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dom_fis4_simpSpecified { get { return this.dom_fis4_simp != null; } }
        [XmlElement(IsNullable = false)]
        public string ddd_cel_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string fone_cel_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string email { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_cli_est { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_doc_est { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_doc_est { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_social_simp { get; set; }
        [XmlElement(IsNullable = false)]
        public string pld_pes { get; set; }
        [XmlElement(IsNullable = false)]
        public string obs_pld { get; set; }

    }
    public class DataSetPessoaRegistroVinculo
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_jur { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil_jur { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_fis { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil_fis { get; set; }
        public int? seq_vinculo { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool seq_vinculoSpecified { get { return this.seq_vinculo != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_partcipacao { get; set; }
        public decimal? pct_participacao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool pct_participacaoSpecified { get { return this.pct_participacao != null; } }
        public DateTime? dat_posse { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_posseSpecified { get { return this.dat_posse != null; } }
        [XmlElement(IsNullable = false)]
        public string tmp_mandato { get; set; }
        [XmlElement(IsNullable = false)]
        public string des_vinc_fisjur { get; set; }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        public int? cod_cargo { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_cargoSpecified { get { return this.cod_cargo != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_assina { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_contato { get; set; }
        public DateTime? dat_fim { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fimSpecified { get { return this.dat_fim != null; } }
        [XmlElement(IsNullable = false)]
        public string cod_vinculo { get; set; }
        public DateTime? dat_venc_proc { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_venc_procSpecified { get { return this.dat_venc_proc != null; } }
        public DateTime? tmp_mandato_1 { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool tmp_mandato_1Specified { get { return this.tmp_mandato_1 != null; } }
        public DateTime? dat_fim_mandato { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fim_mandatoSpecified { get { return this.dat_fim_mandato != null; } }
        [XmlElement(IsNullable = false)]
        public string nom_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string cpf_cnpj_soc { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_pes_soc { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_emite_dupl { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_assina_endosso { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_assina_cessao { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_assina_isoladamente { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_assina1 { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_assina2 { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa_assina3 { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_assina1 { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_assina2 { get; set; }
        [XmlElement(IsNullable = false)]
        public string nom_assina3 { get; set; }
        [XmlElement(IsNullable = false)]
        public string fisjuremailvinculo { get; set; }
    }

    public class DataSetPessoaRegistroBalanco
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        public DateTime? ano_balanco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool ano_balancoSpecified { get { return this.ano_balanco != null; } }
        public int? seq_balanco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool seq_balancoSpecified { get { return this.seq_balanco != null; } }
        public DateTime? dat_ini_balanco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ini_balancoSpecified { get { return this.dat_ini_balanco != null; } }
        public DateTime? dat_fim_balanco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fim_balancoSpecified { get { return this.dat_fim_balanco != null; } }
        [XmlElement(IsNullable = false)]
        public string des_balanco { get; set; }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        [XmlElement(IsNullable = false)]
        public string cod_ind { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_detalhe { get; set; }
        public decimal? val_analisado { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool val_analisadoSpecified { get { return this.val_analisado != null; } }


    }

    public class DataSetPessoaRegistroRendas
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        public int? num_renda { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool num_rendaSpecified { get { return this.num_renda != null; } }
        public decimal? val_renda { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool val_rendaSpecified { get { return this.val_renda != null; } }
        [XmlElement(IsNullable = false)]
        public string nom_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string crg_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_log_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string end_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string cpl_log_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string bai_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string cep_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string per_renda { get; set; }
        public DateTime? dat_vld_renda { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_vld_rendaSpecified { get { return this.dat_vld_renda != null; } }
        [XmlElement(IsNullable = false)]
        public string obs_renda { get; set; }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool ddat_atuSpecified { get { return this.dat_atu != null; } }
        [System.Xml.Serialization.XmlIgnore]
        public bool ddat_atuSpecifiedSpecified { get { return this.ddat_atuSpecified != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitdSpecified { get { return this.dat_sit != null; } }
        public int? tip_renda { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool tip_rendaSpecified { get { return this.tip_renda != null; } }
        public int? cod_municipio { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_municipioSpecified { get { return this.cod_municipio != null; } }
        [XmlElement(IsNullable = false)]
        public string cod_ind { get; set; }
        [XmlElement(IsNullable = false)]
        public string num_log_empreg { get; set; }
        public DateTime? dat_admissao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_admissaooSpecified { get { return this.dat_admissao != null; } }
        public DateTime? dat_demissao { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_demissaoSpecified { get { return this.dat_demissao != null; } }
        [XmlElement(IsNullable = false)]
        public string ddd_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string tel_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string ram_empreg { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_cnpj { get; set; }
        [XmlElement(IsNullable = false)]
        public string tip_emp { get; set; }
        [XmlElement(IsNullable = false)]
        public string renidtrencon { get; set; }
        [XmlElement(IsNullable = false)]
        public string renidtemp { get; set; }
    }

    public class DataSetNegocioRegistroOutrosBancos
    {
        [XmlElement(IsNullable = false)]
        public string statuslinha { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_pessoa { get; set; }
        [XmlElement(IsNullable = false)]
        public string cod_fil { get; set; }
        public int? seq_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool seq_negbcoSpecified { get { return this.seq_negbco != null; } }
        public int? cod_age_negbco { get; set; }///
        [System.Xml.Serialization.XmlIgnore]///
        public bool cod_age_negbcoSpecified { get { return this.cod_age_negbco != null; } }///
        [XmlElement(IsNullable = false)]///
        public string num_negbco { get; set; }///
        public decimal? val_limite_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool val_limite_negbcoSpecified { get { return this.val_limite_negbco != null; } }
        public decimal? val_dev_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool val_dev_negbcoSpecified { get { return this.val_dev_negbco != null; } }
        public DateTime? dat_ini_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_ini_negbcooSpecified { get { return this.dat_ini_negbco != null; } }
        public DateTime? dat_fim_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_fim_negbcoSpecified { get { return this.dat_fim_negbco != null; } }
        public DateTime? dat_cad { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_cadSpecified { get { return this.dat_cad != null; } }
        [XmlElement(IsNullable = false)]
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_atuSpecified { get { return this.dat_atu != null; } }
        public DateTime? dat_sit { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool dat_sitSpecified { get { return this.dat_sit != null; } }
        [XmlElement(IsNullable = false)]
        public string idc_sit { get; set; }
        public int? cod_empresa { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_empresaSpecified { get { return this.cod_empresa != null; } }
        public int? cod_prodbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_prodbcoSpecified { get { return this.cod_prodbco != null; } }
        public int? cod_bco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_bcoSpecified { get { return this.cod_bco != null; } }
        public int? cod_bco_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_bco_negbcoSpecified { get { return this.cod_bco_negbco != null; } }
        [XmlElement(IsNullable = false)]
        public string COD_CTA_RESGATE { get; set; }
        [XmlElement(IsNullable = false)]
        public string STA_REGISTRO { get; set; }
        [XmlElement(IsNullable = false)]
        public string NEGIDCBCO { get; set; }
        [XmlElement(IsNullable = false)]
        public string NEGCODISPB { get; set; }
        public decimal? IPGCOD { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool IPGCODSpecified { get { return this.IPGCOD != null; } }
        [XmlElement(IsNullable = false)]
        public string NEGSTACONTAPADRAO { get; set; }

    }
}
