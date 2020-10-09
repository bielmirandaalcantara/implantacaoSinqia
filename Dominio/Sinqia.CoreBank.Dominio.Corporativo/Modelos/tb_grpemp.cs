using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_grpemp
    {
        public int? cod_grpemp { get; set; }
        public string abv_grpemp { get; set; }
        public string des_grpemp { get; set; }
        public int? cod_empresa { get; set; }
        public int? cod_depend { get; set; }
    }
}
