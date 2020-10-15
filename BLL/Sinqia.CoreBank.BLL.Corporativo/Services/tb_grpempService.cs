using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Interfaces;
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
        private tb_empresaService _empresaService;
        private tb_dependenciaService _dependenciaService;

        public tb_grpempService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
            _empresaService = new tb_empresaService(_databaseConfig);
            _dependenciaService = new tb_dependenciaService(_databaseConfig);
        }

        public tb_grpemp GravarGrupoEmpresarial(tb_grpemp entity, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            if (entity.cod_empresa == null || entity.cod_empresa.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_depend == null || entity.cod_depend.Value <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            tb_dependencia dependencia = _dependenciaService.BuscarDependenciaPorCodigo(entity.cod_depend.Value, entity.cod_depend.Value, transacao);
            if (dependencia == null)
                throw new ApplicationException("Dependencia informada não cadastrada");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_grpemp = {entity.cod_grpemp} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e grupo empresarial: {entity.cod_grpemp} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarGrupoEmpresarial(tb_grpemp entity, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            if (entity.cod_empresa == null || entity.cod_empresa.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_depend == null || entity.cod_depend.Value <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            tb_dependencia dependencia = _dependenciaService.BuscarDependenciaPorCodigo(entity.cod_depend.Value, entity.cod_depend.Value, transacao);
            if (dependencia == null)
                throw new ApplicationException("Dependencia informada não cadastrada");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_grpemp = {entity.cod_grpemp} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e grupo empresarial: {entity.cod_grpemp} ");

            dao.Atualizar(entity, where);

        }

        public void ExcluirGrupoEmpresarial(int cod_empresa, int cod_grpemp, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_grpemp == null || cod_grpemp <= 0)
                throw new ApplicationException("Código de grupo empresarial inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_grpemp = {cod_grpemp} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e grupo empresarial: {cod_grpemp} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

        public IEnumerable<tb_grpemp> BuscarGrupoEmpresarial(int cod_empresa, int cod_grpemp, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_grpemp>();

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_grpemp == null || cod_grpemp <= 0)
                throw new ApplicationException("Código de grupo empresarial inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_grpemp = {cod_grpemp} ";

            return dao.Obter(where);
        }

    }
}
