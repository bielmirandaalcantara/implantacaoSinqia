using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Dominio.Core.Attributes;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_gerente
    {
        public const string tip_gerenteDefault = "G";

        public int? cod_empresa { get; set; }
        public int? cod_oper { get; set; }
        public int? cod_depend { get; set; }
        public DateTime? dat_ini_gerente { get; set; }
        public DateTime? dat_fim_gerente { get; set; }
        public string usu_atu_gerente { get; set; }
        public string tip_gerente { get; set; }
        public string sit_gerente { get; set; }        
        public string GERIDCMAILCUCVCT { get; set; }
    }
}
