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

        public DataSetPessoaRegistroVinculo AdaptarMsgRegistroVinculoToDataSetPessoaRegistroVinculo(MsgRegistroVinculo msg,IList<string> erros)
        {
            DataSetPessoaRegistroVinculo registroVinculo = new DataSetPessoaRegistroVinculo();

            if (!string.IsNullOrWhiteSpace(msg.statusLinha))
                registroVinculo.statuslinha = msg.codigoPessoaJuridica;

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

        public MsgRegistroVinculo AdaptarDataSetPessoaRegistroVinculoToMsgRegistroVinculo(DataSetPessoaRegistroVinculo registroVinculo, IList<string> erros)
        {
            MsgRegistroVinculo msg = new MsgRegistroVinculo();

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_pessoa_jur))
                msg.codigoPessoaJuridica = registroVinculo.cod_pessoa_jur;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_fil_jur))
                msg.codigoFilialPessoaJuridica = registroVinculo.cod_fil_jur;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_pessoa_fis))
                msg.codigoPessoaFisica = registroVinculo.cod_pessoa_fis;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_fil_fis))
                msg.codigoFilialPessoaFisica = registroVinculo.cod_fil_fis;

            if (registroVinculo.seq_vinculo != null && registroVinculo.seq_vinculo.Value > 0)
                msg.numeroSequencia = registroVinculo.seq_vinculo;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_partcipacao))
                msg.indicadorParticipacao = registroVinculo.idc_partcipacao;

            if (registroVinculo.pct_participacao != null && registroVinculo.pct_participacao.Value > 0)
                msg.percentualParticipacao = registroVinculo.pct_participacao;

            if (registroVinculo.dat_posse != null && registroVinculo.dat_posse.Value != DateTime.MinValue)
                msg.dataPosse = registroVinculo.dat_posse;

            if (!string.IsNullOrWhiteSpace(registroVinculo.tmp_mandato))
                msg.tempoMandato = registroVinculo.tmp_mandato;

            if (!string.IsNullOrWhiteSpace(registroVinculo.des_vinc_fisjur))
                msg.observacao = registroVinculo.des_vinc_fisjur;

            if (registroVinculo.dat_cad != null && registroVinculo.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = registroVinculo.dat_cad;

            if (!string.IsNullOrWhiteSpace(registroVinculo.usu_atu))
                msg.usuarioUltimaAtualizacao = registroVinculo.usu_atu;

            if (registroVinculo.dat_atu != null && registroVinculo.dat_atu.Value != DateTime.MinValue)
                msg.dataAtualizacao = registroVinculo.dat_atu;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_sit))
                msg.indicadorSituacao = registroVinculo.idc_sit;

            if (registroVinculo.dat_sit != null && registroVinculo.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = registroVinculo.dat_sit;

            if (registroVinculo.cod_cargo != null && registroVinculo.cod_cargo.Value > 0)
                msg.codigoCargo = registroVinculo.cod_cargo;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_assina))
                msg.indicadorAssinaEmpresa = registroVinculo.idc_assina;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_contato))
                msg.indicadorContato = registroVinculo.idc_contato;

            if (registroVinculo.dat_fim != null && registroVinculo.dat_fim.Value != DateTime.MinValue)
                msg.dataFim = registroVinculo.dat_fim;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_vinculo))
                msg.codigoVinculo = registroVinculo.cod_vinculo;

            if (registroVinculo.dat_venc_proc != null && registroVinculo.dat_venc_proc.Value != DateTime.MinValue)
                msg.dataVencimentoProcuracao = registroVinculo.dat_venc_proc;

            if (registroVinculo.tmp_mandato_1 != null && registroVinculo.tmp_mandato_1.Value != DateTime.MinValue)
                msg.tempoMandato1 = registroVinculo.tmp_mandato_1;

            if (registroVinculo.dat_fim_mandato != null && registroVinculo.dat_fim_mandato.Value != DateTime.MinValue)
                msg.dataFimMandato = registroVinculo.dat_fim_mandato;

            if (!string.IsNullOrWhiteSpace(registroVinculo.nom_pessoa))
                msg.nomePessoa = registroVinculo.nom_pessoa;

            //if (!string.IsNullOrWhiteSpace(registroVinculo.cpf_cnpj_soc))
            //    msg.CNPJCPFSoc = registroVinculo.cpf_cnpj_soc;

            if (!string.IsNullOrWhiteSpace(registroVinculo.tip_pes_soc))
                msg.tipoPesoa = registroVinculo.tip_pes_soc;

           //if (registroVinculo.ppsseqpes != null && registroVinculo.ppsseqpes.Value > 0)
           //    msg.ppsseqpes = registroVinculo.ppsseqpes;

           //if (registroVinculo.pepdthatu != null && registroVinculo.pepdthatu.Value != DateTime.MinValue)
           //   msg.pepdthatu = registroVinculo.pepdthatu;

           //if (!string.IsNullOrWhiteSpace(registroVinculo.pepidcpep))
           //    msg.pepidcpep = registroVinculo.pepidcpep;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_emite_dupl))
                msg.indicadorEmiteDuplicata = registroVinculo.idc_emite_dupl;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_assina_endosso))
                msg.indicadorAssinaEndosso = registroVinculo.idc_assina_endosso;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_assina_cessao))
                msg.indicadorAssinaCessao = registroVinculo.idc_assina_cessao;

            if (!string.IsNullOrWhiteSpace(registroVinculo.idc_assina_isoladamente))
                msg.indicadorAssinaIsoladamente = registroVinculo.idc_assina_isoladamente;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_pessoa_assina1))
                msg.codigoPessoaAssina1 = registroVinculo.cod_pessoa_assina1;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_pessoa_assina2))
                msg.codigoPessoaAssina2 = registroVinculo.cod_pessoa_assina2;

            if (!string.IsNullOrWhiteSpace(registroVinculo.cod_pessoa_assina3))
                msg.codigoPessoaAssina3 = registroVinculo.cod_pessoa_assina3;

            if (!string.IsNullOrWhiteSpace(registroVinculo.nom_assina1))
                msg.nomeAssina1 = registroVinculo.nom_assina1;

            if (!string.IsNullOrWhiteSpace(registroVinculo.nom_assina2))
                msg.nomeAssina2 = registroVinculo.nom_assina2;

            if (!string.IsNullOrWhiteSpace(registroVinculo.nom_assina3))
                msg.nomeAssina3 = registroVinculo.nom_assina3;

            if (!string.IsNullOrWhiteSpace(registroVinculo.fisjuremailvinculo))
                msg.emailVinculo = registroVinculo.fisjuremailvinculo;

            return msg;
        }
    }
}
