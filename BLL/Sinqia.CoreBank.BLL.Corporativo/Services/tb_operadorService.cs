using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
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
        private LogService _log;

        public tb_operadorService(ConfiguracaoBaseDataBase dataBaseConfig, LogService log)
        {
            _log = log;
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig, _log);
            _empresaService = new tb_empresaService(_databaseConfig, _log);            
        }

        public tb_operador BuscarOperadorPorCodigo(int cod_empresa, int cod_oper, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);
            tb_operador retorno = null;

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_oper == null || cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            _log.TraceMethodEnd();
            return retorno;
        }

        public IEnumerable<tb_operador> BuscarOperadores(int cod_empresa, int cod_oper, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_oper == null || cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} ";

            var retorno = dao.Obter(where);

            _log.TraceMethodEnd();
            return retorno;
        }

        public tb_operador GravarOperador(tb_operador entity, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

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

            if (entity.dat_cad == null || entity.dat_cad == DateTime.MinValue)
                entity.dat_cad = DateTime.Now;

            if (entity.dat_atu == null || entity.dat_atu == DateTime.MinValue)
                entity.dat_atu = DateTime.Now;

            entity = dao.Inserir(entity);

            _log.TraceMethodEnd();
            return entity;
        }

        public void EditarOperador(tb_operador entity, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_operador>() : _factory.GetDaoCorporativo<tb_operador>(transacao);

            if (entity.cod_empresa == null || entity.cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (entity.cod_oper == null || entity.cod_oper <= 0)
                throw new ApplicationException("Código do operador inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_oper = {entity.cod_oper} ";

            var listaEntityBanco = dao.Obter(where);

            if (listaEntityBanco == null || !listaEntityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e operador: {entity.cod_oper} ");

            var entityBanco = listaEntityBanco.First();

            entityBanco.cod_depend = entity.cod_depend;
            entityBanco.nom_oper = entity.nom_oper;
            entityBanco.nom_abv_oper = entity.nom_abv_oper;
            entityBanco.idt_oper = entity.idt_oper;
            entityBanco.log_oper = entity.log_oper;
            entityBanco.tip_oper = entity.tip_oper;
            entityBanco.usu_atu = entity.usu_atu;

            if (entity.dat_atu == null || entity.dat_atu == DateTime.MinValue)
                entity.dat_atu = DateTime.Now;

            entityBanco.dat_sit = entity.dat_sit;
            entityBanco.idc_sit = entity.idc_sit;
            entityBanco.cod_cargo = entity.cod_cargo;
            entityBanco.cpf_oper = entity.cpf_oper;
            entityBanco.dig_oper = entity.dig_oper;
            entityBanco.sex_oper = entity.sex_oper;
            entityBanco.ddd_oper = entity.ddd_oper;
            entityBanco.tel_oper = entity.tel_oper;
            entityBanco.ram_oper = entity.ram_oper;
            entityBanco.eml_oper = entity.eml_oper;
            entityBanco.cod_ger_origem = entity.cod_ger_origem;
            entityBanco.OPECODCRK = entity.OPECODCRK;

            dao.Atualizar(entityBanco, where);

            _log.TraceMethodEnd();

        }

        public void ExcluirOperador(int cod_empresa,int cod_oper, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

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

            _log.TraceMethodEnd();
        }
    }
}
