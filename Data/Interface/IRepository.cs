using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Helper;
using Microsoft.Data.SqlClient;

namespace Data.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
        T FindById(object id);
        IList<T> GetAll(Expression<Func<T, bool>> predicate);

        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        IList<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        T GetSingle(Expression<Func<T, bool>> predicate);

        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties);

        void UnChangeEntity(T entity);

        //int SaveChanges(params T[] items);

        void AddToContext(T entity, string username, string operation);

        void Create(T entity, string createdBy);
        
        T CreateAndReturnEntity(T entity, string createdBy);

        T CreateAndReturnEntity(T entity, string createdBy, DateTime createdDate);

        void Update(T entity, string modifiedBy);
       
        void Delete(T entity, string modifiedBy);
        void DetachEntity(T entity);

        void PermanentDelete(T entity);

        void Save();
        void BulkInsert(IEnumerable<T> entities);
        void BulkUpdate(IEnumerable<T> entities);
        void BulkDelete(IEnumerable<T> entities);

        //Dynamic Search
        IEnumerable<T> Search(SearchQuery<T> searchQuery);
        (IEnumerable<T>, int resultCount, decimal? totalAmount) SearchWithCount(SearchQuery<T> searchQuery);
        void ExecuteStoredProcedure(string storedProcedureName, params SqlParameter[] parameters);
        IEnumerable<TResult> ExecuteStoredProcedure<TResult>(string storedProcedureName, params SqlParameter[] parameters);
        
    }
}
