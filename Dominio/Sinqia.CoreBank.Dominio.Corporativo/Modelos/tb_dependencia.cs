using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Dominio.Core.Attributes;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_dependencia
    {
        public int? cod_empresa { get; set; }
        public int? cod_depend { get; set; }
        public int? cod_municipio { get; set; }

        [IgnorePersistencia]
        public string nom_abv_depend { get; set; }
        public string nom_depend { get; set; }
        public string bas_cgc_depend { get; set; }
        public string fil_cgc_depend { get; set; }
        public string dig_cgc_depend { get; set; }
        public string tip_log_depend { get; set; }
        public string end_depend { get; set; }
        public string cpl_log_depend { get; set; }
        public string bai_depend { get; set; }
        public string cep_depend { get; set; }
        public string ddd_fone_depend { get; set; }
        public string ddd_fone2_depend { get; set; }
        public string ddd_fone3_depend { get; set; }
        public string ddd_fone4_depend { get; set; }
        public string tel_depend { get; set; }
        public string tel_2_depend { get; set; }
        public string tel_3_depend { get; set; }
        public string tel_4_depend { get; set; }
        public string ram_depend { get; set; }
        public string ram_2_depend { get; set; }
        public string ram_3_depend { get; set; }
        public string ram_4_depend { get; set; }
        public string ddd_fax_depend { get; set; }
        public string ddd_fax2_depend { get; set; }
        public string ddd_fax3_depend { get; set; }
        public string fax_depend { get; set; }
        public string fax_2_depend { get; set; }
        public string fax_3_depend { get; set; }
        public string eml_depend { get; set; }
        public string ins_estadual { get; set; }
        public string ins_municipal { get; set; }
        public int? nvl_sup_depend { get; set; }
        public int? nvl_1_depend { get; set; }
        public int? nvl_2_depend { get; set; }
        public int? nvl_3_depend { get; set; }
        public int? nvl_4_depend { get; set; }
        public int? nvl_5_depend { get; set; }
        public int? nvl_6_depend { get; set; }
        public int? nvl_7_depend { get; set; }
        public int? nvl_8_depend { get; set; }
        public int? nvl_9_depend { get; set; }
        public int? nvl_10_depend { get; set; }
        public DateTime? dat_ini_depend { get; set; }
        public DateTime? dat_fim_depend { get; set; }
        public DateTime? dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        public string idc_sit { get; set; }
        public string tip_tpdepend { get; set; }
        public int? cod_camara { get; set; }
        public string num_log_depend { get; set; }
        public DateTime? dat_rollout { get; set; }
        public DateTime? dat_sit { get; set; }

    }
}
