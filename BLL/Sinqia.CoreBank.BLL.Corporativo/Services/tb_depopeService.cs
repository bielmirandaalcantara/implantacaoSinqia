using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
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

        public tb_depopeService(IOptions<ConfiguracaoBaseDataBase> dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig.Value;
            _factory = new CorporativoDaoFactory(_databaseConfig);
        }

        public tb_depope GravarOperadorDependencia(tb_depope entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {entity.emp_cod} and oper_cod = {entity.oper_cod} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.emp_cod} e operador dependencia: {entity.oper_cod} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarOperadorDependencia(tb_depope entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {entity.emp_cod} and oper_cod = {entity.oper_cod} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.emp_cod} e operador dependencia: {entity.oper_cod} ");

            dao.Atualizar(entity, where);

        }

        public void ExcluirOperadorDependencia(int emp_cod, int oper_cod)
        {
            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {emp_cod} and cod_depend = {oper_cod} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {emp_cod} e operador dependencia: {oper_cod} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

        public IEnumerable<tb_depope> BuscarOperadorDependencia(int emp_cod, int oper_cod)
        {
            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {emp_cod} and oper_cod = {oper_cod} ";

            return dao.Obter(where);
        }
    }
}
