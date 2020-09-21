using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorNegocios
    {
        public MsgRetorno AdaptarMsgRetorno(MsgNegocios msg, IList<string> erros)
        {
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


        //public DataSetPessoaRegistroEndereco[] AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(MsgRegistroendereco[] msg, string statusLinha, IList<string> erros)
        //{
        //    List<DataSetPessoaRegistroEndereco> registroEnderecos = new List<DataSetPessoaRegistroEndereco>();
        //    foreach (var endereco in msg)
        //    {
        //        registroEnderecos.Add(AdaptarMsgRegistroNegocioToDataSetNegocioRegistroNegocio(endereco, statusLinha, erros));
        //    }

        //    return registroEnderecos.ToArray();
        //}

        public DataSetNegocioRegistroOutrosBancos AdaptarMsgRegistroNegocioToDataSetNegocioRegistroNegocio(MsgRegistroNegocios msg, string statusLinha, IList<string> erros)
        {
            DataSetNegocioRegistroOutrosBancos registroNegocios = new DataSetNegocioRegistroOutrosBancos();

            //registroNegocios.statuslinha = statusLinha;

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

            return registroNegocios;
        }

    }
}
