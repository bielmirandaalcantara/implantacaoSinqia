using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sinqia.CoreBank.API.Core.Models.Corporativo
{
    public class MsgOperador
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
        public MsgRegistroOperadorBody body { get; set; }
    }

    public class MsgRegistroOperadorBody
    {
        public MsgRegistroOperador RegistroOperador { get; set; }
    }

    /// <summary>
    /// Possibilita o cadastramento de Operadores/Gerentes utilizados pela Empresa - TB_OPERADOR
    /// </summary>
    public class MsgRegistroOperador
    {
        /// <summary>
        /// Código Empresa Sisbacen
        /// </summary>
        public int? codigoSisbacen { get; set; }

        /// <summary>
        /// cod_funcionário
        /// </summary>
        public int? codigoFuncionario { get; set; }

        /// <summary>
        /// Código Dependência Sisbacen
        /// </summary>
        public int? codigoDependenciaSisbacen { get; set; }

        /// <summary>
        /// nome_funcionário
        /// </summary>
        public string nomeFuncionario { get; set; }

        /// <summary>
        /// nome_abreviado_funcionário
        /// </summary>
        public string nomeAbreviadoFuncionario { get; set; }

        /// <summary>
        /// identificador_funcionário
        /// </summary>
        public string identificadorFuncionario { get; set; }

        /// <summary>
        /// login_funcionário
        /// </summary>
        public string loginFuncionario { get; set; }

        /// <summary>
        /// tipo_funcionário
        /// </summary>
        public string tipoFuncionario { get; set; }

        /// <summary>
        /// Data de cadastramento
        /// </summary>
        public DateTime? dataCadastro { get; set; }

        /// <summary>
        /// Código do usuário da atualização
        /// </summary>
        public string usuarioUltimaAtualizacao { get; set; }

        /// <summary>
        /// Data de atualização
        /// </summary>
        public DateTime? dataUltimaAtualizacao { get; set; }

        /// <summary>
        /// data_situaçao
        /// </summary>
        public DateTime? dataSituacao { get; set; }

        /// <summary>
        /// indicador_situação
        /// </summary>
        public string indicadorSituacao { get; set; }

        /// <summary>
        /// Código do cargo do Funcionário
        /// </summary>
        public int? codigoCargoFuncionario { get; set; }

        /// <summary>
        /// CPF do operador
        /// </summary>
        public string cpfOperador { get; set; }

        /// <summary>
        /// Digito do Operador
        /// </summary>
        public string digitoOperador { get; set; }

        /// <summary>
        /// Sexo do Operador
        /// </summary>
        public string sexoOperador { get; set; }

        /// <summary>
        /// DDD do Operador
        /// </summary>
        public string dddOperador { get; set; }

        /// <summary>
        /// Telefone do Operador
        /// </summary>
        public string telefoneOperador { get; set; }

        /// <summary>
        /// Ramal do Operador
        /// </summary>
        public string ramalOperador { get; set; }

        /// <summary>
        /// Email do Operador
        /// </summary>
        public string emailOperador { get; set; }

        /// <summary>
        /// Código do gerente no sistema de origem
        /// </summary>
        public int? codigoGerenteOrigem { get; set; }

        /// <summary>
        /// Código CRK
        /// </summary>
        public string codigoCRK { get; set; }

        /// <summary>
        /// data_inicio_operação_gerente
        /// </summary>
        public DateTime? dataInicioOperacao { get; set; }

        /// <summary>
        /// tipo_gerente
        /// </summary>
        public string tipoGerente { get; set; }

        /// <summary>
        /// situação_gerente
        /// </summary>
        public string situacaoGerente { get; set; }

        /// <summary>
        /// data_fim_operação_gerente
        /// </summary>
        public DateTime? dataFimOperacao { get; set; }

        /// <summary>
        /// Indica se o gerente deve receber email de clientes com cadastro vencido
        /// </summary>
        public string indicadorRecebCadVencido { get; set; }

    }
}