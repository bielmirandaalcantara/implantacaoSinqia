using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{
    public class MsgDocumento
    {
        public MsgHeader header { get; set; }
        public MsgRegistroDocumentoBody body { get; set; }
    }

    public class MsgRegistroDocumentoBody
    {
        public MsgRegistrodocumento RegistroDocumento { get; set; }
    }
    public class MsgRegistrodocumento
    {
        public string codigoPessoa { get; set; }
        public string codigoFilial { get; set; }
        public float codigoEndereco { get; set; }
        public string tipoEndereco { get; set; }
        public string tipoLogradouro { get; set; }
        public string nomeLogradouro { get; set; }
        public string complementoLogradouro { get; set; }
        public string nomeBairro { get; set; }
        public string Cep { get; set; }
        public string codigoDddFone1 { get; set; }
        public string codigoDddFone2 { get; set; }
        public string codigoDddFone3 { get; set; }
        public string codigoDddFone4 { get; set; }
        public string numeroTelefone1 { get; set; }
        public string numeroTelefone2 { get; set; }
        public string numeroTelefone3 { get; set; }
        public string numeroTelefone4 { get; set; }
        public string numeroRamal1 { get; set; }
        public string numeroRamal2 { get; set; }
        public string numeroRamal3 { get; set; }
        public string numeroRamal4 { get; set; }
        public string situacaoTelefone1 { get; set; }
        public string situacaoTelefone2 { get; set; }
        public string situacaoTelefone3 { get; set; }
        public string situacaoTelefone4 { get; set; }
        public string codigoDddFax1 { get; set; }
        public string codigoDddFax2 { get; set; }
        public string codigoDddFax3 { get; set; }
        public string numeroFax1 { get; set; }
        public string numeroFax2 { get; set; }
        public string numeroFax3 { get; set; }
        public string email { get; set; }
        public string indicadorSituacaoResidencia { get; set; }
        public string indicadorCorrespondencia { get; set; }
        public string dataInicial { get; set; }
        public string dataFinal { get; set; }
        public string dataCadastro { get; set; }
        public string usuarioUltimaAtualizacao { get; set; }
        public string dataAtualizacao { get; set; }
        public string indicadorSituacao { get; set; }
        public string dataSituacao { get; set; }
        public float codigoMunicipio { get; set; }
        public string descricaoMunicipio { get; set; }
        public string numeroEndereco { get; set; }
        public string indicadorEnvioCorrespondencia { get; set; }
        public string codigoMotivo { get; set; }
        public string indicadorSituacaoRegistro { get; set; }
        public string enderecoEstrangeiro { get; set; }
        public float codigoPais { get; set; }
        public string codigoDdiFone1 { get; set; }
        public string codigoDdiFone2 { get; set; }
        public string codigoDdiFone3 { get; set; }
        public string codigoDdiFone4 { get; set; }
        public string descricaoMunicipioInternacional { get; set; }
        public string descricaoEstadoInternacional { get; set; }
    }
}