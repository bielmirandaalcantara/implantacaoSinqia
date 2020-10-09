using Sinqia.CoreBank.API.Core.Models.Corporativo;
using Sinqia.CoreBank.Dominio.Corporativo.Modelos;
using Sinqia.CoreBank.Logging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Adaptadores.Corporativo
{
    public class AdaptadorDependencia
    {
        private LogService _log;
        public AdaptadorDependencia(LogService log)
        {
            _log = log;
        }

        public tb_dependencia AdaptarMsgDependenciaToModeltb_dependencia(MsgRegistroDependencia msg)
        {
            tb_dependencia tb_dependencia = new tb_dependencia();

            if (msg.codigoEmpresa != null && msg.codigoEmpresa.Value > 0)
                tb_dependencia.cod_empresa = msg.codigoEmpresa;

            if (msg.codigoDependência != null && msg.codigoDependência.Value > 0)
                tb_dependencia.cod_depend = msg.codigoDependência;

            if (msg.codigoMunicipio != null && msg.codigoMunicipio.Value > 0)
                tb_dependencia.cod_municipio = msg.codigoMunicipio;

            if (!string.IsNullOrWhiteSpace(msg.nomeAbreviado))
                tb_dependencia.nom_abv_depend = msg.nomeAbreviado;

            if (!string.IsNullOrWhiteSpace(msg.nomeCompleto))
                tb_dependencia.nom_depend = msg.nomeCompleto;

            if (!string.IsNullOrWhiteSpace(msg.cgcBase))
                tb_dependencia.bas_cgc_depend = msg.cgcBase;

            if (!string.IsNullOrWhiteSpace(msg.cgcFilial))
                tb_dependencia.fil_cgc_depend = msg.cgcFilial;

            if (!string.IsNullOrWhiteSpace(msg.cgccDigito))
                tb_dependencia.dig_cgc_depend = msg.cgccDigito;

            if (!string.IsNullOrWhiteSpace(msg.tipoLogradouro))
                tb_dependencia.tip_log_depend = msg.tipoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.logradouro))
                tb_dependencia.end_depend = msg.logradouro;

            if (!string.IsNullOrWhiteSpace(msg.complementoLogradouro))
                tb_dependencia.cpl_log_depend = msg.complementoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.descricaoBairro))
                tb_dependencia.bai_depend = msg.descricaoBairro;

            if (!string.IsNullOrWhiteSpace(msg.cep))
                tb_dependencia.cep_depend = msg.cep;

            if (!string.IsNullOrWhiteSpace(msg.dddTelefone))
                tb_dependencia.ddd_fone_depend = msg.dddTelefone;

            if (!string.IsNullOrWhiteSpace(msg.dddTelefone2))
                tb_dependencia.ddd_fone2_depend = msg.dddTelefone2;

            if (!string.IsNullOrWhiteSpace(msg.dddTelefone3))
                tb_dependencia.ddd_fone3_depend = msg.dddTelefone3;

            if (!string.IsNullOrWhiteSpace(msg.dddTelefone4))
                tb_dependencia.ddd_fone4_depend = msg.dddTelefone4;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone))
                tb_dependencia.tel_depend = msg.numeroTelefone;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone2))
                tb_dependencia.tel_2_depend = msg.numeroTelefone2;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone3))
                tb_dependencia.tel_3_depend = msg.numeroTelefone3;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone4))
                tb_dependencia.tel_4_depend = msg.numeroTelefone4;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal))
                tb_dependencia.ram_depend = msg.numeroRamal;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal2))
                tb_dependencia.ram_2_depend = msg.numeroRamal2;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal3))
                tb_dependencia.ram_3_depend = msg.numeroRamal3;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal4))
                tb_dependencia.ram_4_depend = msg.numeroRamal4;

            if (!string.IsNullOrWhiteSpace(msg.dddFax))
                tb_dependencia.ddd_fax_depend = msg.dddFax;

            if (!string.IsNullOrWhiteSpace(msg.dddFax2))
                tb_dependencia.ddd_fax2_depend = msg.dddFax2;

            if (!string.IsNullOrWhiteSpace(msg.dddFax3))
                tb_dependencia.ddd_fax3_depend = msg.dddFax3;

            if (!string.IsNullOrWhiteSpace(msg.numeroFax))
                tb_dependencia.fax_depend = msg.numeroFax;

            if (!string.IsNullOrWhiteSpace(msg.numeroFax2))
                tb_dependencia.fax_2_depend = msg.numeroFax2;

            if (!string.IsNullOrWhiteSpace(msg.numeroFax3))
                tb_dependencia.fax_3_depend = msg.numeroFax3;

            if (!string.IsNullOrWhiteSpace(msg.email))
                tb_dependencia.eml_depend = msg.email;

            if (!string.IsNullOrWhiteSpace(msg.inscricaoEstadual))
                tb_dependencia.ins_estadual = msg.inscricaoEstadual;

            if (!string.IsNullOrWhiteSpace(msg.inscricaoMunicipal))
                tb_dependencia.ins_municipal = msg.inscricaoMunicipal;

            if (msg.nivelHierarquico != null && msg.nivelHierarquico.Value > 0)
                tb_dependencia.nvl_sup_depend = msg.nivelHierarquico;

            if (msg.nivelHierarquico1 != null && msg.nivelHierarquico1.Value > 0)
                tb_dependencia.nvl_1_depend = msg.nivelHierarquico1;

            if (msg.nivelHierarquico2 != null && msg.nivelHierarquico2.Value > 0)
                tb_dependencia.nvl_2_depend = msg.nivelHierarquico2;

            if (msg.nivelHierarquico3 != null && msg.nivelHierarquico3.Value > 0)
                tb_dependencia.nvl_3_depend = msg.nivelHierarquico3;

            if (msg.nivelHierarquico4 != null && msg.nivelHierarquico4.Value > 0)
                tb_dependencia.nvl_4_depend = msg.nivelHierarquico4;

            if (msg.nivelHierarquico5 != null && msg.nivelHierarquico5.Value > 0)
                tb_dependencia.nvl_5_depend = msg.nivelHierarquico5;

            if (msg.nivelHierarquico6 != null && msg.nivelHierarquico6.Value > 0)
                tb_dependencia.nvl_6_depend = msg.nivelHierarquico6;

            if (msg.nivelHierarquico7 != null && msg.nivelHierarquico7.Value > 0)
                tb_dependencia.nvl_7_depend = msg.nivelHierarquico7;

            if (msg.nivelHierarquico8 != null && msg.nivelHierarquico8.Value > 0)
                tb_dependencia.nvl_8_depend = msg.nivelHierarquico8;

            if (msg.nivelHierarquico9 != null && msg.nivelHierarquico9.Value > 0)
                tb_dependencia.nvl_9_depend = msg.nivelHierarquico9;

            if (msg.nivelHierarquico10 != null && msg.nivelHierarquico10.Value > 0)
                tb_dependencia.nvl_10_depend = msg.nivelHierarquico10;

            if (msg.dataInicioOperacao != null && msg.dataInicioOperacao.Value != DateTime.MinValue)
                tb_dependencia.dat_ini_depend = msg.dataInicioOperacao;

            if (msg.dataFimOperacao != null && msg.dataFimOperacao.Value != DateTime.MinValue)
                tb_dependencia.dat_fim_depend = msg.dataFimOperacao;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                tb_dependencia.dat_cad = msg.dataCadastro;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                tb_dependencia.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                tb_dependencia.dat_atu = msg.dataAtualizacao;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                tb_dependencia.idc_sit = msg.indicadorSituacao;

            if (!string.IsNullOrWhiteSpace(msg.tipoDependencia))
                tb_dependencia.tip_tpdepend = msg.tipoDependencia;

            if (msg.codigoCamaraCompensacao != null && msg.codigoCamaraCompensacao.Value > 0)
                tb_dependencia.cod_camara = msg.codigoCamaraCompensacao;

            if (!string.IsNullOrWhiteSpace(msg.numeroLogradouro))
                tb_dependencia.num_log_depend = msg.numeroLogradouro;

            if (msg.dataRollOut != null && msg.dataRollOut.Value != DateTime.MinValue)
                tb_dependencia.dat_rollout = msg.dataRollOut;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                tb_dependencia.dat_sit = msg.dataSituacao;

            return tb_dependencia;
        }
    }
}
