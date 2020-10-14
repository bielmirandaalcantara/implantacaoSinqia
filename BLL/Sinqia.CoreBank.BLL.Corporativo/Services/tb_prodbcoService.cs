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
    public class tb_prodbcoService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;

        public tb_prodbcoService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
        }

        public tb_prodbco BuscarProdutoBancarioPorCodigo(int cod_empresa, int cod_prodbco)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();
            tb_prodbco retorno = null;

            string where = $" cod_empresa = {cod_empresa} and cod_prodbco = {cod_prodbco} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            return retorno;

        }

        public tb_prodbco GravarProdutoBancario(tb_prodbco entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            string where = $" cod_empresa = {entity.cod_empresa} and cod_prodbco = {entity.cod_prodbco} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e produto bancário: {entity.cod_prodbco} ");

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarProdutoBancario(tb_prodbco entity)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            string where = $" cod_empresa = {entity.cod_empresa} and cod_prodbco = {entity.cod_prodbco} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e produto bancário: {entity.cod_prodbco} ");

            dao.Atualizar(entity, where);
        }

        public void ExcluirProdutoBancario(int cod_empresa, int cod_prodbco)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            string where = $" cod_empresa = {cod_empresa} and cod_prodbco = {cod_prodbco} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e produto bancário: {cod_prodbco} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }

        public IEnumerable<tb_prodbco> BuscarProdutoBancario(int cod_empresa, int cod_prodbco)
        {
            var dao = _factory.GetDaoCorporativo<tb_prodbco>();

            string where = $" cod_empresa = {cod_empresa} and cod_prodbco = {cod_prodbco} ";

            return dao.Obter(where);
        }

    }
}
