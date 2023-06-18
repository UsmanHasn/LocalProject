using Data.Context;
using Data.Interface;
using System;
using System.Data;
using System.Data.Entity;

namespace Data.Concrete
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DbContextTransaction _transaction;
        private DateTime _transactionDateTime;
        public DateTime TransactionDateTime { get { return _transactionDateTime; } }
        private ApplicationDbContext _objectContext;

        public UnitOfWork(ApplicationDbContext context)
        {
            _objectContext = context;
            _objectContext.Database.CommandTimeout = 0;
        }
        public bool IsTransaction
        {
            get { return _transaction != null; }
        }
        public UnitOfWork BeginTransaction()
        {
            return BeginTransaction(IsolationLevel.ReadUncommitted);
        }
        public UnitOfWork BeginTransaction(IsolationLevel isolationLevel)
        {
            if (_transaction != null)
            {
                throw new ApplicationException("Cannot begin a new transaction while an existing transaction is still running. " +
                                                "Please commit or rollback the existing transaction before starting a new one.");
            }
            try
            {
                OpenConnection();
                _transaction = _objectContext.Database.BeginTransaction(isolationLevel);
                _transactionDateTime = DateTime.UtcNow;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return this;
        }
        public void RollBackTransaction()
        {
            if (_transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }

            try
            {
                _transaction.Rollback();
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }
        public void SaveChange()
        {
            _objectContext.SaveChanges();
        }
        public void CommitTransaction(bool disposeTransaction = false)
        {

            if (_transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }
            try
            {
                _objectContext.SaveChanges();
                _transaction.Commit();
                if (disposeTransaction)
                {
                    _transaction.Dispose();
                    _transaction = null;

                }
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                ReleaseCurrentTransaction();
            }
        }
        private void ReleaseCurrentTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }
        private void OpenConnection()
        {
            if (_objectContext.Database.Connection.State != ConnectionState.Open)
            {
                _objectContext.Database.Connection.Open();
            }
        }

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!disposing)
                return;

            if (_disposed)
                return;

            ReleaseCurrentTransaction();

            _disposed = true;
        }
        private bool _disposed;
        #endregion
    }
}
