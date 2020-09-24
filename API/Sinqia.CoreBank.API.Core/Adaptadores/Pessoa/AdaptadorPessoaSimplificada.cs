//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Sinqia.CoreBank.API.Core.Models;
//using Sinqia.CoreBank.API.Core.Models.Pessoa;
//using Sinqia.CoreBank.API.Core.Constantes;
//using Sinqia.CoreBank.Services.CUC.Models;

//namespace Sinqia.CoreBank.API.Core.Adaptadores.Pessoa
//{
//    public class AdaptadorPessoaSimplificada
//    {
//        private AdaptadorVinculo _AdaptadorVinculo;
//        public AdaptadorVinculo AdaptadorVinculo
//        {
//            get
//            {
//                if (_AdaptadorVinculo == null) _AdaptadorVinculo = new AdaptadorVinculo();
//                return _AdaptadorVinculo;
//            }
//        }

//        public MsgRetorno AdaptarMsgRetorno(MsgPessoaSimplificada msgPessoa, IList<string> erros)
//        {
//            MsgRetorno retorno = new MsgRetorno();
//            string identificador = string.Empty;
//            DateTime dataEnvio = DateTime.MinValue;
//            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

//            if (msgPessoa != null && msgPessoa.header != null)
//            {
//                identificador = msgPessoa.header.identificadorEnvio;
//                dataEnvio = msgPessoa.header.dataHoraEnvio.HasValue ? msgPessoa.header.dataHoraEnvio.Value : DateTime.Now;
//            }

//            var header = new MsgHeaderRetorno()
//            {
//                identificador = identificador,
//                dataHoraEnvio = dataEnvio,
//                dataHoraRetorno = DateTime.Now,
//                status = status,
//                codigoPessoa = msgPessoa.body.RegistroPessoaSimplificada.codigo
//            };

//            if (erros.Any())
//            {
//                header.erros = erros.ToArray();
//            }

//            retorno.header = header;
//            return retorno;
//        }

//        public MsgRetorno AdaptarMsgRetorno(IList<string> erros)
//        {
//            return AdaptarMsgRetorno(erros, string.Empty);
//        }

//        public MsgRetorno AdaptarMsgRetorno(IList<string> erros, string identificador)
//        {
//            MsgRetorno retorno = new MsgRetorno();
//            DateTime dataEnvio = DateTime.MinValue;
//            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

//            var header = new MsgHeaderRetorno()
//            {
//                identificador = identificador,
//                dataHoraEnvio = dataEnvio,
//                dataHoraRetorno = DateTime.Now,
//                status = status
//            };

//            if (erros.Any())
//            {
//                header.erros = erros.ToArray();
//            }

//            retorno.header = header;
//            return retorno;
//        }

//        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros)
//        {
//            return AdaptarMsgRetornoGet(null, erros, string.Empty);
//        }

//        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros, string identificador)
//        {
//            return AdaptarMsgRetornoGet(null, erros, identificador);
//        }

//        public MsgRetornoGet AdaptarMsgRetornoGet(object msg, IList<string> erros, string identificador)
//        {
//            MsgRetornoGet retorno = new MsgRetornoGet();
//            DateTime dataEnvio = DateTime.MinValue;
//            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

//            var header = new MsgHeaderRetorno()
//            {
//                identificador = identificador,
//                dataHoraEnvio = dataEnvio,
//                dataHoraRetorno = DateTime.Now,
//                status = status
//            };
//            retorno.header = header;

//            if (erros.Any())
//            {
//                header.erros = erros.ToArray();
//            }

//            if (!erros.Any() && msg != null)
//                retorno.body = msg;

//            return retorno;
//        }

//        public DataSetPessoa AdaptarMsgPessoaSimplificadaToDataSetPessoa(MsgPessoaSimplificada msg, string statusLinha, IList<string> erros)
//        {
//            if (msg.body == null)
//                throw new ApplicationException("Campo body obrigatório");

//            if (msg.body.RegistroPessoaSimplificada == null)
//                throw new ApplicationException("Campo RegistroPessoaSimplificada obrigatório");

//            MsgRegistroPessoaSimplificada registroPessoaSimplificada = msg.body.RegistroPessoaSimplificada;

//            DataSetPessoa xml = new DataSetPessoa();
//            xml.RegistroPessoaSimplificada = new DataSetPessoaRegistroPessoaSimplificada[] {
//                AdaptarMsgRegistroPessoaSimplificadaToDataSetPessoaRegistroPessoaSimplificada(registroPessoaSimplificada, statusLinha, erros)
//            };

//            if (registroPessoaSimplificada.RegistroVinculo != null && registroPessoaSimplificada.RegistroVinculo.Any())
//                xml.RegistroVinculo = AdaptadorVinculo.AdaptarMsgRegistroVinculoToDataSetPessoaRegistroVinculo(registroPessoaSimplificada.RegistroVinculo, erros);

//            return xml;
//        }

//        public DataSetPessoaRegistroPessoaSimplificada AdaptarMsgRegistroPessoaSimplificadaToDataSetPessoaRegistroPessoaSimplificada(MsgRegistroPessoaSimplificada msg, string statusLinha, IList<string> erros)
//        {
//            DataSetPessoaRegistroPessoaSimplificada registroPessoaSimplificada = new DataSetPessoaRegistroPessoaSimplificada();

//            registroPessoaSimplificada.statuslinha = statusLinha;

//            if (!string.IsNullOrWhiteSpace(msg.codigo))
//                registroPessoaSimplificada.cod_simp = msg.codigo;

//            if (!string.IsNullOrWhiteSpace(msg.nome))
//                registroPessoaSimplificada.nom_simp = msg.nome;

//            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone1))
//                registroPessoaSimplificada.ddd_fone_1_simp = msg.codigoDddFone1;

//            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone2))
//                registroPessoaSimplificada.ddd_fone_2_simp = msg.codigoDddFone2;

//            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone1))
//                registroPessoaSimplificada.fone_1_simp = msg.numeroTelefone1;

//            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone2))
//                registroPessoaSimplificada.fone_2_simp = msg.numeroTelefone2;

//            if (!string.IsNullOrWhiteSpace(msg.numeroRamal1))
//                registroPessoaSimplificada.ram_fone_1_simp = msg.numeroRamal1;

//            if (!string.IsNullOrWhiteSpace(msg.numeroRamal2))
//                registroPessoaSimplificada.ram_fone_2_simp = msg.numeroRamal2;

//            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone1))
//                registroPessoaSimplificada.sit_fone_1_simp = msg.situacaoTelefone1;

//            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone2))
//                registroPessoaSimplificada.sit_fone_2_simp = msg.situacaoTelefone2;

//            if (msg.dataNascimento != null && msg.dataNascimento.Value != DateTime.MinValue)
//                registroPessoaSimplificada.dat_nasc_simp = msg.dataNascimento.Value;

//            if (!string.IsNullOrWhiteSpace(msg.observacao))
//                registroPessoaSimplificada.obs_simp = msg.observacao;

//            if (!string.IsNullOrWhiteSpace(msg.tipoReferencia))
//                registroPessoaSimplificada.tip_simp = msg.tipoReferencia;

//            if (msg.dataCadastramento != null &&  msg.dataCadastramento.Value != DateTime.MinValue)
//                registroPessoaSimplificada.dat_cad = msg.dataCadastramento.Value;

//            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
//                registroPessoaSimplificada.usu_atu = msg.usuarioUltimaAtualizacao;

//            if (msg.dataAtualizacao != null &&  msg.dataAtualizacao.Value != DateTime.MinValue)
//                registroPessoaSimplificada.dat_atu = msg.dataAtualizacao.Value;

//            if (msg.codigoMunicipio != null &&  msg.codigoMunicipio.Value > 0)
//                registroPessoaSimplificada.cod_mun_simp = msg.codigoMunicipio.Value;

//            if (!string.IsNullOrWhiteSpace(msg.descricaoMunicipio))
//                registroPessoaSimplificada.des_mun_simp = msg.descricaoMunicipio;

//            if (!string.IsNullOrWhiteSpace(msg.tipoLogradouro))
//                registroPessoaSimplificada.tip_log_simp = msg.tipoLogradouro;

//            if (!string.IsNullOrWhiteSpace(msg.descricicaoLogradouro))
//                registroPessoaSimplificada.des_log_simp = msg.descricicaoLogradouro;

//            if (!string.IsNullOrWhiteSpace(msg.numeroEndereco))
//                registroPessoaSimplificada.num_simp = msg.numeroEndereco;

//            if (!string.IsNullOrWhiteSpace(msg.complementoLogradouro))
//                registroPessoaSimplificada.cpl_end_simp = msg.complementoLogradouro;

//            if (!string.IsNullOrWhiteSpace(msg.nomeBairro))
//                registroPessoaSimplificada.bai_end_simp = msg.nomeBairro;

//            if (!string.IsNullOrWhiteSpace(msg.tipoEndereco))
//                registroPessoaSimplificada.tip_end_simp = msg.tipoEndereco;

//            if (!string.IsNullOrWhiteSpace(msg.uf))
//                registroPessoaSimplificada.uf_end_simp = msg.uf;

//            if (!string.IsNullOrWhiteSpace(msg.pais))
//                registroPessoaSimplificada.pais_simp = msg.pais;

//            if (!string.IsNullOrWhiteSpace(msg.numeroCep))
//                registroPessoaSimplificada.cep_simp = msg.numeroCep;

//            if (!string.IsNullOrWhiteSpace(msg.estadoCivil))
//                registroPessoaSimplificada.est_civ_simp = msg.estadoCivil;

//            if (!string.IsNullOrWhiteSpace(msg.regimeComunhao))
//                registroPessoaSimplificada.reg_com_simp = msg.regimeComunhao;

//            if (!string.IsNullOrWhiteSpace(msg.nomeConjugue))
//                registroPessoaSimplificada.nom_conj_simp = msg.nomeConjugue;

//            if (!string.IsNullOrWhiteSpace(msg.indicadorAvalista))
//                registroPessoaSimplificada.idc_ava_simp = msg.indicadorAvalista;

//            if (!string.IsNullOrWhiteSpace(msg.CpfCnpjSimplificado))
//                registroPessoaSimplificada.cpf_cnpj_simp = msg.CpfCnpjSimplificado;

//            if (!string.IsNullOrWhiteSpace(msg.tipoPessoa))
//                registroPessoaSimplificada.tip_pes_simp = msg.tipoPessoa;

//            if (!string.IsNullOrWhiteSpace(msg.identificadorIsentoCpf))
//                registroPessoaSimplificada.idc_isen_cpf_cnpf_simp = msg.identificadorIsentoCpf;

//            if (!string.IsNullOrWhiteSpace(msg.codigoSistemaOrigem))
//                registroPessoaSimplificada.pescodsisorigem = msg.codigoSistemaOrigem;

//            if (!string.IsNullOrWhiteSpace(msg.CpfConjugue))
//                registroPessoaSimplificada.pescpfconj = msg.CpfConjugue;

//            if (!string.IsNullOrWhiteSpace(msg.indicadorClienteFatca))
//                registroPessoaSimplificada.idc_fatca = msg.indicadorClienteFatca;

//            if (!string.IsNullOrWhiteSpace(msg.numeroRg))
//                registroPessoaSimplificada.rg_simp = msg.numeroRg;

//            if (!string.IsNullOrWhiteSpace(msg.numeroIdentificadorFiscal))
//                registroPessoaSimplificada.nif_simp = msg.numeroIdentificadorFiscal;

//            if (msg.codigoNacionalidade1 != null &&  msg.codigoNacionalidade1.Value > 0)
//                registroPessoaSimplificada.nac1_simp = msg.codigoNacionalidade1.Value;

//            if (msg.codigoNacionalidade2 != null &&  msg.codigoNacionalidade2.Value > 0)
//                registroPessoaSimplificada.nac2_simp = msg.codigoNacionalidade2.Value;

//            if (msg.codigoNacionalidade3 != null &&  msg.codigoNacionalidade3.Value > 0)
//                registroPessoaSimplificada.nac3_simp = msg.codigoNacionalidade3.Value;

//            if (msg.codigoNacionalidade4 != null &&  msg.codigoNacionalidade4.Value > 0)
//                registroPessoaSimplificada.nac4_simp = msg.codigoNacionalidade4.Value;

//            if (msg.codigoDomicilioFiscal1 != null &&  msg.codigoDomicilioFiscal1.Value > 0)
//                registroPessoaSimplificada.dom_fis1_simp = msg.codigoDomicilioFiscal1.Value;

//            if (msg.codigoDomicilioFiscal2 != null &&  msg.codigoDomicilioFiscal2.Value > 0)
//                registroPessoaSimplificada.dom_fis2_simp = msg.codigoDomicilioFiscal2.Value;

//            if (msg.codigoDomicilioFiscal3 != null &&  msg.codigoDomicilioFiscal3.Value > 0)
//                registroPessoaSimplificada.dom_fis3_simp = msg.codigoDomicilioFiscal3.Value;

//            if (msg.codigoDomicilioFiscal4 != null &&  msg.codigoDomicilioFiscal4.Value > 0)
//                registroPessoaSimplificada.dom_fis4_simp = msg.codigoDomicilioFiscal4.Value;

//            if (!string.IsNullOrWhiteSpace(msg.codigoDddCelular))
//                registroPessoaSimplificada.ddd_cel_simp = msg.codigoDddCelular;

//            if (!string.IsNullOrWhiteSpace(msg.numeroCelular))
//                registroPessoaSimplificada.fone_cel_simp = msg.numeroCelular;

//            if (!string.IsNullOrWhiteSpace(msg.email))
//                registroPessoaSimplificada.email = msg.email;

//            if (!string.IsNullOrWhiteSpace(msg.indicadorClienteEstrangeiro))
//                registroPessoaSimplificada.idc_cli_est = msg.indicadorClienteEstrangeiro;

//            if (!string.IsNullOrWhiteSpace(msg.tipoDocumentoEstrangeiro))
//                registroPessoaSimplificada.tip_doc_est = msg.tipoDocumentoEstrangeiro;

//            if (!string.IsNullOrWhiteSpace(msg.numeroDocumentoEstrangeiro))
//                registroPessoaSimplificada.num_doc_est = msg.numeroDocumentoEstrangeiro;

//            if (!string.IsNullOrWhiteSpace(msg.nomeSocial))
//                registroPessoaSimplificada.nom_social_simp = msg.nomeSocial;

//            if (!string.IsNullOrWhiteSpace(msg.nivelRiscoPld))
//                registroPessoaSimplificada.pld_pes = msg.nivelRiscoPld;

//            if (!string.IsNullOrWhiteSpace(msg.observacaoPld))
//                registroPessoaSimplificada.obs_pld = msg.observacaoPld;

//            //if (!string.IsNullOrWhiteSpace(msg.CodigoAtividadeCbo))
//            //    registroPessoaSimplificada.cod_cbo = msg.CodigoAtividadeCbo;

//            //if (msg.CodigoAtividade > 0)
//            //    registroPessoaSimplificada.COD_ATIVIDADE = msg.CodigoAtividade;

//            return registroPessoaSimplificada;
//        }

//        public MsgRegistroPessoaSimplificada AdaptarDataSetPessoaSimplificadaPessoaSimplificadaToMsgRegistroPessoaSimplificada(DataSetPessoaSimplificadaPessoaSimplificada[] dataset, IList<string> erros)
//        {
//            MsgRegistroPessoaSimplificada msg = new MsgRegistroPessoaSimplificada();

//            if (dataset != null && dataset.Any())
//                msg = AdaptarDataSetPessoaSimplificadaPessoaSimplificadaToMsgRegistroPessoaSimplificada(dataset.First(), erros);

//            return msg;
//        } 

//        public MsgRegistroPessoaSimplificada AdaptarDataSetPessoaSimplificadaPessoaSimplificadaToMsgRegistroPessoaSimplificada(DataSetPessoaSimplificadaPessoaSimplificada registroPessoaSimplificada, IList<string> erros)
//        {
//            MsgRegistroPessoaSimplificada msg = new MsgRegistroPessoaSimplificada();

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.cod_simp))
//                msg.codigo = registroPessoaSimplificada.cod_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.nom_simp))
//                msg.nome = registroPessoaSimplificada.nom_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.ddd_fone_1_simp))
//                msg.codigoDddFone1 = registroPessoaSimplificada.ddd_fone_1_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.ddd_fone_2_simp))
//                msg.codigoDddFone2 = registroPessoaSimplificada.ddd_fone_2_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.fone_1_simp))
//                msg.numeroTelefone1 = registroPessoaSimplificada.fone_1_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.fone_2_simp))
//                msg.numeroTelefone2 = registroPessoaSimplificada.fone_2_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.ram_fone_1_simp))
//                msg.numeroRamal1 = registroPessoaSimplificada.ram_fone_1_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.ram_fone_2_simp))
//                msg.numeroRamal2 = registroPessoaSimplificada.ram_fone_2_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.sit_fone_1_simp))
//                msg.situacaoTelefone1 = registroPessoaSimplificada.sit_fone_1_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.sit_fone_2_simp))
//                msg.situacaoTelefone2 = registroPessoaSimplificada.sit_fone_2_simp;

//            if (registroPessoaSimplificada.dat_nasc_simp != null && registroPessoaSimplificada.dat_nasc_simp.Value != DateTime.MinValue)
//                msg.dataNascimento = registroPessoaSimplificada.dat_nasc_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.obs_simp))
//                msg.observacao = registroPessoaSimplificada.obs_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.tip_simp))
//                msg.tipoReferencia = registroPessoaSimplificada.tip_simp;

//            if (registroPessoaSimplificada.dat_cad != null && registroPessoaSimplificada.dat_cad.Value != DateTime.MinValue)
//                msg.dataCadastramento = registroPessoaSimplificada.dat_cad;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.usu_atu))
//                msg.usuarioUltimaAtualizacao = registroPessoaSimplificada.usu_atu;

//            if (registroPessoaSimplificada.dat_atu != null && registroPessoaSimplificada.dat_atu.Value != DateTime.MinValue)
//                msg.dataAtualizacao = registroPessoaSimplificada.dat_atu;

//            if (registroPessoaSimplificada.cod_mun_simp != null && registroPessoaSimplificada.cod_mun_simp.Value > 0)
//                msg.codigoMunicipio = registroPessoaSimplificada.cod_mun_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.des_mun_simp))
//                msg.descricaoMunicipio = registroPessoaSimplificada.des_mun_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.tip_log_simp))
//                msg.tipoLogradouro = registroPessoaSimplificada.tip_log_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.des_log_simp))
//                msg.descricicaoLogradouro = registroPessoaSimplificada.des_log_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.num_simp))
//                msg.numeroEndereco = registroPessoaSimplificada.num_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.cpl_end_simp))
//                msg.complementoLogradouro = registroPessoaSimplificada.cpl_end_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.bai_end_simp))
//                msg.nomeBairro = registroPessoaSimplificada.bai_end_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.tip_end_simp))
//                msg.tipoEndereco = registroPessoaSimplificada.tip_end_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.uf_end_simp))
//                msg.uf = registroPessoaSimplificada.uf_end_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.pais_simp))
//                msg.pais = registroPessoaSimplificada.pais_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.cep_simp))
//                msg.numeroCep = registroPessoaSimplificada.cep_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.est_civ_simp))
//                msg.estadoCivil = registroPessoaSimplificada.est_civ_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.reg_com_simp))
//                msg.regimeComunhao = registroPessoaSimplificada.reg_com_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.nom_conj_simp))
//                msg.nomeConjugue = registroPessoaSimplificada.nom_conj_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.idc_ava_simp))
//                msg.indicadorAvalista = registroPessoaSimplificada.idc_ava_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.cpf_cnpj_simp))
//                msg.CpfCnpjSimplificado = registroPessoaSimplificada.cpf_cnpj_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.tip_pes_simp))
//                msg.tipoPessoa = registroPessoaSimplificada.tip_pes_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.idc_isen_cpf_cnpf_simp))
//                msg.identificadorIsentoCpf = registroPessoaSimplificada.idc_isen_cpf_cnpf_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.pescodsisorigem))
//                msg.codigoSistemaOrigem = registroPessoaSimplificada.pescodsisorigem;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.pescpfconj))
//                msg.CpfConjugue = registroPessoaSimplificada.pescpfconj;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.idc_fatca))
//                msg.indicadorClienteFatca = registroPessoaSimplificada.idc_fatca;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.rg_simp))
//                msg.numeroRg = registroPessoaSimplificada.rg_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.nif_simp))
//                msg.numeroIdentificadorFiscal = registroPessoaSimplificada.nif_simp;

//            if (registroPessoaSimplificada.nac1_simp != null && registroPessoaSimplificada.nac1_simp.Value > 0)
//                msg.codigoNacionalidade1 = registroPessoaSimplificada.nac1_simp;

//            if (registroPessoaSimplificada.nac2_simp != null && registroPessoaSimplificada.nac2_simp.Value > 0)
//                msg.codigoNacionalidade2 = registroPessoaSimplificada.nac2_simp;

//            if (registroPessoaSimplificada.nac3_simp != null && registroPessoaSimplificada.nac3_simp.Value > 0)
//                msg.codigoNacionalidade3 = registroPessoaSimplificada.nac3_simp;

//            if (registroPessoaSimplificada.nac4_simp != null && registroPessoaSimplificada.nac4_simp.Value > 0)
//                msg.codigoNacionalidade4 = registroPessoaSimplificada.nac4_simp;

//            if (registroPessoaSimplificada.dom_fis1_simp != null && registroPessoaSimplificada.dom_fis1_simp.Value > 0)
//                msg.codigoDomicilioFiscal1 = registroPessoaSimplificada.dom_fis1_simp;

//            if (registroPessoaSimplificada.dom_fis2_simp != null && registroPessoaSimplificada.dom_fis2_simp.Value > 0)
//                msg.codigoDomicilioFiscal2 = registroPessoaSimplificada.dom_fis2_simp;

//            if (registroPessoaSimplificada.dom_fis3_simp != null && registroPessoaSimplificada.dom_fis3_simp.Value > 0)
//                msg.codigoDomicilioFiscal3 = registroPessoaSimplificada.dom_fis3_simp;

//            if (registroPessoaSimplificada.dom_fis4_simp != null && registroPessoaSimplificada.dom_fis4_simp.Value > 0)
//                msg.codigoDomicilioFiscal4 = registroPessoaSimplificada.dom_fis4_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.ddd_cel_simp))
//                msg.codigoDddCelular = registroPessoaSimplificada.ddd_cel_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.fone_cel_simp))
//                msg.numeroCelular = registroPessoaSimplificada.fone_cel_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.email))
//                msg.email = registroPessoaSimplificada.email;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.idc_cli_est))
//                msg.indicadorClienteEstrangeiro = registroPessoaSimplificada.idc_cli_est;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.tip_doc_est))
//                msg.tipoDocumentoEstrangeiro = registroPessoaSimplificada.tip_doc_est;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.num_doc_est))
//                msg.numeroDocumentoEstrangeiro = registroPessoaSimplificada.num_doc_est;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.nom_social_simp))
//                msg.nomeSocial = registroPessoaSimplificada.nom_social_simp;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.pld_pes))
//                msg.nivelRiscoPld = registroPessoaSimplificada.pld_pes;

//            if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.obs_pld))
//                msg.observacaoPld = registroPessoaSimplificada.obs_pld;

//            //if (!string.IsNullOrWhiteSpace(registroPessoaSimplificada.cod_cbo))
//             //   msg.CodigoAtividadeCbo = registroPessoaSimplificada.cod_cbo;

//            //if (registroPessoaSimplificada.COD_ATIVIDADE != null && registroPessoaSimplificada.COD_ATIVIDADE.Value > 0)
//            //    msg.CodigoAtividade = registroPessoaSimplificada.COD_ATIVIDADE;

//            return msg;
//        }
//    }
//}