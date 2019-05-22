using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using My_IKS.Data.Domain;
using My_IKS.Data.Domain.Enumerations;

namespace My_IKS.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, Filter filter, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(filter.SortBy) || !columnsMap.ContainsKey(filter.SortBy))
            {
                return query;
            }
            if (filter.SortDirection == SortDirection.Asc)
            {
                return query.OrderBy(columnsMap[filter.SortBy]);
            }
            else
            {
                return query.OrderByDescending(columnsMap[filter.SortBy]);
            }
        }

        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, Filter filter)
        {
            if(filter.PageSize <= 0 || filter.Page < 0)
            {
                return query;
            }
            return query.Skip((filter.Page - 1) * filter.PageSize).Take(filter.PageSize);
        }

        public static IQueryable<T> ApplySearchKeyword<T>(this IQueryable<T> query, Filter filter, Dictionary<string, Expression<Func<T, bool>>> columnsMap)
        {
            if(String.IsNullOrWhiteSpace(filter.SearchBy) || String.IsNullOrWhiteSpace(filter.Keyword))
            {
                return query;
            }
            return query.Where(columnsMap[filter.SearchBy]);
        }
    }
}
