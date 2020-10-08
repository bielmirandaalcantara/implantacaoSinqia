using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Sinqia.CoreBank.Services.CUC.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public class DataSetNegocioOutrosBancos
    {
        [System.Xml.Serialization.XmlElementAttribute("RegistroNegocioOutrosBancos")]
        public DataSetNegocioRegistroOutrosBancos[] RegistroNegocioOutrosBancos { get; set; }

    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class DataSetNegocioRegistroOutrosBancos_
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
        public int? cod_age_negbco { get; set; }
        [System.Xml.Serialization.XmlIgnore]
        public bool cod_age_negbcoSpecified { get { return this.cod_age_negbco != null; } }
        [XmlElement(IsNullable = false)]
        public string num_negbco { get; set; }
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
