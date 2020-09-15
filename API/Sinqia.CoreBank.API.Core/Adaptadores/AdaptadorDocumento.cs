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

            if (msgDocumento != null && msgDocumento.header != null)
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

        public DataSetPessoaRegistroDocumento[] AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(MsgRegistrodocumento[] msg, string statusLinha, IList<string> erros)
        {
            List<DataSetPessoaRegistroDocumento> registroDocumentos = new List<DataSetPessoaRegistroDocumento>();
            foreach (var documento in msg)
            {
                registroDocumentos.Add(AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(documento, statusLinha, erros));
            }

            return registroDocumentos.ToArray();
        }

        public DataSetPessoaRegistroDocumento AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(MsgRegistrodocumento msg, string statusLinha, IList<string> erros)
        {
            DataSetPessoaRegistroDocumento registroDocumento = new DataSetPessoaRegistroDocumento();

            registroDocumento.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroDocumento.cod_pessoa = msg.codigoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.numeroDocumento))
                registroDocumento.num_doc = msg.numeroDocumento;

            if (msg.dataExpedicao != null && msg.dataExpedicao.Value != DateTime.MinValue)
                registroDocumento.dat_expedicao = msg.dataExpedicao.Value;

            if (!string.IsNullOrWhiteSpace(msg.orgaoExpedidor))
                registroDocumento.org_expedidor = msg.orgaoExpedidor;

            if (!string.IsNullOrWhiteSpace(msg.observacao))
                registroDocumento.obs_doc = msg.observacao;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroDocumento.dat_cad = msg.dataCadastro.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroDocumento.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroDocumento.dat_atu = msg.dataAtualizacao.Value;

            if (!string.IsNullOrWhiteSpace(msg.IndicadorSituacao))
                registroDocumento.idc_sit = msg.IndicadorSituacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroDocumento.dat_sit = msg.dataSituacao.Value;

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

            if (msg.tipoComprovacaoRenda != null && msg.tipoComprovacaoRenda.Value > 0)
                registroDocumento.crecod = msg.tipoComprovacaoRenda.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorPreposto))
                registroDocumento.idc_preposto = msg.indicadorPreposto;

            if (msg.dataVencimento != null && msg.dataVencimento.Value != DateTime.MinValue)
                registroDocumento.dat_venc = msg.dataVencimento.Value;

            if (msg.codigoNacionalidade != null && msg.codigoNacionalidade.Value > 0)
                registroDocumento.naccod = msg.codigoNacionalidade.Value;

            return registroDocumento;
        }

        public MsgRegistrodocumento[] AdaptarDataSetPessoaRegistroDocumentoToMsgRegistrodocumento(DataSetPessoaRegistroDocumento[] dataset, IList<string> erros)
        {
            List<MsgRegistrodocumento> registros = new List<MsgRegistrodocumento>();

            foreach(var item in dataset)
            {
                registros.Add(AdaptarDataSetPessoaRegistroDocumentoToMsgRegistrodocumento(item, erros));
            }

            return registros.ToArray();
        }

        public MsgRegistrodocumento AdaptarDataSetPessoaRegistroDocumentoToMsgRegistrodocumento(DataSetPessoaRegistroDocumento registroDocumento, IList<string> erros)
        {
            MsgRegistrodocumento msg = new MsgRegistrodocumento();

            if (!string.IsNullOrWhiteSpace(registroDocumento.cod_pessoa))
                msg.codigoPessoa = registroDocumento.cod_pessoa;

            if (!string.IsNullOrWhiteSpace(registroDocumento.num_doc))
                msg.numeroDocumento = registroDocumento.num_doc;

            if (registroDocumento.dat_expedicao != null && registroDocumento.dat_expedicao.Value != DateTime.MinValue)
                msg.dataExpedicao = registroDocumento.dat_expedicao;

            if (!string.IsNullOrWhiteSpace(registroDocumento.org_expedidor))
                msg.orgaoExpedidor = registroDocumento.org_expedidor;

            if (!string.IsNullOrWhiteSpace(registroDocumento.obs_doc))
                msg.observacao = registroDocumento.obs_doc;

            if (registroDocumento.dat_cad != null && registroDocumento.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = registroDocumento.dat_cad;

            if (!string.IsNullOrWhiteSpace(registroDocumento.usu_atu))
                msg.usuarioUltimaAtualizacao = registroDocumento.usu_atu;

            if (registroDocumento.dat_atu != null && registroDocumento.dat_atu.Value != DateTime.MinValue)
                msg.dataAtualizacao = registroDocumento.dat_atu;

            if (!string.IsNullOrWhiteSpace(registroDocumento.idc_sit))
                msg.IndicadorSituacao = registroDocumento.idc_sit;

            if (registroDocumento.dat_sit != null && registroDocumento.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = registroDocumento.dat_sit;

            if (!string.IsNullOrWhiteSpace(registroDocumento.tip_doc))
                msg.tipoDocumento = registroDocumento.tip_doc;

            if (!string.IsNullOrWhiteSpace(registroDocumento.cod_federacao))
                msg.ufExpedicao = registroDocumento.cod_federacao;

            if (!string.IsNullOrWhiteSpace(registroDocumento.idc_imp_cheque))
                msg.documentoCheque = registroDocumento.idc_imp_cheque;

            if (!string.IsNullOrWhiteSpace(registroDocumento.idc_microemp))
                msg.indicadorMicroEmpresa = registroDocumento.idc_microemp;

            if (!string.IsNullOrWhiteSpace(registroDocumento.idc_comprovado))
                msg.IndicadorComprovado = registroDocumento.idc_comprovado;

            if (registroDocumento.crecod != null && registroDocumento.crecod.Value > 0)
                msg.tipoComprovacaoRenda = registroDocumento.crecod;

            if (!string.IsNullOrWhiteSpace(registroDocumento.idc_preposto))
                msg.indicadorPreposto = registroDocumento.idc_preposto;

            if (registroDocumento.dat_venc != null && registroDocumento.dat_venc.Value != DateTime.MinValue)
                msg.dataVencimento = registroDocumento.dat_venc;

            if (registroDocumento.naccod != null && registroDocumento.naccod.Value > 0)
                msg.codigoNacionalidade = registroDocumento.naccod;

            return msg;
        }

    }
}
