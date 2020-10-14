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

        public tb_operadorService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);            
        }

        public tb_operador BuscarOperadorPorCodigo(int cod_empresa, int cod_oper, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);
            tb_operador retorno = null;

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            return retorno;
        }

        public IEnumerable<tb_operador> BuscarOperadores(int cod_empresa, int cod_oper, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} ";

            return dao.Obter(where);
        }

        public tb_operador GravarOperador(tb_operador entity, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

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

            string where = $" cod_empresa = {entity.cod_empresa} and cod_oper = {entity.cod_oper} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e operador: {entity.cod_oper} ");

            dao.Atualizar(entity, where);

        }

        public void ExcluirOperador(int cod_empresa,int cod_oper, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            string where = $" cod_empresa = {cod_empresa}  and cod_oper = {cod_oper} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e operador: {cod_oper} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);
        }
    }
}
