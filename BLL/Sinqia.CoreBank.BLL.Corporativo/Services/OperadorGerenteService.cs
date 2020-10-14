﻿using Microsoft.Extensions.Options;
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
    public class OperadorGerenteService
    {
        private ConfiguracaoBaseDataBase _databaseConfig;
        private tb_operadorService _serviceOperador;
        private tb_gerenteService _serviceGerente;
        private CoreDaoFactory _factoryCore;

        public OperadorGerenteService(ConfiguracaoBaseDataBase dataBaseConfig)
        {
            _databaseConfig = dataBaseConfig;
            _serviceOperador = new tb_operadorService(dataBaseConfig);
            _serviceGerente = new tb_gerenteService(dataBaseConfig);
            _factoryCore = new CoreDaoFactory(dataBaseConfig);
        }

        public tb_operador BuscarOperadorGerentePorCodigo(int cod_empresa, int cod_oper, string tipoGerente, IDaoTransacao transacao = null)
        {
            tb_operador operador = _serviceOperador.BuscarOperadorPorCodigo(cod_empresa, cod_oper, transacao);

            if (operador != null)
                operador.tb_gerentes = _serviceGerente.BuscarGerente(cod_empresa, cod_oper, tipoGerente, transacao);
            return operador;
        }

        public void GravarOperadorGerente(tb_operador operador)
        {
            using (var transacao = _factoryCore.GetTransacao())
            {
                transacao.BeginTransaction();
                try
                {
                    _serviceOperador.GravarOperador(operador, transacao);

                    if(operador.tb_gerentes != null && operador.tb_gerentes.Any())
                    {
                        foreach(tb_gerente gerente in operador.tb_gerentes)
                            _serviceGerente.GravarGerente(gerente, transacao);
                    }

                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }

        public void AtualizarOperadorGerente(tb_operador operador)
        {
            using (var transacao = _factoryCore.GetTransacao())
            {
                transacao.BeginTransaction();
                try
                {
                    _serviceOperador.EditarOperador(operador, transacao);

                    if (operador.tb_gerentes != null && operador.tb_gerentes.Any())
                    {
                        foreach (tb_gerente gerente in operador.tb_gerentes)
                            _serviceGerente.EditarGerente(gerente, transacao);
                    }

                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }

        public void ExcluirOperadorGerente(int cod_empresa, int cod_operador, string tipoGerente)
        {
            using (var transacao = _factoryCore.GetTransacao())
            {
                transacao.BeginTransaction();
                try
                {
                    _serviceGerente.ExcluirGerente(cod_empresa, cod_operador, tipoGerente, transacao);
                    _serviceOperador.ExcluirOperador(cod_empresa, cod_operador, transacao);

                    transacao.Commit();
                }
                catch (Exception ex)
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }
    }
}
