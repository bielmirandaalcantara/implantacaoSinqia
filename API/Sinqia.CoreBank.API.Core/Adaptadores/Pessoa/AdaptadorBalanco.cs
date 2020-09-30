using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.API.Core.Models.Pessoa;
using Sinqia.CoreBank.Logging.Services;
using Sinqia.CoreBank.Services.CUC.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Adaptadores.Pessoa
{
    public class AdaptadorBalanco
    {
        private LogService _log;
        public AdaptadorBalanco(LogService log)
        {
            _log = log;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgBalanco msgBalanco, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgBalanco != null && msgBalanco.header != null)
            {
                identificador = msgBalanco.header.identificadorEnvio;
                dataEnvio = msgBalanco.header.dataHoraEnvio.HasValue ? msgBalanco.header.dataHoraEnvio.Value : DateTime.Now;
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

        public DataSetPessoaRegistroBalanco AdaptarMsgRegistroBalancoToDataSetPessoaRegistroBalanco(MsgRegistroBalanco msg, string statusLinha, IList<string> erros)
        {
            _log.TraceMethodStart();

            DataSetPessoaRegistroBalanco registroBalanco = new DataSetPessoaRegistroBalanco();

            registroBalanco.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroBalanco.cod_pessoa = msg.codigoPessoa;

            if (msg.anoBalanco != null && msg.anoBalanco.Value != DateTime.MinValue)
                registroBalanco.ano_balanco = msg.anoBalanco;

            if (msg.sequencialBalanco != null && msg.sequencialBalanco.Value > 0)
                registroBalanco.seq_balanco = msg.sequencialBalanco;

            if (msg.dataInicioBalanco != null && msg.dataInicioBalanco.Value != DateTime.MinValue)
                registroBalanco.dat_ini_balanco = msg.dataInicioBalanco;

            if (msg.dataFimBalanco != null && msg.dataFimBalanco.Value != DateTime.MinValue)
                registroBalanco.dat_fim_balanco = msg.dataFimBalanco;

            if (!string.IsNullOrWhiteSpace(msg.descricaoBalanco))
                registroBalanco.des_balanco = msg.descricaoBalanco;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroBalanco.dat_cad = msg.dataCadastro;

            if (!string.IsNullOrWhiteSpace(msg.codigoUsuarioAtualizacao))
                registroBalanco.usu_atu = msg.codigoUsuarioAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroBalanco.dat_atu = msg.dataAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                registroBalanco.idc_sit = msg.indicadorSituacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroBalanco.dat_sit = msg.dataSituacao;

            if (!string.IsNullOrWhiteSpace(msg.codigoIndice))
                registroBalanco.cod_ind = msg.codigoIndice;

            if (!string.IsNullOrWhiteSpace(msg.codigoDetalheLinhaBalanco))
                registroBalanco.cod_detalhe = msg.codigoDetalheLinhaBalanco;

            if (msg.valorAnalisado != null && msg.valorAnalisado.Value > 0)
                registroBalanco.val_analisado = msg.valorAnalisado;

            _log.TraceMethodEnd();

            return registroBalanco;
        }

        public DataSetPessoaRegistroBalanco[] AdaptarMsgRegistroBalancoToDataSetPessoaRegistroBalancoExclusao(string cod_pessoa, string Balanco, IList<string> erros)
        {
            _log.TraceMethodStart();

            List<DataSetPessoaRegistroBalanco> registroBalancos = new List<DataSetPessoaRegistroBalanco>();
            registroBalancos.Add(AdaptarMsgRegistroBalancoToDataSetPessoaRegistroBalancoExclusao(cod_pessoa, Balanco));

            _log.TraceMethodEnd();

            return registroBalancos.ToArray();
        }

        public DataSetPessoaRegistroBalanco AdaptarMsgRegistroBalancoToDataSetPessoaRegistroBalancoExclusao(string cod_pessoa, string Balanco)
        {
            _log.TraceMethodStart();

            DataSetPessoaRegistroBalanco registroBalanco = new DataSetPessoaRegistroBalanco();

            registroBalanco.statuslinha = ConstantesInegracao.StatusLinhaCUC.Exclusao;

            if (!string.IsNullOrWhiteSpace(cod_pessoa))
                registroBalanco.cod_pessoa = cod_pessoa;

            if (!string.IsNullOrWhiteSpace(Balanco))
                registroBalanco.cod_detalhe = Balanco;

            _log.TraceMethodEnd();

            return registroBalanco;
        }
    }
}
