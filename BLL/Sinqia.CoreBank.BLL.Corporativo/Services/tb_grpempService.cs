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
    public class tb_grpempService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;

        public tb_grpempService(IOptions<ConfiguracaoBaseDataBase> dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig.Value;
            _factory = new CorporativoDaoFactory(_databaseConfig);
        }

        public tb_grpemp GravarGrupoEmpresarial(tb_grpemp entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            string where = $" cod_empresa = {entity.cod_empresa} and cod_grpemp = {entity.cod_grpemp} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e grupo empresarial: {entity.cod_grpemp} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarGrupoEmpresarial(tb_grpemp entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            string where = $" cod_empresa = {entity.cod_empresa} and cod_grpemp = {entity.cod_grpemp} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e grupo empresarial: {entity.cod_grpemp} ");

            dao.Atualizar(entity, where);

        }

        public void ExcluirGrupoEmpresarial(int cod_empresa, int cod_grpemp)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            string where = $" cod_empresa = {cod_empresa} and cod_grpemp = {cod_grpemp} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e grupo empresarial: {cod_grpemp} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

        public IEnumerable<tb_grpemp> BuscarGrupoEmpresarial(int cod_empresa, int cod_grpemp)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            string where = $" cod_empresa = {cod_empresa} and cod_grpemp = {cod_grpemp} ";

            return dao.Obter(where);
        }

    }
}
