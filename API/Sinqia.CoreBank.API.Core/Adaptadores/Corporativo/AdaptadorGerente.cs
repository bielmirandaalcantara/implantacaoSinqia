using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Adaptadores.Corporativo
{
    public class AdaptadorGerente
    {
        private LogService _log;
        public AdaptadorGerente(LogService log)
        {
            _log = log;
        }

        public tb_gerente AdaptarMsgOperadorTotb_gerente(MsgRegistroOperador msg)
        {
            _log.TraceMethodStart();

            tb_gerente tb_gerente = new tb_gerente();

            if (msg.codigoSisbacen != null && msg.codigoSisbacen.Value > 0)
                tb_gerente.cod_empresa = msg.codigoSisbacen;

            if (msg.codigoFuncionario != null && msg.codigoFuncionario.Value > 0)
                tb_gerente.cod_oper = msg.codigoFuncionario;

            if (msg.codigoDependenciaSisbacen != null && msg.codigoDependenciaSisbacen.Value > 0)
                tb_gerente.cod_depend = msg.codigoDependenciaSisbacen;

            if (msg.dataInicioOperacao != null && msg.dataInicioOperacao.Value != DateTime.MinValue)
                tb_gerente.dat_ini_gerente = msg.dataInicioOperacao;

            if (msg.dataFimOperacao != null && msg.dataFimOperacao.Value != DateTime.MinValue)
                tb_gerente.dat_fim_gerente = msg.dataFimOperacao;

            if (!string.IsNullOrWhiteSpace(msg.tipoGerente))
                tb_gerente.tip_gerente = msg.tipoGerente.ToUpper();

            if (!string.IsNullOrWhiteSpace(msg.situacaoGerente))
                tb_gerente.sit_gerente = msg.situacaoGerente;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                tb_gerente.usu_atu_gerente = msg.usuarioUltimaAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorRecebCadVencido))
                tb_gerente.GERIDCMAILCUCVCT = msg.indicadorRecebCadVencido;

            _log.TraceMethodEnd();

            return tb_gerente;
        }

        public MsgRegistroOperador tb_depndenciaToMsgOperador(tb_gerente tb_gerente)
        {
            _log.TraceMethodStart();

            MsgRegistroOperador msg = new MsgRegistroOperador();

            if (tb_gerente.cod_empresa != null && tb_gerente.cod_empresa.Value > 0)
                msg.codigoSisbacen = tb_gerente.cod_empresa;

            if (tb_gerente.cod_oper != null && tb_gerente.cod_oper.Value > 0)
                msg.codigoFuncionario = tb_gerente.cod_oper;

            if (tb_gerente.cod_depend != null && tb_gerente.cod_depend.Value > 0)
                msg.codigoDependenciaSisbacen = tb_gerente.cod_depend;

            if (tb_gerente.dat_ini_gerente != null && tb_gerente.dat_ini_gerente.Value != DateTime.MinValue)
                msg.dataInicioOperacao = tb_gerente.dat_ini_gerente;

            if (tb_gerente.dat_fim_gerente != null && tb_gerente.dat_fim_gerente.Value != DateTime.MinValue)
                msg.dataFimOperacao = tb_gerente.dat_fim_gerente;

            if (!string.IsNullOrWhiteSpace(tb_gerente.tip_gerente))
                msg.tipoGerente = tb_gerente.tip_gerente.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_gerente.sit_gerente))
                msg.situacaoGerente = tb_gerente.sit_gerente.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_gerente.usu_atu_gerente))
                msg.usuarioUltimaAtualizacao = tb_gerente.usu_atu_gerente.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_gerente.GERIDCMAILCUCVCT))
                msg.indicadorRecebCadVencido = tb_gerente.GERIDCMAILCUCVCT.TrimEnd();

            _log.TraceMethodEnd();

            return msg;
        }
    }
}
