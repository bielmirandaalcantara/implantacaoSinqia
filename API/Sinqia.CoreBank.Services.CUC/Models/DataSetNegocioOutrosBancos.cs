using System;
using System.Collections.Generic;
using System.Text;

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
    public class DataSetNegocioRegistroOutrosBancos
    {
        public string cod_pessoa { get; set; }
        public string cod_fil { get; set; }
        public int? seq_negbco { get; set; }
        public int? cod_age_negbco { get; set; }
        public string num_negbco { get; set; }
        public decimal? val_limite_negbco { get; set; }
        public decimal? val_dev_negbco { get; set; }
        public DateTime? dat_ini_negbco { get; set; }
        public DateTime? dat_fim_negbco { get; set; }
        public DateTime? dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        public DateTime? dat_sit { get; set; }
        public string idc_sit { get; set; }
        public int? cod_empresa { get; set; }
        public int? cod_prodbco { get; set; }
        public int? cod_bco { get; set; }
        public int? cod_bco_negbco { get; set; }
        public string COD_CTA_RESGATE { get; set; }
        public string STA_REGISTRO { get; set; }
        public string NEGIDCBCO { get; set; }
        public string NEGCODISPB { get; set; }
        public decimal? IPGCOD { get; set; }
        public string NEGSTACONTAPADRAO { get; set; }

    }
}
