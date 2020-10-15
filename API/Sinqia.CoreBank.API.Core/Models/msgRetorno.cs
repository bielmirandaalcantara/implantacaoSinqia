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

    public class MsgRetornoGet : MsgRetorno
    {
        /// <summary>
        /// body da mensagem get
        /// </summary>
        public object body { get; set; }
    }        
}