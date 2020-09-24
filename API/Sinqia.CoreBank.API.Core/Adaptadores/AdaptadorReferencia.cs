using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorReferencia
    {
        private LogService _log;
        public AdaptadorReferencia(LogService log)
        {
            _log = log;
        }
        public MsgRetorno AdaptarMsgRetorno(MsgReferencia msgReferencia, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgReferencia != null && msgReferencia.header != null)
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

            if (erros.Any())
            {
                header.erros = erros.ToArray();
            }

            retorno.header = header;

            _log.TraceMethodEnd();

            return retorno;
        }

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros)
        {
            return AdaptarMsgRetorno(erros, string.Empty);
        }

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros, string identificador)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
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

            _log.TraceMethodEnd();

            return retorno;
        }

        public DataSetPessoaRegistroReferencia[] AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(MsgRegistroreferencia[] msg, string statusLinha,IList<string> erros)
        {
            _log.TraceMethodStart();

            List<DataSetPessoaRegistroReferencia> registroReferencias = new List<DataSetPessoaRegistroReferencia>();
            foreach (var referencia in msg)
            {
                registroReferencias.Add(AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(referencia, statusLinha, erros));
            }

            _log.TraceMethodEnd();

            return registroReferencias.ToArray();
        }

        public DataSetPessoaRegistroReferencia AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(MsgRegistroreferencia msg, string statusLinha, IList<string> erros)
        {
            _log.TraceMethodStart();

            DataSetPessoaRegistroReferencia registroReferencia = new DataSetPessoaRegistroReferencia();

            registroReferencia.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaTitular))
                registroReferencia.cod_pessoa_tit = msg.codigoPessoaTitular;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilialTitular))
                registroReferencia.cod_fil_tit = msg.codigoFilialTitular;

            if (msg.sequencial != null && msg.sequencial.Value > 0)
                registroReferencia.seq_ref = msg.sequencial.Value;

            if (!string.IsNullOrWhiteSpace(msg.tipo))
                registroReferencia.tip_ref = msg.tipo;

            if (!string.IsNullOrWhiteSpace(msg.observacao))
                registroReferencia.obs_ref = msg.observacao;

            if (msg.numeroCartao != null && msg.numeroCartao > 0)
                registroReferencia.num_cartao_ref = msg.numeroCartao;

            if (msg.valorLimite != null && msg.valorLimite > 0)
                registroReferencia.val_lim_ref = msg.valorLimite;

            if (msg.dataInicioEmprego != null && msg.dataInicioEmprego.Value != DateTime.MinValue)
                registroReferencia.dat_ini_emprego = msg.dataInicioEmprego.Value;

            if (msg.dataFinalEmprego != null && msg.dataFinalEmprego.Value != DateTime.MinValue)
                registroReferencia.dat_fim_emprego = msg.dataFinalEmprego.Value;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroReferencia.dat_cad = msg.dataCadastro.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroReferencia.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroReferencia.dat_atu = msg.dataAtualizacao.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                registroReferencia.idc_sit = msg.indicadorSituacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroReferencia.dat_sit = msg.dataSituacao.Value;

            if (msg.codigoCartao != null && msg.codigoCartao.Value > 0)
                registroReferencia.cod_cartao = msg.codigoCartao.Value;

            if (msg.codigoSeguradora != null && msg.codigoSeguradora.Value > 0)
                registroReferencia.cod_segur = msg.codigoSeguradora.Value;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaReferencia))
                registroReferencia.cod_pessoa_ref = msg.codigoPessoaReferencia;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilialReferencia))
                registroReferencia.cod_fil_ref = msg.codigoFilialReferencia;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaSimplificada))
                registroReferencia.cod_simp = msg.codigoPessoaSimplificada;

            if (msg.dataVencimentoSeguroCartao != null && msg.dataVencimentoSeguroCartao.Value != DateTime.MinValue)
                registroReferencia.dat_venc_seg_cartao = msg.dataVencimentoSeguroCartao.Value;

            _log.TraceMethodEnd();

            return registroReferencia;
        }

        public DataSetPessoaRegistroReferencia[] AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferenciaExclusao(string cod_pessoa, int codPessoaReferencia, string cod_filial, IList<string> erros)
        {
            _log.TraceMethodStart();

            List<DataSetPessoaRegistroReferencia> registroReferencias = new List<DataSetPessoaRegistroReferencia>();
                registroReferencias.Add(AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferenciaExclusao(cod_pessoa, codPessoaReferencia, cod_filial));

            _log.TraceMethodEnd();

            return registroReferencias.ToArray();
        }

        public DataSetPessoaRegistroReferencia AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferenciaExclusao(string cod_pessoa, int codPessoaReferencia, string cod_filial)
        {
            _log.TraceMethodStart();

            DataSetPessoaRegistroReferencia registroReferencia = new DataSetPessoaRegistroReferencia();

            registroReferencia.statuslinha = ConstantesInegracao.StatusLinhaCUC.Exclusao;

            if (!string.IsNullOrWhiteSpace(cod_pessoa))
                registroReferencia.cod_pessoa_tit = cod_pessoa;

            if (codPessoaReferencia != null && codPessoaReferencia > 0)
                registroReferencia.seq_ref = codPessoaReferencia;

            if (!string.IsNullOrWhiteSpace(cod_filial))
                registroReferencia.cod_fil_tit = cod_filial;

            _log.TraceMethodEnd();

            return registroReferencia;
        }

        public MsgRegistroreferencia[] AdaptarDataSetPessoaRegistroReferenciaToMsgRegistroreferencia(DataSetPessoaRegistroReferencia[] dataset, IList<string> erros)
        {
            _log.TraceMethodStart();

            List<MsgRegistroreferencia> registros = new List<MsgRegistroreferencia>();

            foreach (var item in dataset)
            {
                registros.Add(AdaptarDataSetPessoaRegistroReferenciaToMsgRegistroreferencia(item, erros));
            }

            _log.TraceMethodEnd();

            return registros.ToArray();
        }

        public MsgRegistroreferencia AdaptarDataSetPessoaRegistroReferenciaToMsgRegistroreferencia(DataSetPessoaRegistroReferencia registroReferencia, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRegistroreferencia msg = new MsgRegistroreferencia();

            if (!string.IsNullOrWhiteSpace(registroReferencia.cod_pessoa_tit))
                msg.codigoPessoaTitular = registroReferencia.cod_pessoa_tit;

            if (!string.IsNullOrWhiteSpace(registroReferencia.cod_fil_tit))
                msg.codigoFilialTitular = registroReferencia.cod_fil_tit;

            if (registroReferencia.seq_ref != null && registroReferencia.seq_ref.Value > 0)
                msg.sequencial = registroReferencia.seq_ref;

            if (!string.IsNullOrWhiteSpace(registroReferencia.tip_ref))
                msg.tipo = registroReferencia.tip_ref;

            if (!string.IsNullOrWhiteSpace(registroReferencia.obs_ref))
                msg.observacao = registroReferencia.obs_ref;

            if (registroReferencia.num_cartao_ref != null && registroReferencia.num_cartao_ref.Value > 0)
                msg.numeroCartao = registroReferencia.num_cartao_ref;

            if (registroReferencia.val_lim_ref != null && registroReferencia.val_lim_ref.Value > 0)
                msg.valorLimite = registroReferencia.val_lim_ref;

            if (registroReferencia.dat_ini_emprego != null && registroReferencia.dat_ini_emprego.Value != DateTime.MinValue)
                msg.dataInicioEmprego = registroReferencia.dat_ini_emprego;

            if (registroReferencia.dat_fim_emprego != null && registroReferencia.dat_fim_emprego.Value != DateTime.MinValue)
                msg.dataFinalEmprego = registroReferencia.dat_fim_emprego;

            if (registroReferencia.dat_cad != null && registroReferencia.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = registroReferencia.dat_cad;

            if (!string.IsNullOrWhiteSpace(registroReferencia.usu_atu))
                msg.usuarioUltimaAtualizacao = registroReferencia.usu_atu;

            if (registroReferencia.dat_atu != null && registroReferencia.dat_atu.Value != DateTime.MinValue)
                msg.dataAtualizacao = registroReferencia.dat_atu;

            if (!string.IsNullOrWhiteSpace(registroReferencia.idc_sit))
                msg.indicadorSituacao = registroReferencia.idc_sit;

            if (registroReferencia.dat_sit != null && registroReferencia.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = registroReferencia.dat_sit;

            if (registroReferencia.cod_cartao != null && registroReferencia.cod_cartao.Value > 0)
                msg.codigoCartao = registroReferencia.cod_cartao;

            if (registroReferencia.cod_segur != null && registroReferencia.cod_segur.Value > 0)
                msg.codigoSeguradora = registroReferencia.cod_segur;

            if (!string.IsNullOrWhiteSpace(registroReferencia.cod_pessoa_ref))
                msg.codigoPessoaReferencia = registroReferencia.cod_pessoa_ref;

            if (!string.IsNullOrWhiteSpace(registroReferencia.cod_fil_ref))
                msg.codigoFilialReferencia = registroReferencia.cod_fil_ref;

            if (!string.IsNullOrWhiteSpace(registroReferencia.cod_simp))
                msg.codigoPessoaSimplificada = registroReferencia.cod_simp;

            if (registroReferencia.dat_venc_seg_cartao != null && registroReferencia.dat_venc_seg_cartao.Value != DateTime.MinValue)
                msg.dataVencimentoSeguroCartao = registroReferencia.dat_venc_seg_cartao;

            _log.TraceMethodEnd();

            return msg;
        }
    }
}
