using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    public class MsgHeaderRetorno
    {

        /// <summary>
        /// Identificador da mensagem para localização (caso exista)
        /// </summary>
        public string identificador { get; set; }
        /// <summary>
        /// Data e hora que foi enviado a mensagem
        /// </summary>
        public DateTime? dataHoraEnvio { get; set; }
        /// <summary>
        /// Data e hora do retorno da mensagem
        /// </summary>
        public DateTime? dataHoraRetorno { get; set; }
        /// <summary>
        /// Código da pessoa cadastrado no sistema (nulo caso seja retorno de um get com inumeros códigos ou ocorra alguma inconsistência)
        /// </summary>
        public string codigoPessoa { get; set; }
        /// <summary>
        /// Código cadastrado no sistema (nulo caso seja retorno de um get com inumeros códigos ou ocorra alguma inconsistência)
        /// </summary>
        public string codigoChave { get; set; }
        /// <summary>
        /// OK - sucesso / ERRO - Com erro
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Lista de erros na integração (nulo caso a integração ocorra com sucesso)
        /// </summary>
        /// 
        public string[] erros { get; set; }
    }
}