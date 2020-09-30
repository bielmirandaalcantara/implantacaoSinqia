using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.API.Core.Models;
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
    public class AdaptadorRendas
    {
        private LogService _log;
        public AdaptadorRendas(LogService log)
        {
            _log = log;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgRendas msgRendas, IList<string> erros)
        {
            _log.TraceMethodStart();

            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgRendas != null && msgRendas.header != null)
            {
                identificador = msgRendas.header.identificadorEnvio;
                dataEnvio = msgRendas.header.dataHoraEnvio.HasValue ? msgRendas.header.dataHoraEnvio.Value : DateTime.Now;
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

        public DataSetPessoaRegistroRendas[] AdaptarMsgRegistroRendasToDataSetPessoaRegistroRendasExclusao(string cod_pessoa, int num_rendas, IList<string> erros)
        {
            _log.TraceMethodStart();

            List<DataSetPessoaRegistroRendas> registroRendass = new List<DataSetPessoaRegistroRendas>();
            registroRendass.Add(AdaptarMsgRegistroRendasToDataSetPessoaRegistroRendasExclusao(cod_pessoa, num_rendas));

            _log.TraceMethodEnd();

            return registroRendass.ToArray();
        }

        public DataSetPessoaRegistroRendas AdaptarMsgRegistroRendasToDataSetPessoaRegistroRendasExclusao(string cod_pessoa, int num_rendas)
        {
            _log.TraceMethodStart();

            DataSetPessoaRegistroRendas registroRendas = new DataSetPessoaRegistroRendas();

            registroRendas.statuslinha = ConstantesInegracao.StatusLinhaCUC.Exclusao;

            if (!string.IsNullOrWhiteSpace(cod_pessoa))
                registroRendas.cod_pessoa = cod_pessoa;

            if (num_rendas > 0)
                registroRendas.num_renda = num_rendas;

            _log.TraceMethodEnd();

            return registroRendas;
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

        public DataSetPessoaRegistroRendas AdaptarMsgRegistroRendasToDataSetPessoaRegistroRendas(MsgRegistroRendas msg, string statusLinha, IList<string> erros)
        {
            _log.TraceMethodStart();

            DataSetPessoaRegistroRendas registroRendas = new DataSetPessoaRegistroRendas();

            registroRendas.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroRendas.cod_pessoa = msg.codigoPessoa;

            if (msg.numeroRenda != null && msg.numeroRenda.Value > 0)
                registroRendas.num_renda = msg.numeroRenda;

            if (msg.valRenda != null && msg.valRenda.Value > 0)
                registroRendas.val_renda = msg.valRenda;

            if (!string.IsNullOrWhiteSpace(msg.nomeEmpregador))
                registroRendas.nom_empreg = msg.nomeEmpregador;

            if (!string.IsNullOrWhiteSpace(msg.cargoEmpregador))
                registroRendas.crg_empreg = msg.cargoEmpregador;

            if (!string.IsNullOrWhiteSpace(msg.tipoLogradouro))
                registroRendas.tip_log_empreg = msg.tipoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.logradouroTrabalho))
                registroRendas.end_empreg = msg.logradouroTrabalho;

            if (!string.IsNullOrWhiteSpace(msg.complemento))
                registroRendas.cpl_log_empreg = msg.complemento;

            if (!string.IsNullOrWhiteSpace(msg.bairroTrabalho))
                registroRendas.bai_empreg = msg.bairroTrabalho;

            if (!string.IsNullOrWhiteSpace(msg.cepTrabalho))
                registroRendas.cep_empreg = msg.cepTrabalho;

            if (!string.IsNullOrWhiteSpace(msg.periodicidadeRenda))
                registroRendas.per_renda = msg.periodicidadeRenda;

            if (msg.dataValidadeRenda != null && msg.dataValidadeRenda.Value != DateTime.MinValue)
                registroRendas.dat_vld_renda = msg.dataValidadeRenda;

            if (!string.IsNullOrWhiteSpace(msg.observacaoRenda))
                registroRendas.obs_renda = msg.observacaoRenda;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroRendas.dat_cad = msg.dataCadastro;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroRendas.dat_atu = msg.dataAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.codigoUsuarioAtualizacao))
                registroRendas.usu_atu = msg.codigoUsuarioAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                registroRendas.idc_sit = msg.indicadorSituacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroRendas.dat_sit = msg.dataSituacao;

            if (msg.tipoRenda != null && msg.tipoRenda.Value > 0)
                registroRendas.tip_renda = msg.tipoRenda;

            if (msg.codigoMunicipio != null && msg.codigoMunicipio.Value > 0)
                registroRendas.cod_municipio = msg.codigoMunicipio;

            if (!string.IsNullOrWhiteSpace(msg.codigoIndice))
                registroRendas.cod_ind = msg.codigoIndice;

            if (!string.IsNullOrWhiteSpace(msg.numeroLogradouroEmpregador))
                registroRendas.num_log_empreg = msg.numeroLogradouroEmpregador;

            if (msg.dataAdmissao != null && msg.dataAdmissao.Value != DateTime.MinValue)
                registroRendas.dat_admissao = msg.dataAdmissao;

            if (msg.dataDemissao != null && msg.dataDemissao.Value != DateTime.MinValue)
                registroRendas.dat_demissao = msg.dataDemissao;

            if (!string.IsNullOrWhiteSpace(msg.dddEmpregador))
                registroRendas.ddd_empreg = msg.dddEmpregador;

            if (!string.IsNullOrWhiteSpace(msg.telefoneEmpregador))
                registroRendas.tel_empreg = msg.telefoneEmpregador;

            if (!string.IsNullOrWhiteSpace(msg.ramalEmpregador))
                registroRendas.ram_empreg = msg.ramalEmpregador;

            if (!string.IsNullOrWhiteSpace(msg.cnpjEmpregador))
                registroRendas.cod_cnpj = msg.cnpjEmpregador;

            if (!string.IsNullOrWhiteSpace(msg.tipoEmpresa))
                registroRendas.tip_emp = msg.tipoEmpresa;

            if (!string.IsNullOrWhiteSpace(msg.identificadorRendaConjugue))
                registroRendas.renidtrencon = msg.identificadorRendaConjugue;

            if (!string.IsNullOrWhiteSpace(msg.identificaRendaCorrespEmpregador))
                registroRendas.renidtemp = msg.identificaRendaCorrespEmpregador;

            _log.TraceMethodEnd();

            return registroRendas;
        }
    }
}
