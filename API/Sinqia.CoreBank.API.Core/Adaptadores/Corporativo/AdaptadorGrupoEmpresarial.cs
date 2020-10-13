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
    public class AdaptadorGrupoEmpresarial
    {
        private LogService _log;
        public AdaptadorGrupoEmpresarial(LogService log)
        {
            _log = log;
        }

        public tb_grpemp AdaptarMsgGrupoEmpresarialToModeltb_grpemp(MsgRegistroGrupoEmpresarial msg)
        {
            tb_grpemp tb_grpemp = new tb_grpemp();

            if (msg.codigoGrupoEmpresarial != null && msg.codigoGrupoEmpresarial.Value > 0)
                tb_grpemp.cod_grpemp = msg.codigoGrupoEmpresarial;

            if (!string.IsNullOrWhiteSpace(msg.nomeAbreviadoGrupoEmpresarial))
                tb_grpemp.abv_grpemp = msg.nomeAbreviadoGrupoEmpresarial;

            if (!string.IsNullOrWhiteSpace(msg.nomedoGrupoEmpresarial))
                tb_grpemp.des_grpemp = msg.nomedoGrupoEmpresarial;

            if (msg.codigoEmpresaSisbacen != null && msg.codigoEmpresaSisbacen.Value > 0)
                tb_grpemp.cod_empresa = msg.codigoEmpresaSisbacen;

            if (msg.codigoDependenciaSisbacen != null && msg.codigoDependenciaSisbacen.Value > 0)
                tb_grpemp.cod_depend = msg.codigoDependenciaSisbacen;

            return tb_grpemp;
        }

        public MsgRegistroGrupoEmpresarial tb_grpempToMsgGrupoEmpresarial(tb_grpemp tb_grpemp)
        {
            _log.TraceMethodStart();

            MsgRegistroGrupoEmpresarial msg = new MsgRegistroGrupoEmpresarial();

            if (tb_grpemp.cod_grpemp != null && tb_grpemp.cod_grpemp.Value > 0)
                msg.codigoGrupoEmpresarial = tb_grpemp.cod_grpemp;

            if (!string.IsNullOrWhiteSpace(tb_grpemp.abv_grpemp))
                msg.nomeAbreviadoGrupoEmpresarial = tb_grpemp.abv_grpemp;

            if (!string.IsNullOrWhiteSpace(tb_grpemp.des_grpemp))
                msg.nomedoGrupoEmpresarial = tb_grpemp.des_grpemp;

            if (tb_grpemp.cod_empresa != null && tb_grpemp.cod_empresa.Value > 0)
                msg.codigoEmpresaSisbacen = tb_grpemp.cod_empresa;

            if (tb_grpemp.cod_depend != null && tb_grpemp.cod_depend.Value > 0)
                msg.codigoDependenciaSisbacen = tb_grpemp.cod_depend;

            return msg;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgGrupoEmpresarial msg, IList<string> erros)
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

    }
}
