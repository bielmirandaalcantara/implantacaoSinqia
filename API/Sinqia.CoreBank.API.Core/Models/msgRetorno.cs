using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models
{
    /// <summary>
    /// Classe responsável pelas mensagens de retorno 
    /// </summary>
    public class MsgRetorno
    {
        /// <summary>
        /// header da mensagem de retorno
        /// </summary>
        public MsgHeaderRetorno header { get; set; }
    }

    public class MsgHeaderRetorno
    {
        /// <summary>
        /// Identificador da mensagem para localização (caso exista)
        /// </summary>
        public string identificador { get; set; }
        /// <summary>
        /// Data e hora que foi enviado a mensagem
        /// </summary>
        public DateTime dataHoraEnvio { get; set; }
        /// <summary>
        /// Data e hora do retorno da mensagem
        /// </summary>
        public DateTime dataHoraRetorno { get; set; }
        /// <summary>
        /// OK - sucesso / ERRO - Com erro
        /// </summary>
        public string status { get; set; }
        /// <summary>
        /// Lista de erros na integração (nulo caso a integração ocorra com sucesso)
        /// </summary>
        public string[] erros { get; set; }
    }
}