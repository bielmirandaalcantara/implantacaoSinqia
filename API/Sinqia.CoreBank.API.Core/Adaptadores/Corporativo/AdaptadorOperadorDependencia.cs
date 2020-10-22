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
    public class AdaptadorOperadorDependencia
    {
        private LogService _log;
        public AdaptadorOperadorDependencia(LogService log)
        {
            _log = log;
        }

        public tb_depope AdaptarMsgOperadorDependenciaToModeltb_depope(MsgRegistroOperadorDependencia msg, string modo)
        {
            _log.TraceMethodStart();

            tb_depope tb_depope = new tb_depope();

            if (msg.codigoEmpresa != null && msg.codigoEmpresa.Value > 0)
                tb_depope.emp_cod = msg.codigoEmpresa;

            if (msg.codigoDependencia != null && msg.codigoDependencia.Value > 0)
                tb_depope.depend_cod = msg.codigoDependencia;

            if (msg.codigoOperador != null && msg.codigoOperador.Value > 0)
                tb_depope.oper_cod = msg.codigoOperador;

            _log.TraceMethodEnd();

            return tb_depope;
        }

        public MsgRegistroOperadorDependencia tb_depopeToMsgOperadorDependencia(tb_depope tb_depope)
        {
            _log.TraceMethodStart();

            MsgRegistroOperadorDependencia msg = new MsgRegistroOperadorDependencia();

            if (tb_depope.emp_cod != null && tb_depope.emp_cod.Value > 0)
                msg.codigoEmpresa = tb_depope.emp_cod;

            if (tb_depope.depend_cod != null && tb_depope.depend_cod.Value > 0)
                msg.codigoDependencia = tb_depope.depend_cod;

            if (tb_depope.oper_cod != null && tb_depope.oper_cod.Value > 0)
                msg.codigoOperador = tb_depope.oper_cod;

            _log.TraceMethodEnd();

            return msg;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgOperadorDependencia msg, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.Now;
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

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros, string identificador)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            DateTime dataEnvio = DateTime.Now;
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
            DateTime dataEnvio = DateTime.Now;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
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

    }
}
