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
    }
}
