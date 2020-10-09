using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Dominio.Core.Attributes;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_prodbco
    {
        public int? cod_empresa { get; set; }
        public int? cod_prodbco { get; set; }
        public string abv_prodbco { get; set; }
        public string des_prodbco { get; set; }
        public int? cod_grproduto { get; set; }
        public string idc_replica { get; set; }
        public string tip_produto { get; set; }
        /*
        public string idc_bdv { get; set; }
        public string IDC_CPN { get; set; }
        public int? COD_PRODCARM { get; set; }
        public string DES_PRODCARM { get; set; }
        */
    }
}
