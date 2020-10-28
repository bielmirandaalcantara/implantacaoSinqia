using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.SincronizadorTabela.Logging
{
    public class LogErrorException : Exception
    {
        public LogErrorException()
        {
        }

        public LogErrorException(string message) : base(message)
        {
        }

        public LogErrorException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
