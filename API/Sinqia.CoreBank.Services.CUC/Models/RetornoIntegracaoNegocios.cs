using System;
using System.Collections.Generic;
using System.Text;
using Sinqia.CoreBank.Services.CUC.WCF.Negocios;

namespace Sinqia.CoreBank.Services.CUC.Models
{
    public class RetornoIntegracaoNegocios
    {
        public string CodigoContaRelacionamento { get; set; }

        public string CodigoFilial { get; set; }

        public string CodigoPessoa { get; set; }

        public CucCluExcecao Excecao { get; set; }

        public string TipoPessoa { get; set; }

        public string Xml { get; set; }

    }
}
