﻿using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorPerfil
    {
        public MsgRetorno AdaptarMsgRetorno(MsgPerfil msgPerfil, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgPerfil != null && msgPerfil.header != null)
            {
                identificador = msgPerfil.header.identificadorEnvio;
                dataEnvio = msgPerfil.header.dataHoraEnvio.HasValue ? msgPerfil.header.dataHoraEnvio.Value : DateTime.Now;
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
            return retorno;
        }

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
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
            return retorno;
        }

        public DataSetPessoaRegistroPerfil[] AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(MsgRegistroperfil[] msg, string statusLinha, IList<string> erros)
        {
            List<DataSetPessoaRegistroPerfil> registroPerfis = new List<DataSetPessoaRegistroPerfil>();
            foreach (var perfil in msg)
            {
                registroPerfis.Add(AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(perfil, statusLinha, erros));
            }

            return registroPerfis.ToArray();
        }

        public DataSetPessoaRegistroPerfil AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(MsgRegistroperfil msg, string statusLinha, IList<string> erros)
        {
            DataSetPessoaRegistroPerfil registroPerfil = new DataSetPessoaRegistroPerfil();

            registroPerfil.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroPerfil.cod_pessoa = msg.codigoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.codigoPerfil))
                registroPerfil.cod_perfil = msg.codigoPerfil;

            return registroPerfil;
        }

        public MsgRegistroperfil[] AdaptarDataSetPessoaRegistroPerfilToMsgRegistroperfil(DataSetPessoaRegistroPerfil[] dataset, IList<string> erros)
        {
            List<MsgRegistroperfil> registros = new List<MsgRegistroperfil>();

            foreach (var item in dataset)
            {
                registros.Add(AdaptarDataSetPessoaRegistroPerfilToMsgRegistroperfil(item, erros));
            }

            return registros.ToArray();
        }

        public MsgRegistroperfil AdaptarDataSetPessoaRegistroPerfilToMsgRegistroperfil(DataSetPessoaRegistroPerfil registroPerfil, IList<string> erros)
        {
            MsgRegistroperfil msg = new MsgRegistroperfil();

            if (!string.IsNullOrWhiteSpace(registroPerfil.cod_pessoa))
                msg.codigoPessoa = registroPerfil.cod_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPerfil.cod_perfil))
                msg.codigoPerfil = registroPerfil.cod_perfil;

            return msg;
        }
    }
}
