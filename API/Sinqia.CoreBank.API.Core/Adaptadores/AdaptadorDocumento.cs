using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorDocumento
    {
        public MsgRetorno AdaptarMsgRetorno(MsgDocumento msgDocumento, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

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

        public DataSetPessoaRegistroDocumento[] AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(MsgRegistrodocumento[] msg, IList<string> erros)
        {
            List<DataSetPessoaRegistroDocumento> registroDocumentos = new List<DataSetPessoaRegistroDocumento>();
            foreach (var documento in msg)
            {
                registroDocumentos.Add(AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(documento, erros));
            }

            return registroDocumentos.ToArray();
        }

        public DataSetPessoaRegistroDocumento AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(MsgRegistrodocumento msg, IList<string> erros)
        {
            DataSetPessoaRegistroDocumento registroDocumento = new DataSetPessoaRegistroDocumento();


            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroDocumento.cod_pessoa = msg.codigoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.numeroDocumento))
                registroDocumento.num_doc = msg.numeroDocumento;

            if (msg.dataExpedicao != DateTime.MinValue)
                registroDocumento.dat_expedicao = msg.dataExpedicao;

            if (!string.IsNullOrWhiteSpace(msg.orgaoExpedidor))
                registroDocumento.org_expedidor = msg.orgaoExpedidor;

            if (!string.IsNullOrWhiteSpace(msg.observacao))
                registroDocumento.obs_doc = msg.observacao;

            if (msg.dataCadastro != DateTime.MinValue)
                registroDocumento.dat_cad = msg.dataCadastro;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroDocumento.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != DateTime.MinValue)
                registroDocumento.dat_atu = msg.dataAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.IndicadorSituacao))
                registroDocumento.idc_sit = msg.IndicadorSituacao;

            if (msg.dataSituacao != DateTime.MinValue)
                registroDocumento.dat_sit = msg.dataSituacao;

            if (!string.IsNullOrWhiteSpace(msg.tipoDocumento))
                registroDocumento.tip_doc = msg.tipoDocumento;

            if (!string.IsNullOrWhiteSpace(msg.ufExpedicao))
                registroDocumento.cod_federacao = msg.ufExpedicao;

            if (!string.IsNullOrWhiteSpace(msg.documentoCheque))
                registroDocumento.idc_imp_cheque = msg.documentoCheque;

            if (!string.IsNullOrWhiteSpace(msg.indicadorMicroEmpresa))
                registroDocumento.idc_microemp = msg.indicadorMicroEmpresa;

            if (!string.IsNullOrWhiteSpace(msg.IndicadorComprovado))
                registroDocumento.idc_comprovado = msg.IndicadorComprovado;

            if (msg.tipoComprovacaoRenda > 0)
                registroDocumento.crecod = msg.tipoComprovacaoRenda;

            if (!string.IsNullOrWhiteSpace(msg.indicadorPreposto))
                registroDocumento.idc_preposto = msg.indicadorPreposto;

            if (msg.dataVencimento != DateTime.MinValue)
                registroDocumento.dat_venc = msg.dataVencimento;

            if (msg.codigoNacionalidade > 0)
                registroDocumento.naccod = msg.codigoNacionalidade;

            return registroDocumento;
        }

     }
}
