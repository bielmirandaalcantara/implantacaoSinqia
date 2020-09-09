using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Models
{
    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://tempuri.org/DataSetPessoa.xsd", IsNullable = false)]
    public partial class DataSetPessoa
    {

        private DataSetPessoaRegistroPessoa registroPessoaField;

        private DataSetPessoaRegistroPerfil registroPerfilField;

        private DataSetPessoaRegistroEndereco registroEnderecoField;

        private DataSetPessoaRegistroDocumento registroDocumentoField;

        private DataSetPessoaRegistroVinculo registroVinculoField;

        /// <remarks/>
        public DataSetPessoaRegistroPessoa RegistroPessoa
        {
            get
            {
                return this.registroPessoaField;
            }
            set
            {
                this.registroPessoaField = value;
            }
        }

        /// <remarks/>
        public DataSetPessoaRegistroPerfil RegistroPerfil
        {
            get
            {
                return this.registroPerfilField;
            }
            set
            {
                this.registroPerfilField = value;
            }
        }

        /// <remarks/>
        public DataSetPessoaRegistroEndereco RegistroEndereco
        {
            get
            {
                return this.registroEnderecoField;
            }
            set
            {
                this.registroEnderecoField = value;
            }
        }

        /// <remarks/>
        public DataSetPessoaRegistroDocumento RegistroDocumento
        {
            get
            {
                return this.registroDocumentoField;
            }
            set
            {
                this.registroDocumentoField = value;
            }
        }

        /// <remarks/>
        public DataSetPessoaRegistroVinculo RegistroVinculo
        {
            get
            {
                return this.registroVinculoField;
            }
            set
            {
                this.registroVinculoField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    public partial class DataSetPessoaRegistroPessoa
    {

        private byte cod_pessoaField;

        private string nom_pessoaField;

        private string nom_abv_pessoaField;

        private string set_pessoaField;

        private string est_civilField;

        private string sex_pessoaField;

        private byte gra_instrucaoField;

        private string fil_paternaField;

        private string fil_maternaField;

        private byte num_depField;

        private System.DateTime dat_cadField;

        private string usu_atuField;

        private System.DateTime dat_atuField;

        private System.DateTime dat_fundacaoField;

        private ushort cod_atividadeField;

        private byte cod_grpempField;

        private ushort cod_municipioField;

        private string des_municipioField;

        private string des_nacionalidadeField;

        private System.DateTime dat_naturalizacaoField;

        private byte idc_constituicaoField;

        private string niv_riscoField;

        private string idc_funcField;

        private byte cod_segmentoField;

        private byte cod_subsegmentoField;

        private System.DateTime dat_ren_cadField;

        private System.DateTime dat_ven_cadField;

        private string idc_estrangField;

        private byte ddd_contatoField;

        private uint tel_contatoField;

        private byte ramal_contatoField;

        private string idc_cons_riscoField;

        private byte naccodField;

        private string pesidcusucadField;

        private string pesidtligField;

        private byte cod_filField;

        private uint bas_cgccpfField;

        private byte dig_cgccpfField;

        private string tip_filField;

        private string idc_isen_cgccpfField;

        private byte til_cpfField;

        private string idc_depField;

        private byte idc_sit_filField;

        private System.DateTime dat_cad1Field;

        private string usu_atu1Field;

        private System.DateTime dat_sitField;

        private byte cod_empresaField;

        private byte cod_dependField;

        private byte cod_operField;

        private System.DateTime dat_ini_gerenteField;

        private byte cli_codField;

        private string idc_isen_irField;

        private byte cod_empresa_indicField;

        private byte cod_oper_indicField;

        private ulong cGCCPF_FORMATADOField;

        private string idc_cli_estField;

        private object tip_doc_estField;

        private object num_doc_estField;

        private ulong cpf_cnpjField;

        /// <remarks/>
        public byte cod_pessoa
        {
            get
            {
                return this.cod_pessoaField;
            }
            set
            {
                this.cod_pessoaField = value;
            }
        }

        /// <remarks/>
        public string nom_pessoa
        {
            get
            {
                return this.nom_pessoaField;
            }
            set
            {
                this.nom_pessoaField = value;
            }
        }

        /// <remarks/>
        public string nom_abv_pessoa
        {
            get
            {
                return this.nom_abv_pessoaField;
            }
            set
            {
                this.nom_abv_pessoaField = value;
            }
        }

        /// <remarks/>
        public string set_pessoa
        {
            get
            {
                return this.set_pessoaField;
            }
            set
            {
                this.set_pessoaField = value;
            }
        }

        /// <remarks/>
        public string est_civil
        {
            get
            {
                return this.est_civilField;
            }
            set
            {
                this.est_civilField = value;
            }
        }

        /// <remarks/>
        public string sex_pessoa
        {
            get
            {
                return this.sex_pessoaField;
            }
            set
            {
                this.sex_pessoaField = value;
            }
        }

        /// <remarks/>
        public byte gra_instrucao
        {
            get
            {
                return this.gra_instrucaoField;
            }
            set
            {
                this.gra_instrucaoField = value;
            }
        }

        /// <remarks/>
        public string fil_paterna
        {
            get
            {
                return this.fil_paternaField;
            }
            set
            {
                this.fil_paternaField = value;
            }
        }

        /// <remarks/>
        public string fil_materna
        {
            get
            {
                return this.fil_maternaField;
            }
            set
            {
                this.fil_maternaField = value;
            }
        }

        /// <remarks/>
        public byte num_dep
        {
            get
            {
                return this.num_depField;
            }
            set
            {
                this.num_depField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_cad
        {
            get
            {
                return this.dat_cadField;
            }
            set
            {
                this.dat_cadField = value;
            }
        }

        /// <remarks/>
        public string usu_atu
        {
            get
            {
                return this.usu_atuField;
            }
            set
            {
                this.usu_atuField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_atu
        {
            get
            {
                return this.dat_atuField;
            }
            set
            {
                this.dat_atuField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_fundacao
        {
            get
            {
                return this.dat_fundacaoField;
            }
            set
            {
                this.dat_fundacaoField = value;
            }
        }

        /// <remarks/>
        public ushort cod_atividade
        {
            get
            {
                return this.cod_atividadeField;
            }
            set
            {
                this.cod_atividadeField = value;
            }
        }

        /// <remarks/>
        public byte cod_grpemp
        {
            get
            {
                return this.cod_grpempField;
            }
            set
            {
                this.cod_grpempField = value;
            }
        }

        /// <remarks/>
        public ushort cod_municipio
        {
            get
            {
                return this.cod_municipioField;
            }
            set
            {
                this.cod_municipioField = value;
            }
        }

        /// <remarks/>
        public string des_municipio
        {
            get
            {
                return this.des_municipioField;
            }
            set
            {
                this.des_municipioField = value;
            }
        }

        /// <remarks/>
        public string des_nacionalidade
        {
            get
            {
                return this.des_nacionalidadeField;
            }
            set
            {
                this.des_nacionalidadeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_naturalizacao
        {
            get
            {
                return this.dat_naturalizacaoField;
            }
            set
            {
                this.dat_naturalizacaoField = value;
            }
        }

        /// <remarks/>
        public byte idc_constituicao
        {
            get
            {
                return this.idc_constituicaoField;
            }
            set
            {
                this.idc_constituicaoField = value;
            }
        }

        /// <remarks/>
        public string niv_risco
        {
            get
            {
                return this.niv_riscoField;
            }
            set
            {
                this.niv_riscoField = value;
            }
        }

        /// <remarks/>
        public string idc_func
        {
            get
            {
                return this.idc_funcField;
            }
            set
            {
                this.idc_funcField = value;
            }
        }

        /// <remarks/>
        public byte cod_segmento
        {
            get
            {
                return this.cod_segmentoField;
            }
            set
            {
                this.cod_segmentoField = value;
            }
        }

        /// <remarks/>
        public byte cod_subsegmento
        {
            get
            {
                return this.cod_subsegmentoField;
            }
            set
            {
                this.cod_subsegmentoField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_ren_cad
        {
            get
            {
                return this.dat_ren_cadField;
            }
            set
            {
                this.dat_ren_cadField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_ven_cad
        {
            get
            {
                return this.dat_ven_cadField;
            }
            set
            {
                this.dat_ven_cadField = value;
            }
        }

        /// <remarks/>
        public string idc_estrang
        {
            get
            {
                return this.idc_estrangField;
            }
            set
            {
                this.idc_estrangField = value;
            }
        }

        /// <remarks/>
        public byte ddd_contato
        {
            get
            {
                return this.ddd_contatoField;
            }
            set
            {
                this.ddd_contatoField = value;
            }
        }

        /// <remarks/>
        public uint tel_contato
        {
            get
            {
                return this.tel_contatoField;
            }
            set
            {
                this.tel_contatoField = value;
            }
        }

        /// <remarks/>
        public byte ramal_contato
        {
            get
            {
                return this.ramal_contatoField;
            }
            set
            {
                this.ramal_contatoField = value;
            }
        }

        /// <remarks/>
        public string idc_cons_risco
        {
            get
            {
                return this.idc_cons_riscoField;
            }
            set
            {
                this.idc_cons_riscoField = value;
            }
        }

        /// <remarks/>
        public byte naccod
        {
            get
            {
                return this.naccodField;
            }
            set
            {
                this.naccodField = value;
            }
        }

        /// <remarks/>
        public string pesidcusucad
        {
            get
            {
                return this.pesidcusucadField;
            }
            set
            {
                this.pesidcusucadField = value;
            }
        }

        /// <remarks/>
        public string pesidtlig
        {
            get
            {
                return this.pesidtligField;
            }
            set
            {
                this.pesidtligField = value;
            }
        }

        /// <remarks/>
        public byte cod_fil
        {
            get
            {
                return this.cod_filField;
            }
            set
            {
                this.cod_filField = value;
            }
        }

        /// <remarks/>
        public uint bas_cgccpf
        {
            get
            {
                return this.bas_cgccpfField;
            }
            set
            {
                this.bas_cgccpfField = value;
            }
        }

        /// <remarks/>
        public byte dig_cgccpf
        {
            get
            {
                return this.dig_cgccpfField;
            }
            set
            {
                this.dig_cgccpfField = value;
            }
        }

        /// <remarks/>
        public string tip_fil
        {
            get
            {
                return this.tip_filField;
            }
            set
            {
                this.tip_filField = value;
            }
        }

        /// <remarks/>
        public string idc_isen_cgccpf
        {
            get
            {
                return this.idc_isen_cgccpfField;
            }
            set
            {
                this.idc_isen_cgccpfField = value;
            }
        }

        /// <remarks/>
        public byte til_cpf
        {
            get
            {
                return this.til_cpfField;
            }
            set
            {
                this.til_cpfField = value;
            }
        }

        /// <remarks/>
        public string idc_dep
        {
            get
            {
                return this.idc_depField;
            }
            set
            {
                this.idc_depField = value;
            }
        }

        /// <remarks/>
        public byte idc_sit_fil
        {
            get
            {
                return this.idc_sit_filField;
            }
            set
            {
                this.idc_sit_filField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_cad1
        {
            get
            {
                return this.dat_cad1Field;
            }
            set
            {
                this.dat_cad1Field = value;
            }
        }

        /// <remarks/>
        public string usu_atu1
        {
            get
            {
                return this.usu_atu1Field;
            }
            set
            {
                this.usu_atu1Field = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_sit
        {
            get
            {
                return this.dat_sitField;
            }
            set
            {
                this.dat_sitField = value;
            }
        }

        /// <remarks/>
        public byte cod_empresa
        {
            get
            {
                return this.cod_empresaField;
            }
            set
            {
                this.cod_empresaField = value;
            }
        }

        /// <remarks/>
        public byte cod_depend
        {
            get
            {
                return this.cod_dependField;
            }
            set
            {
                this.cod_dependField = value;
            }
        }

        /// <remarks/>
        public byte cod_oper
        {
            get
            {
                return this.cod_operField;
            }
            set
            {
                this.cod_operField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_ini_gerente
        {
            get
            {
                return this.dat_ini_gerenteField;
            }
            set
            {
                this.dat_ini_gerenteField = value;
            }
        }

        /// <remarks/>
        public byte cli_cod
        {
            get
            {
                return this.cli_codField;
            }
            set
            {
                this.cli_codField = value;
            }
        }

        /// <remarks/>
        public string idc_isen_ir
        {
            get
            {
                return this.idc_isen_irField;
            }
            set
            {
                this.idc_isen_irField = value;
            }
        }

        /// <remarks/>
        public byte cod_empresa_indic
        {
            get
            {
                return this.cod_empresa_indicField;
            }
            set
            {
                this.cod_empresa_indicField = value;
            }
        }

        /// <remarks/>
        public byte cod_oper_indic
        {
            get
            {
                return this.cod_oper_indicField;
            }
            set
            {
                this.cod_oper_indicField = value;
            }
        }

        /// <remarks/>
        public ulong CGCCPF_FORMATADO
        {
            get
            {
                return this.cGCCPF_FORMATADOField;
            }
            set
            {
                this.cGCCPF_FORMATADOField = value;
            }
        }

        /// <remarks/>
        public string idc_cli_est
        {
            get
            {
                return this.idc_cli_estField;
            }
            set
            {
                this.idc_cli_estField = value;
            }
        }

        /// <remarks/>
        public object tip_doc_est
        {
            get
            {
                return this.tip_doc_estField;
            }
            set
            {
                this.tip_doc_estField = value;
            }
        }

        /// <remarks/>
        public object num_doc_est
        {
            get
            {
                return this.num_doc_estField;
            }
            set
            {
                this.num_doc_estField = value;
            }
        }

        /// <remarks/>
        public ulong cpf_cnpj
        {
            get
            {
                return this.cpf_cnpjField;
            }
            set
            {
                this.cpf_cnpjField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    public partial class DataSetPessoaRegistroPerfil
    {

        private byte cod_pessoaField;

        private byte cod_perfilField;

        /// <remarks/>
        public byte cod_pessoa
        {
            get
            {
                return this.cod_pessoaField;
            }
            set
            {
                this.cod_pessoaField = value;
            }
        }

        /// <remarks/>
        public byte cod_perfil
        {
            get
            {
                return this.cod_perfilField;
            }
            set
            {
                this.cod_perfilField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    public partial class DataSetPessoaRegistroEndereco
    {

        private byte cod_pessoaField;

        private byte cod_filField;

        private byte cod_endField;

        private string tip_endField;

        private string tip_log_endField;

        private string nom_log_endField;

        private uint cep_endField;

        private string sit_telField;

        private string sit_tel2Field;

        private string sit_tel3Field;

        private string sit_tel4Field;

        private string idc_correspField;

        private System.DateTime dat_cadField;

        private string usu_atuField;

        private System.DateTime dat_atuField;

        private string idc_sitField;

        private System.DateTime dat_sitField;

        private ushort cod_municipioField;

        private string idt_naocorrespField;

        private string cc_end_auxField;

        /// <remarks/>
        public byte cod_pessoa
        {
            get
            {
                return this.cod_pessoaField;
            }
            set
            {
                this.cod_pessoaField = value;
            }
        }

        /// <remarks/>
        public byte cod_fil
        {
            get
            {
                return this.cod_filField;
            }
            set
            {
                this.cod_filField = value;
            }
        }

        /// <remarks/>
        public byte cod_end
        {
            get
            {
                return this.cod_endField;
            }
            set
            {
                this.cod_endField = value;
            }
        }

        /// <remarks/>
        public string tip_end
        {
            get
            {
                return this.tip_endField;
            }
            set
            {
                this.tip_endField = value;
            }
        }

        /// <remarks/>
        public string tip_log_end
        {
            get
            {
                return this.tip_log_endField;
            }
            set
            {
                this.tip_log_endField = value;
            }
        }

        /// <remarks/>
        public string nom_log_end
        {
            get
            {
                return this.nom_log_endField;
            }
            set
            {
                this.nom_log_endField = value;
            }
        }

        /// <remarks/>
        public uint cep_end
        {
            get
            {
                return this.cep_endField;
            }
            set
            {
                this.cep_endField = value;
            }
        }

        /// <remarks/>
        public string sit_tel
        {
            get
            {
                return this.sit_telField;
            }
            set
            {
                this.sit_telField = value;
            }
        }

        /// <remarks/>
        public string sit_tel2
        {
            get
            {
                return this.sit_tel2Field;
            }
            set
            {
                this.sit_tel2Field = value;
            }
        }

        /// <remarks/>
        public string sit_tel3
        {
            get
            {
                return this.sit_tel3Field;
            }
            set
            {
                this.sit_tel3Field = value;
            }
        }

        /// <remarks/>
        public string sit_tel4
        {
            get
            {
                return this.sit_tel4Field;
            }
            set
            {
                this.sit_tel4Field = value;
            }
        }

        /// <remarks/>
        public string idc_corresp
        {
            get
            {
                return this.idc_correspField;
            }
            set
            {
                this.idc_correspField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_cad
        {
            get
            {
                return this.dat_cadField;
            }
            set
            {
                this.dat_cadField = value;
            }
        }

        /// <remarks/>
        public string usu_atu
        {
            get
            {
                return this.usu_atuField;
            }
            set
            {
                this.usu_atuField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_atu
        {
            get
            {
                return this.dat_atuField;
            }
            set
            {
                this.dat_atuField = value;
            }
        }

        /// <remarks/>
        public string idc_sit
        {
            get
            {
                return this.idc_sitField;
            }
            set
            {
                this.idc_sitField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_sit
        {
            get
            {
                return this.dat_sitField;
            }
            set
            {
                this.dat_sitField = value;
            }
        }

        /// <remarks/>
        public ushort cod_municipio
        {
            get
            {
                return this.cod_municipioField;
            }
            set
            {
                this.cod_municipioField = value;
            }
        }

        /// <remarks/>
        public string idt_naocorresp
        {
            get
            {
                return this.idt_naocorrespField;
            }
            set
            {
                this.idt_naocorrespField = value;
            }
        }

        /// <remarks/>
        public string cc_end_aux
        {
            get
            {
                return this.cc_end_auxField;
            }
            set
            {
                this.cc_end_auxField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    public partial class DataSetPessoaRegistroDocumento
    {

        private byte cod_pessoaField;

        private uint num_docField;

        private System.DateTime dat_expedicaoField;

        private string org_expedidorField;

        private System.DateTime dat_cadField;

        private string usu_atuField;

        private System.DateTime dat_atuField;

        private string idc_sitField;

        private System.DateTime dat_sitField;

        private string tip_docField;

        private string cod_federacaoField;

        private string idc_imp_chequeField;

        private string idc_comprovadoField;

        private byte crecodField;

        private string idc_prepostoField;

        private System.DateTime dat_vencField;

        /// <remarks/>
        public byte cod_pessoa
        {
            get
            {
                return this.cod_pessoaField;
            }
            set
            {
                this.cod_pessoaField = value;
            }
        }

        /// <remarks/>
        public uint num_doc
        {
            get
            {
                return this.num_docField;
            }
            set
            {
                this.num_docField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_expedicao
        {
            get
            {
                return this.dat_expedicaoField;
            }
            set
            {
                this.dat_expedicaoField = value;
            }
        }

        /// <remarks/>
        public string org_expedidor
        {
            get
            {
                return this.org_expedidorField;
            }
            set
            {
                this.org_expedidorField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_cad
        {
            get
            {
                return this.dat_cadField;
            }
            set
            {
                this.dat_cadField = value;
            }
        }

        /// <remarks/>
        public string usu_atu
        {
            get
            {
                return this.usu_atuField;
            }
            set
            {
                this.usu_atuField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_atu
        {
            get
            {
                return this.dat_atuField;
            }
            set
            {
                this.dat_atuField = value;
            }
        }

        /// <remarks/>
        public string idc_sit
        {
            get
            {
                return this.idc_sitField;
            }
            set
            {
                this.idc_sitField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_sit
        {
            get
            {
                return this.dat_sitField;
            }
            set
            {
                this.dat_sitField = value;
            }
        }

        /// <remarks/>
        public string tip_doc
        {
            get
            {
                return this.tip_docField;
            }
            set
            {
                this.tip_docField = value;
            }
        }

        /// <remarks/>
        public string cod_federacao
        {
            get
            {
                return this.cod_federacaoField;
            }
            set
            {
                this.cod_federacaoField = value;
            }
        }

        /// <remarks/>
        public string idc_imp_cheque
        {
            get
            {
                return this.idc_imp_chequeField;
            }
            set
            {
                this.idc_imp_chequeField = value;
            }
        }

        /// <remarks/>
        public string idc_comprovado
        {
            get
            {
                return this.idc_comprovadoField;
            }
            set
            {
                this.idc_comprovadoField = value;
            }
        }

        /// <remarks/>
        public byte crecod
        {
            get
            {
                return this.crecodField;
            }
            set
            {
                this.crecodField = value;
            }
        }

        /// <remarks/>
        public string idc_preposto
        {
            get
            {
                return this.idc_prepostoField;
            }
            set
            {
                this.idc_prepostoField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_venc
        {
            get
            {
                return this.dat_vencField;
            }
            set
            {
                this.dat_vencField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://tempuri.org/DataSetPessoa.xsd")]
    public partial class DataSetPessoaRegistroVinculo
    {

        private byte cod_pessoa_jurField;

        private byte cod_fil_jurField;

        private byte cod_pessoa_fisField;

        private byte cod_fil_fisField;

        private byte seq_vinculoField;

        private string idc_partcipacaoField;

        private System.DateTime dat_posseField;

        private System.DateTime dat_cadField;

        private string usu_atuField;

        private System.DateTime dat_atuField;

        private string idc_sitField;

        private System.DateTime dat_sitField;

        private byte cod_cargoField;

        private string idc_assinaField;

        private string idc_contatoField;

        private System.DateTime dat_fimField;

        private string cod_vinculoField;

        private string nom_pessoaField;

        private ulong cpf_cnpj_socField;

        private string tip_pes_socField;

        /// <remarks/>
        public byte cod_pessoa_jur
        {
            get
            {
                return this.cod_pessoa_jurField;
            }
            set
            {
                this.cod_pessoa_jurField = value;
            }
        }

        /// <remarks/>
        public byte cod_fil_jur
        {
            get
            {
                return this.cod_fil_jurField;
            }
            set
            {
                this.cod_fil_jurField = value;
            }
        }

        /// <remarks/>
        public byte cod_pessoa_fis
        {
            get
            {
                return this.cod_pessoa_fisField;
            }
            set
            {
                this.cod_pessoa_fisField = value;
            }
        }

        /// <remarks/>
        public byte cod_fil_fis
        {
            get
            {
                return this.cod_fil_fisField;
            }
            set
            {
                this.cod_fil_fisField = value;
            }
        }

        /// <remarks/>
        public byte seq_vinculo
        {
            get
            {
                return this.seq_vinculoField;
            }
            set
            {
                this.seq_vinculoField = value;
            }
        }

        /// <remarks/>
        public string idc_partcipacao
        {
            get
            {
                return this.idc_partcipacaoField;
            }
            set
            {
                this.idc_partcipacaoField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_posse
        {
            get
            {
                return this.dat_posseField;
            }
            set
            {
                this.dat_posseField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_cad
        {
            get
            {
                return this.dat_cadField;
            }
            set
            {
                this.dat_cadField = value;
            }
        }

        /// <remarks/>
        public string usu_atu
        {
            get
            {
                return this.usu_atuField;
            }
            set
            {
                this.usu_atuField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_atu
        {
            get
            {
                return this.dat_atuField;
            }
            set
            {
                this.dat_atuField = value;
            }
        }

        /// <remarks/>
        public string idc_sit
        {
            get
            {
                return this.idc_sitField;
            }
            set
            {
                this.idc_sitField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_sit
        {
            get
            {
                return this.dat_sitField;
            }
            set
            {
                this.dat_sitField = value;
            }
        }

        /// <remarks/>
        public byte cod_cargo
        {
            get
            {
                return this.cod_cargoField;
            }
            set
            {
                this.cod_cargoField = value;
            }
        }

        /// <remarks/>
        public string idc_assina
        {
            get
            {
                return this.idc_assinaField;
            }
            set
            {
                this.idc_assinaField = value;
            }
        }

        /// <remarks/>
        public string idc_contato
        {
            get
            {
                return this.idc_contatoField;
            }
            set
            {
                this.idc_contatoField = value;
            }
        }

        /// <remarks/>
        public System.DateTime dat_fim
        {
            get
            {
                return this.dat_fimField;
            }
            set
            {
                this.dat_fimField = value;
            }
        }

        /// <remarks/>
        public string cod_vinculo
        {
            get
            {
                return this.cod_vinculoField;
            }
            set
            {
                this.cod_vinculoField = value;
            }
        }

        /// <remarks/>
        public string nom_pessoa
        {
            get
            {
                return this.nom_pessoaField;
            }
            set
            {
                this.nom_pessoaField = value;
            }
        }

        /// <remarks/>
        public ulong cpf_cnpj_soc
        {
            get
            {
                return this.cpf_cnpj_socField;
            }
            set
            {
                this.cpf_cnpj_socField = value;
            }
        }

        /// <remarks/>
        public string tip_pes_soc
        {
            get
            {
                return this.tip_pes_socField;
            }
            set
            {
                this.tip_pes_socField = value;
            }
        }
    }



}
