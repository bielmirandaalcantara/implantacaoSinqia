using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.API.Core.Models;
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
        private AdaptadorGerente _AdaptadorGerente;

        public AdaptadorOperador(LogService log)
        {
            _log = log;
            _AdaptadorGerente = new AdaptadorGerente(_log);
        }

        public MsgRetorno AdaptarMsgRetorno(MsgOperador msg, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msg != null && msg.header != null)
            {
                identificador = msg.header.identificadorEnvio;
                dataEnvio = msg.header.dataHoraEnvio.HasValue ? msg.header.dataHoraEnvio.Value : DateTime.Now;
            }

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };

            if (erros.Any())
            {
                header.erros = erros.ToArray();
            }

            retorno.header = header;

            _log.TraceMethodEnd();

            return retorno;
        }

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros)
        {
            return AdaptarMsgRetorno(erros, string.Empty);
        }
        public MsgRetorno AdaptarMsgRetorno(IList<string> erros, string identificador)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };

            if (erros.Any())
            {
                header.erros = erros.ToArray();
            }

            retorno.header = header;

            _log.TraceMethodEnd();

            return retorno;
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros)
        {
            return AdaptarMsgRetornoGet(null, erros, string.Empty);
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros, string identificador)
        {
            return AdaptarMsgRetornoGet(null, erros, identificador);
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(object msg, IList<string> erros, string identificador)
        {
            _log.TraceMethodStart();

            MsgRetornoGet retorno = new MsgRetornoGet();
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };
            retorno.header = header;

            if (erros.Any())
            {
                header.erros = erros.ToArray();
            }

            if (!erros.Any() && msg != null)
                retorno.body = msg;

            _log.TraceMethodEnd();

            return retorno;
        }


        public tb_operador AdaptarMsgOperadorGerenteTotb_operador(MsgRegistroOperador msg)
        {

            tb_operador tb_operador = new tb_operador();

            tb_operador = AdaptarMsgOperadorTotb_operador(msg);

            var listatbgerente = new List<tb_gerente>();
            listatbgerente.Add(_AdaptadorGerente.AdaptarMsgOperadorTotb_gerente(msg));

            tb_operador.tb_gerentes = listatbgerente;

            return tb_operador;
        }

        public tb_operador AdaptarMsgOperadorTotb_operador(MsgRegistroOperador msg)
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

            return tb_operador;
        }

        public MsgRegistroOperador tb_operadorToMsgOperador(tb_operador tb_operador)
        {
            _log.TraceMethodStart();

            MsgRegistroOperador msg = new MsgRegistroOperador();

            if (tb_operador.cod_empresa != null && tb_operador.cod_empresa.Value > 0)
                msg.codigoSisbacen = tb_operador.cod_empresa;

            if (tb_operador.cod_oper != null && tb_operador.cod_oper.Value > 0)
                msg.codigoFuncionario = tb_operador.cod_oper;

            if (tb_operador.cod_depend != null && tb_operador.cod_depend.Value > 0)
                msg.codigoDependenciaSisbacen = tb_operador.cod_depend;

            if (!string.IsNullOrWhiteSpace(tb_operador.nom_oper))
                msg.nomeFuncionario = tb_operador.nom_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.nom_abv_oper))
                msg.nomeAbreviadoFuncionario = tb_operador.nom_abv_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.idt_oper))
                msg.identificadorFuncionario = tb_operador.idt_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.log_oper))
                msg.loginFuncionario = tb_operador.log_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.tip_oper))
                msg.tipoFuncionario = tb_operador.tip_oper.TrimEnd();

            if (tb_operador.dat_cad != null && tb_operador.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = tb_operador.dat_cad;

            if (!string.IsNullOrWhiteSpace(tb_operador.usu_atu))
                msg.usuarioUltimaAtualizacao = tb_operador.usu_atu.TrimEnd();

            if (tb_operador.dat_atu != null && tb_operador.dat_atu.Value != DateTime.MinValue)
                msg.dataUltimaAtualizacao = tb_operador.dat_atu;

            if (tb_operador.dat_sit != null && tb_operador.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = tb_operador.dat_sit;

            if (!string.IsNullOrWhiteSpace(tb_operador.idc_sit))
                msg.indicadorSituacao = tb_operador.idc_sit.TrimEnd();

            if (tb_operador.cod_cargo != null && tb_operador.cod_cargo.Value > 0)
                msg.codigoCargoFuncionario = tb_operador.cod_cargo;

            if (!string.IsNullOrWhiteSpace(tb_operador.cpf_oper))
                msg.cpfOperador = tb_operador.cpf_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.dig_oper))
                msg.digitoOperador = tb_operador.dig_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.sex_oper))
                msg.sexoOperador = tb_operador.sex_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.ddd_oper))
                msg.dddOperador = tb_operador.ddd_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.tel_oper))
                msg.telefoneOperador = tb_operador.tel_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.ram_oper))
                msg.ramalOperador = tb_operador.ram_oper.TrimEnd();

            if (!string.IsNullOrWhiteSpace(tb_operador.eml_oper))
                msg.emailOperador = tb_operador.eml_oper.TrimEnd();

            if (tb_operador.cod_ger_origem != null && tb_operador.cod_ger_origem.Value > 0)
                msg.codigoGerenteOrigem = tb_operador.cod_ger_origem;

            if (!string.IsNullOrWhiteSpace(tb_operador.OPECODCRK))
                msg.codigoCRK = tb_operador.OPECODCRK.TrimEnd();

            return msg;
        }
    }
}
