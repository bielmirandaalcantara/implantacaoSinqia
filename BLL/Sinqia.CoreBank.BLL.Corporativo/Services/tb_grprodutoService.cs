using Sinqia.CoreBank.Configuracao.Configuration;
using Sinqia.CoreBank.DAO.Core.Interfaces;
using Sinqia.CoreBank.DAO.Corporativo.Services;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.BLL.Corporativo.Services
{
    class tb_grprodutoService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;
        private LogService _log;

        public tb_grprodutoService(ConfiguracaoBaseDataBase dataBaseConfig, LogService log)
        {
            _log = log;
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig, _log);            
        }

        public tb_grproduto BuscarGrupoProdutoPorCodigo(int cod_empresa, int cod_grproduto, IDaoTransacao transacao = null)
        {
            _log.TraceMethodStart();

            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_grproduto>() : _factory.GetDaoCorporativo<tb_grproduto>(transacao);

            tb_grproduto retorno = dao.ObterPrimeiro($" cod_empresa = {cod_empresa}  and cod_grproduto = {cod_grproduto} ");

            _log.TraceMethodEnd();
            return retorno;

        }
    }
}
