using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorDocumento
    {
        public MsgRetorno AdaptarMsgRetorno(MsgDocumento msgDocumento, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? "ERRO" : "OK";

            if (msgDocumento.header != null)
            {
                identificador = msgDocumento.header.identificadorEnvio;
                dataEnvio = msgDocumento.header.dataHoraEnvio.HasValue ? msgDocumento.header.dataHoraEnvio.Value : DateTime.Now;
            }

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };

            retorno.header = header;
            return retorno;
        }

    }
}
