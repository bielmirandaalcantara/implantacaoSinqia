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
    public class tb_gerenteService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private LogService _log;

        public tb_gerenteService(ConfiguracaoBaseDataBase dataBaseConfig, LogService log)
        {
            _log = log;
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig, _log);            
        }

        public IEnumerable<tb_gerente> BuscarGerente(int cod_empresa, int cod_oper, string tipoGerente, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_gerente>() : _factory.GetDaoCorporativo<tb_gerente>(transacao);

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} and tip_gerente = '{tipoGerente}' ";

            var retorno = dao.Obter(where);

            _log.TraceMethodEnd();
            return retorno;
        }

        public tb_gerente GravarGerente(tb_gerente entity, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_gerente>() : _factory.GetDaoCorporativo<tb_gerente>(transacao);

            string where = $" cod_empresa = {entity.cod_empresa}  and cod_oper = {entity.cod_oper} and tip_gerente = '{entity.tip_gerente}' ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e operador-gerente: {entity.cod_oper} ");

            if(string.IsNullOrWhiteSpace(entity.tip_gerente))
                throw new ApplicationException($"Tipo do gerente obrigatório");

            if (string.IsNullOrWhiteSpace(entity.sit_gerente))
                throw new ApplicationException($"Situação do gerente obrigatório");

            entity = dao.Inserir(entity);

            _log.TraceMethodEnd();
            return entity;
        }

        public void EditarGerente(tb_gerente entity, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_gerente>() : _factory.GetDaoCorporativo<tb_gerente>(transacao);

            string where = $" cod_empresa = {entity.cod_empresa} and cod_oper = {entity.cod_oper} and tip_gerente = '{entity.tip_gerente.ToUpper()}' ";

            var listaEntityBanco = dao.Obter(where);

            if (listaEntityBanco != null && listaEntityBanco.Any())
            {
                var entityBanco = listaEntityBanco.First();

                entityBanco.cod_depend = entity.cod_depend;
                entityBanco.dat_ini_gerente = entity.dat_ini_gerente;
                entityBanco.dat_fim_gerente = entity.dat_fim_gerente;
                entityBanco.usu_atu_gerente = entity.usu_atu_gerente;
                entityBanco.sit_gerente = entity.sit_gerente;
                entityBanco.GERIDCMAILCUCVCT = entity.GERIDCMAILCUCVCT;

                dao.Atualizar(entityBanco, where);
            }

            _log.TraceMethodEnd();
        }

        public void ExcluirGerente(int cod_empresa, int cod_oper, string tipoGerente, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_gerente>() : _factory.GetDaoCorporativo<tb_gerente>(transacao);

            string where = $" cod_empresa = {cod_empresa} and cod_oper = {cod_oper} and tip_gerente = '{tipoGerente}' ";

            var entityBanco = dao.Obter(where);

            if (entityBanco != null && entityBanco.Any())
            {
                var entity = entityBanco.FirstOrDefault();

                dao.Remover(entity, where);

            }

            _log.TraceMethodEnd();
        }
    }
}
