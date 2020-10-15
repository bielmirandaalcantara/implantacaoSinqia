using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinqia.CoreBank.BLL.Corporativo.Services
{
    public class tb_operadorService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private tb_empresaService _empresaService;

        public tb_operadorService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
            _empresaService = new tb_empresaService(_databaseConfig);
        }

        public tb_operador BuscarOperadorPorCodigo(int cod_empresa, int cod_oper, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);
            tb_operador retorno = null;

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_oper == null || cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            return retorno;
        }

        public IEnumerable<tb_operador> BuscarOperadores(int cod_empresa, int cod_oper, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_oper == null || cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} ";

            return dao.Obter(where);
        }

        public tb_operador GravarOperador(tb_operador entity, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            if (entity.cod_empresa == null || entity.cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_oper == null || entity.cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {entity.cod_empresa}  and cod_oper = {entity.cod_oper} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e operador: {entity.cod_oper} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarOperador(tb_operador entity, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            if (entity.cod_empresa == null || entity.cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_oper == null || entity.cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_oper = {entity.cod_oper} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e operador: {entity.cod_oper} ");

            dao.Atualizar(entity, where);

        }

        public void ExcluirOperador(int cod_empresa,int cod_oper, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_oper == null || cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa}  and cod_oper = {cod_oper} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e operador: {cod_oper} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }
    }
}
