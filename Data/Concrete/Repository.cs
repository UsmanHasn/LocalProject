using System.Linq.Expressions;
using System.Reflection;
using Data.Interface;
using log4net;
using System.Data.Entity.Validation;
using Domain.Entities;
using Domain.Helper;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected readonly ApplicationDbContext DbContext;
        private readonly DbSet<T> _entity = null;
        private IUnitOfWork unitOfWork;

        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
            _entity = DbContext.Set<T>();
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                if (unitOfWork == null)
                    unitOfWork = new UnitOfWork(DbContext);
                return unitOfWork;
            }
        }

        #region Read Operations

        /// <summary>
        /// Find entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>T</returns>
        public virtual T FindById(object id)
        {
            Logger();
            return _entity.Find(id);
        }


        //params are Linq expressions

        /// <summary>
        /// Returns all results for the Linq expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>List</returns>
        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            Logger();
            IQueryable<T> query = _entity.Where(predicate);
            List<T> list = query
                .AsNoTracking()
                .ToList<T>();

            return list;
        }

        /// <summary>
        /// Returns results for included navigationalProperties (foreign keys)
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns>IList</returns>
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            Logger();

            IQueryable<T> dbQuery = _entity;
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            List<T> list = dbQuery
                .AsNoTracking()
                .ToList<T>();
            
            return list;
        }

        /// <summary>
        /// Returns results for included navigationalProperties (foreign keys)
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="navigationProperties"></param>
        /// <returns>IList</returns>
        public virtual IList<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            Logger();

            IQueryable<T> dbQuery = _entity.Where(predicate);
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<T, object>(navigationProperty);

            List<T> list = dbQuery
                .AsNoTracking()
                .ToList<T>();

            return list;
        }

        /// <summary>
        /// Returns Single
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>Single</returns>
        public virtual T GetSingle(Expression<Func<T, bool>> predicate)
        {
            Logger();
            IQueryable<T> query = _entity.Where(predicate);
            T item = query
                .AsNoTracking()
                .FirstOrDefault();

            return item;
        }

        /// <summary>
        /// Returns Single
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public virtual T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] navigationProperties)
        {
            Logger();
            IQueryable<T> query = _entity.Where(predicate);
            foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                query = query.Include<T, object>(navigationProperty);

            T item = query
                .AsNoTracking()
                .FirstOrDefault();

            return item;
        }

        /// <summary>
        /// Dont change the state of the entity.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void UnChangeEntity(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Unchanged;
        }

        #endregion
        
        #region Create, Update and Delete operations

        /// <summary>
        /// Adds entity to context.
        /// 1. If operation is Create Add new entity to context along with createdby and createdDate
        /// 2. If operation is Update Attaches to context aling with lastModifiedBy and LastModifiedDate
        /// 2. If operation is Delete Attaches to context aling with lastModifiedBy and LastModifiedDate and Delete = true (soft delete)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="username"></param>
        /// <param name="operation"></param>
        public virtual void AddToContext(T entity, string username, string operation)
        {
            Logger();
            if (operation.Equals("Create"))
            {
                Create(entity, username);
            }
            else if(operation.Equals("Update"))
            {
                Update(entity, username);
            }
            else if (operation.Equals("Delete"))
            {
                Delete(entity, username);
            }
        }

        /// <summary>
        /// Create Add new entity to context along with createdby and createdDate
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="createdBy"></param>
        public virtual void Create(T entity, string createdBy)
        {
            Logger();
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = createdBy;
            entity.LastModifiedDate = DateTime.Now;
            entity.LastModifiedBy = createdBy;
            entity.Deleted = false;
            _entity.Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;
        }

        public virtual T CreateAndReturnEntity(T entity, string createdBy)
        {
            Logger();
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = createdBy;
            entity.LastModifiedDate = DateTime.Now;
            entity.LastModifiedBy = createdBy;
            entity.Deleted = false;
            _entity.Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;

            return entity;
        }

        public virtual T CreateAndReturnEntity(T entity, string createdBy, DateTime createdDate)
        {
            Logger();
            entity.CreatedBy = createdBy;
            entity.CreatedDate = createdDate;
            entity.LastModifiedBy = createdBy;
            entity.LastModifiedDate = createdDate;
            entity.Deleted = false;
            _entity.Add(entity);
            DbContext.Entry(entity).State = EntityState.Added;

            return entity;
        }

        /// <summary>
        /// Update Attaches to context along with lastModifiedBy and LastModifiedDate
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="modifiedBy"></param>
        public virtual void Update(T entity, string modifiedBy)
        {
            Logger();
            entity.LastModifiedDate = DateTime.Now;
            entity.LastModifiedBy = modifiedBy;
            entity.Deleted = false;
            _entity.Attach(entity);//check if this need to be Add instead if adding a new child to parent.
            DbContext.Entry(entity).State = EntityState.Modified;
        }
        
        /// <summary>
        /// Delete Attaches to context aling with lastModifiedBy and LastModifiedDate and Delete = true (soft delete)
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="modifiedBy"></param>
        public virtual void Delete(T entity, string modifiedBy)
        {
            Logger();
            entity.Deleted = true;
            entity.LastModifiedDate = DateTime.Now;
            entity.LastModifiedBy = modifiedBy;
            _entity.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void DetachEntity(T entity)
        {
            Logger();
            DbContext.Entry(entity).State = EntityState.Detached;
        }

        /// <summary>
        /// Delete Attaches to context aling with lastModifiedBy and LastModifiedDate and Delete = true (soft delete)
        /// </summary>
        /// <param name="entity"></param>
        public virtual void PermanentDelete(T entity)
        {
            Logger();
            _entity.Remove(entity);
        }

        /// <summary>
        /// Saves all entities added and Attached to context to database.
        /// </summary>
        public virtual void Save()
        {
            Logger();
            try
            {
                DbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Log.Fatal(
                        String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Log.Fatal(String.Format("- Property: \"{0}\", Error: \"{1}\"",
                             ve.PropertyName, ve.ErrorMessage));
                    }
                }
                throw;
            }
        }

        #endregion

        #region Dynamic Search

        /// <summary>
        /// Search Entity
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns>List</returns>
        public virtual IEnumerable<T> Search(SearchQuery<T> searchQuery)
        {
            Logger();

            IQueryable<T> sequence = _entity;

            //Applying filters
            sequence = ManageFilters(searchQuery, sequence);

            //Include Properties
            sequence = ManageIncludeProperties(searchQuery, sequence);

            //Applying sorts
            sequence = SortBy(sequence, searchQuery.SortBy);

            //Applying NoTracking
            sequence = sequence.AsNoTracking();
            
            return GetTheResult(searchQuery, sequence);
        }

        /// <summary>
        /// Executes the query against the repository (database).
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns>List</returns>
        protected virtual IEnumerable<T> GetTheResult(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            Logger();
            //Counting the total number of object.
            int resultCount = sequence.Count();

            IQueryable<T> result = (searchQuery.Take > 0)
                                ? sequence.Skip(searchQuery.Skip).Take(searchQuery.Take)
                                : sequence;

            return result;
        }
        /// <summary>
        /// Search entity along with total results count
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        public virtual (IEnumerable<T>, int resultCount, decimal? totalAmount) SearchWithCount(SearchQuery<T> searchQuery)
        {
            Logger();

            IQueryable<T> sequence = _entity;

            //Applying filters
            sequence = ManageFilters(searchQuery, sequence);

            //Include Properties
            sequence = ManageIncludeProperties(searchQuery, sequence);

            //Applying sorts
            sequence = SortBy(sequence, searchQuery.SortBy);

            //Applying NoTracking
            sequence = sequence.AsNoTracking();

            return GetTheResultWithCount(searchQuery, sequence);
        }
        /// <summary>
        /// Executes query 
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns>Results with total count</returns>
        protected virtual (IEnumerable<T>, int resultCount, decimal? totalAmount) GetTheResultWithCount(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            Logger();
            //Counting the total number of object.
            int resultCount = sequence.Count();
            decimal? totalAmount = 0;// GetTotalAmount(sequence);

            IQueryable<T> result = (searchQuery.Take > 0)
                                ? sequence.Skip(searchQuery.Skip).Take(searchQuery.Take)
                                : sequence;

            return (result, resultCount, totalAmount);
        }
        /// <summary>
        /// Chains the where clause to the IQueryable instance.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns>T</returns>
        protected virtual IQueryable<T> ManageFilters(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            Logger();

            if (searchQuery.Filters != null && searchQuery.Filters.Count > 0)
            {
                foreach (var filterClause in searchQuery.Filters)
                {
                    sequence = sequence.Where(filterClause);
                }
            }
            return sequence;
        }

        /// <summary>
        /// Includes the properties sent as part of the SearchQuery.
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        protected virtual IQueryable<T> ManageIncludeProperties(SearchQuery<T> searchQuery, IQueryable<T> sequence)
        {
            Logger();

            if (!string.IsNullOrWhiteSpace(searchQuery.IncludeProperties))
            {
                var properties = searchQuery.IncludeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var includeProperty in properties)
                {
                    sequence = sequence.Include(includeProperty);
                }
            }
            return sequence;
        }
        public IQueryable<TEntity> SortBy<TEntity>(IQueryable<TEntity> source, SortBy sortBy)
        {
            if (source is null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (sortBy != null) { 
                string method = GetMethod(sortBy.IsAscending);
                Type type = typeof(TEntity);
                ParameterExpression parameter = Expression.Parameter(type, "p");
                Expression propertyAccess = CreateLeft(sortBy.PropertyName, parameter);
                LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);
                MethodCallExpression resultExpression = Expression.Call(typeof(Queryable), method, new Type[] { type, propertyAccess.Type }, source.Expression, Expression.Quote(orderByExpression));
                source = source.Provider.CreateQuery<TEntity>(resultExpression);
            }
            return source;
        }
        public Expression CreateLeft(string property, ParameterExpression parameter)
        {
            if (property is null)
            {
                throw new ArgumentNullException(nameof(property));
            }

            return property.Split('.')
               .Aggregate((Expression)parameter, Expression.Property);
        }

        private string GetMethod(bool asc)
        {           
            return asc ? "OrderBy" : "OrderByDescending";
        }
        public virtual void BulkInsert(IEnumerable<T> entities)
        {
            //DbContext.BulkInsert(entities);
        }

        public virtual void BulkUpdate(IEnumerable<T> entities)
        {
            //DbContext.BulkUpdate(entities);
        }

        public virtual void BulkDelete(IEnumerable<T> entities)
        {
            //DbContext.BulkDelete(entities);
        }
        #endregion

        /// <summary>
        /// Log all  database operations and queries to File
        /// </summary>
        private void Logger()
        {
            //DbContext.Database.Log = message => Log.Debug(message);

            //To reset Logging
            // DbContext.Database.Log = null;
        }
        public void ExecuteStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            using var command = DbContext.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }

            DbContext.Database.OpenConnection();
            command.ExecuteNonQuery();
        }
        public IEnumerable<TResult> ExecuteStoredProcedure<TResult>(string storedProcedureName, params SqlParameter[] parameters)
        {
            using var command = DbContext.Database.GetDbConnection().CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = storedProcedureName;
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
           
            DbContext.Database.OpenConnection();

            using var reader = command.ExecuteReader();
            var result = new List<TResult>();

            var schemaTable = reader.GetSchemaTable();
            var columns = schemaTable.Columns;
            var properties = typeof(TResult).GetProperties();

            while (reader.Read())
            {
                var item = Activator.CreateInstance<TResult>();

                foreach (var property in properties)
                {
                    var columnName = property.Name;

                    try
                    {
                        var columnIndex = reader.GetOrdinal(columnName);

                        if (!reader.IsDBNull(columnIndex))
                        {
                            var value = reader.GetValue(columnIndex);
                            if (property.PropertyType.Name.ToLower() == "datetime")
                            {
                                property.SetValue(item, Convert.ToDateTime(value));
                            }
                            else if (property.PropertyType.Name.ToLower() == "double")
                            {
                                property.SetValue(item, Convert.ToDouble(value));
                            }
                            else if (property.PropertyType.Name.ToLower() == "decimal")
                            {
                                property.SetValue(item, Convert.ToDecimal(value));
                            }
                            else if (property.PropertyType.Name.ToLower() == "int")
                            {
                                property.SetValue(item, Convert.ToInt32(value));
                            }
                            else if (property.PropertyType.Name.ToLower() == "long")
                            {
                                property.SetValue(item, Convert.ToInt64(value));
                            }
                            else
                            {
                                property.SetValue(item, value);
                            }
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        // Handle non-existent column
                        // You can throw an exception or handle it based on your requirements
                        continue;
                    }
                }

                result.Add(item);
            }

            return result;
        }
    }

}
