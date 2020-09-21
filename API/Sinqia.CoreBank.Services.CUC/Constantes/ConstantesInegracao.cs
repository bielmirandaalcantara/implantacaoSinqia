using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Services.CUC.Constantes
{
    public class ConstantesInegracao
    {
        public static class URLConfiguracao
        {
            public const string Autenticacao = "AUTENTICACAO";
            public const string CadastroPessoa = "CADASTROPESSOA";
            public const string CadastroPessoaSimplificada = "CADASTROPESSOASIMPLIFICADA";
            public const string CadastroNegocios = "CADASTRONEGOCIOS";
        }

        public static class StatusLinhaCUC
        {
            public const string Insercao = "I";
            public const string Atualizacao = "A";
            public const string Exclusao = "E";
        }
    }
}
