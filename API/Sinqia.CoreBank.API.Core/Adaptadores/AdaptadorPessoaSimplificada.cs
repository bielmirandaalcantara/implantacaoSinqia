using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorPessoaSimplificada
    {
        private AdaptadorVinculo _AdaptadorVinculo;
        public AdaptadorVinculo AdaptadorVinculo
        {
            get
            {
                if (_AdaptadorVinculo == null) _AdaptadorVinculo = new AdaptadorVinculo();
                return _AdaptadorVinculo;
            }
        }

        public MsgRetorno AdaptarMsgRetorno(MsgPessoaSimplificada msgPessoa, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgPessoa.header != null)
            {
                identificador = msgPessoa.header.identificadorEnvio;
                dataEnvio = msgPessoa.header.dataHoraEnvio.HasValue ? msgPessoa.header.dataHoraEnvio.Value : DateTime.Now;
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

        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros)
        {
            return AdaptarMsgRetornoGet(null, erros);
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(MsgRegistroPessoaSimplificada msgPessoaSimp, IList<string> erros)
        {
            MsgRetornoGet retorno = new MsgRetornoGet();
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
            retorno.header = header;

            if (!erros.Any() && msgPessoaSimp != null)
            {
                retorno.body = msgPessoaSimp;
            }
            return retorno;
        }

        public DataSetPessoa AdaptarMsgPessoaSimplificadaToDataSetPessoa(MsgPessoaSimplificada msg, IList<string> erros)
        {
            if (msg.body == null)
                throw new ApplicationException("Campo body obrigatório");

            if (msg.body.RegistroPessoaSimplificada == null)
                throw new ApplicationException("Campo RegistroPessoaSimplificada obrigatório");

            MsgRegistroPessoaSimplificada registroPessoaSimplificada = msg.body.RegistroPessoaSimplificada;

            DataSetPessoa xml = new DataSetPessoa();
            xml.RegistroPessoaSimplificada = AdaptarMsgRegistroPessoaSimplificadaToDataSetPessoaRegistroPessoaSimplificada(registroPessoaSimplificada, erros);

            if (registroPessoaSimplificada.RegistroVinculo != null && registroPessoaSimplificada.RegistroVinculo.Any())
                xml.RegistroVinculo = AdaptadorVinculo.AdaptarMsgRegistroVinculoToDataSetPessoaRegistroVinculo(registroPessoaSimplificada.RegistroVinculo, erros);

            return xml;
        }

        public DataSetPessoaRegistroPessoaSimplificada AdaptarMsgRegistroPessoaSimplificadaToDataSetPessoaRegistroPessoaSimplificada(MsgRegistroPessoaSimplificada msg, IList<string> erros)
        {
            DataSetPessoaRegistroPessoaSimplificada registroPessoaSimplificada = new DataSetPessoaRegistroPessoaSimplificada();

            if (!string.IsNullOrWhiteSpace(msg.codigo))
                registroPessoaSimplificada.cod_simp = msg.codigo;

            if (!string.IsNullOrWhiteSpace(msg.nome))
                registroPessoaSimplificada.nom_simp = msg.nome;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone1))
                registroPessoaSimplificada.ddd_fone_1_simp = msg.codigoDddFone1;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone2))
                registroPessoaSimplificada.ddd_fone_2_simp = msg.codigoDddFone2;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone1))
                registroPessoaSimplificada.fone_1_simp = msg.numeroTelefone1;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone2))
                registroPessoaSimplificada.fone_2_simp = msg.numeroTelefone2;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal1))
                registroPessoaSimplificada.ram_fone_1_simp = msg.numeroRamal1;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal2))
                registroPessoaSimplificada.ram_fone_2_simp = msg.numeroRamal2;

            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone1))
                registroPessoaSimplificada.sit_fone_1_simp = msg.situacaoTelefone1;

            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone2))
                registroPessoaSimplificada.sit_fone_2_simp = msg.situacaoTelefone2;

            if (msg.dataNascimento != null && msg.dataNascimento.Value != DateTime.MinValue)
                registroPessoaSimplificada.dat_nasc_simp = msg.dataNascimento.Value;

            if (!string.IsNullOrWhiteSpace(msg.observacao))
                registroPessoaSimplificada.obs_simp = msg.observacao;

            if (!string.IsNullOrWhiteSpace(msg.tipoReferencia))
                registroPessoaSimplificada.tip_simp = msg.tipoReferencia;

            if (msg.dataCadastramento != null &&  msg.dataCadastramento.Value != DateTime.MinValue)
                registroPessoaSimplificada.dat_cad = msg.dataCadastramento.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroPessoaSimplificada.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null &&  msg.dataAtualizacao.Value != DateTime.MinValue)
                registroPessoaSimplificada.dat_atu = msg.dataAtualizacao.Value;

            if (msg.codigoMunicipio != null &&  msg.codigoMunicipio.Value > 0)
                registroPessoaSimplificada.cod_mun_simp = msg.codigoMunicipio.Value;

            if (!string.IsNullOrWhiteSpace(msg.descricaoMunicipio))
                registroPessoaSimplificada.des_mun_simp = msg.descricaoMunicipio;

            if (!string.IsNullOrWhiteSpace(msg.tipoLogradouro))
                registroPessoaSimplificada.tip_log_simp = msg.tipoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.descricicaoLogradouro))
                registroPessoaSimplificada.des_log_simp = msg.descricicaoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.numeroEndereco))
                registroPessoaSimplificada.num_simp = msg.numeroEndereco;

            if (!string.IsNullOrWhiteSpace(msg.complementoLogradouro))
                registroPessoaSimplificada.cpl_end_simp = msg.complementoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.nomeBairro))
                registroPessoaSimplificada.bai_end_simp = msg.nomeBairro;

            if (!string.IsNullOrWhiteSpace(msg.tipoEndereco))
                registroPessoaSimplificada.tip_end_simp = msg.tipoEndereco;

            if (!string.IsNullOrWhiteSpace(msg.uf))
                registroPessoaSimplificada.uf_end_simp = msg.uf;

            if (!string.IsNullOrWhiteSpace(msg.pais))
                registroPessoaSimplificada.pais_simp = msg.pais;

            if (!string.IsNullOrWhiteSpace(msg.numeroCep))
                registroPessoaSimplificada.cep_simp = msg.numeroCep;

            if (!string.IsNullOrWhiteSpace(msg.estadoCivil))
                registroPessoaSimplificada.est_civ_simp = msg.estadoCivil;

            if (!string.IsNullOrWhiteSpace(msg.regimeComunhao))
                registroPessoaSimplificada.reg_com_simp = msg.regimeComunhao;

            if (!string.IsNullOrWhiteSpace(msg.nomeConjugue))
                registroPessoaSimplificada.nom_conj_simp = msg.nomeConjugue;

            if (!string.IsNullOrWhiteSpace(msg.indicadorAvalista))
                registroPessoaSimplificada.idc_ava_simp = msg.indicadorAvalista;

            if (!string.IsNullOrWhiteSpace(msg.CpfCnpjSimplificado))
                registroPessoaSimplificada.cpf_cnpj_simp = msg.CpfCnpjSimplificado;

            if (!string.IsNullOrWhiteSpace(msg.tipoPessoa))
                registroPessoaSimplificada.tip_pes_simp = msg.tipoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.identificadorIsentoCpf))
                registroPessoaSimplificada.idc_isen_cpf_cnpf_simp = msg.identificadorIsentoCpf;

            if (!string.IsNullOrWhiteSpace(msg.codigoSistemaOrigem))
                registroPessoaSimplificada.pescodsisorigem = msg.codigoSistemaOrigem;

            if (!string.IsNullOrWhiteSpace(msg.CpfConjugue))
                registroPessoaSimplificada.pescpfconj = msg.CpfConjugue;

            if (!string.IsNullOrWhiteSpace(msg.indicadorClienteFatca))
                registroPessoaSimplificada.idc_fatca = msg.indicadorClienteFatca;

            if (!string.IsNullOrWhiteSpace(msg.numeroRg))
                registroPessoaSimplificada.rg_simp = msg.numeroRg;

            if (!string.IsNullOrWhiteSpace(msg.numeroIdentificadorFiscal))
                registroPessoaSimplificada.nif_simp = msg.numeroIdentificadorFiscal;

            if (msg.codigoNacionalidade1 != null &&  msg.codigoNacionalidade1.Value > 0)
                registroPessoaSimplificada.nac1_simp = msg.codigoNacionalidade1.Value;

            if (msg.codigoNacionalidade2 != null &&  msg.codigoNacionalidade2.Value > 0)
                registroPessoaSimplificada.nac2_simp = msg.codigoNacionalidade2.Value;

            if (msg.codigoNacionalidade3 != null &&  msg.codigoNacionalidade3.Value > 0)
                registroPessoaSimplificada.nac3_simp = msg.codigoNacionalidade3.Value;

            if (msg.codigoNacionalidade4 != null &&  msg.codigoNacionalidade4.Value > 0)
                registroPessoaSimplificada.nac4_simp = msg.codigoNacionalidade4.Value;

            if (msg.codigoDomicilioFiscal1 != null &&  msg.codigoDomicilioFiscal1.Value > 0)
                registroPessoaSimplificada.dom_fis1_simp = msg.codigoDomicilioFiscal1.Value;

            if (msg.codigoDomicilioFiscal2 != null &&  msg.codigoDomicilioFiscal2.Value > 0)
                registroPessoaSimplificada.dom_fis2_simp = msg.codigoDomicilioFiscal2.Value;

            if (msg.codigoDomicilioFiscal3 != null &&  msg.codigoDomicilioFiscal3.Value > 0)
                registroPessoaSimplificada.dom_fis3_simp = msg.codigoDomicilioFiscal3.Value;

            if (msg.codigoDomicilioFiscal4 != null &&  msg.codigoDomicilioFiscal4.Value > 0)
                registroPessoaSimplificada.dom_fis4_simp = msg.codigoDomicilioFiscal4.Value;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddCelular))
                registroPessoaSimplificada.ddd_cel_simp = msg.codigoDddCelular;

            if (!string.IsNullOrWhiteSpace(msg.numeroCelular))
                registroPessoaSimplificada.fone_cel_simp = msg.numeroCelular;

            if (!string.IsNullOrWhiteSpace(msg.email))
                registroPessoaSimplificada.email = msg.email;

            if (!string.IsNullOrWhiteSpace(msg.indicadorClienteEstrangeiro))
                registroPessoaSimplificada.idc_cli_est = msg.indicadorClienteEstrangeiro;

            if (!string.IsNullOrWhiteSpace(msg.tipoDocumentoEstrangeiro))
                registroPessoaSimplificada.tip_doc_est = msg.tipoDocumentoEstrangeiro;

            if (!string.IsNullOrWhiteSpace(msg.numeroDocumentoEstrangeiro))
                registroPessoaSimplificada.num_doc_est = msg.numeroDocumentoEstrangeiro;

            if (!string.IsNullOrWhiteSpace(msg.nomeSocial))
                registroPessoaSimplificada.nom_social_simp = msg.nomeSocial;

            if (!string.IsNullOrWhiteSpace(msg.nivelRiscoPld))
                registroPessoaSimplificada.pld_pes = msg.nivelRiscoPld;

            if (!string.IsNullOrWhiteSpace(msg.observacaoPld))
                registroPessoaSimplificada.obs_pld = msg.observacaoPld;

            //if (!string.IsNullOrWhiteSpace(msg.CodigoAtividadeCbo))
            //    registroPessoaSimplificada.cod_cbo = msg.CodigoAtividadeCbo;

            //if (msg.CodigoAtividade > 0)
            //    registroPessoaSimplificada.COD_ATIVIDADE = msg.CodigoAtividade;

            return registroPessoaSimplificada;
        }

    }
}