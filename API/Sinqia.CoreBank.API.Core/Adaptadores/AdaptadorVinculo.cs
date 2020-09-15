using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorVinculo
    {
        public MsgRetorno AdaptarMsgRetorno(MsgVinculo msgVinculo, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgVinculo != null && msgVinculo.header != null)
            {
                identificador = msgVinculo.header.identificadorEnvio;
                dataEnvio = msgVinculo.header.dataHoraEnvio.HasValue ? msgVinculo.header.dataHoraEnvio.Value : DateTime.Now;
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

        public DataSetPessoaRegistroVinculo[] AdaptarMsgRegistroVinculoToDataSetPessoaRegistroVinculo(MsgRegistroVinculo[] msg, IList<string> erros)
        {
            List<DataSetPessoaRegistroVinculo> registroVinculos = new List<DataSetPessoaRegistroVinculo>();
            foreach (var vinculo in msg)
            {
                registroVinculos.Add(AdaptarMsgRegistroVinculoToDataSetPessoaRegistroVinculo(vinculo, erros));
            }

            return registroVinculos.ToArray();
        }

        public DataSetPessoaRegistroVinculo AdaptarMsgRegistroVinculoToDataSetPessoaRegistroVinculo(MsgRegistroVinculo msg, IList<string> erros)
        {
            DataSetPessoaRegistroVinculo registroVinculo = new DataSetPessoaRegistroVinculo();

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaJuridica))
                registroVinculo.cod_pessoa_jur = msg.codigoPessoaJuridica;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilialPessoaJuridica))
                registroVinculo.cod_fil_jur = msg.codigoFilialPessoaJuridica;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaFisica))
                registroVinculo.cod_pessoa_fis = msg.codigoPessoaFisica;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilialPessoaFisica))
                registroVinculo.cod_fil_fis = msg.codigoFilialPessoaFisica;

            if (msg.numeroSequencia != null && msg.numeroSequencia.Value> 0)
                registroVinculo.seq_vinculo = msg.numeroSequencia.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorParticipacao))
                registroVinculo.idc_partcipacao = msg.indicadorParticipacao;

            if (msg.percentualParticipacao > 0)
                registroVinculo.pct_participacao = msg.percentualParticipacao;

            if (msg.dataPosse != null && msg.dataPosse.Value != DateTime.MinValue)
                registroVinculo.dat_posse = msg.dataPosse.Value;

            if (!string.IsNullOrWhiteSpace(msg.tempoMandato))
                registroVinculo.tmp_mandato = msg.tempoMandato;

            if (!string.IsNullOrWhiteSpace(msg.observacao))
                registroVinculo.des_vinc_fisjur = msg.observacao;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroVinculo.dat_cad = msg.dataCadastro.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroVinculo.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroVinculo.dat_atu = msg.dataAtualizacao.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                registroVinculo.idc_sit = msg.indicadorSituacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroVinculo.dat_sit = msg.dataSituacao.Value;

            if (msg.codigoCargo != null && msg.codigoCargo.Value > 0)
                registroVinculo.cod_cargo = msg.codigoCargo.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorAssinaEmpresa))
                registroVinculo.idc_assina = msg.indicadorAssinaEmpresa;

            if (!string.IsNullOrWhiteSpace(msg.indicadorContato))
                registroVinculo.idc_contato = msg.indicadorContato;

            if (msg.dataFim != null && msg.dataFim.Value != DateTime.MinValue)
                registroVinculo.dat_fim = msg.dataFim.Value;

            if (!string.IsNullOrWhiteSpace(msg.codigoVinculo))
                registroVinculo.cod_vinculo = msg.codigoVinculo;

            if (registroVinculo.dat_venc_proc != null && msg.dataVencimentoProcuracao.Value != DateTime.MinValue)
                registroVinculo.dat_venc_proc = msg.dataVencimentoProcuracao.Value;

            if (msg.tempoMandato1 != null && msg.tempoMandato1.Value != DateTime.MinValue)
                registroVinculo.tmp_mandato_1 = msg.tempoMandato1.Value;

            if (msg.dataFimMandato != null && msg.dataFimMandato.Value != DateTime.MinValue)
                registroVinculo.dat_fim_mandato = msg.dataFimMandato.Value;

            if (!string.IsNullOrWhiteSpace(msg.nomePessoa))
                registroVinculo.nom_pessoa = msg.nomePessoa;

            if (!string.IsNullOrWhiteSpace(msg.tipoPesoa))
                registroVinculo.tip_pes_soc = msg.tipoPesoa;

            if (!string.IsNullOrWhiteSpace(msg.indicadorEmiteDuplicata))
                registroVinculo.idc_emite_dupl = msg.indicadorEmiteDuplicata;

            if (!string.IsNullOrWhiteSpace(msg.indicadorAssinaEndosso))
                registroVinculo.idc_assina_endosso = msg.indicadorAssinaEndosso;

            if (!string.IsNullOrWhiteSpace(msg.indicadorAssinaCessao))
                registroVinculo.idc_assina_cessao = msg.indicadorAssinaCessao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorAssinaIsoladamente))
                registroVinculo.idc_assina_isoladamente = msg.indicadorAssinaIsoladamente;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaAssina1))
                registroVinculo.cod_pessoa_assina1 = msg.codigoPessoaAssina1;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaAssina2))
                registroVinculo.cod_pessoa_assina2 = msg.codigoPessoaAssina2;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoaAssina3))
                registroVinculo.cod_pessoa_assina3 = msg.codigoPessoaAssina3;

            if (!string.IsNullOrWhiteSpace(msg.emailVinculo))
                registroVinculo.fisjuremailvinculo = msg.emailVinculo;

            return registroVinculo;
        }
    }
}
