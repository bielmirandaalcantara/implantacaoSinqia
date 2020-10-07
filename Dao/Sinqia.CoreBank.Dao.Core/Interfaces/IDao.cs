using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Interfaces
{
    public interface IDao<T> : IDaoRead<T>
    {
        T Inserir(T entidade);
        void InserirLote(IEnumerable<T> entidade);

        void Atualizar(T entidade);
        void Atualizar(T entidade, string where);
        void Atualizar(T entidade , string[] campos, string where);

        void remover(T entidade);
        void remover(T entidade, string where);
        void remover();
    }
}
