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
    public class tb_empresaService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private CorporativoDaoFactory _factory;

        public tb_empresaService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _factory = new CorporativoDaoFactory(_databaseConfig);
        }

        public tb_empresa BuscarEmpresaPorCodigo(int cod_empresa, IDaoTransacao transacao = null)
        {
            var dao = transacao == null ? _factory.GetDaoCorporativo<tb_empresa>() : _factory.GetDaoCorporativo<tb_empresa>(transacao);

            tb_empresa retorno = dao.ObterPrimeiro($" cod_empresa = {cod_empresa} ");            

            return retorno;

        }       

    }
}
