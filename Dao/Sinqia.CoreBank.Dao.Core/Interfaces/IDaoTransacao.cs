using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sinqia.CoreBank.DAO.Core.Interfaces
{
    public interface IDaoTransacao : IDisposable
    {
        IDbConnection GetConnection();
        IDbTransaction GetTransaction();
        bool TemConexao();
        void BeginTransaction();
        void Rollback();
        void Commit();
    }
}
