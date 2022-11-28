using Hamroh_V2.Domain.Configurations;
using Hamroh_V2.Service.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Hamroh_V2.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagedAsEnumerable<T>(this IQueryable<T> sources, PaginationParameters? parameters)
        {
            if (HttpContextHelper.ResponseHeaders.ContainsKey("total-count"))
                HttpContextHelper.ResponseHeaders.Remove("total-count");

            HttpContextHelper.ResponseHeaders.Add("total-count", $"{sources.Count()}");

            return parameters is { PageSize: > 0, PageIndex: > 0 }
                ? sources.Skip((parameters.PageIndex - 1) * parameters.PageSize).Take(parameters.PageSize)
                : sources;
        }

        public static IQueryable<T> ToPagedAsQueryable<T>(this IQueryable<T> sources,
            PaginationParameters? parameters)
        {
            if (HttpContextHelper.ResponseHeaders.ContainsKey("total-count"))
                HttpContextHelper.ResponseHeaders.Remove("total-count");

            HttpContextHelper.ResponseHeaders.Add("total-count", $"{sources.Count()}");

            return parameters is { PageSize: > 0, PageIndex: > 0 }
                ? sources.Skip((parameters.PageIndex - 1) * parameters.PageSize).Take(parameters.PageSize)
                : sources;
        }

        public static IEnumerable<TSource> ToPagedAsEnumerable<TSource>(this IEnumerable<TSource> sources,
            PaginationParameters? parameters) => parameters is { PageSize: > 0, PageIndex: > 0 }
            ? sources.Skip((parameters.PageIndex - 1) * parameters.PageSize).Take(parameters.PageSize)
            : sources;
    }
}
