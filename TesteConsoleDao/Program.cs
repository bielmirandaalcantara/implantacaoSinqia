using Microsoft.Extensions.Configuration;
using Sinqia.CoreBank.DAO.Core.Configuration;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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



            //--Obter todos
            IEnumerable<tb_dependencia> result = dao.Obter();

/*

            //--update com um obter com código
            IEnumerable<tb_dependencia> result2 = dao.Obter("cod_depend = 55");
            tb_dependencia dependenciaAlterar = result2.FirstOrDefault();
            if(dependenciaAlterar != null)
            {
                dependenciaAlterar.nom_abv_depend = "SINQIA TESTE - G";
                dao.Atualizar(dependenciaAlterar, "cod_depend = 55", new List<string>() {"nom_abv_depend"});
            }
            

            //insert

            tb_dependencia dep = new tb_dependencia()
            {
                cod_empresa = 1
                ,cod_depend = 88
                ,cod_municipio = 5621
                ,nom_abv_depend = "TESTE GABRIEL"
                ,nom_depend = "TESTE GABRIEL N"
                ,bas_cgc_depend = "45520049"
                ,fil_cgc_depend = "0001"
                ,dig_cgc_depend = "03"
                ,tip_log_depend = "RUA"
                ,end_depend = "RUA CAMPO SANTO"
                ,cpl_log_depend = "182"
                ,bai_depend = "VILA CURUÇA"
                ,cep_depend = "09230330"
                ,ddd_fone_depend = "11"
                ,tel_depend = "25343033"
                ,dat_ini_depend = DateTime.Now.AddDays(-5)
                ,dat_cad = DateTime.Now
                ,usu_atu = "att"
                ,dat_atu = DateTime.Now
                ,idc_sit = "A"
                ,tip_tpdepend = "A"
                ,num_log_depend = "408"
            };


            var factoryCore = new CoreDaoFactory(configBase);
            using (var transacao = factoryCore.GetTransacao())
            {
                transacao.BeginTransaction();
                try
                {

                    var daoTransacao = factory.GetDaoCorporativo<tb_dependencia>(transacao);
                    daoTransacao.Inserir(dep);
                    transacao.Commit();

                }
                catch (Exception)
                {
                    transacao.Rollback();
                    throw;
                }
            }

            

            var dao = factory.GetDaoCorporativo<tb_dependencia>();
            dao.Remover(new tb_dependencia(), "cod_depend = 88");

*/

        }
    }
}
