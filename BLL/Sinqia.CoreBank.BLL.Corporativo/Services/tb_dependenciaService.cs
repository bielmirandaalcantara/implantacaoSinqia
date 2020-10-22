using Microsoft.Extensions.Options;
using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.DAO.Core.Services;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.BLL.Corporativo.Services
{
    public class tb_dependenciaService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private CoreDaoFactory _factoryCore;
        private tb_empresaService _empresaService;
        private tb_dependenciaService _dependenciaService;
        private LogService _log;

        public tb_dependenciaService(ConfiguracaoBaseDataBase dataBaseConfig, LogService log)
        {
            _log = log;
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig, _log);
            _factoryCore = new CoreDaoFactory(_databaseConfig);
            _empresaService = new tb_empresaService(_databaseConfig, _log);            
        }       

        public tb_dependencia BuscarDependenciaPorCodigo(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            tb_dependencia retorno = null;

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_depend == null || cod_depend <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            _log.TraceMethodEnd();
            return retorno;

        }

        public IEnumerable<tb_dependencia> BuscarDependencias(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_depend == null || cod_depend <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            var dao = _factory.GetDaoCorporativo<tb_dependencia>();

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            var retorno = dao.Obter(where);

            _log.TraceMethodEnd();

            return retorno;
        }

        public tb_dependencia GravarDependencia(tb_dependencia entity, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            if (entity.cod_empresa == null || entity.cod_empresa.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            var entityBanco = dao.ObterPrimeiro($" cod_empresa = {entity.cod_empresa} and cod_depend = {entity.cod_depend} ");
            if (entityBanco != null)
                throw new ApplicationException($"Dados informados já foram cadastrados - empresa: {entity.cod_empresa} e dependência: {entity.cod_depend} ");

            if (entity.cod_municipio != null)
            {
                var daoMunicipio = _factory.GetDaoCorporativo<tb_municipio>(transacao);
                var municipio = daoMunicipio.ObterPrimeiro($" cod_municipio = {entity.cod_municipio} ");
                if (municipio == null)
                    throw new ApplicationException("Município não encontrado na base de dados");
            }
            else
                throw new ApplicationException("Município obrigatório");

            if(entity.tip_tpdepend != null)
            {
                var daoTpDepend = _factory.GetDaoCorporativo<tb_tpdepend>(transacao);
                var tipoDepend = daoTpDepend.ObterPrimeiro($" tip_tpdepend  = '{entity.tip_tpdepend}' ");
                if (tipoDepend == null)
                    throw new ApplicationException("Tipo de dependência inválido");
            }
            else
                throw new ApplicationException("Tipo de dependência obrigatório");

            if(entity.idc_sit != null)
            {
                if (!entity.idc_sit.ToUpper().Equals(tb_dependencia.situacaoAtivo)
                  && !entity.idc_sit.ToUpper().Equals(tb_dependencia.situacaoInativo))
                    throw new ApplicationException("Campo indicador de situação inválido");
            }
            else
                throw new ApplicationException("Campo indicador de situação obrigatório");

            if(entity.cod_camara != null)
            {
                var daoCamara = _factory.GetDaoCorporativo<tb_camara>(transacao);
                var camara = daoCamara.ObterPrimeiro($" cod_camara = {entity.cod_camara} ");
                if (camara == null)
                    throw new ApplicationException("Código de camara de compensação inválido");
            }

            if (entity.dat_cad == null || entity.dat_cad == DateTime.MinValue)
                entity.dat_cad = DateTime.Now;

            if (entity.dat_atu == null || entity.dat_atu == DateTime.MinValue)
                entity.dat_atu = DateTime.Now;

            entity = dao.Inserir(entity);

            _log.TraceMethodEnd();

            return entity;
        }

        public void EditarDependencia(tb_dependencia entity, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            if (entity.cod_empresa == null || entity.cod_empresa.Value <= 0)
                throw new ApplicationException("Código da empresa inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(entity.cod_empresa.Value, transacao);
            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            if (entity.cod_municipio != null)
            {
                var daoMunicipio = _factory.GetDaoCorporativo<tb_municipio>(transacao);
                var municipio = daoMunicipio.ObterPrimeiro($" cod_municipio = {entity.cod_municipio} ");
                if (municipio == null)
                    throw new ApplicationException("Município não encontrado na base de dados");
            }
            else
                throw new ApplicationException("Município obrigatório");

            if (entity.tip_tpdepend != null)
            {
                var daoTpDepend = _factory.GetDaoCorporativo<tb_tpdepend>(transacao);
                var tipoDepend = daoTpDepend.ObterPrimeiro($" tip_tpdepend  = '{entity.tip_tpdepend}' ");
                if (tipoDepend == null)
                    throw new ApplicationException("Tipo de dependência inválido");
            }
            else
                throw new ApplicationException("Tipo de dependência obrigatório");

            if (entity.idc_sit != null)
            {
                if (!entity.idc_sit.ToUpper().Equals(tb_dependencia.situacaoAtivo)
                  && !entity.idc_sit.ToUpper().Equals(tb_dependencia.situacaoInativo))
                    throw new ApplicationException("Campo indicador de situação inválido");
            }
            else
                throw new ApplicationException("Campo indicador de situação obrigatório");

            string where = $" cod_empresa = {entity.cod_empresa} and cod_depend = {entity.cod_depend} ";

            var listaEntityBanco = dao.Obter(where);

            if (listaEntityBanco == null || !listaEntityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e dependência: {entity.cod_depend} ");

            var entityBanco = listaEntityBanco.First();

            entityBanco.cod_municipio = entity.cod_municipio;
            entityBanco.nom_abv_depend = entity.nom_abv_depend;
            entityBanco.nom_depend = entity.nom_depend;
            entityBanco.bas_cgc_depend = entity.bas_cgc_depend;
            entityBanco.fil_cgc_depend = entity.fil_cgc_depend;
            entityBanco.dig_cgc_depend = entity.dig_cgc_depend;
            entityBanco.tip_log_depend = entity.tip_log_depend;
            entityBanco.end_depend = entity.end_depend;
            entityBanco.cpl_log_depend = entity.cpl_log_depend;
            entityBanco.bai_depend = entity.bai_depend;
            entityBanco.cep_depend = entity.cep_depend;
            entityBanco.ddd_fone_depend = entity.ddd_fone_depend;
            entityBanco.ddd_fone2_depend = entity.ddd_fone2_depend;
            entityBanco.ddd_fone3_depend = entity.ddd_fone3_depend;
            entityBanco.ddd_fone4_depend = entity.ddd_fone4_depend;
            entityBanco.tel_depend = entity.tel_depend;
            entityBanco.tel_2_depend = entity.tel_2_depend;
            entityBanco.tel_3_depend = entity.tel_3_depend;
            entityBanco.tel_4_depend = entity.tel_4_depend;
            entityBanco.ram_depend = entity.ram_depend;
            entityBanco.ram_2_depend = entity.ram_2_depend;
            entityBanco.ram_3_depend = entity.ram_3_depend;
            entityBanco.ram_4_depend = entity.ram_4_depend;
            entityBanco.ddd_fax_depend = entity.ddd_fax_depend;
            entityBanco.ddd_fax2_depend = entity.ddd_fax2_depend;
            entityBanco.ddd_fax3_depend = entity.ddd_fax3_depend;
            entityBanco.fax_depend = entity.fax_depend;
            entityBanco.fax_2_depend = entity.fax_2_depend;
            entityBanco.fax_3_depend = entity.fax_3_depend;
            entityBanco.eml_depend = entity.eml_depend;
            entityBanco.ins_estadual = entity.ins_estadual;
            entityBanco.ins_municipal = entity.ins_municipal;
            entityBanco.nvl_sup_depend = entity.nvl_sup_depend;
            entityBanco.nvl_1_depend = entity.nvl_1_depend;
            entityBanco.nvl_2_depend = entity.nvl_2_depend;
            entityBanco.nvl_3_depend = entity.nvl_3_depend;
            entityBanco.nvl_4_depend = entity.nvl_4_depend;
            entityBanco.nvl_5_depend = entity.nvl_5_depend;
            entityBanco.nvl_6_depend = entity.nvl_6_depend;
            entityBanco.nvl_7_depend = entity.nvl_7_depend;
            entityBanco.nvl_8_depend = entity.nvl_8_depend;
            entityBanco.nvl_9_depend = entity.nvl_9_depend;
            entityBanco.nvl_10_depend = entity.nvl_10_depend;
            entityBanco.dat_ini_depend = entity.dat_ini_depend;
            entityBanco.dat_fim_depend = entity.dat_fim_depend;

            entityBanco.usu_atu = entity.usu_atu;
            if (entity.dat_atu == null || entity.dat_atu == DateTime.MinValue)
                entityBanco.dat_atu = DateTime.Now;

            entityBanco.idc_sit = entity.idc_sit;
            entityBanco.tip_tpdepend = entity.tip_tpdepend;
            entityBanco.cod_camara = entity.cod_camara;
            entityBanco.num_log_depend = entity.num_log_depend;
            entityBanco.dat_rollout = entity.dat_rollout;
            entityBanco.dat_sit = entity.dat_sit;

            dao.Atualizar(entity, where);

            _log.TraceMethodEnd();
        }

        public void ExcluirDependencia(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_depend == null || cod_depend <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não estão cadastrados - empresa: {cod_empresa} e dependência: {cod_depend} ");

            var entity = entityBanco.FirstOrDefault();

            dao.Remover(entity, where);

            _log.TraceMethodEnd();
        }

    }
}
