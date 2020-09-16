using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorPessoa
    {
        private AdaptadorEndereco _AdaptadorEndereco;
        public AdaptadorEndereco AdaptadorEndereco
        {
            get
            {
                if (_AdaptadorEndereco == null) _AdaptadorEndereco = new AdaptadorEndereco();
                return _AdaptadorEndereco;
            }
        }

        private AdaptadorDocumento _AdaptadorDocumento;
        public AdaptadorDocumento AdaptadorDocumento
        {
            get
            {
                if (_AdaptadorDocumento == null) _AdaptadorDocumento = new AdaptadorDocumento();
                return _AdaptadorDocumento;
            }
        }

        private AdaptadorPerfil _AdaptadorPerfil;
        public AdaptadorPerfil AdaptadorPerfil
        {
            get
            {
                if (_AdaptadorPerfil == null) _AdaptadorPerfil = new AdaptadorPerfil();
                return _AdaptadorPerfil;
            }
        }

        private AdaptadorReferencia _AdaptadorReferencia;
        public AdaptadorReferencia AdaptadorReferencia
        {
            get
            {
                if (_AdaptadorReferencia == null) _AdaptadorReferencia = new AdaptadorReferencia();
                return _AdaptadorReferencia;
            }
        }

        public MsgRetorno AdaptarMsgRetorno(MsgPessoa msgPessoa, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgPessoa != null && msgPessoa.header != null)
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

        public MsgRetorno AdaptarMsgRetorno(MsgPessoaCompleto msgPessoa, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgPessoa != null && msgPessoa.header != null)
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

        public MsgRetornoGet AdaptarMsgRetornoGet(object msg, IList<string> erros) 
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

            if (erros.Any())
            {
                header.erros = erros.ToArray();
            }

            if (!erros.Any() && msg != null)
                retorno.body = msg;

            return retorno;
        }

        public DataSetPessoa AdaptarMsgPessoaCompletoToDataSetPessoa(MsgPessoaCompleto msg, string statusLinha, IList<string> erros)
        {
            MsgRegistropessoaCompleto registroPessoa = msg.body.RegistroPessoa;

            DataSetPessoa xml = new DataSetPessoa();

            xml.RegistroPessoa = new DataSetPessoaRegistroPessoa[] {
                AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(registroPessoa, statusLinha, erros)
            };

            if(registroPessoa.RegistroEndereco != null && registroPessoa.RegistroEndereco.Any())
                xml.RegistroEndereco = AdaptadorEndereco.AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(registroPessoa.RegistroEndereco, statusLinha, erros);

            if (registroPessoa.RegistroDocumento != null && registroPessoa.RegistroDocumento.Any())
                xml.RegistroDocumento = AdaptadorDocumento.AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(registroPessoa.RegistroDocumento, statusLinha, erros);

            if (registroPessoa.RegistroPerfil != null && registroPessoa.RegistroPerfil.Any())
                xml.RegistroPerfil = AdaptadorPerfil.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(registroPessoa.RegistroPerfil, statusLinha, erros);

            if (registroPessoa.RegistroReferencia != null && registroPessoa.RegistroReferencia.Any())
                xml.RegistroReferencia = AdaptadorReferencia.AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(registroPessoa.RegistroReferencia, statusLinha, erros);

            return xml;
        }

        public DataSetPessoaRegistroPessoa[] AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(MsgRegistropessoa[] msg, string statusLinha, IList<string> erros)
        {
            List<DataSetPessoaRegistroPessoa> registroPessoas = new List<DataSetPessoaRegistroPessoa>();
            foreach (var pessoa in msg)
            {
                registroPessoas.Add(AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(pessoa, statusLinha, erros));
            }

            return registroPessoas.ToArray();
        }

        public DataSetPessoaRegistroPessoa AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(MsgRegistropessoa msg, string statusLinha, IList<string> erros)
        {
            DataSetPessoaRegistroPessoa registroPessoa = new DataSetPessoaRegistroPessoa();

            registroPessoa.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroPessoa.cod_pessoa = msg.codigoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.nomePessoa))
                registroPessoa.nom_pessoa = msg.nomePessoa;

            if (!string.IsNullOrWhiteSpace(msg.nomeAbvPessoa))
                registroPessoa.nom_abv_pessoa = msg.nomeAbvPessoa;

            if (!string.IsNullOrWhiteSpace(msg.setorAtividade))
                registroPessoa.set_pessoa = msg.setorAtividade;

            if (!string.IsNullOrWhiteSpace(msg.descricaoProfissao))
                registroPessoa.des_profissao = msg.descricaoProfissao;

            if (!string.IsNullOrWhiteSpace(msg.estadoCivil))
                registroPessoa.est_civil = msg.estadoCivil;

            if (!string.IsNullOrWhiteSpace(msg.regimeComunhao))
                registroPessoa.com_bens = msg.regimeComunhao;

            if (!string.IsNullOrWhiteSpace(msg.sexoPessoa))
                registroPessoa.sex_pessoa = msg.sexoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.grauInstrucao))
                registroPessoa.gra_instrucao = msg.grauInstrucao;

            if (!string.IsNullOrWhiteSpace(msg.nomePai))
                registroPessoa.fil_paterna = msg.nomePai;

            if (!string.IsNullOrWhiteSpace(msg.nomeMae))
                registroPessoa.fil_materna = msg.nomeMae;

            if (msg.qtdeDependentes != null && msg.qtdeDependentes.Value > 0)
                registroPessoa.num_dep = msg.qtdeDependentes.Value;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroPessoa.dat_cad = msg.dataCadastro.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioAtualizacao))
                registroPessoa.usu_atu = msg.usuarioAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroPessoa.dat_atu = msg.dataAtualizacao.Value;

            if (msg.dataFundacao != null && msg.dataFundacao.Value != DateTime.MinValue)
                registroPessoa.dat_fundacao = msg.dataFundacao.Value;

            if (msg.codigoAtividade != null && msg.codigoAtividade.Value > 0)
                registroPessoa.cod_atividade = msg.codigoAtividade.Value;

            if (msg.codigoGrupoEmpresarial != null && msg.codigoGrupoEmpresarial.Value > 0)
                registroPessoa.cod_grpemp = msg.codigoGrupoEmpresarial.Value;

            if (msg.codigoMunicipio != null && msg.codigoMunicipio.Value > 0)
                registroPessoa.cod_municipio = msg.codigoMunicipio.Value;

            if (!string.IsNullOrWhiteSpace(msg.descricaoMunicipio))
                registroPessoa.des_municipio = msg.descricaoMunicipio;

            if (!string.IsNullOrWhiteSpace(msg.descricaoNacionalidade))
                registroPessoa.des_nacionalidade = msg.descricaoNacionalidade;

            if (msg.dataNaturalizacao != null && msg.dataNaturalizacao.Value != DateTime.MinValue)
                registroPessoa.dat_naturalizacao = msg.dataNaturalizacao.Value;

            if (!string.IsNullOrWhiteSpace(msg.codigoCbo))
                registroPessoa.cod_cbo = msg.codigoCbo;

            if (msg.codigoSetor != null && msg.codigoSetor.Value > 0)
                registroPessoa.cod_setor = msg.codigoSetor.Value;

            if (msg.codigoSubsetor != null && msg.codigoSubsetor.Value > 0)
                registroPessoa.cod_subsetor = msg.codigoSubsetor.Value;

            if (msg.codigoRamo != null && msg.codigoRamo.Value > 0)
                registroPessoa.cod_ramo = msg.codigoRamo.Value;

            if (msg.codigoRamoAtiv != null && msg.codigoRamoAtiv.Value > 0)
                registroPessoa.cod_ramo_ativ = msg.codigoRamoAtiv.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorConstituicao))
                registroPessoa.idc_constituicao = msg.indicadorConstituicao;

            if (!string.IsNullOrWhiteSpace(msg.nivelRisco))
                registroPessoa.niv_risco = msg.nivelRisco;

            if (!string.IsNullOrWhiteSpace(msg.indicadorfuncionario))
                registroPessoa.idc_func = msg.indicadorfuncionario;

            if (!string.IsNullOrWhiteSpace(msg.codigoSegmento))
                registroPessoa.cod_segmento = msg.codigoSegmento;

            if (!string.IsNullOrWhiteSpace(msg.codigoSubsegmento))
                registroPessoa.cod_subsegmento = msg.codigoSubsegmento;

            if (!string.IsNullOrWhiteSpace(msg.codigoClasse))
                registroPessoa.cod_classe = msg.codigoClasse;

            if (msg.dataRenovacao != null && msg.dataRenovacao.Value != DateTime.MinValue)
                registroPessoa.dat_ren_cad = msg.dataRenovacao.Value;

            if (msg.dataVencimento != null && msg.dataVencimento.Value != DateTime.MinValue)
                registroPessoa.dat_ven_cad = msg.dataVencimento.Value;

            if (msg.codigoTipo != null && msg.codigoTipo.Value > 0)
                registroPessoa.cod_tip = msg.codigoTipo.Value;

            if (msg.codigoclassificacaoLegal != null && msg.codigoclassificacaoLegal.Value > 0)
                registroPessoa.cod_leg = msg.codigoclassificacaoLegal.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorEstrangeiro))
                registroPessoa.idc_estrang = msg.indicadorEstrangeiro;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddContato))
                registroPessoa.Ddd_contato = msg.codigoDddContato;

            if (!string.IsNullOrWhiteSpace(msg.telefoneContato))
                registroPessoa.tel_contato = msg.telefoneContato;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamalContato))
                registroPessoa.ramal_contato = msg.numeroRamalContato;

            if (!string.IsNullOrWhiteSpace(msg.indicadorConsRisco))
                registroPessoa.idc_cons_risco = msg.indicadorConsRisco;

            if (!string.IsNullOrWhiteSpace(msg.codigoCvm))
                registroPessoa.cvmcod = msg.codigoCvm;

            if (!string.IsNullOrWhiteSpace(msg.codigoAnbid))
                registroPessoa.anbcod = msg.codigoAnbid;

            if (!string.IsNullOrWhiteSpace(msg.tipoPessoa))
                registroPessoa.tip_pes = msg.tipoPessoa;

            if (msg.codigoNacionalidade != null && msg.codigoNacionalidade.Value > 0)
                registroPessoa.naccod = msg.codigoNacionalidade.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacaoCadastral))
                registroPessoa.pessta = msg.indicadorSituacaoCadastral;

            if (!string.IsNullOrWhiteSpace(msg.indicadorImpedidoOperar))
                registroPessoa.pesidcimpedido = msg.indicadorImpedidoOperar;

            if (!string.IsNullOrWhiteSpace(msg.indicadorCnpjCpfVerificado))
                registroPessoa.pesidcpro = msg.indicadorCnpjCpfVerificado;

            if (msg.dataConsulta != null && msg.dataConsulta.Value != DateTime.MinValue)
                registroPessoa.pesdatsta = msg.dataConsulta.Value;

            if (msg.numeroProcuracao != null && msg.numeroProcuracao.Value > 0)
                registroPessoa.rcfcodpro = msg.numeroProcuracao.Value;

            if (!string.IsNullOrWhiteSpace(msg.nomeDivergente))
                registroPessoa.pesstanom = msg.nomeDivergente;

            if (!string.IsNullOrWhiteSpace(msg.usuarioCadastro))
                registroPessoa.pesidcusucad = msg.usuarioCadastro;

            if (msg.codigoPisPasep != null && msg.codigoPisPasep.Value > 0)
                registroPessoa.pescodPisPasep = msg.codigoPisPasep.Value;

            if (msg.valorTotalBens != null && msg.valorTotalBens.Value > 0)
                registroPessoa.pestotvlrben = msg.valorTotalBens.Value;

            if (msg.valorRendaMensal != null && msg.valorRendaMensal.Value > 0)
                registroPessoa.pesvalmedmen = msg.valorRendaMensal.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorPosuiRenda))
                registroPessoa.pesidcposren = msg.indicadorPosuiRenda;

            if (!string.IsNullOrWhiteSpace(msg.pessoaLigada))
                registroPessoa.pesidtlig = msg.pessoaLigada;

            if (!string.IsNullOrWhiteSpace(msg.indicadorCobrancaIOf))
                registroPessoa.pesidciof = msg.indicadorCobrancaIOf;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilial))
                registroPessoa.cod_fil = msg.codigoFilial;

            if (!string.IsNullOrWhiteSpace(msg.codigoCpfCnpjBase))
                registroPessoa.bas_cgcCpf = msg.codigoCpfCnpjBase;

            if (!string.IsNullOrWhiteSpace(msg.codigoCpfCnpjFilial))
                registroPessoa.fil_cgcCpf = msg.codigoCpfCnpjFilial;

            if (!string.IsNullOrWhiteSpace(msg.codigoCpfCnpjDigito))
                registroPessoa.dig_cgcCpf = msg.codigoCpfCnpjDigito;

            if (!string.IsNullOrWhiteSpace(msg.tipoPessoaFilial))
                registroPessoa.tip_fil = msg.tipoPessoaFilial;

            if (!string.IsNullOrWhiteSpace(msg.indicadorIsencaoCpf))
                registroPessoa.idc_isen_cgccpf = msg.indicadorIsencaoCpf;

            if (!string.IsNullOrWhiteSpace(msg.CpfTitular))
                registroPessoa.til_Cpf = msg.CpfTitular;

            if (!string.IsNullOrWhiteSpace(msg.inscricaoEstadualTitular))
                registroPessoa.ins_est = msg.inscricaoEstadualTitular;

            if (!string.IsNullOrWhiteSpace(msg.inscricaoMunicipalTitular))
                registroPessoa.ins_mun = msg.inscricaoMunicipalTitular;

            if (!string.IsNullOrWhiteSpace(msg.indicadorDependente))
                registroPessoa.idc_dep = msg.indicadorDependente;

            if (!string.IsNullOrWhiteSpace(msg.indicadorFornecedor))
                registroPessoa.idc_for = msg.indicadorFornecedor;

            if (!string.IsNullOrWhiteSpace(msg.indicadorCliente))
                registroPessoa.idc_cli = msg.indicadorCliente;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacaoFilial))
                registroPessoa.idc_sit_fil = msg.indicadorSituacaoFilial;

            if (msg.dataCadastro1 != null && msg.dataCadastro1.Value != DateTime.MinValue)
                registroPessoa.dat_cad1 = msg.dataCadastro1.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioAtualizacao1))
                registroPessoa.usu_atu1 = msg.usuarioAtualizacao1;

            if (msg.dataAtualizacao1 != null && msg.dataAtualizacao1.Value != DateTime.MinValue)
                registroPessoa.dat_atu1 = msg.dataAtualizacao1.Value;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroPessoa.dat_sit = msg.dataSituacao.Value;

            if (msg.codigoEmpresa != null && msg.codigoEmpresa.Value > 0)
                registroPessoa.cod_empresa = msg.codigoEmpresa.Value;

            if (msg.codigoDependente != null && msg.codigoDependente.Value > 0)
                registroPessoa.cod_depend = msg.codigoDependente.Value;

            if (msg.codigoOperador != null && msg.codigoOperador.Value > 0)
                registroPessoa.cod_oper = msg.codigoOperador.Value;

            if (msg.dataInicialGerente != null && msg.dataInicialGerente.Value != DateTime.MinValue)
                registroPessoa.dat_ini_gerente = msg.dataInicialGerente.Value;

            if (msg.codigoCliente != null && msg.codigoCliente.Value > 0)
                registroPessoa.cli_cod = msg.codigoCliente.Value;

            if (msg.codigoPorte != null && msg.codigoPorte.Value > 0)
                registroPessoa.cod_porte = msg.codigoPorte.Value;

            if (msg.qtdAssinaturas != null && msg.qtdAssinaturas.Value > 0)
                registroPessoa.qtd_assinatura = msg.qtdAssinaturas.Value;

            if (!string.IsNullOrWhiteSpace(msg.enderecoHomePage))
                registroPessoa.end_home_page = msg.enderecoHomePage;

            if (!string.IsNullOrWhiteSpace(msg.email1))
                registroPessoa.eml_fil_1 = msg.email1;

            if (!string.IsNullOrWhiteSpace(msg.email2))
                registroPessoa.eml_fil_2 = msg.email2;

            if (!string.IsNullOrWhiteSpace(msg.email3))
                registroPessoa.eml_fil_3 = msg.email3;

            if (!string.IsNullOrWhiteSpace(msg.email4))
                registroPessoa.eml_fil_4 = msg.email4;

            if (!string.IsNullOrWhiteSpace(msg.email5))
                registroPessoa.eml_fil_5 = msg.email5;

            if (!string.IsNullOrWhiteSpace(msg.indicadorIsencaoIr))
                registroPessoa.idc_isen_ir = msg.indicadorIsencaoIr;

            if (msg.codigoEmpresaIndic != null && msg.codigoEmpresaIndic.Value > 0)
                registroPessoa.cod_empresa_indic = msg.codigoEmpresaIndic.Value;

            if (msg.codigoOperIndic != null && msg.codigoOperIndic.Value > 0)
                registroPessoa.cod_oper_indic = msg.codigoOperIndic.Value;

            if (!string.IsNullOrWhiteSpace(msg.codigoSistemaOrigem))
                registroPessoa.cod_sist_origem = msg.codigoSistemaOrigem;

            if (!string.IsNullOrWhiteSpace(msg.obs))
                registroPessoa.observ = msg.obs;

            if (!string.IsNullOrWhiteSpace(msg.codigoIspb))
                registroPessoa.cod_ispb = msg.codigoIspb;

            if (msg.sequencialCnpjDuplicado != null && msg.sequencialCnpjDuplicado.Value > 0)
                registroPessoa.seq_Cnpj = msg.sequencialCnpjDuplicado.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorCorrespAgencia))
                registroPessoa.idc_corresp_age = msg.indicadorCorrespAgencia;

            if (msg.dataInicioSfn != null && msg.dataInicioSfn.Value != DateTime.MinValue)
                registroPessoa.fildatsfn = msg.dataInicioSfn.Value;

            //if (!string.IsNullOrWhiteSpace(msg.CpfConjugue))
            //    registroPessoa.Cpf_conjuge = msg.CpfConjugue;

            //if (!string.IsNullOrWhiteSpace(msg.nomeConjugue))
            //    registroPessoa.nome_conjuge = msg.nomeConjugue;

            if (!string.IsNullOrWhiteSpace(msg.indicadorNaoResidente))
                registroPessoa.FILIDTNAORESIDE = msg.indicadorNaoResidente;

            if (!string.IsNullOrWhiteSpace(msg.indicadorRes2686))
                registroPessoa.FILIDTRES2686 = msg.indicadorRes2686;

            if (msg.codigoNovaNacionalidade != null && msg.codigoNovaNacionalidade.Value > 0)
                registroPessoa.FILCODNOVONAC = msg.codigoNovaNacionalidade.Value;

            if (msg.dataSaidaPais != null && msg.dataSaidaPais.Value != DateTime.MinValue)
                registroPessoa.FILDATSAIDAPAIS = msg.dataSaidaPais.Value;

            //if (msg.  != null && msg.codigoNatureza.Value > 0)
            //    registroPessoa.natcod = msg.codigoNatureza;

            if (msg.tipoImunidade != null && msg.tipoImunidade.Value > 0)
                registroPessoa.tip_imunidade = msg.tipoImunidade.Value;

            if (msg.dataRegistroRbf != null && msg.dataRegistroRbf.Value != DateTime.MinValue)
                registroPessoa.dat_reg_rbf = msg.dataRegistroRbf.Value;

            if (!string.IsNullOrWhiteSpace(msg.numeroProcesso))
                registroPessoa.num_processo = msg.numeroProcesso;

            if (!string.IsNullOrWhiteSpace(msg.numeroVara))
                registroPessoa.num_vara = msg.numeroVara;

            if (msg.dataInicio != null && msg.dataInicio.Value != DateTime.MinValue)
                registroPessoa.dat_inicio = msg.dataInicio.Value;

            if (msg.dataFim != null && msg.dataFim.Value != DateTime.MinValue)
                registroPessoa.dat_fim = msg.dataFim.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacaoRegistro))
                registroPessoa.STA_REGISTRO = msg.indicadorSituacaoRegistro;

            if (msg.codigoCnae2 != null && msg.codigoCnae2.Value > 0)
                registroPessoa.cnaseq = msg.codigoCnae2.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorClienteFatca))
                registroPessoa.pesidcFatca = msg.indicadorClienteFatca;

            if (msg.codigoNacionalidade1 != null && msg.codigoNacionalidade1.Value > 0)
                registroPessoa.PESNACIONALIDADE1 = msg.codigoNacionalidade1.Value;

            if (msg.codigoNacionalidade2 != null && msg.codigoNacionalidade2.Value > 0)
                registroPessoa.PESNACIONALIDADE2 = msg.codigoNacionalidade2.Value;

            if (msg.codigoNacionalidade3 != null && msg.codigoNacionalidade3.Value > 0)
                registroPessoa.PESNACIONALIDADE3 = msg.codigoNacionalidade3.Value;

            if (msg.codigoNacionalidade4 != null && msg.codigoNacionalidade4.Value > 0)
                registroPessoa.PESNACIONALIDADE4 = msg.codigoNacionalidade4.Value;

            if (msg.codigoDomicilio1 != null && msg.codigoDomicilio1.Value > 0)
                registroPessoa.PESDOMICILIO1 = msg.codigoDomicilio1.Value;

            if (msg.codigoDomicilio2 != null && msg.codigoDomicilio2.Value > 0)
                registroPessoa.PESDOMICILIO2 = msg.codigoDomicilio2.Value;

            if (msg.codigoDomicilio3 != null && msg.codigoDomicilio3.Value > 0)
                registroPessoa.PESDOMICILIO3 = msg.codigoDomicilio3.Value;

            if (msg.codigoDomicilio4 != null && msg.codigoDomicilio4.Value > 0)
                registroPessoa.PESDOMICILIO4 = msg.codigoDomicilio4.Value;

            if (msg.sUnid != null && msg.sUnid.Value > 0)
                registroPessoa.SUNID = msg.sUnid.Value;

            if (!string.IsNullOrWhiteSpace(msg.apelido1))
                registroPessoa.APELIDO1 = msg.apelido1;

            if (!string.IsNullOrWhiteSpace(msg.apelido2))
                registroPessoa.APELIDO2 = msg.apelido2;

            if (!string.IsNullOrWhiteSpace(msg.apelido3))
                registroPessoa.APELIDO3 = msg.apelido3;

            if (!string.IsNullOrWhiteSpace(msg.indicadorOptanteSimples))
                registroPessoa.IDC_SIMP = msg.indicadorOptanteSimples;

            if (!string.IsNullOrWhiteSpace(msg.CpfFormatado))
                registroPessoa.CGCCpf_FORMATADO = msg.CpfFormatado;

            if (!string.IsNullOrWhiteSpace(msg.situacaoBeneficiario))
                registroPessoa.SIT_BEN = msg.situacaoBeneficiario;

            if (!string.IsNullOrWhiteSpace(msg.indicadorOperaContaPropria))
                registroPessoa.idc_ope_pro = msg.indicadorOperaContaPropria;

            if (!string.IsNullOrWhiteSpace(msg.indicadorTransmissaoProcurador))
                registroPessoa.idc_aut_tra = msg.indicadorTransmissaoProcurador;

            if (!string.IsNullOrWhiteSpace(msg.tipoDeclarado))
                registroPessoa.pestipdec = msg.tipoDeclarado;

            //if (!string.IsNullOrWhiteSpace(msg.indicadorClienteEstrangeiro))
            //   registroPessoa.idc_cli_est = msg.indicadorClienteEstrangeiro;

            //if (!string.IsNullOrWhiteSpace(msg.tipoDocumentoEstrangeiro))
            //    registroPessoa.tip_doc_est = msg.tipoDocumentoEstrangeiro;

            //if (!string.IsNullOrWhiteSpace(msg.numeroDocumentoEstrangeiro))
            //    registroPessoa.num_doc_est = msg.numeroDocumentoEstrangeiro;

            if (msg.codigoJustificativa != null && msg.codigoJustificativa.Value > 0)
                registroPessoa.juscod = msg.codigoJustificativa.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorAtivo))
                registroPessoa.pesidcativoprob = msg.indicadorAtivo;

            if (!string.IsNullOrWhiteSpace(msg.pesjustificativa))
                registroPessoa.pesjustificativa = msg.pesjustificativa;

            //if (!string.IsNullOrWhiteSpace(msg.cpfCnpj))
            //    registroPessoa.Cpf_Cnpj = msg.cpfCnpj;

            if (!string.IsNullOrWhiteSpace(msg.nomeContato))
                registroPessoa.pesnomcontato = msg.nomeContato;

            if (msg.codigoCargo != null && msg.codigoCargo.Value > 0)
                registroPessoa.pescodcargo = msg.codigoCargo.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorDeclaracaoFatca1))
                registroPessoa.pesidcdeclarFatca1 = msg.indicadorDeclaracaoFatca1;

            if (!string.IsNullOrWhiteSpace(msg.indicadorDeclaracaoFatca2))
                registroPessoa.pesidcdeclarFatca2 = msg.indicadorDeclaracaoFatca2;

            if (!string.IsNullOrWhiteSpace(msg.indicadorDomicilioExterno))
                registroPessoa.pesidcdomicilioext = msg.indicadorDomicilioExterno;

            if (msg.numeroFuncionarios != null && msg.numeroFuncionarios.Value > 0)
                registroPessoa.pesnumfuncionarios = msg.numeroFuncionarios.Value;

            if (msg.codigoNacCapital != null && msg.codigoNacCapital.Value > 0)
                registroPessoa.pescodnaccapital = msg.codigoNacCapital.Value;

            if (msg.valorCapitalEstrangeiro != null && msg.valorCapitalEstrangeiro.Value > 0)
                registroPessoa.pesvalcapitalestr = msg.valorCapitalEstrangeiro.Value;

            if (msg.valorCapitalNacional != null && msg.valorCapitalNacional.Value > 0)
                registroPessoa.pesvalcapitalnac = msg.valorCapitalNacional.Value;

            if (!string.IsNullOrWhiteSpace(msg.tipoCapital))
                registroPessoa.pestipcapital = msg.tipoCapital;

            if (msg.codigoClasseEconomicaCetip != null && msg.codigoClasseEconomicaCetip.Value > 0)
                registroPessoa.pescodatvcetip = msg.codigoClasseEconomicaCetip.Value;

            if (!string.IsNullOrWhiteSpace(msg.codigoIdentificadorRacial))
                registroPessoa.circod = msg.codigoIdentificadorRacial;

           if (!string.IsNullOrWhiteSpace(msg.codigoDdi))
                registroPessoa.pescoDDdi = msg.codigoDdi;

           if (!string.IsNullOrWhiteSpace(msg.nomeSocialPessoa))
                registroPessoa.nom_social_pessoa = msg.nomeSocialPessoa;

           if (!string.IsNullOrWhiteSpace(msg.indicadorIsencaoInscricaoEstadual))
                registroPessoa.idc_isen_insc_estadual = msg.indicadorIsencaoInscricaoEstadual;

            if (!string.IsNullOrWhiteSpace(msg.codigoSubgrupoEmpresarial))
                registroPessoa.sgecod = msg.codigoSubgrupoEmpresarial;

            if (!string.IsNullOrWhiteSpace(msg.nivelRiscoPld))
                registroPessoa.Pld_pes = msg.nivelRiscoPld;

            if (!string.IsNullOrWhiteSpace(msg.observacaoPld))
                registroPessoa.obs_Pld = msg.observacaoPld;

            if (msg.codigoGerente != null && msg.codigoGerente.Value > 0)
                registroPessoa.cod_oper_ger = msg.codigoGerente.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorCobrancaIofAdicional))
                registroPessoa.pesidciofadic = msg.indicadorCobrancaIofAdicional;

            if (msg.codigoCestroResultado != null && msg.codigoCestroResultado.Value > 0)
                registroPessoa.fil_rescod = msg.codigoCestroResultado.Value;

            if (!string.IsNullOrWhiteSpace(msg.cpfCnpjFormatado))
                registroPessoa.cgccpf_formatado = msg.cpfCnpjFormatado;

            return registroPessoa;
        }


        public MsgRegistropessoaCompleto AdaptaDataSetPessoaToMsgPessoaCompleto(DataSetPessoa dataset, IList<string> erros)
        {
            MsgRegistropessoaCompleto msg = new MsgRegistropessoaCompleto();

            if(dataset.RegistroPessoa != null && dataset.RegistroPessoa.Any())
                msg = AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoaCompleto(dataset.RegistroPessoa.First(), erros);

            if (dataset.RegistroDocumento != null && dataset.RegistroDocumento.Any())
                msg.RegistroDocumento = AdaptadorDocumento.AdaptarDataSetPessoaRegistroDocumentoToMsgRegistrodocumento(dataset.RegistroDocumento, erros);

            if(dataset.RegistroEndereco != null && dataset.RegistroEndereco.Any())
                msg.RegistroEndereco = AdaptadorEndereco.AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoa(dataset.RegistroEndereco, erros);

            if(dataset.RegistroPerfil != null && dataset.RegistroPerfil.Any())
                msg.RegistroPerfil = AdaptadorPerfil.AdaptarDataSetPessoaRegistroPerfilToMsgRegistroperfil(dataset.RegistroPerfil, erros);

            if(dataset.RegistroReferencia != null && dataset.RegistroReferencia.Any())
                msg.RegistroReferencia = AdaptadorReferencia.AdaptarDataSetPessoaRegistroReferenciaToMsgRegistroreferencia(dataset.RegistroReferencia, erros);

            return msg;
        }

        public MsgRegistropessoa[] AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoa(DataSetPessoaRegistroPessoa[] dataset, IList<string> erros)
        {
            List<MsgRegistropessoa> registros = new List<MsgRegistropessoa>();
            if(dataset != null)
            {
                foreach (var item in dataset)
                {
                    registros.Add(AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoaCompleto(item, erros));
                }
            }          

            return registros.ToArray();
        }

        public MsgRegistropessoaCompleto[] AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoaCompleto(DataSetPessoaRegistroPessoa[] dataset, IList<string> erros)
        {
            List<MsgRegistropessoaCompleto> registros = new List<MsgRegistropessoaCompleto>();

            if (dataset != null)
            {
                foreach (var item in dataset)
                {
                    registros.Add(AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoaCompleto(item, erros));
                }
            }            

            return registros.ToArray();
        }

        public MsgRegistropessoaCompleto AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoaCompleto(DataSetPessoaRegistroPessoa registroPessoa, IList<string> erros)
        {
            MsgRegistropessoaCompleto msg = new MsgRegistropessoaCompleto();


            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_pessoa))
                msg.codigoPessoa = registroPessoa.cod_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPessoa.nom_pessoa))
                msg.nomePessoa = registroPessoa.nom_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPessoa.nom_abv_pessoa))
                msg.nomeAbvPessoa = registroPessoa.nom_abv_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPessoa.set_pessoa))
                msg.setorAtividade = registroPessoa.set_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPessoa.des_profissao))
                msg.descricaoProfissao = registroPessoa.des_profissao;

            if (!string.IsNullOrWhiteSpace(registroPessoa.est_civil))
                msg.estadoCivil = registroPessoa.est_civil;

            if (!string.IsNullOrWhiteSpace(registroPessoa.com_bens))
                msg.regimeComunhao = registroPessoa.com_bens;

            if (!string.IsNullOrWhiteSpace(registroPessoa.sex_pessoa))
                msg.sexoPessoa = registroPessoa.sex_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPessoa.gra_instrucao))
                msg.grauInstrucao = registroPessoa.gra_instrucao;

            if (!string.IsNullOrWhiteSpace(registroPessoa.fil_paterna))
                msg.nomePai = registroPessoa.fil_paterna;

            if (!string.IsNullOrWhiteSpace(registroPessoa.fil_materna))
                msg.nomeMae = registroPessoa.fil_materna;

            if (registroPessoa.num_dep != null && registroPessoa.num_dep.Value > 0)
                msg.qtdeDependentes = registroPessoa.num_dep;

            if (registroPessoa.dat_cad != null && registroPessoa.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = registroPessoa.dat_cad;

            if (!string.IsNullOrWhiteSpace(registroPessoa.usu_atu))
                msg.usuarioAtualizacao = registroPessoa.usu_atu;

            if (registroPessoa.dat_atu != null && registroPessoa.dat_atu.Value != DateTime.MinValue)
                msg.dataAtualizacao = registroPessoa.dat_atu;

            if (registroPessoa.dat_fundacao != null && registroPessoa.dat_fundacao.Value != DateTime.MinValue)
                msg.dataFundacao = registroPessoa.dat_fundacao;

            if (registroPessoa.cod_atividade != null && registroPessoa.cod_atividade.Value > 0)
                msg.codigoAtividade = registroPessoa.cod_atividade;

            if (registroPessoa.cod_grpemp != null && registroPessoa.cod_grpemp.Value > 0)
                msg.codigoGrupoEmpresarial = registroPessoa.cod_grpemp;

            if (registroPessoa.cod_municipio != null && registroPessoa.cod_municipio.Value > 0)
                msg.codigoMunicipio = registroPessoa.cod_municipio;

            if (!string.IsNullOrWhiteSpace(registroPessoa.des_municipio))
                msg.descricaoMunicipio = registroPessoa.des_municipio;

            if (!string.IsNullOrWhiteSpace(registroPessoa.des_nacionalidade))
                msg.descricaoNacionalidade = registroPessoa.des_nacionalidade;

            if (registroPessoa.dat_naturalizacao != null && registroPessoa.dat_naturalizacao.Value != DateTime.MinValue)
                msg.dataNaturalizacao = registroPessoa.dat_naturalizacao;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_cbo))
                msg.codigoCbo = registroPessoa.cod_cbo;

            if (registroPessoa.cod_setor != null && registroPessoa.cod_setor.Value > 0)
                msg.codigoSetor = registroPessoa.cod_setor;

            if (registroPessoa.cod_subsetor != null && registroPessoa.cod_subsetor.Value > 0)
                msg.codigoSubsetor = registroPessoa.cod_subsetor;

            if (registroPessoa.cod_ramo != null && registroPessoa.cod_ramo.Value > 0)
                msg.codigoRamo = registroPessoa.cod_ramo;

            if (registroPessoa.cod_ramo_ativ != null && registroPessoa.cod_ramo_ativ.Value > 0)
                msg.codigoRamoAtiv = registroPessoa.cod_ramo_ativ;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_constituicao))
                msg.indicadorConstituicao = registroPessoa.idc_constituicao;

            if (!string.IsNullOrWhiteSpace(registroPessoa.niv_risco))
                msg.nivelRisco = registroPessoa.niv_risco;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_func))
                msg.indicadorfuncionario = registroPessoa.idc_func;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_segmento))
                msg.codigoSegmento = registroPessoa.cod_segmento;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_subsegmento))
                msg.codigoSubsegmento = registroPessoa.cod_subsegmento;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_classe))
                msg.codigoClasse = registroPessoa.cod_classe;

            if (registroPessoa.dat_ren_cad != null && registroPessoa.dat_ren_cad.Value != DateTime.MinValue)
                msg.dataRenovacao = registroPessoa.dat_ren_cad;

            if (registroPessoa.dat_ven_cad != null && registroPessoa.dat_ven_cad.Value != DateTime.MinValue)
                msg.dataVencimento = registroPessoa.dat_ven_cad;

            if (registroPessoa.cod_tip != null && registroPessoa.cod_tip.Value > 0)
                msg.codigoTipo = registroPessoa.cod_tip;

            if (registroPessoa.cod_leg != null && registroPessoa.cod_leg.Value > 0)
                msg.codigoclassificacaoLegal = registroPessoa.cod_leg;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_estrang))
                msg.indicadorEstrangeiro = registroPessoa.idc_estrang;

            if (!string.IsNullOrWhiteSpace(registroPessoa.Ddd_contato))
                msg.codigoDddContato = registroPessoa.Ddd_contato;

            if (!string.IsNullOrWhiteSpace(registroPessoa.tel_contato))
                msg.telefoneContato = registroPessoa.tel_contato;

            if (!string.IsNullOrWhiteSpace(registroPessoa.ramal_contato))
                msg.numeroRamalContato = registroPessoa.ramal_contato;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_cons_risco))
                msg.indicadorConsRisco = registroPessoa.idc_cons_risco;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cvmcod))
                msg.codigoCvm = registroPessoa.cvmcod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.anbcod))
                msg.codigoAnbid = registroPessoa.anbcod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.tip_pes))
                msg.tipoPessoa = registroPessoa.tip_pes;

            if (registroPessoa.naccod != null && registroPessoa.naccod.Value > 0)
                msg.codigoNacionalidade = registroPessoa.naccod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pessta))
                msg.indicadorSituacaoCadastral = registroPessoa.pessta;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcimpedido))
                msg.indicadorImpedidoOperar = registroPessoa.pesidcimpedido;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcpro))
                msg.indicadorCnpjCpfVerificado = registroPessoa.pesidcpro;

            if (registroPessoa.pesdatsta != null && registroPessoa.pesdatsta.Value != DateTime.MinValue)
                msg.dataConsulta = registroPessoa.pesdatsta;

            if (registroPessoa.rcfcodpro != null && registroPessoa.rcfcodpro.Value > 0)
                msg.numeroProcuracao = registroPessoa.rcfcodpro;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesstanom))
                msg.nomeDivergente = registroPessoa.pesstanom;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcusucad))
                msg.usuarioCadastro = registroPessoa.pesidcusucad;

            if (registroPessoa.pescodPisPasep != null && registroPessoa.pescodPisPasep.Value > 0)
                msg.codigoPisPasep = registroPessoa.pescodPisPasep;

            if (registroPessoa.pestotvlrben != null && registroPessoa.pestotvlrben.Value > 0)
                msg.valorTotalBens = registroPessoa.pestotvlrben;

            if (registroPessoa.pesvalmedmen != null && registroPessoa.pesvalmedmen.Value > 0)
                msg.valorRendaMensal = registroPessoa.pesvalmedmen;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcposren))
                msg.indicadorPosuiRenda = registroPessoa.pesidcposren;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidtlig))
                msg.pessoaLigada = registroPessoa.pesidtlig;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidciof))
                msg.indicadorCobrancaIOf = registroPessoa.pesidciof;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_fil))
                msg.codigoFilial = registroPessoa.cod_fil;

            if (!string.IsNullOrWhiteSpace(registroPessoa.bas_cgcCpf))
                msg.codigoCpfCnpjBase = registroPessoa.bas_cgcCpf;

            if (!string.IsNullOrWhiteSpace(registroPessoa.fil_cgcCpf))
                msg.codigoCpfCnpjFilial = registroPessoa.fil_cgcCpf;

            if (!string.IsNullOrWhiteSpace(registroPessoa.dig_cgcCpf))
                msg.codigoCpfCnpjDigito = registroPessoa.dig_cgcCpf;

            if (!string.IsNullOrWhiteSpace(registroPessoa.tip_fil))
                msg.tipoPessoaFilial = registroPessoa.tip_fil;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_isen_cgccpf))
                msg.indicadorIsencaoCpf = registroPessoa.idc_isen_cgccpf;

            if (!string.IsNullOrWhiteSpace(registroPessoa.til_Cpf))
                msg.CpfTitular = registroPessoa.til_Cpf;

            if (!string.IsNullOrWhiteSpace(registroPessoa.ins_est))
                msg.inscricaoEstadualTitular = registroPessoa.ins_est;

            if (!string.IsNullOrWhiteSpace(registroPessoa.ins_mun))
                msg.inscricaoMunicipalTitular = registroPessoa.ins_mun;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_dep))
                msg.indicadorDependente = registroPessoa.idc_dep;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_for))
                msg.indicadorFornecedor = registroPessoa.idc_for;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_cli))
                msg.indicadorCliente = registroPessoa.idc_cli;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_sit_fil))
                msg.indicadorSituacaoFilial = registroPessoa.idc_sit_fil;

            if (registroPessoa.dat_cad1 != null && registroPessoa.dat_cad1.Value != DateTime.MinValue)
                msg.dataCadastro1 = registroPessoa.dat_cad1;

            if (!string.IsNullOrWhiteSpace(registroPessoa.usu_atu1))
                msg.usuarioAtualizacao1 = registroPessoa.usu_atu1;

            if (registroPessoa.dat_atu1 != null && registroPessoa.dat_atu1.Value != DateTime.MinValue)
                msg.dataAtualizacao1 = registroPessoa.dat_atu1;

            if (registroPessoa.dat_sit != null && registroPessoa.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = registroPessoa.dat_sit;

            if (registroPessoa.cod_empresa != null && registroPessoa.cod_empresa.Value > 0)
                msg.codigoEmpresa = registroPessoa.cod_empresa;

            if (registroPessoa.cod_depend != null && registroPessoa.cod_depend.Value > 0)
                msg.codigoDependente = registroPessoa.cod_depend;

            if (registroPessoa.cod_oper != null && registroPessoa.cod_oper.Value > 0)
                msg.codigoOperador = registroPessoa.cod_oper;

            if (registroPessoa.dat_ini_gerente != null && registroPessoa.dat_ini_gerente.Value != DateTime.MinValue)
                msg.dataInicialGerente = registroPessoa.dat_ini_gerente;

            if (registroPessoa.cli_cod != null && registroPessoa.cli_cod.Value > 0)
                msg.codigoCliente = registroPessoa.cli_cod;

            if (registroPessoa.cod_porte != null && registroPessoa.cod_porte.Value > 0)
                msg.codigoPorte = registroPessoa.cod_porte;

            if (registroPessoa.qtd_assinatura != null && registroPessoa.qtd_assinatura.Value > 0)
                msg.qtdAssinaturas = registroPessoa.qtd_assinatura;

            if (!string.IsNullOrWhiteSpace(registroPessoa.end_home_page))
                msg.enderecoHomePage = registroPessoa.end_home_page;

            if (!string.IsNullOrWhiteSpace(registroPessoa.eml_fil_1))
                msg.email1 = registroPessoa.eml_fil_1;

            if (!string.IsNullOrWhiteSpace(registroPessoa.eml_fil_2))
                msg.email2 = registroPessoa.eml_fil_2;

            if (!string.IsNullOrWhiteSpace(registroPessoa.eml_fil_3))
                msg.email3 = registroPessoa.eml_fil_3;

            if (!string.IsNullOrWhiteSpace(registroPessoa.eml_fil_4))
                msg.email4 = registroPessoa.eml_fil_4;

            if (!string.IsNullOrWhiteSpace(registroPessoa.eml_fil_5))
                msg.email5 = registroPessoa.eml_fil_5;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_isen_ir))
                msg.indicadorIsencaoIr = registroPessoa.idc_isen_ir;

            if (registroPessoa.cod_empresa_indic != null && registroPessoa.cod_empresa_indic.Value > 0)
                msg.codigoEmpresaIndic = registroPessoa.cod_empresa_indic;

            if (registroPessoa.cod_oper_indic != null && registroPessoa.cod_oper_indic.Value > 0)
                msg.codigoOperIndic = registroPessoa.cod_oper_indic;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_sist_origem))
                msg.codigoSistemaOrigem = registroPessoa.cod_sist_origem;

            if (!string.IsNullOrWhiteSpace(registroPessoa.observ))
                msg.obs = registroPessoa.observ;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cod_ispb))
                msg.codigoIspb = registroPessoa.cod_ispb;

            if (registroPessoa.seq_Cnpj != null && registroPessoa.seq_Cnpj.Value > 0)
                msg.sequencialCnpjDuplicado = registroPessoa.seq_Cnpj;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_corresp_age))
                msg.indicadorCorrespAgencia = registroPessoa.idc_corresp_age;

            if (registroPessoa.fildatsfn != null && registroPessoa.fildatsfn.Value != DateTime.MinValue)
                msg.dataInicioSfn = registroPessoa.fildatsfn;

            //if (!string.IsNullOrWhiteSpace(registroPessoa.Cpf_conjuge))
            //    msg.CpfConjugue = registroPessoa.Cpf_conjuge;

            //if (!string.IsNullOrWhiteSpace(registroPessoa.nome_conjuge))
            //    msg.nomeConjugue = registroPessoa.nome_conjuge;

            if (!string.IsNullOrWhiteSpace(registroPessoa.FILIDTNAORESIDE))
                msg.indicadorNaoResidente = registroPessoa.FILIDTNAORESIDE;

            if (!string.IsNullOrWhiteSpace(registroPessoa.FILIDTRES2686))
                msg.indicadorRes2686 = registroPessoa.FILIDTRES2686;

            if (registroPessoa.FILCODNOVONAC != null && registroPessoa.FILCODNOVONAC.Value > 0)
                msg.codigoNovaNacionalidade = registroPessoa.FILCODNOVONAC;

            if (registroPessoa.FILDATSAIDAPAIS != null && registroPessoa.FILDATSAIDAPAIS.Value != DateTime.MinValue)
                msg.dataSaidaPais = registroPessoa.FILDATSAIDAPAIS;

            //if (registroPessoa.natcod != null && registroPessoa.natcod.Value > 0)
            //    msg.codigoNatureza = registroPessoa.natcod;

            if (registroPessoa.tip_imunidade != null && registroPessoa.tip_imunidade.Value > 0)
                msg.tipoImunidade = registroPessoa.tip_imunidade;

            if (registroPessoa.dat_reg_rbf != null && registroPessoa.dat_reg_rbf.Value != DateTime.MinValue)
                msg.dataRegistroRbf = registroPessoa.dat_reg_rbf;

            if (!string.IsNullOrWhiteSpace(registroPessoa.num_processo))
                msg.numeroProcesso = registroPessoa.num_processo;

            if (!string.IsNullOrWhiteSpace(registroPessoa.num_vara))
                msg.numeroVara = registroPessoa.num_vara;

            if (registroPessoa.dat_inicio != null && registroPessoa.dat_inicio.Value != DateTime.MinValue)
                msg.dataInicio = registroPessoa.dat_inicio;

            if (registroPessoa.dat_fim != null && registroPessoa.dat_fim.Value != DateTime.MinValue)
                msg.dataFim = registroPessoa.dat_fim;

            if (!string.IsNullOrWhiteSpace(registroPessoa.STA_REGISTRO))
                msg.indicadorSituacaoRegistro = registroPessoa.STA_REGISTRO;

            if (registroPessoa.cnaseq != null && registroPessoa.cnaseq.Value > 0)
                msg.codigoCnae2 = registroPessoa.cnaseq;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcFatca))
                msg.indicadorClienteFatca = registroPessoa.pesidcFatca;

            if (registroPessoa.PESNACIONALIDADE1 != null && registroPessoa.PESNACIONALIDADE1.Value > 0)
                msg.codigoNacionalidade1 = registroPessoa.PESNACIONALIDADE1;

            if (registroPessoa.PESNACIONALIDADE2 != null && registroPessoa.PESNACIONALIDADE2.Value > 0)
                msg.codigoNacionalidade2 = registroPessoa.PESNACIONALIDADE2;

            if (registroPessoa.PESNACIONALIDADE3 != null && registroPessoa.PESNACIONALIDADE3.Value > 0)
                msg.codigoNacionalidade3 = registroPessoa.PESNACIONALIDADE3;

            if (registroPessoa.PESNACIONALIDADE4 != null && registroPessoa.PESNACIONALIDADE4.Value > 0)
                msg.codigoNacionalidade4 = registroPessoa.PESNACIONALIDADE4;

            if (registroPessoa.PESDOMICILIO1 != null && registroPessoa.PESDOMICILIO1.Value > 0)
                msg.codigoDomicilio1 = registroPessoa.PESDOMICILIO1;

            if (registroPessoa.PESDOMICILIO2 != null && registroPessoa.PESDOMICILIO2.Value > 0)
                msg.codigoDomicilio2 = registroPessoa.PESDOMICILIO2;

            if (registroPessoa.PESDOMICILIO3 != null && registroPessoa.PESDOMICILIO3.Value > 0)
                msg.codigoDomicilio3 = registroPessoa.PESDOMICILIO3;

            if (registroPessoa.PESDOMICILIO4 != null && registroPessoa.PESDOMICILIO4.Value > 0)
                msg.codigoDomicilio4 = registroPessoa.PESDOMICILIO4;

            if (registroPessoa.SUNID != null && registroPessoa.SUNID.Value > 0)
                msg.sUnid = registroPessoa.SUNID;

            if (!string.IsNullOrWhiteSpace(registroPessoa.APELIDO1))
                msg.apelido1 = registroPessoa.APELIDO1;

            if (!string.IsNullOrWhiteSpace(registroPessoa.APELIDO2))
                msg.apelido2 = registroPessoa.APELIDO2;

            if (!string.IsNullOrWhiteSpace(registroPessoa.APELIDO3))
                msg.apelido3 = registroPessoa.APELIDO3;

            if (!string.IsNullOrWhiteSpace(registroPessoa.IDC_SIMP))
                msg.indicadorOptanteSimples = registroPessoa.IDC_SIMP;

            if (!string.IsNullOrWhiteSpace(registroPessoa.CGCCpf_FORMATADO))
                msg.CpfFormatado = registroPessoa.CGCCpf_FORMATADO;

            if (!string.IsNullOrWhiteSpace(registroPessoa.SIT_BEN))
                msg.situacaoBeneficiario = registroPessoa.SIT_BEN;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_ope_pro))
                msg.indicadorOperaContaPropria = registroPessoa.idc_ope_pro;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_aut_tra))
                msg.indicadorTransmissaoProcurador = registroPessoa.idc_aut_tra;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pestipdec))
                msg.tipoDeclarado = registroPessoa.pestipdec;

            //if (!string.IsNullOrWhiteSpace(registroPessoa.idc_cli_est))
            //    msg.indicadorClienteEstrangeiro = registroPessoa.idc_cli_est;

            //if (!string.IsNullOrWhiteSpace(registroPessoa.tip_doc_est))
            //    msg.tipoDocumentoEstrangeiro = registroPessoa.tip_doc_est;

            //if (!string.IsNullOrWhiteSpace(registroPessoa.num_doc_est))
            //    msg.numeroDocumentoEstrangeiro = registroPessoa.num_doc_est;

            if (registroPessoa.juscod != null && registroPessoa.juscod.Value > 0)
                msg.codigoJustificativa = registroPessoa.juscod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcativoprob))
                msg.indicadorAtivo = registroPessoa.pesidcativoprob;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesjustificativa))
                msg.pesjustificativa = registroPessoa.pesjustificativa;

            //if (!string.IsNullOrWhiteSpace(registroPessoa.Cpf_Cnpj))
            //    msg.cpfCnpj = registroPessoa.Cpf_Cnpj;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesnomcontato))
                msg.nomeContato = registroPessoa.pesnomcontato;

            if (registroPessoa.pescodcargo != null && registroPessoa.pescodcargo.Value > 0)
                msg.codigoCargo = registroPessoa.pescodcargo;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcdeclarFatca1))
                msg.indicadorDeclaracaoFatca1 = registroPessoa.pesidcdeclarFatca1;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcdeclarFatca2))
                msg.indicadorDeclaracaoFatca2 = registroPessoa.pesidcdeclarFatca2;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidcdomicilioext))
                msg.indicadorDomicilioExterno = registroPessoa.pesidcdomicilioext;

            if (registroPessoa.pesnumfuncionarios != null && registroPessoa.pesnumfuncionarios.Value > 0)
                msg.numeroFuncionarios = registroPessoa.pesnumfuncionarios;

            if (registroPessoa.pescodnaccapital != null && registroPessoa.pescodnaccapital.Value > 0)
                msg.codigoNacCapital = registroPessoa.pescodnaccapital;

            if (registroPessoa.pesvalcapitalestr != null && registroPessoa.pesvalcapitalestr.Value > 0)
                msg.valorCapitalEstrangeiro = registroPessoa.pesvalcapitalestr;

            if (registroPessoa.pesvalcapitalnac != null && registroPessoa.pesvalcapitalnac.Value > 0)
                msg.valorCapitalNacional = registroPessoa.pesvalcapitalnac;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pestipcapital))
                msg.tipoCapital = registroPessoa.pestipcapital;

            if (registroPessoa.pescodatvcetip != null && registroPessoa.pescodatvcetip.Value > 0)
                msg.codigoClasseEconomicaCetip = registroPessoa.pescodatvcetip;

            if (!string.IsNullOrWhiteSpace(registroPessoa.circod))
                msg.codigoIdentificadorRacial = registroPessoa.circod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pescoDDdi))
                msg.codigoDdi = registroPessoa.pescoDDdi;

            if (!string.IsNullOrWhiteSpace(registroPessoa.nom_social_pessoa))
                msg.nomeSocialPessoa = registroPessoa.nom_social_pessoa;

            if (!string.IsNullOrWhiteSpace(registroPessoa.idc_isen_insc_estadual))
                msg.indicadorIsencaoInscricaoEstadual = registroPessoa.idc_isen_insc_estadual;

            if (!string.IsNullOrWhiteSpace(registroPessoa.sgecod))
                msg.codigoSubgrupoEmpresarial = registroPessoa.sgecod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.Pld_pes))
                msg.nivelRiscoPld = registroPessoa.Pld_pes;

            if (!string.IsNullOrWhiteSpace(registroPessoa.obs_Pld))
                msg.observacaoPld = registroPessoa.obs_Pld;

            if (registroPessoa.cod_oper_ger != null && registroPessoa.cod_oper_ger.Value > 0)
                msg.codigoGerente = registroPessoa.cod_oper_ger;

            if (!string.IsNullOrWhiteSpace(registroPessoa.pesidciofadic))
                msg.indicadorCobrancaIofAdicional = registroPessoa.pesidciofadic;

            if (registroPessoa.fil_rescod != null && registroPessoa.fil_rescod.Value > 0)
                msg.codigoCestroResultado = registroPessoa.fil_rescod;

            if (!string.IsNullOrWhiteSpace(registroPessoa.cgccpf_formatado))
                msg.cpfCnpjFormatado = registroPessoa.cgccpf_formatado;

            return msg;
        }
        public MsgRegistropessoa[] AdaptarDataSetPessoaRegistroPessoaConsultaToMsgRegistropessoa(DataSetPessoaRegistroPessoaConsulta[] dataset, IList<string> erros)
        {
            List<MsgRegistropessoa> registros = new List<MsgRegistropessoa>();

            foreach (var item in dataset)
            {
                registros.Add(AdaptarDataSetPessoaRegistroPessoaConsultaToMsgRegistropessoa(item, erros));
            }

            return registros.ToArray();
        }

        public MsgRegistropessoa AdaptarDataSetPessoaRegistroPessoaConsultaToMsgRegistropessoa(DataSetPessoaRegistroPessoaConsulta registroPessoa, IList<string> erros)
        {
            MsgRegistropessoa msg = new MsgRegistropessoa();

            if (!string.IsNullOrWhiteSpace(registroPessoa.CODIGO))
                msg.codigoPessoa = registroPessoa.CODIGO;


            if (!string.IsNullOrWhiteSpace(registroPessoa.NOME))
                msg.nomePessoa = registroPessoa.NOME;


            if (!string.IsNullOrWhiteSpace(registroPessoa.NOME_ABV))
                msg.nomeAbvPessoa = registroPessoa.NOME_ABV;


            if (!string.IsNullOrWhiteSpace(registroPessoa.SEXO))
                msg.sexoPessoa = registroPessoa.SEXO;

            if (registroPessoa.DATAFUNDACAO != null && registroPessoa.DATAFUNDACAO.Value != DateTime.MinValue)
                msg.dataFundacao = registroPessoa.DATAFUNDACAO;

            if (!string.IsNullOrWhiteSpace(registroPessoa.TIPOPESSOA))
                msg.tipoPessoa = registroPessoa.TIPOPESSOA;

            if (!string.IsNullOrWhiteSpace(registroPessoa.ATIVIDADE))
                msg.descricaoProfissao = registroPessoa.ATIVIDADE;

            return msg;
        }
    }
}