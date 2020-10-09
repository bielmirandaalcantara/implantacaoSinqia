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

        public tb_depope AdaptarMsgOperadorDependenciaToModeltb_depope(MsgRegistroOperadorDependencia msg)
        {
            tb_depope tb_depope = new tb_depope();

            if (msg.codigoEmpresa != null && msg.codigoEmpresa.Value > 0)
                tb_depope.emp_cod = msg.codigoEmpresa;

            if (msg.codigoDependencia != null && msg.codigoDependencia.Value > 0)
                tb_depope.depend_cod = msg.codigoDependencia;

            if (msg.codigoOperador != null && msg.codigoOperador.Value > 0)
                tb_depope.oper_cod = msg.codigoOperador;

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

            return msg;
        }
    }
}
