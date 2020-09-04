﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sinqia.CoreBank.API.Core.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorPessoa
    {
        public MsgRetorno AdaptarMsgRetorno(MsgPessoa msgPessoa, IList<string> erros)
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

        public MsgRetorno AdaptarMsgRetorno(MsgPessoaConsulta msgPessoa, IList<string> erros)
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

        public MsgRetorno AdaptarMsgRetorno(MsgPessoaCompleto msgPessoa, IList<string> erros)
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

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? "ERRO" : "OK";

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

        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros)
        {
            return AdaptarMsgRetornoGet(null, erros);
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(MsgRegistropessoaCompleto msgPessoa, IList<string> erros)
        {
            MsgRetornoGet retorno = new MsgRetornoGet();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? "ERRO" : "OK";

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };
            retorno.header = header;

            if (!erros.Any() && msgPessoa != null)
            {
                retorno.body = msgPessoa;
            }            
            return retorno;
        }

        public MsgRetornoGet AdaptarMsgRetornoConsultaGet(IList<string> erros)
        {
            return AdaptarMsgRetornoConsultaGet(null, erros);
        }

        public MsgRetornoGet AdaptarMsgRetornoConsultaGet(MsgRegistropessoaConsulta msgPessoa, IList<string> erros)
        {
            MsgRetornoGet retorno = new MsgRetornoGet();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? "ERRO" : "OK";

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };
            retorno.header = header;

            if (!erros.Any() && msgPessoa != null)
            {
                retorno.body = msgPessoa;
            }
            return retorno;
        }

        public MsgRegistropessoaCompleto AdaptarMensagem()
        {
            return new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste"                
            };
        }

        public MsgRegistropessoaConsulta AdaptarMensagemConsulta()
        {
            return new MsgRegistropessoaConsulta()
            {
                nomePessoa = "Teste"
                ,
                dataAtualizacao = DateTime.Now
                ,
                dataInicio = DateTime.Now
                ,
                nomeMae = "Mãe do Teste"
            };
        }
    }
}