using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Logging.Services;

namespace Sinqia.CoreBank.API.Core.Adaptadores.Pessoa
{
    public class AdaptadorNegocios
    {
        private LogService _log;
        public AdaptadorNegocios(LogService log)
        {
            _log = log;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgNegocios msg, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msg != null && msg.header != null)
            {
                identificador = msg.header.identificadorEnvio;
                dataEnvio = msg.header.dataHoraEnvio.HasValue ? msg.header.dataHoraEnvio.Value : DateTime.Now;
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

        public DataSetNegocioRegistroOutrosBancos AdaptarMsgRegistroNegocioToDataSetNegocioRegistroNegocio(MsgRegistroNegocios msg, string statusLinha, IList<string> erros)
        {
            _log.TraceMethodStart();

            DataSetNegocioRegistroOutrosBancos registroNegocios = new DataSetNegocioRegistroOutrosBancos();

            registroNegocios.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroNegocios.cod_pessoa = msg.codigoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilial))
                registroNegocios.cod_fil = msg.codigoFilial;

            if (msg.sequencial != null && msg.sequencial.Value > 0)
                registroNegocios.seq_negbco = msg.sequencial;

            if (msg.codigoAgencia != null && msg.codigoAgencia.Value > 0)
                registroNegocios.cod_age_negbco = msg.codigoAgencia;

            if (!string.IsNullOrWhiteSpace(msg.numeroConta))
                registroNegocios.num_negbco = msg.numeroConta;

            if (msg.valorLimite != null && msg.valorLimite.Value > 0)
                registroNegocios.val_limite_negbco = msg.valorLimite;

            if (msg.valdoDevedor != null && msg.valdoDevedor.Value > 0)
                registroNegocios.val_dev_negbco = msg.valdoDevedor;

            if (msg.dataInicio != null && msg.dataInicio.Value != DateTime.MinValue)
                registroNegocios.dat_ini_negbco = msg.dataInicio;

            if (msg.dataFim != null && msg.dataFim.Value != DateTime.MinValue)
                registroNegocios.dat_fim_negbco = msg.dataFim;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroNegocios.dat_cad = msg.dataCadastro;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroNegocios.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroNegocios.dat_atu = msg.dataAtualizacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroNegocios.dat_sit = msg.dataSituacao;

            if (!string.IsNullOrWhiteSpace(msg.identificadorSituacao))
                registroNegocios.idc_sit = msg.identificadorSituacao;

            if (msg.codigoEmpresa != null && msg.codigoEmpresa.Value > 0)
                registroNegocios.cod_empresa = msg.codigoEmpresa;

            if (msg.codigoProdutoBancario != null && msg.codigoProdutoBancario.Value > 0)
                registroNegocios.cod_prodbco = msg.codigoProdutoBancario;

            if (msg.codigoBanco != null && msg.codigoBanco.Value > 0)
                registroNegocios.cod_bco = msg.codigoBanco;

            if (msg.codigoBancoNegocio != null && msg.codigoBancoNegocio.Value > 0)
                registroNegocios.cod_bco_negbco = msg.codigoBancoNegocio;

            if (!string.IsNullOrWhiteSpace(msg.contaCreditoResgate))
                registroNegocios.COD_CTA_RESGATE = msg.contaCreditoResgate;

            if (!string.IsNullOrWhiteSpace(msg.SituacaoRegistro))
                registroNegocios.STA_REGISTRO = msg.SituacaoRegistro;

            if (!string.IsNullOrWhiteSpace(msg.IndicadorBancoOuInstPagamento))
                registroNegocios.NEGIDCBCO = msg.IndicadorBancoOuInstPagamento;

            if (!string.IsNullOrWhiteSpace(msg.codigoIspb))
                registroNegocios.NEGCODISPB = msg.codigoIspb;

            if (msg.codigoInstPagamento != null && msg.codigoInstPagamento.Value > 0)
                registroNegocios.IPGCOD = msg.codigoInstPagamento;

            if (!string.IsNullOrWhiteSpace(msg.indicadorContaPadrao))
                registroNegocios.NEGSTACONTAPADRAO = msg.indicadorContaPadrao;

            _log.TraceMethodEnd();

            return registroNegocios;
        }


        public DataSetNegocioRegistroOutrosBancos[] AdaptarMsgRegistronegociosToDataSetNegocioRegistroMegociosExclusao(string cod_pessoa, int sequencial, string cod_filial, IList<string> erros)
        {
            _log.TraceMethodStart();

            List<DataSetNegocioRegistroOutrosBancos> registroEnderecos = new List<DataSetNegocioRegistroOutrosBancos>();
            registroEnderecos.Add(AdaptarMsgRegistronegociosToDataSetNegocioRegistroMegociosExclusao(cod_pessoa, sequencial, cod_filial));

            _log.TraceMethodEnd();

            return registroEnderecos.ToArray();
        }

        public DataSetNegocioRegistroOutrosBancos AdaptarMsgRegistronegociosToDataSetNegocioRegistroMegociosExclusao(string cod_pessoa, int sequencial, string cod_filial)
        {
            _log.TraceMethodStart();

            DataSetNegocioRegistroOutrosBancos registroNegocios = new DataSetNegocioRegistroOutrosBancos();

            registroNegocios.statuslinha = ConstantesInegracao.StatusLinhaCUC.Exclusao;

            if (!string.IsNullOrWhiteSpace(cod_pessoa))
                registroNegocios.cod_pessoa = cod_pessoa;

            if (!string.IsNullOrWhiteSpace(cod_filial))
                registroNegocios.cod_fil = cod_filial;

            if (sequencial > 0)
                registroNegocios.seq_negbco = sequencial;

            _log.TraceMethodEnd();

            return registroNegocios;
        }

        public MsgRegistroNegocios AdaptaDataSetNegocioToMsgNegocio(DataSetNegocioOutrosBancos dataset, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRegistroNegocios msg = new MsgRegistroNegocios();

            if (dataset.RegistroNegocioOutrosBancos != null && dataset.RegistroNegocioOutrosBancos.Any())
                msg = AdaptarDataSetNegociosRegistroNegociosToMsgNegocios(dataset.RegistroNegocioOutrosBancos.First(), erros);

            _log.TraceMethodEnd();

            return msg;
        }

        public MsgRegistroNegocios AdaptarDataSetNegociosRegistroNegociosToMsgNegocios(DataSetNegocioRegistroOutrosBancos registroNegocio, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRegistroNegocios msg = new MsgRegistroNegocios();


            if (!string.IsNullOrWhiteSpace(registroNegocio.cod_pessoa))
                msg.codigoPessoa = registroNegocio.cod_pessoa;

            if (!string.IsNullOrWhiteSpace(registroNegocio.cod_fil))
                msg.codigoFilial = registroNegocio.cod_fil;

            if (registroNegocio.seq_negbco != null && registroNegocio.seq_negbco.Value > 0)
                msg.sequencial = registroNegocio.seq_negbco;

            if (registroNegocio.cod_age_negbco != null && registroNegocio.cod_age_negbco.Value > 0)
                msg.codigoAgencia = registroNegocio.cod_age_negbco;

            if (!string.IsNullOrWhiteSpace(registroNegocio.num_negbco))
                msg.numeroConta = registroNegocio.num_negbco;

            if (registroNegocio.val_limite_negbco != null && registroNegocio.val_limite_negbco.Value > 0)
                msg.valorLimite = registroNegocio.val_limite_negbco;

            if (registroNegocio.val_dev_negbco != null && registroNegocio.val_dev_negbco.Value > 0)
                msg.valdoDevedor = registroNegocio.val_dev_negbco;

            if (registroNegocio.dat_ini_negbco != null && registroNegocio.dat_ini_negbco.Value != DateTime.MinValue)
                msg.dataInicio = registroNegocio.dat_ini_negbco;

            if (registroNegocio.dat_fim_negbco != null && registroNegocio.dat_fim_negbco.Value != DateTime.MinValue)
                msg.dataFim = registroNegocio.dat_fim_negbco;

            if (registroNegocio.dat_cad != null && registroNegocio.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = registroNegocio.dat_cad;

            if (!string.IsNullOrWhiteSpace(registroNegocio.usu_atu))
                msg.usuarioUltimaAtualizacao = registroNegocio.usu_atu;

            if (registroNegocio.dat_atu != null && registroNegocio.dat_atu.Value != DateTime.MinValue)
                msg.dataAtualizacao = registroNegocio.dat_atu;

            if (registroNegocio.dat_sit != null && registroNegocio.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = registroNegocio.dat_sit;

            if (!string.IsNullOrWhiteSpace(registroNegocio.idc_sit))
                msg.identificadorSituacao = registroNegocio.idc_sit;

            if (registroNegocio.cod_empresa != null && registroNegocio.cod_empresa.Value > 0)
                msg.codigoEmpresa = registroNegocio.cod_empresa;

            if (registroNegocio.cod_prodbco != null && registroNegocio.cod_prodbco.Value > 0)
                msg.codigoProdutoBancario = registroNegocio.cod_prodbco;

            if (registroNegocio.cod_bco != null && registroNegocio.cod_bco.Value > 0)
                msg.codigoBanco = registroNegocio.cod_bco;

            if (registroNegocio.cod_bco_negbco != null && registroNegocio.cod_bco_negbco.Value > 0)
                msg.codigoBancoNegocio = registroNegocio.cod_bco_negbco;

            if (!string.IsNullOrWhiteSpace(registroNegocio.COD_CTA_RESGATE))
                msg.contaCreditoResgate = registroNegocio.COD_CTA_RESGATE;

            if (!string.IsNullOrWhiteSpace(registroNegocio.STA_REGISTRO))
                msg.SituacaoRegistro = registroNegocio.STA_REGISTRO;

            if (!string.IsNullOrWhiteSpace(registroNegocio.NEGIDCBCO))
                msg.IndicadorBancoOuInstPagamento = registroNegocio.NEGIDCBCO;

            if (!string.IsNullOrWhiteSpace(registroNegocio.NEGCODISPB))
                msg.codigoIspb = registroNegocio.NEGCODISPB;

            if (registroNegocio.IPGCOD != null && registroNegocio.IPGCOD.Value > 0)
                msg.codigoInstPagamento = registroNegocio.IPGCOD;

            if (!string.IsNullOrWhiteSpace(registroNegocio.NEGSTACONTAPADRAO))
                msg.indicadorContaPadrao = registroNegocio.NEGSTACONTAPADRAO;

            _log.TraceMethodEnd();

            return msg;
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(object msg, IList<string> erros, string identificador)
        {
            _log.TraceMethodStart();

            MsgRetornoGet retorno = new MsgRetornoGet();
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

            if (erros.Any())
            {
                header.erros = erros.ToArray();
            }

            if (!erros.Any() && msg != null)
                retorno.body = msg;

            _log.TraceMethodEnd();

            return retorno;
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros, string identificador)
        {
            return AdaptarMsgRetornoGet(null, erros, identificador);
        }
        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros)
        {
            return AdaptarMsgRetornoGet(null, erros, string.Empty);
        }
    }
}
