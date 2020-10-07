using Microsoft.Extensions.Configuration;
using Sinqia.CoreBank.DAO.Core.Configuration;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System;
using System.Collections.Generic;
using System.IO;

namespace TesteConsoleDao
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");  
            IConfigurationRoot config = builder.Build();
            ConfiguracaoBaseDataBase configBase = config.GetSection("ConfiguracaoBaseDataBase").Get<ConfiguracaoBaseDataBase>();


            var factory = new CorporativoDaoFactory(configBase);
            var dao = factory.GetDaoCorporativo<tb_dependencia>();
            IEnumerable<tb_dependencia> result = dao.Obter();


            tb_grpemp grpemp = new tb_grpemp()
            {
                cod_grpemp = 99
                , abv_grpemp = "GT"
                , des_grpemp = "Teste do Gabriel"                
            };

            var factoryCore = new CoreDaoFactory(configBase);
            using (var transacao = factoryCore.GetTransacao())
            {
                transacao.BeginTransaction();
                try
                {

                    var daoTransacao = factory.GetDaoCorporativo<tb_grpemp>(transacao);
                    daoTransacao.Inserir(grpemp);
                    transacao.Commit();

                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }
    }
}
