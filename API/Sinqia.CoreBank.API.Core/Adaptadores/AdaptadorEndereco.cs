﻿using Sinqia.CoreBank.API.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sinqia.CoreBank.API.Core.Constantes;
using Sinqia.CoreBank.Services.CUC.Models;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorEndereco
    {
        public MsgRetorno AdaptarMsgRetorno(MsgEndereco MsgEndereco, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (MsgEndereco != null && MsgEndereco.header != null)
            {
                identificador = MsgEndereco.header.identificadorEnvio;
                dataEnvio = MsgEndereco.header.dataHoraEnvio.HasValue ? MsgEndereco.header.dataHoraEnvio.Value : DateTime.Now;
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

        public DataSetPessoaRegistroEndereco[] AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(MsgRegistroendereco[] msg, string statusLinha, IList<string> erros)
        {
            List<DataSetPessoaRegistroEndereco> registroEnderecos = new List<DataSetPessoaRegistroEndereco>();
            foreach(var endereco in msg)
            {
                registroEnderecos.Add(AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(endereco, statusLinha, erros));
            }

            return registroEnderecos.ToArray();
        }

        public DataSetPessoaRegistroEndereco AdaptarMsgRegistropessoaToDataSetPessoaRegistroPessoa(MsgRegistroendereco msg, string statusLinha, IList<string> erros)
        {
            DataSetPessoaRegistroEndereco registroEndereco = new DataSetPessoaRegistroEndereco();

            registroEndereco.statuslinha = statusLinha;

            if (!string.IsNullOrWhiteSpace(msg.codigoPessoa))
                registroEndereco.cod_pessoa = msg.codigoPessoa;

            if (!string.IsNullOrWhiteSpace(msg.codigoFilial))
                registroEndereco.cod_fil = msg.codigoFilial;

            if (msg.codigoEndereco != null && msg.codigoEndereco.Value > 0)
                registroEndereco.cod_end = msg.codigoEndereco.Value;

            if (!string.IsNullOrWhiteSpace(msg.tipoEndereco))
                registroEndereco.tip_end = msg.tipoEndereco;

            if (!string.IsNullOrWhiteSpace(msg.tipoLogradouro))
                registroEndereco.tip_log_end = msg.tipoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.nomeLogradouro))
                registroEndereco.nom_log_end = msg.nomeLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.complementoLogradouro))
                registroEndereco.cpl_log_end = msg.complementoLogradouro;

            if (!string.IsNullOrWhiteSpace(msg.nomeBairro))
                registroEndereco.bai_end = msg.nomeBairro;

            if (!string.IsNullOrWhiteSpace(msg.Cep))
                registroEndereco.Cep_end = msg.Cep;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone1))
                registroEndereco.Ddd_fone_end = msg.codigoDddFone1;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone2))
                registroEndereco.Ddd_fone2_end = msg.codigoDddFone2;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone3))
                registroEndereco.Ddd_fone3_end = msg.codigoDddFone3;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFone4))
                registroEndereco.Ddd_fone4_end = msg.codigoDddFone4;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone1))
                registroEndereco.tel_end = msg.numeroTelefone1;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone2))
                registroEndereco.tel_2_end = msg.numeroTelefone2;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone3))
                registroEndereco.tel_3_end = msg.numeroTelefone3;

            if (!string.IsNullOrWhiteSpace(msg.numeroTelefone4))
                registroEndereco.tel_4_end = msg.numeroTelefone4;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal1))
                registroEndereco.ram_end = msg.numeroRamal1;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal2))
                registroEndereco.ram_2_end = msg.numeroRamal2;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal3))
                registroEndereco.ram_3_end = msg.numeroRamal3;

            if (!string.IsNullOrWhiteSpace(msg.numeroRamal4))
                registroEndereco.ram_4_end = msg.numeroRamal4;

            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone1))
                registroEndereco.sit_tel = msg.situacaoTelefone1;

            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone2))
                registroEndereco.sit_tel2 = msg.situacaoTelefone2;

            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone3))
                registroEndereco.sit_tel3 = msg.situacaoTelefone3;

            if (!string.IsNullOrWhiteSpace(msg.situacaoTelefone4))
                registroEndereco.sit_tel4 = msg.situacaoTelefone4;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFax1))
                registroEndereco.Ddd_fax_end = msg.codigoDddFax1;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFax2))
                registroEndereco.Ddd_fax2_end = msg.codigoDddFax2;

            if (!string.IsNullOrWhiteSpace(msg.codigoDddFax3))
                registroEndereco.Ddd_fax3_end = msg.codigoDddFax3;

            if (!string.IsNullOrWhiteSpace(msg.numeroFax1))
                registroEndereco.fax_end = msg.numeroFax1;

            if (!string.IsNullOrWhiteSpace(msg.numeroFax2))
                registroEndereco.fax_2_end = msg.numeroFax2;

            if (!string.IsNullOrWhiteSpace(msg.numeroFax3))
                registroEndereco.fax_3_end = msg.numeroFax3;

            if (!string.IsNullOrWhiteSpace(msg.email))
                registroEndereco.eml_end = msg.email;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacaoResidencia))
                registroEndereco.sit_residencia = msg.indicadorSituacaoResidencia;

            if (!string.IsNullOrWhiteSpace(msg.indicadorCorrespondencia))
                registroEndereco.idc_corresp = msg.indicadorCorrespondencia;

            if (msg.dataInicial != null && msg.dataInicial.Value != DateTime.MinValue)
                registroEndereco.dat_ini_end = msg.dataInicial.Value;

            if (msg.dataFinal != null && msg.dataFinal.Value != DateTime.MinValue)
                registroEndereco.dat_fim_end = msg.dataFinal.Value;

            if (msg.dataCadastro != null && msg.dataCadastro.Value != DateTime.MinValue)
                registroEndereco.dat_cad = msg.dataCadastro.Value;

            if (!string.IsNullOrWhiteSpace(msg.usuarioUltimaAtualizacao))
                registroEndereco.usu_atu = msg.usuarioUltimaAtualizacao;

            if (msg.dataAtualizacao != null && msg.dataAtualizacao.Value != DateTime.MinValue)
                registroEndereco.dat_atu = msg.dataAtualizacao.Value;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacao))
                registroEndereco.idc_sit = msg.indicadorSituacao;

            if (msg.dataSituacao != null && msg.dataSituacao.Value != DateTime.MinValue)
                registroEndereco.dat_sit = msg.dataSituacao.Value;

            if (msg.codigoMunicipio != null && msg.codigoMunicipio.Value > 0)
                registroEndereco.cod_municipio = msg.codigoMunicipio.Value;

            if (!string.IsNullOrWhiteSpace(msg.descricaoMunicipio))
                registroEndereco.des_municipio = msg.descricaoMunicipio;

            if (!string.IsNullOrWhiteSpace(msg.numeroEndereco))
                registroEndereco.num_log_end = msg.numeroEndereco;

            if (!string.IsNullOrWhiteSpace(msg.indicadorEnvioCorrespondencia))
                registroEndereco.idt_naocorresp = msg.indicadorEnvioCorrespondencia;

            if (!string.IsNullOrWhiteSpace(msg.codigoMotivo))
                registroEndereco.motcod = msg.codigoMotivo;

            if (!string.IsNullOrWhiteSpace(msg.indicadorSituacaoRegistro))
                registroEndereco.sta_registro = msg.indicadorSituacaoRegistro;

            if (!string.IsNullOrWhiteSpace(msg.enderecoEstrangeiro))
                registroEndereco.endidcestrang = msg.enderecoEstrangeiro;

            if (msg.codigoPais != null && msg.codigoPais.Value > 0)
                registroEndereco.endcodpais = msg.codigoPais.Value;

            return registroEndereco;
        }

        public MsgRegistroendereco[] AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoa(DataSetPessoaRegistroEndereco[] dataset, IList<string> erros)
        {
            List<MsgRegistroendereco> registros = new List<MsgRegistroendereco>();

            foreach (var item in dataset)
            {
                registros.Add(AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoa(item, erros));
            }

            return registros.ToArray();
        }

        public MsgRegistroendereco AdaptarDataSetPessoaRegistroPessoaToMsgRegistropessoa(DataSetPessoaRegistroEndereco registroEndereco, IList<string> erros)
        {
            MsgRegistroendereco msg = new MsgRegistroendereco();


            if (!string.IsNullOrWhiteSpace(registroEndereco.cod_pessoa))
                msg.codigoPessoa = registroEndereco.cod_pessoa;

            if (!string.IsNullOrWhiteSpace(registroEndereco.cod_fil))
                msg.codigoFilial = registroEndereco.cod_fil;

            if (registroEndereco.cod_end != null && registroEndereco.cod_end.Value > 0)
                msg.codigoEndereco = registroEndereco.cod_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.tip_end))
                msg.tipoEndereco = registroEndereco.tip_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.tip_log_end))
                msg.tipoLogradouro = registroEndereco.tip_log_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.nom_log_end))
                msg.nomeLogradouro = registroEndereco.nom_log_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.cpl_log_end))
                msg.complementoLogradouro = registroEndereco.cpl_log_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.bai_end))
                msg.nomeBairro = registroEndereco.bai_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Cep_end))
                msg.Cep = registroEndereco.Cep_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fone_end))
                msg.codigoDddFone1 = registroEndereco.Ddd_fone_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fone2_end))
                msg.codigoDddFone2 = registroEndereco.Ddd_fone2_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fone3_end))
                msg.codigoDddFone3 = registroEndereco.Ddd_fone3_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fone4_end))
                msg.codigoDddFone4 = registroEndereco.Ddd_fone4_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.tel_end))
                msg.numeroTelefone1 = registroEndereco.tel_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.tel_2_end))
                msg.numeroTelefone2 = registroEndereco.tel_2_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.tel_3_end))
                msg.numeroTelefone3 = registroEndereco.tel_3_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.tel_4_end))
                msg.numeroTelefone4 = registroEndereco.tel_4_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.ram_end))
                msg.numeroRamal1 = registroEndereco.ram_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.ram_2_end))
                msg.numeroRamal2 = registroEndereco.ram_2_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.ram_3_end))
                msg.numeroRamal3 = registroEndereco.ram_3_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.ram_4_end))
                msg.numeroRamal4 = registroEndereco.ram_4_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.sit_tel))
                msg.situacaoTelefone1 = registroEndereco.sit_tel;

            if (!string.IsNullOrWhiteSpace(registroEndereco.sit_tel2))
                msg.situacaoTelefone2 = registroEndereco.sit_tel2;

            if (!string.IsNullOrWhiteSpace(registroEndereco.sit_tel3))
                msg.situacaoTelefone3 = registroEndereco.sit_tel3;

            if (!string.IsNullOrWhiteSpace(registroEndereco.sit_tel4))
                msg.situacaoTelefone4 = registroEndereco.sit_tel4;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fax_end))
                msg.codigoDddFax1 = registroEndereco.Ddd_fax_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fax2_end))
                msg.codigoDddFax2 = registroEndereco.Ddd_fax2_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.Ddd_fax3_end))
                msg.codigoDddFax3 = registroEndereco.Ddd_fax3_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.fax_end))
                msg.numeroFax1 = registroEndereco.fax_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.fax_2_end))
                msg.numeroFax2 = registroEndereco.fax_2_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.fax_3_end))
                msg.numeroFax3 = registroEndereco.fax_3_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.eml_end))
                msg.email = registroEndereco.eml_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.sit_residencia))
                msg.indicadorSituacaoResidencia = registroEndereco.sit_residencia;

            if (!string.IsNullOrWhiteSpace(registroEndereco.idc_corresp))
                msg.indicadorCorrespondencia = registroEndereco.idc_corresp;

            if (registroEndereco.dat_ini_end != null && registroEndereco.dat_ini_end.Value != DateTime.MinValue)
                msg.dataInicial = registroEndereco.dat_ini_end;

            if (registroEndereco.dat_fim_end != null && registroEndereco.dat_fim_end.Value != DateTime.MinValue)
                msg.dataFinal = registroEndereco.dat_fim_end;

            if (registroEndereco.dat_cad != null && registroEndereco.dat_cad.Value != DateTime.MinValue)
                msg.dataCadastro = registroEndereco.dat_cad;

            if (!string.IsNullOrWhiteSpace(registroEndereco.usu_atu))
                msg.usuarioUltimaAtualizacao = registroEndereco.usu_atu;

            if (registroEndereco.dat_atu != null && registroEndereco.dat_atu.Value != DateTime.MinValue)
                msg.dataAtualizacao = registroEndereco.dat_atu;

            if (!string.IsNullOrWhiteSpace(registroEndereco.idc_sit))
                msg.indicadorSituacao = registroEndereco.idc_sit;

            if (registroEndereco.dat_sit != null && registroEndereco.dat_sit.Value != DateTime.MinValue)
                msg.dataSituacao = registroEndereco.dat_sit;

            if (registroEndereco.cod_municipio != null && registroEndereco.cod_municipio.Value > 0)
                msg.codigoMunicipio = registroEndereco.cod_municipio;

            if (!string.IsNullOrWhiteSpace(registroEndereco.des_municipio))
                msg.descricaoMunicipio = registroEndereco.des_municipio;

            if (!string.IsNullOrWhiteSpace(registroEndereco.num_log_end))
                msg.numeroEndereco = registroEndereco.num_log_end;

            if (!string.IsNullOrWhiteSpace(registroEndereco.idt_naocorresp))
                msg.indicadorEnvioCorrespondencia = registroEndereco.idt_naocorresp;

            if (!string.IsNullOrWhiteSpace(registroEndereco.motcod))
                msg.codigoMotivo = registroEndereco.motcod;

            if (!string.IsNullOrWhiteSpace(registroEndereco.sta_registro))
                msg.indicadorSituacaoRegistro = registroEndereco.sta_registro;

            if (!string.IsNullOrWhiteSpace(registroEndereco.endidcestrang))
                msg.enderecoEstrangeiro = registroEndereco.endidcestrang;

            if (registroEndereco.endcodpais != null && registroEndereco.endcodpais.Value > 0)
                msg.codigoPais = registroEndereco.endcodpais;

            //if (!string.IsNullOrWhiteSpace(registroEndereco.Ddi_fone_end))
            //    msg.codigoDdiFone1 = registroEndereco.Ddi_fone_end;

            //if (!string.IsNullOrWhiteSpace(registroEndereco.Ddi_fone2_end))
            //    msg.codigoDdiFone2 = registroEndereco.Ddi_fone2_end;

            //if (!string.IsNullOrWhiteSpace(registroEndereco.Ddi_fone3_end))
            //    msg.codigoDdiFone3 = registroEndereco.Ddi_fone3_end;

            //if (!string.IsNullOrWhiteSpace(registroEndereco.Ddi_fone4_end))
            //    msg.codigoDdiFone4 = registroEndereco.Ddi_fone4_end;

            //if (!string.IsNullOrWhiteSpace(registroEndereco.des_mun_int))
            //    msg.descricaoMunicipioInternacional = registroEndereco.des_mun_int;

            //if (!string.IsNullOrWhiteSpace(registroEndereco.des_est_int))
            //    msg.descricaoEstadoInternacional = registroEndereco.des_est_int;

            return msg;
        }
    }
}