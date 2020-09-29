using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.Dominio.Corporativo.Modelos
{
    public class tb_dependencia
    {
        public string TIP_TPDEPEND { get; set; }
        public int COD_CAMARA { get; set; }
        public string NUM_LOG_DEPEND { get; set; }
        public DateTime DAT_ROLLOUT { get; set; }
        public DateTime DAT_SIT { get; set; }
    }
}
