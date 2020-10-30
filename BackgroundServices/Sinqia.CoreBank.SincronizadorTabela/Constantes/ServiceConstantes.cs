using System;
using System.Collections.Generic;
using System.Text;

namespace Sinqia.CoreBank.SincronizadorTabela.Constantes
{
    public static class ServiceConstantes
    {
        public const string ServiceName = "SincronizadorTabela";
    }

    public static class Metodo
    {
        public const string Inclusao = "INSERT";
        public const string Exclusao = "DELETE";
    }
    public static class StatusIntegracao
    {
        public const string Novo = "NEW";
        public const string Atualizando = "UPDATING";
        public const string Finalizado = "FINISHED";
        public const string Erro = "ERROR";
    }

    public static class Banco
    {
        public const string SQLSERVER = "SQLSERVER";
        public const string MYSQL = "MYSQL";
        public const string SYBASE = "SYBASE";
    }

    public static class ColunasConfiguracao
    {
        public const string CHAVEINTEGRACAO = "SCHAVEINTEGRACAO";
        public const string METODO = "SMETODO";
        public const string QTDETENTATIVA = "SQTDETENTATIVA";
        public const string STATUSINTEGRACAO = "SSTATUSINTEGRACAO";
        public const string DATAINTEGRACAO = "SDATAINTEGRACAO";
    }
} 
