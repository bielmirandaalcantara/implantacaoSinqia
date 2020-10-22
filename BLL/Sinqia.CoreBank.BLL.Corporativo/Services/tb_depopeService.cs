using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinqia.CoreBank.BLL.Corporativo.Services
{
    public class tb_depopeService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private tb_empresaService _empresaService;
        private tb_dependenciaService _dependenciaService;
        private tb_operadorService _operadorService;
        private LogService _log;

        public tb_depopeService(ConfiguracaoBaseDataBase dataBaseConfig, LogService log)
        {
            _log = log;
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig, _log);
            _empresaService = new tb_empresaService(_databaseConfig, _log);
            _dependenciaService = new tb_dependenciaService(_databaseConfig, _log);
            _operadorService = new tb_operadorService(_databaseConfig, _log);            
        }
        
        public IEnumerable<tb_depope> BuscarOperadorDependencia(int? emp_cod, int? oper_cod, int? dep_cod, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            if (emp_cod == null || emp_cod.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {emp_cod.Value} ";

            if (oper_cod != null && oper_cod.Value > 0)
                where += $" and oper_cod = {oper_cod.Value} ";

            if (dep_cod != null && dep_cod.Value > 0)
                where += $" and depend_cod = {dep_cod.Value} ";

            var retorno = dao.Obter(where);

            _log.TraceMethodEnd();
            return retorno;
        }
    }
}
