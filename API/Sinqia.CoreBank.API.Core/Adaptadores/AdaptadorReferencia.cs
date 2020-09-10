﻿using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorReferencia
    {
        public MsgRetorno AdaptarMsgRetorno(MsgReferencia msgReferencia, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgReferencia.header != null)
            {
                identificador = msgReferencia.header.identificadorEnvio;
                dataEnvio = msgReferencia.header.dataHoraEnvio.HasValue ? msgReferencia.header.dataHoraEnvio.Value : DateTime.Now;
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
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

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

        public DataSetPessoaRegistroReferencia[] AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(MsgRegistroreferencia[] msg, IList<string> erros)
        {
            List<DataSetPessoaRegistroReferencia> registroReferencias = new List<DataSetPessoaRegistroReferencia>();
            foreach (var referencia in msg)
            {
                registroReferencias.Add(AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(referencia, erros));
            }

            return registroReferencias.ToArray();
        }

        public DataSetPessoaRegistroReferencia AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(MsgRegistroreferencia msg, IList<string> erros)
        {
            DataSetPessoaRegistroReferencia registroReferencia = new DataSetPessoaRegistroReferencia();
                       
            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaTitular))
                registroReferencia.cod_pessoa_tit = msg.codigoPessoaTitular;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilialTitular))
                registroReferencia.cod_fil_tit = msg.codigoFilialTitular;

            if (msg.sequencial > 0)
                registroReferencia.seq_ref = msg.sequencial;

            if (!string.IsNullOrWhiteSpace(msg.tipo))
                registroReferencia.tip_ref = msg.tipo;

            if (!string.IsNullOrWhiteSpace(msg.observacao))
                registroReferencia.obs_ref = msg.observacao;

            if (msg.numeroCartao > 0)
                registroReferencia.num_cartao_ref = msg.numeroCartao;

            if (msg.valorLimite > 0)
                registroReferencia.val_lim_ref = msg.valorLimite;

            if (msg.dataInicioEmprego != DateTime.MinValue)
                registroReferencia.dat_ini_emprego = msg.dataInicioEmprego;

            if (msg.dataFinalEmprego != DateTime.MinValue)
                registroReferencia.dat_fim_emprego = msg.dataFinalEmprego;

            if (msg.dataCadastro != DateTime.MinValue)
                registroReferencia.dat_cad = msg.dataCadastro;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroReferencia.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != DateTime.MinValue)
                registroReferencia.dat_atu = msg.dataAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                registroReferencia.idc_sit = msg.indicadorSituacao;

            if (msg.dataSituacao != DateTime.MinValue)
                registroReferencia.dat_sit = msg.dataSituacao;

            if (msg.codigoCartao > 0)
                registroReferencia.cod_cartao = msg.codigoCartao;

            if (msg.codigoSeguradora > 0)
                registroReferencia.cod_segur = msg.codigoSeguradora;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaReferencia))
                registroReferencia.cod_pessoa_ref = msg.codigoPessoaReferencia;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilialReferencia))
                registroReferencia.cod_fil_ref = msg.codigoFilialReferencia;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaSimplificada))
                registroReferencia.cod_simp = msg.codigoPessoaSimplificada;

            if (msg.dataVencimentoSeguroCartao != DateTime.MinValue)
                registroReferencia.dat_venc_seg_cartao = msg.dataVencimentoSeguroCartao;

            return registroReferencia;
        }
    }
}
