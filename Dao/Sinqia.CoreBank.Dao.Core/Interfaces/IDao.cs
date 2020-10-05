using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.Dao.Core.Interfaces
{
    public interface IDao<T>
    {
        DataTable ObterDataTable(T entidade, IDbTransaction trans = null);
        DataTable ObterDataTable(T entidade, string where, IDbTransaction trans = null);
        IEnumerable<T> Obter(T entidade, IDbTransaction trans = null);
        IEnumerable<T> Obter(T entidade, string where, IDbTransaction trans = null);

        T Inserir(T entidade, IDbTransaction trans);
        void InserirLote(IEnumerable<T> entidade, IDbTransaction trans = null);

        void Atualizar(T entidade, IDbTransaction trans = null);
        void Atualizar(T entidade, string where, IDbTransaction trans = null);
        void Atualizar(T entidade , string[] campos, string where, IDbTransaction trans = null);

        void remover(T entidade, IDbTransaction trans);
        void remover(T entidade, string where, IDbTransaction trans);
        void remover(IDbTransaction trans);
    }
}
