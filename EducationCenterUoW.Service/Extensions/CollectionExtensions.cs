using EducationCenterUoW.Domain.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationCenterUoW.Service.Extensions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> source, PaginationParams @params)
        {
            return @params.PageSize > 0 && @params.PageIndex >= 0
                ? source.Skip(@params.PageSize * (@params.PageIndex - 1)).Take(@params.PageSize) : source;
        }
    }
}
