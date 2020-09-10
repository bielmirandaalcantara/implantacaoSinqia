using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Models
{    
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/DataSetPessoa.xsd", IsNullable = false)]
    public class DataSetPessoa
    {
        public DataSetPessoaRegistroPessoa RegistroPessoa { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroEndereco")]
        public DataSetPessoaRegistroEndereco[] RegistroEndereco { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroDocumento")]
        public DataSetPessoaRegistroDocumento[] RegistroDocumento { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroPerfil")]
        public DataSetPessoaRegistroPerfil[] RegistroPerfil { get; set; }

        [System.Xml.Serialization.XmlElementAttribute("RegistroReferencia")]
        public DataSetPessoaRegistroReferencia[] RegistroReferencia { get; set; }
    }

    public class DataSetPessoaRegistroPessoa
    {
        public string cod_pessoa { get; set; }
        public string nom_pessoa { get; set; }
        public string nom_abv_pessoa { get; set; }
        public string set_pessoa { get; set; }
        public string des_profissao { get; set; }
        public string est_civil { get; set; }
        public string com_bens { get; set; }
        public string sex_pessoa { get; set; }
        public string gra_instrucao { get; set; }
        public string fil_paterna { get; set; }
        public string fil_materna { get; set; }
        public int num_dep { get; set; }
        public DateTime dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime dat_atu { get; set; }
        public DateTime dat_fundacao { get; set; }
        public int cod_atividade { get; set; }
        public int cod_grpemp { get; set; }
        public int cod_municipio { get; set; }
        public string des_municipio { get; set; }
        public string des_nacionalidade { get; set; }
        public DateTime dat_naturalizacao { get; set; }
        public string cod_cbo { get; set; }
        public int cod_setor { get; set; }
        public int cod_subsetor { get; set; }
        public int cod_ramo { get; set; }
        public int cod_ramo_ativ { get; set; }
        public string idc_constituicao { get; set; }
        public string niv_risco { get; set; }
        public string idc_func { get; set; }
        public string cod_segmento { get; set; }
        public string cod_subsegmento { get; set; }
        public string cod_classe { get; set; }
        public DateTime dat_ren_cad { get; set; }
        public DateTime dat_ven_cad { get; set; }
        public int cod_tip { get; set; }
        public int cod_leg { get; set; }
        public string idc_estrang { get; set; }
        public string Ddd_contato { get; set; }
        public string tel_contato { get; set; }
        public string ramal_contato { get; set; }
        public string idc_cons_risco { get; set; }
        public string cvmcod { get; set; }
        public string anbcod { get; set; }
        public string tip_pes { get; set; }
        public int naccod { get; set; }
        public string pessta { get; set; }
        public string pesidcimpedido { get; set; }
        public string pesidcpro { get; set; }
        public DateTime pesdatsta { get; set; }
        public int rcfcodpro { get; set; }
        public string pesstanom { get; set; }
        public string pesidcusucad { get; set; }
        public int pescodPisPasep { get; set; }
        public decimal pestotvlrben { get; set; }
        public decimal pesvalmedmen { get; set; }
        public string pesidcposren { get; set; }
        public string pesidtlig { get; set; }
        public string pesidciof { get; set; }
        public string cod_fil { get; set; }
        public string bas_cgcCpf { get; set; }
        public string fil_cgcCpf { get; set; }
        public string dig_cgcCpf { get; set; }
        public string tip_fil { get; set; }
        public string idc_isen_cgcCpf { get; set; }
        public string til_Cpf { get; set; }
        public string ins_est { get; set; }
        public string ins_mun { get; set; }
        public string idc_dep { get; set; }
        public string idc_for { get; set; }
        public string idc_cli { get; set; }
        public string idc_sit_fil { get; set; }
        public DateTime dat_cad1 { get; set; }
        public string usu_atu1 { get; set; }
        public DateTime dat_atu1 { get; set; }
        public DateTime dat_sit { get; set; }
        public int cod_empresa { get; set; }
        public int cod_depend { get; set; }
        public int cod_oper { get; set; }
        public DateTime dat_ini_gerente { get; set; }
        public int cli_cod { get; set; }
        public int cod_porte { get; set; }
        public int qtd_assinatura { get; set; }
        public string end_home_page { get; set; }
        public string eml_fil_1 { get; set; }
        public string eml_fil_2 { get; set; }
        public string eml_fil_3 { get; set; }
        public string eml_fil_4 { get; set; }
        public string eml_fil_5 { get; set; }
        public string idc_isen_ir { get; set; }
        public int cod_empresa_indic { get; set; }
        public int cod_oper_indic { get; set; }
        public string cod_sist_origem { get; set; }
        public string observ { get; set; }
        public string cod_ispb { get; set; }
        public int seq_Cnpj { get; set; }
        public string idc_corresp_age { get; set; }
        public DateTime fildatsfn { get; set; }
        public string Cpf_conjuge { get; set; }
        public string nome_conjuge { get; set; }
        public string FILIDTNAORESIDE { get; set; }
        public string FILIDTRES2686 { get; set; }
        public int FILCODNOVONAC { get; set; }
        public DateTime FILDATSAIDAPAIS { get; set; }
        public int natcod { get; set; }
        public int tip_imunidade { get; set; }
        public DateTime dat_reg_rbf { get; set; }
        public string num_processo { get; set; }
        public string num_vara { get; set; }
        public DateTime dat_inicio { get; set; }
        public DateTime dat_fim { get; set; }
        public string STA_REGISTRO { get; set; }
        public int cnaseq { get; set; }
        public string pesidcFatca { get; set; }
        public int PESNACIONALIDADE1 { get; set; }
        public int PESNACIONALIDADE2 { get; set; }
        public int PESNACIONALIDADE3 { get; set; }
        public int PESNACIONALIDADE4 { get; set; }
        public int PESDOMICILIO1 { get; set; }
        public int PESDOMICILIO2 { get; set; }
        public int PESDOMICILIO3 { get; set; }
        public int PESDOMICILIO4 { get; set; }
        public int SUNID { get; set; }
        public string APELIDO1 { get; set; }
        public string APELIDO2 { get; set; }
        public string APELIDO3 { get; set; }
        public string IDC_SIMP { get; set; }
        public string CGCCpf_FORMATADO { get; set; }
        public string SIT_BEN { get; set; }
        public string idc_ope_pro { get; set; }
        public string idc_aut_tra { get; set; }
        public string pestipdec { get; set; }
        public string idc_cli_est { get; set; }
        public string tip_doc_est { get; set; }
        public string num_doc_est { get; set; }
        public int juscod { get; set; }
        public string pesidcativoprob { get; set; }
        public string pesjustificativa { get; set; }
        public string Cpf_Cnpj { get; set; }
        public string pesnomcontato { get; set; }
        public int pescodcargo { get; set; }
        public string pesidcdeclarFatca1 { get; set; }
        public string pesidcdeclarFatca2 { get; set; }
        public string pesidcdomicilioext { get; set; }
        public int pesnumfuncionarios { get; set; }
        public int pescodnaccapital { get; set; }
        public decimal pesvalcapitalestr { get; set; }
        public decimal pesvalcapitalnac { get; set; }
        public string pestipcapital { get; set; }
        public int pescodatvcetip { get; set; }
        public string circod { get; set; }
        public string pescoDDdi { get; set; }
        public string nom_social_pessoa { get; set; }
        public string idc_isen_insc_estadual { get; set; }
        public string sgecod { get; set; }
        public string Pld_pes { get; set; }
        public string obs_Pld { get; set; }
        public int cod_oper_ger { get; set; }
        public string pesidciofadic { get; set; }
        public int fil_rescod { get; set; }
        public string cgccpf_formatado { get; set; }
        public string USU_ATU_IMU { get; set; }

    }

    public class DataSetPessoaRegistroEndereco
    {
        public string cod_pessoa { get; set; }
        public string cod_fil { get; set; }
        public int cod_end { get; set; }
        public string tip_end { get; set; }
        public string tip_log_end { get; set; }
        public string nom_log_end { get; set; }
        public string cpl_log_end { get; set; }
        public string bai_end { get; set; }
        public string Cep_end { get; set; }
        public string Ddd_fone_end { get; set; }
        public string Ddd_fone2_end { get; set; }
        public string Ddd_fone3_end { get; set; }
        public string Ddd_fone4_end { get; set; }
        public string tel_end { get; set; }
        public string tel_2_end { get; set; }
        public string tel_3_end { get; set; }
        public string tel_4_end { get; set; }
        public string ram_end { get; set; }
        public string ram_2_end { get; set; }
        public string ram_3_end { get; set; }
        public string ram_4_end { get; set; }
        public string sit_tel { get; set; }
        public string sit_tel2 { get; set; }
        public string sit_tel3 { get; set; }
        public string sit_tel4 { get; set; }
        public string Ddd_fax_end { get; set; }
        public string Ddd_fax2_end { get; set; }
        public string Ddd_fax3_end { get; set; }
        public string fax_end { get; set; }
        public string fax_2_end { get; set; }
        public string fax_3_end { get; set; }
        public string eml_end { get; set; }
        public string sit_residencia { get; set; }
        public string idc_corresp { get; set; }
        public DateTime dat_ini_end { get; set; }
        public DateTime dat_fim_end { get; set; }
        public DateTime dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime dat_atu { get; set; }
        public string idc_sit { get; set; }
        public DateTime dat_sit { get; set; }
        public decimal cod_municipio { get; set; }
        public string des_municipio { get; set; }
        public string num_log_end { get; set; }
        public string idt_naocorresp { get; set; }
        public string motcod { get; set; }
        public string sta_registro { get; set; }
        public string endidcestrang { get; set; }
        public int endcodpais { get; set; }

    }

    public class DataSetPessoaRegistroDocumento
    {
        public string cod_pessoa { get; set; }
        public string num_doc { get; set; }
        public DateTime dat_expedicao { get; set; }
        public string org_expedidor { get; set; }
        public string obs_doc { get; set; }
        public DateTime dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime dat_atu { get; set; }
        public string idc_sit { get; set; }
        public DateTime dat_sit { get; set; }
        public string tip_doc { get; set; }
        public string cod_federacao { get; set; }
        public string idc_imp_cheque { get; set; }
        public string idc_microemp { get; set; }
        public string idc_comprovado { get; set; }
        public int crecod { get; set; }
        public string idc_preposto { get; set; }
        public DateTime dat_venc { get; set; }
        public int naccod { get; set; }
    }

    public class DataSetPessoaRegistroPerfil
    {
        public string cod_pessoa { get; set; }
        public string cod_perfil { get; set; }

    }

    public class DataSetPessoaRegistroReferencia
    {
        public string cod_pessoa_tit { get; set; }
        public string cod_fil_tit { get; set; }
        public int seq_ref { get; set; }
        public string tip_ref { get; set; }
        public string obs_ref { get; set; }
        public decimal num_cartao_ref { get; set; }
        public decimal val_lim_ref { get; set; }
        public DateTime dat_ini_emprego { get; set; }
        public DateTime dat_fim_emprego { get; set; }
        public DateTime dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime dat_atu { get; set; }
        public string idc_sit { get; set; }
        public DateTime dat_sit { get; set; }
        public int cod_cartao { get; set; }
        public int cod_segur { get; set; }
        public string cod_pessoa_ref { get; set; }
        public string cod_fil_ref { get; set; }
        public string cod_simp { get; set; }
        public DateTime dat_venc_seg_cartao { get; set; }

    }
}
