using System;
using System.IO;
using System.ServiceProcess;
using Microsoft.Extensions.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Configuration;
using Sinqia.CoreBank.SincronizadorTabela.Services;
using System.Diagnostics;
using System.Linq;

namespace Sinqia.CoreBank.SincronizadorTabela
{
    class Program
    {
        static void Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console")); ;
            
            if (isService) 
                ServiceBase.Run(new SincronizadorTabelasService(isService)); 
            else
            {
                var baseService = new SincronizadorTabelasService(isService);
                baseService.OnStartConsole(new string[0]);
            }   
        }

    }
}
