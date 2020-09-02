using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQBI.CoreBank.API.Core.Models
{

    public class MsgEndereco
    {
        public MsgHeader header { get; set; }
        public MsgRegistroEnderecoBody body { get; set; }
    }

    public class MsgRegistroEnderecoBody
    {
        public MsgEndereco RegistroEndereco { get; set; }
    }
    public class MsgRegistroendereco
    {
        public string codigoPessoa { get; set; }
        public string numeroDocumento { get; set; }
        public string dataExpedicao { get; set; }
        public string orgaoExpedidor { get; set; }
        public string observacao { get; set; }
        public string dataCadastro { get; set; }
        public string usuarioUltimaAtualizacao { get; set; }
        public string dataAtualizacao { get; set; }
        public string IndicadorSituacao { get; set; }
        public string dataSituacao { get; set; }
        public string tipoDocumento { get; set; }
        public string ufExpedicao { get; set; }
        public string documentoCheque { get; set; }
        public string indicadorMicroEmpresa { get; set; }
        public string IndicadorComprovado { get; set; }
        public float tipoComprovacaoRenda { get; set; }
        public string indicadorPreposto { get; set; }
        public string dataVencimento { get; set; }
        public float codigoNacionalidade { get; set; }
    }
}