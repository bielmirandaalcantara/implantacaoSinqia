using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Models
{
    public class RetornoIntegracaoPessoa
    {
        public string CodigoContaRelacionamento { get; set; }

        public string CodigoFilial { get; set; }

        public string CodigoPessoa { get; set; }

        public Sinqia.CoreBank.Services.CUC.CadastroPessoa.CucCluExcecao Excecao { get; set; }

        public string TipoPessoa { get; set; }

        public string Xml { get; set; }

    }
}
