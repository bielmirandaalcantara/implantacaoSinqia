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
    public class tb_depopeService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private tb_empresaService _empresaService;
        private tb_dependenciaService _dependenciaService;
        private tb_operadorService _operadorService;

        public tb_depopeService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
            _empresaService = new tb_empresaService(_databaseConfig);
            _dependenciaService = new tb_dependenciaService(_databaseConfig);
            _operadorService = new tb_operadorService(_databaseConfig);
        }

        public tb_depope GravarOperadorDependencia(tb_depope entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_depope>();

            if (entity.emp_cod == null || entity.emp_cod.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.depend_cod == null || entity.depend_cod.Value <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            if (entity.oper_cod == null || entity.oper_cod.Value <= 0)
                throw new ApplicationException("Código do operador inválido");

            string where = $" emp_cod = {entity.emp_cod} and oper_cod = {entity.oper_cod} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.emp_cod} e operador dependencia: {entity.oper_cod} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarOperadorDependencia(tb_depope entity, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_depope>() : _factory.GetDaoCorporativo<tb_depope>(transacao);

            if (entity.emp_cod == null || entity.emp_cod.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.emp_cod.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            if (entity.depend_cod == null || entity.depend_cod.Value <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            tb_dependencia dependencia = _dependenciaService.BuscarDependenciaPorCodigo(entity.emp_cod.Value, entity.depend_cod.Value, transacao);
            if (dependencia == null)
                throw new ApplicationException("Dependencia informada não cadastrada");

            if(entity.oper_cod == null || entity.oper_cod.Value <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_operador operador = _operadorService.BuscarOperadorPorCodigo(entity.emp_cod.Value, entity.oper_cod.Value, transacao);
            if (dependencia == null)
                throw new ApplicationException("Operador informado não cadastrado");

            string where = $" emp_cod = {entity.emp_cod} and oper_cod = {entity.oper_cod} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.emp_cod} e operador dependencia: {entity.oper_cod} ");

            dao.Atualizar(entity, where);

        }

        public void ExcluirOperadorDependencia(int emp_cod, int oper_cod, IDaoTransacao transacao = null)
        {

            if (emp_cod == null || emp_cod <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (oper_cod == null || oper_cod <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(emp_cod, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            tb_operador operador = _operadorService.BuscarOperadorPorCodigo(emp_cod, oper_cod, transacao);

            if (operador == null)
                throw new ApplicationException("Operador informado não cadastrado");

            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {emp_cod} and cod_depend = {oper_cod} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {emp_cod} e operador dependencia: {oper_cod} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

        public IEnumerable<tb_depope> BuscarOperadorDependencia(int emp_cod, int oper_cod, IDaoTransacao transacao = null)
        {

            if (emp_cod == null || emp_cod <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (oper_cod == null || oper_cod <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(emp_cod, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            tb_operador operador = _operadorService.BuscarOperadorPorCodigo(emp_cod, oper_cod, transacao);

            if (operador == null)
                throw new ApplicationException("Operador informado não cadastrado");

            var dao = _factory.GetDaoCorporativo<tb_depope>();

            string where = $" emp_cod = {emp_cod} and oper_cod = {oper_cod} ";

            return dao.Obter(where);
        }
    }
}
