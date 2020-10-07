using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Interfaces
{
    public interface IDaoRead<T>
    {
        DataTable ObterDataTable();
        DataTable ObterDataTable(string where);
        IEnumerable<T> Obter();
        IEnumerable<T> Obter(string where);
    }
}
