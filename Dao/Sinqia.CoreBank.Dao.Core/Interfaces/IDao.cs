using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.Dao.Core.Interfaces
{
    public interface IDao<T> : IDaoRead<T>
    {
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
