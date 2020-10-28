using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.SincronizadorTabela.DataBases.Interfaces
{
    public interface IConector
    {
        DataTable BuscarDadosTabela(string tabela);
        void EnviarDadosTabela(string chave, DataTable data, DataRow row);
        void IniciarSincronizacao(string chave, DataTable data, DataRow row);
        void AtualizarSincronizacao(string chave, DataTable data, DataRow row, int qtdTentativas, string statusIntegracao);
    }
}
