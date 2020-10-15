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
    public class tb_prodbcoService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private tb_empresaService _empresaService;
        private tb_grprodutoService _grprodutoService;

        public tb_prodbcoService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
            _empresaService = new tb_empresaService(_databaseConfig);
            _grprodutoService = new tb_grprodutoService(_databaseConfig);
        }

        public tb_prodbco BuscarProdutoBancarioPorCodigo(int cod_empresa, int cod_prodbco, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();
            tb_prodbco retorno = null;

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_prodbco == null || cod_prodbco <= 0)
                throw new ApplicationException("Código de produto inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_prodbco = {cod_prodbco} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            return retorno;

        }

        public tb_prodbco GravarProdutoBancario(tb_prodbco entity, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            if (entity.cod_empresa == null || entity.cod_empresa.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_grproduto == null || entity.cod_grproduto.Value <= 0)
                throw new ApplicationException("Código do grupo do produto inválido");

            if (entity.cod_prodbco == null || entity.cod_prodbco.Value <= 0)
                throw new ApplicationException("Código do produto inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            tb_grproduto grproduto = _grprodutoService.BuscarGrupoProdutoPorCodigo(entity.cod_empresa.Value, entity.cod_grproduto.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Grupo do produto informado não cadastrado");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_prodbco = {entity.cod_prodbco} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e produto bancário: {entity.cod_prodbco} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarProdutoBancario(tb_prodbco entity, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            if (entity.cod_empresa == null || entity.cod_empresa.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_grproduto == null || entity.cod_grproduto.Value <= 0)
                throw new ApplicationException("Código do grupo do produto inválido");

            if (entity.cod_prodbco == null || entity.cod_prodbco.Value <= 0)
                throw new ApplicationException("Código do produto inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            tb_grproduto grproduto = _grprodutoService.BuscarGrupoProdutoPorCodigo(entity.cod_empresa.Value, entity.cod_grproduto.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Grupo do produto informado não cadastrado");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_prodbco = {entity.cod_prodbco} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e produto bancário: {entity.cod_prodbco} ");

            dao.Atualizar(entity, where);
        }

        public void ExcluirProdutoBancario(int cod_empresa, int cod_prodbco, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_prodbco == null || cod_prodbco <= 0)
                throw new ApplicationException("Código de produto inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_prodbco = {cod_prodbco} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e produto bancário: {cod_prodbco} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

        public IEnumerable<tb_prodbco> BuscarProdutoBancario(int cod_empresa, int cod_prodbco, IDaoTransacao transacao = null)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_prodbco == null || cod_prodbco <= 0)
                throw new ApplicationException("Código de produto inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_prodbco = {cod_prodbco} ";

            return dao.Obter(where);
        }

    }
}
