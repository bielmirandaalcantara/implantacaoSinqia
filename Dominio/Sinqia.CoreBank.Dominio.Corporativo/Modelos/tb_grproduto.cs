﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_grproduto
    {
        public int? cod_empresa { get; set; }
        public int? cod_grproduto { get; set; }
        public string abv_grproduto { get; set; }
        public string des_grproduto { get; set; }
        public int? cod_sistema { get; set; }
    }
}
