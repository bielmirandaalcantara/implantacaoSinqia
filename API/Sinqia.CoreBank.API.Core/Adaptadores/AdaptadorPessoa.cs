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

            if (!erros.Any() && msg != null)
                retorno.body = msg;

            return retorno;
        }

        public MsgRegistropessoaCompleto AdaptarMsgRegistropessoaCompleto()
        {
            return new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste"                
            };
        }

        public IList<MsgRegistropessoaCompleto> AdaptarMsgRegistropessoaCompletoLista()
        {
            List<MsgRegistropessoaCompleto> listaRegristros = new List<MsgRegistropessoaCompleto>();
            listaRegristros.Add(new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste"
            });

            listaRegristros.Add(new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste 1"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste 1"
            });

            return listaRegristros;
        }

        public DataSetPessoa AdaptarMsgPessoaCompletoToDataSetPessoa(MsgPessoaCompleto msg, IList<string> erros)
        {
            if(msg.body == null)
                throw new ApplicationException("Campo body obrigatório");

            if(msg.body.RegistroPessoa == null)
                throw new ApplicationException("Campo Registro pessoa obrigatório");

            MsgRegistropessoaCompleto registroPessoa = msg.body.RegistroPessoa;

            DataSetPessoa xml = new DataSetPessoa();
            xml.RegistroPessoa = AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(registroPessoa, erros);

            if(registroPessoa.RegistroEndereco != null && registroPessoa.RegistroEndereco.Any())
                xml.RegistroEndereco = AdaptadorEndereco.AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(registroPessoa.RegistroEndereco, erros);

            if (registroPessoa.RegistroDocumento != null && registroPessoa.RegistroDocumento.Any())
                xml.RegistroDocumento = AdaptadorDocumento.AdaptarMsgRegistrodocumentoToDataSetPessoaRegistroDocumento(registroPessoa.RegistroDocumento, erros);

            if (registroPessoa.RegistroPerfil != null && registroPessoa.RegistroPerfil.Any())
                xml.RegistroPerfil = AdaptadorPerfil.AdaptarMsgRegistroperfilToDataSetPessoaRegistroPerfil(registroPessoa.RegistroPerfil, erros);

            if (registroPessoa.RegistroReferencia != null && registroPessoa.RegistroReferencia.Any())
                xml.RegistroReferencia = AdaptadorReferencia.AdaptarMsgRegistroreferenciaToDataSetPessoaRegistroReferencia(registroPessoa.RegistroReferencia, erros);

            return xml;
        }

        public DataSetPessoaRegistroPessoa AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(MsgRegistropessoa msg, IList<string> erros)
        {
            DataSetPessoaRegistroPessoa registroPessoa = new DataSetPessoaRegistroPessoa();

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
                registroPessoa.idc_isen_cgcCpf = msg.indicadorIsencaoCpf;

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
    }
}