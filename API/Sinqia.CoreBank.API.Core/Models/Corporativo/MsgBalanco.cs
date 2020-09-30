using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgBalanco
    {
        public MsgHeader header { get; set; }

        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgRegistroBalancoBody body { get; set; }
    }

    public class MsgRegistroBalancoBody
    {
        public MsgRegistroBalanco RegistroBalanco { get; set; }
    }

    public class MsgRegistroBalanco
    {

        /// <summary>
        /// Data início Balanço
        /// </summary>
        public DateTime dataInicioBalanco { get; set; }

        /// <summary>
        /// Data fim Balanço
        /// </summary>
        public DateTime dataFimBalanco { get; set; }

        /// <summary>
        /// Descrição Balanço
        /// </summary>
        public string descricaoBalanco { get; set; }

        /// <summary>
        /// Data de cadastramento
        /// </summary>
        public DateTime dataCadastro { get; set; }

        /// <summary>
        /// Código do usuário da atualização
        /// </summary>
        public string codigoUsuarioAtualizacao { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime dataAtualizacao { get; set; }

        /// <summary>
        /// Indicador de situação
        /// </summary>
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Data da situação
        /// </summary>
        public DateTime dataSituacao { get; set; }

        /// <summary>
        /// Código do Índice
        /// </summary>
        public string codigoIndice { get; set; }

        /// <summary>
        /// Código do Detalhe – Linha Balanço
        /// </summary>
        public string codigoDetalheLinhaBalanco { get; set; }

        /// <summary>
        /// Valor Analisado
        /// </summary>
        public decimal valorAnalisado { get; set; }

    }

}
