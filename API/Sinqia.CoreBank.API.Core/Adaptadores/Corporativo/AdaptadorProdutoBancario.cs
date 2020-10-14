using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Adaptadores.Corporativo
{
    public class AdaptadorProdutoBancario
    {
        private LogService _log;
        public AdaptadorProdutoBancario(LogService log)
        {
            _log = log;
        }

        public tb_prodbco AdaptarMsgProdutoBancarioToModeltb_prodbco(MsgRegistroProdutoBancario msg)
        {
            tb_prodbco tb_prodbco = new tb_prodbco();

            if (msg.codigoEmpresa != null && msg.codigoEmpresa.Value > 0)
                tb_prodbco.cod_empresa = msg.codigoEmpresa;

            if (msg.codigoProduto != null && msg.codigoProduto.Value > 0)
                tb_prodbco.cod_prodbco = msg.codigoProduto;

            if (!string.IsNullOrWhiteSpace(msg.nomeAbreviado))
                tb_prodbco.abv_prodbco = msg.nomeAbreviado;

            if (!string.IsNullOrWhiteSpace(msg.nomeCompleto))
                tb_prodbco.des_prodbco = msg.nomeCompleto;

            if (msg.codigoGrupo != null && msg.codigoGrupo.Value > 0)
                tb_prodbco.cod_grproduto = msg.codigoGrupo;

            if (!string.IsNullOrWhiteSpace(msg.indicadorReplica))
                tb_prodbco.idc_replica = msg.indicadorReplica;

            if (!string.IsNullOrWhiteSpace(msg.tipoProduto))
                tb_prodbco.tip_produto = msg.tipoProduto;

            return tb_prodbco;
        }

        public MsgRegistroProdutoBancario tb_prodbcoToMsgProdutoBancario(tb_prodbco tb_prodbco)
        {
            _log.TraceMethodStart();

            MsgRegistroProdutoBancario msg = new MsgRegistroProdutoBancario();

            if (tb_prodbco.cod_empresa != null && tb_prodbco.cod_empresa.Value > 0)
                msg.codigoEmpresa = tb_prodbco.cod_empresa;

            if (tb_prodbco.cod_prodbco != null && tb_prodbco.cod_prodbco.Value > 0)
                msg.codigoProduto = tb_prodbco.cod_prodbco;

            if (!string.IsNullOrWhiteSpace(tb_prodbco.abv_prodbco))
                msg.nomeAbreviado = tb_prodbco.abv_prodbco;

            if (!string.IsNullOrWhiteSpace(tb_prodbco.des_prodbco))
                msg.nomeCompleto = tb_prodbco.des_prodbco;

            if (tb_prodbco.cod_grproduto != null && tb_prodbco.cod_grproduto.Value > 0)
                msg.codigoGrupo = tb_prodbco.cod_grproduto;

            if (!string.IsNullOrWhiteSpace(tb_prodbco.idc_replica))
                msg.indicadorReplica = tb_prodbco.idc_replica;

            if (!string.IsNullOrWhiteSpace(tb_prodbco.tip_produto))
                msg.tipoProduto = tb_prodbco.tip_produto;

            return msg;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgProdutoBancario msg, IList<string> erros)
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

    }
}
