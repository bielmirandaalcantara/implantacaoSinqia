using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Models
{
    [System.SerializableAttribute()]

    public class DataSetPessoaConsulta
    {
        [System.Xml.Serialization.XmlElementAttribute("RegistroPessoa")]
        public DataSetPessoaRegistroPessoaConsulta[] RegistroPessoa { get; set; }
    }
    public class DataSetPessoaRegistroPessoaConsulta
    {
        public string CODIGO { get; set; }
        public string NOME { get; set; }
        public string NOME_ABV { get; set; }
        public string SEXO { get; set; }
        public DateTime? DATAFUNDACAO { get; set; }
        public string TIPOPESSOA { get; set; }
        public string ATIVIDADE { get; set; }
    }
}
