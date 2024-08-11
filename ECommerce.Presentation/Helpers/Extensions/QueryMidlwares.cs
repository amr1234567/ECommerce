using ECommerce.Presentation.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

public static class QueryExtensions
{
    public static PaginationParams ToObject<T>(this IQueryCollection query)
    {
        var paginationParams = new PaginationParams();

        var properties = typeof(T).GetProperties();
        foreach (var prop in properties)
        {
            if (query.TryGetValue(prop.Name, out var value))
            {
                var convertedValue = Convert.ChangeType(value.First(), prop.PropertyType);
                prop.SetValue(paginationParams, convertedValue);
            }
        }

        return paginationParams;
    }
}
