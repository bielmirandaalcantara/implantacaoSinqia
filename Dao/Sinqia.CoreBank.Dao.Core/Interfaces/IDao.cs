using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Interfaces
{
    public interface IDao<T> : IDaoRead<T>
    {
        T Inserir(T entidade);
        void Atualizar(T entidade, string where);
        void Atualizar(T entidade, string where, List<string> campos);    
        void Remover(T entidade, string where);
    }
}
