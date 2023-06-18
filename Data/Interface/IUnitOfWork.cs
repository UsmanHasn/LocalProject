using Data.Concrete;
using System;
using System.Data;

namespace Data.Interface
{
    public interface IUnitOfWork: IDisposable
    {
        bool IsTransaction { get; }
        UnitOfWork BeginTransaction();
        void SaveChange();
        UnitOfWork BeginTransaction(IsolationLevel isolationLevel);
        void RollBackTransaction();
        void CommitTransaction(bool disposeTransaction = false);
    }
}
