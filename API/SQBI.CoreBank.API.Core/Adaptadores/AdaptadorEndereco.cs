using SQBI.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorEndereco
    {
        public MsgRetorno AdaptarMsgRetorno(MsgEndereco MsgEndereco, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? "ERRO" : "OK";

            if (MsgEndereco.header != null)
            {
                identificador = MsgEndereco.header.identificadorEnvio;
                dataEnvio = MsgEndereco.header.dataHoraEnvio.HasValue ? MsgEndereco.header.dataHoraEnvio.Value : DateTime.Now;
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