﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQBI.CoreBank.API.Core.Models;

namespace SQBI.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorPessoaSimplificada
    {
        public MsgRetorno AdaptarMsgRetorno(MsgPessoaSimplificada msgPessoa, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? "ERRO" : "OK";

            if (msgPessoa.header != null)
            {
                identificador = msgPessoa.header.identificadorEnvio;
                dataEnvio = msgPessoa.header.dataHoraEnvio.HasValue ? msgPessoa.header.dataHoraEnvio.Value : DateTime.Now;
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