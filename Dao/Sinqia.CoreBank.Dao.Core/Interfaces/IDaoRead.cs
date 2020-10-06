using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.Dao.Core.Interfaces
{
    public interface IDaoRead<T>
    {
        DataTable ObterDataTable(T entidade, IDbTransaction trans = null);
        DataTable ObterDataTable(T entidade, string where, IDbTransaction trans = null);
        IEnumerable<T> Obter(T entidade, IDbTransaction trans = null);
        IEnumerable<T> Obter(T entidade, string where, IDbTransaction trans = null);
    }
}
