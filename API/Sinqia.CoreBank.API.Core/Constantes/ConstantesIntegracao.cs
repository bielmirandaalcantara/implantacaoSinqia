﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Constantes
{
    public class ConstantesIntegracao
    {
        public const string ApiKey = "ApiKey";
        public static class StatusIntegracao
        {
            public const string Erro = "ERRO";
            public const string OK = "OK";
        }

        public static class ModoIntegracao
        {
            public const string ModoInclusao = "I";
            public const string ModoAlteracao = "A";
        }
    }
}
