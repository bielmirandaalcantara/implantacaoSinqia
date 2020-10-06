using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.Dao.Core.Interfaces
{
    public interface IDaoRead<T>
    {
        DataTable ObterDataTable(IDbTransaction trans = null);
        DataTable ObterDataTable(string where, IDbTransaction trans = null);
        IEnumerable<T> Obter(IDbTransaction trans = null);
        IEnumerable<T> Obter(string where, IDbTransaction trans = null);
    }
}
