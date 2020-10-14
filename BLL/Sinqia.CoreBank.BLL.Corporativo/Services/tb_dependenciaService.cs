﻿using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Sinqia.CoreBank.BLL.Corporativo.Services
{
    public class tb_dependenciaService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private CoreDaoFactory _factoryCore;

        public tb_dependenciaService(IOptions<ConfiguracaoBaseDataBase> dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig.Value;
            _factory = new CorporativoDaoFactory(_databaseConfig);
            _factoryCore = new CoreDaoFactory(_databaseConfig);
        }

        public tb_dependencia BuscarDependenciaPorCodigo(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            tb_dependencia retorno = null;

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            return retorno;

        }

        public IEnumerable<tb_dependencia> BuscarDependencias(int cod_empresa, int cod_depend)
        {
            var dao = _factory.GetDaoCorporativo<tb_dependencia>();

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            return dao.Obter(where);
        }

        public tb_dependencia GravarDependencia(tb_dependencia entity, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            string where = $" cod_empresa = {entity.cod_empresa} and cod_depend = {entity.cod_depend} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e dependência: {entity.cod_depend} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarDependencia(tb_dependencia entity, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            string where = $" cod_empresa = {entity.cod_empresa} and cod_depend = {entity.cod_depend} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e dependência: {entity.cod_depend} ");

            dao.Atualizar(entity, where);           

        }

        public void ExcluirDependencia(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e dependência: {cod_depend} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

    }
}
