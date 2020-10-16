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

namespace Sinqia.CoreBank.BLL.Corporativo.Services
{
    public class tb_dependenciaService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private CoreDaoFactory _factoryCore;
        private tb_empresaService _empresaService;
        private tb_dependenciaService _dependenciaService;

        public tb_dependenciaService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
            _factoryCore = new CoreDaoFactory(_databaseConfig);
            _empresaService = new tb_empresaService(_databaseConfig);
        }       

        public tb_dependencia BuscarDependenciaPorCodigo(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_dependencia>() : _factory.GetDaoCorporativo<tb_dependencia>(transacao);

            tb_dependencia retorno = null;

            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_depend == null || cod_depend <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            var listaEntity = dao.Obter(where);

            if (listaEntity != null && listaEntity.Any())
                retorno = listaEntity.FirstOrDefault();

            return retorno;

        }

        public IEnumerable<tb_dependencia> BuscarDependencias(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
            
            if (cod_empresa == null || cod_empresa <= 0)
                throw new ApplicationException("Código da empresa inválido");

            if (cod_depend == null || cod_depend <= 0)
                throw new ApplicationException("Código de dependencia inválido");

            tb_empresa empresa = _empresaService.BuscarEmpresaPorCodigo(cod_empresa, transacao);

            if (empresa == null)
                throw new ApplicationException("Empresa informada não cadastrada");

            var dao = _factory.GetDaoCorporativo<tb_dependencia>();

            string where = $" cod_empresa = {cod_empresa} and cod_depend = {cod_depend} ";

            return dao.Obter(where);
        }

        public tb_dependencia GravarDependencia(tb_dependencia entity, IDaoTransacao transacao = null)
        {
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

            entity = dao.Inserir(entity);

            return entity;
        }

        public void EditarDependencia(tb_dependencia entity, IDaoTransacao transacao = null)
        {
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

            if (entity.tip_tpdepend != null)
            {
                var daoTpDepend = _factory.GetDaoCorporativo<tb_tpdepend>(transacao);
                var tipoDepend = daoTpDepend.ObterPrimeiro($" tip_tpdepend  = '{entity.tip_tpdepend}' ");
                if (tipoDepend == null)
                    throw new ApplicationException("Tipo de dependência inválido");
            }

            if (entity.idc_sit != null)
            {
                if (!entity.idc_sit.ToUpper().Equals(tb_dependencia.situacaoAtivo)
                  && !entity.idc_sit.ToUpper().Equals(tb_dependencia.situacaoInativo))
                    throw new ApplicationException("Campo indicador de situação inválido");
            }

            string where = $" cod_empresa = {entity.cod_empresa} and cod_depend = {entity.cod_depend} ";

            var entityBanco = dao.Obter(where);

            if (entityBanco == null || !entityBanco.Any())
                throw new ApplicationException($"Dados informados não foram cadastrados - empresa: {entity.cod_empresa} e dependência: {entity.cod_depend} ");

            dao.Atualizar(entity, where);           

        }

        public void ExcluirDependencia(int cod_empresa, int cod_depend, IDaoTransacao transacao = null)
        {
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
        }

    }
}
