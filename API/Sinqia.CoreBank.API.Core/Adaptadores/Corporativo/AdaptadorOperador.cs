using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Adaptadores.Corporativo
{
    public class AdaptadorOperador
    {
        private LogService _log;
        public AdaptadorOperador(LogService log)
        {
            _log = log;
        }

        public tb_operador AdaptarMsgOperadorToModeltb_operador(MsgRegistroOperador msg)
        {
            tb_operador tb_operador = new tb_operador();

            if (msg.codigoSisbacen != null && msg.codigoSisbacen.Value > 0)
                tb_operador.cod_empresa = msg.codigoSisbacen;

            if (msg.codigoFuncionario != null && msg.codigoFuncionario.Value > 0)
                tb_operador.cod_oper = msg.codigoFuncionario;

            if (msg.codigoDependenciaSisbacen != null && msg.codigoDependenciaSisbacen.Value > 0)
                tb_operador.cod_depend = msg.codigoDependenciaSisbacen;

            if (!string.IsNullOrWhiteSpace(msg.nomeFuncionario))
                tb_operador.nom_oper = msg.nomeFuncionario;

            if (!string.IsNullOrWhiteSpace(msg.nomeAbreviadoFuncionario))
                tb_operador.nom_abv_oper = msg.nomeAbreviadoFuncionario;

            if (!string.IsNullOrWhiteSpace(msg.identificadorFuncionario))
                tb_operador.idt_oper = msg.identificadorFuncionario;

            if (!string.IsNullOrWhiteSpace(msg.loginFuncionario))
                tb_operador.log_oper = msg.loginFuncionario;

            if (!string.IsNullOrWhiteSpace(msg.tipoFuncionario))
                tb_operador.tip_oper = msg.tipoFuncionario;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                tb_operador.dat_cad = msg.dataCadastro;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                tb_operador.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataUltimaAtualizacao != null && msg.dataUltimaAtualizacao.Value != DateTime.MinValue)
                tb_operador.dat_atu = msg.dataUltimaAtualizacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                tb_operador.dat_sit = msg.dataSituacao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                tb_operador.idc_sit = msg.indicadorSituacao;

            if (msg.codigoCargoFuncionario != null && msg.codigoCargoFuncionario.Value > 0)
                tb_operador.cod_cargo = msg.codigoCargoFuncionario;

            if (!string.IsNullOrWhiteSpace(msg.cpfOperador))
                tb_operador.cpf_oper = msg.cpfOperador;

            if (!string.IsNullOrWhiteSpace(msg.digitoOperador))
                tb_operador.dig_oper = msg.digitoOperador;

            if (!string.IsNullOrWhiteSpace(msg.sexoOperador))
                tb_operador.sex_oper = msg.sexoOperador;

            if (!string.IsNullOrWhiteSpace(msg.dddOperador))
                tb_operador.ddd_oper = msg.dddOperador;

            if (!string.IsNullOrWhiteSpace(msg.telefoneOperador))
                tb_operador.tel_oper = msg.telefoneOperador;

            if (!string.IsNullOrWhiteSpace(msg.ramalOperador))
                tb_operador.ram_oper = msg.ramalOperador;

            if (!string.IsNullOrWhiteSpace(msg.emailOperador))
                tb_operador.eml_oper = msg.emailOperador;

            if (msg.codigoGerenteOrigem != null && msg.codigoGerenteOrigem.Value > 0)
                tb_operador.cod_ger_origem = msg.codigoGerenteOrigem;

            if (!string.IsNullOrWhiteSpace(msg.codigoCRK))
                tb_operador.OPECODCRK = msg.codigoCRK;

            //if (msg.dataInicioOperacao != null && msg.dataInicioOperacao.Value != DateTime.MinValue)
            //    tb_operador.dat_ini_gerente = msg.dataInicioOperacao;

            //if (!string.IsNullOrWhiteSpace(msg.tipoGerente))
            //    tb_operador.tip_gerente = msg.tipoGerente;

            //if (!string.IsNullOrWhiteSpace(msg.situacaoGerente))
            //    tb_operador.sit_gerente = msg.situacaoGerente;

            //if (msg.dataFimOperacao != null && msg.dataFimOperacao.Value != DateTime.MinValue)
            //    tb_operador.dat_fim_gerente = msg.dataFimOperacao;

            //if (!string.IsNullOrWhiteSpace(msg.indicadorRecebCadVencido))
            //    tb_operador.GERIDCMAILCUCVCT = msg.indicadorRecebCadVencido;

            return tb_operador;
        }
    }
}
