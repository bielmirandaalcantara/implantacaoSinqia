using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgProdutoBancario
    {
        /// <summary>
        /// header da mensagem
        /// erros será nulo em retornos http 200
        /// identificador será nulo ou em branco caso seja uma requisição GET
        /// </summary>
        public MsgHeader header { get; set; }

        /// <summary>
        /// corpo da mensagem
        /// body será nulo ou vazio caso retornos http 400 e 500
        /// </summary>
        public MsgProdutoBancarioBody body { get; set; }
    }

    public class MsgProdutoBancarioBody
    {
        public MsgRegistroProdutoBancario RegistroProdutoBancario { get; set; }
    }

    /// <summary>
    /// Possibilita o cadastramento de Produtos Bancários utilizados pela Empresa - TB_PRODBCO
    /// </summary>
    public class MsgRegistroProdutoBancario
    {
        /// <summary>
        /// Código da Empresa Sisbacen
        /// </summary>
        public int? codigoEmpresa { get; set; }

        /// <summary>
        /// cod_produto_bancário
        /// </summary>
        public int? codigoProduto { get; set; }

        /// <summary>
        /// Nome abreviado do Produto bancário
        /// </summary>
        public string nomeAbreviado { get; set; }

        /// <summary>
        /// nome_completo_produto_bancário
        /// </summary>
        public string nomeCompleto { get; set; }

        /// <summary>
        /// Código do Grupo Produto bancário
        /// </summary>
        public int? codigoGrupo { get; set; }

        /// <summary>
        /// indicador replica
        /// </summary>
        public string indicadorReplica { get; set; }

        /// <summary>
        /// Tipo de produto
        /// </summary>
        public string tipoProduto { get; set; }

    }
}