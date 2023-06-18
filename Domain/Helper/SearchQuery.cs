using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helper
{
    public class SearchQuery<T>
    {
        //-----------------------------------------------------------------------
        /// <summary>
        /// Default constructor
        /// </summary>
        public SearchQuery()
        {
            Filters = new List<Expression<Func<T, bool>>>();
        }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Contains a list of filters to be applied to the query.
        /// </summary>
        public List<Expression<Func<T, bool>>> Filters { get; protected set; }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Adds a new filter to the list
        /// </summary>
        /// <param name="filter"></param>
        public void AddFilter(Expression<Func<T, Boolean>> filter)
        {
            Filters.Add(filter);
        }



        //-----------------------------------------------------------------------
        /// <summary>
        /// Contains a list of properties that would be eagerly loaded 
        /// with he query.
        /// </summary>
        public string IncludeProperties { get; set; }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Number of items to be skipped. Useful for paging.
        /// </summary>
        public int Skip { get; set; }

        //-----------------------------------------------------------------------
        /// <summary>
        /// Represents the number of items to be returned by the query.
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// Sort column & sort order for the query
        /// </summary>
        public SortBy SortBy { get; set; }
    }
    public class SortBy
    {
        public string PropertyName { get; set; }
        public bool IsAscending { get; set; }
    }
}
