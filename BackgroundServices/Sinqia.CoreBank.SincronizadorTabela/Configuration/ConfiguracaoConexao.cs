﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.SincronizadorTabela.Configuration
{
    public class ConfiguracaoConexao
    {
        public static string nomeSessao = "ConfiguracaoConexao";

        public string NomeConexao { get; set; }
        public string NomeBancoDe { get; set; }
        public string ConexaoDe { get; set; }
        public string SufixoTabelaControle { get; set; }
        public string NomeBancoPara { get; set; }
        public string ConexaoPara { get; set; }
        public int QuantidadeMaximaTentativas { get; set; }
        public int LimiteDiasSincronizacao { get; set; }
        public List<string> ListaTabelas { get; set; }
        
    }
}
