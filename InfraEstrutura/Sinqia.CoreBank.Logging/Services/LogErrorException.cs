using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.Logging.Services
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
