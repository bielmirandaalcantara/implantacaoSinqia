using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Dominio.Core.Attributes;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_operador
    {
        public int? cod_empresa { get; set; }
        public int? cod_oper { get; set; }
        public int? cod_depend { get; set; }
        public string nom_oper { get; set; }
        public string nom_abv_oper { get; set; }
        public string idt_oper { get; set; }
        public string log_oper { get; set; }
        public string tip_oper { get; set; }
        public DateTime? dat_cad { get; set; }
        public string usu_atu { get; set; }
        public DateTime? dat_atu { get; set; }
        public DateTime? dat_sit { get; set; }
        public string idc_sit { get; set; }
        public int? cod_cargo { get; set; }
        public string cpf_oper { get; set; }
        public string dig_oper { get; set; }
        public string sex_oper { get; set; }
        public string ddd_oper { get; set; }
        public string tel_oper { get; set; }
        public string ram_oper { get; set; }
        public string eml_oper { get; set; }
        public int? cod_ger_origem { get; set; }
        public string OPECODCRK { get; set; }

        [IgnorePersistencia]
        public IEnumerable<tb_gerente> tb_gerentes { get; set; }
    }
}
