using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_municipio
    {
        public int? cod_municipio { get; set; }
        public string nom_municipio { get; set; }
        public int? cod_municipio_bacen { get; set; }
        public int? cod_municipio_ibge { get; set; }
        public string cod_federacao { get; set; }
        public int? cod_municipio_ect { get; set; }
        public string cep_municipio { get; set; }
        public string sit_cep_mun { get; set; }
        public string tip_municipio { get; set; }
        public int? cod_municipio_ect_sup { get; set; }
        public string ind_capital { get; set; }
        public string ind_acesso { get; set; }
    }
}
