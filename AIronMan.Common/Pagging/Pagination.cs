using System.Collections.Generic;
using System.Linq;

namespace AIronMan.Common.Pagging
{
    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index, int pageSize, int itemCount)
        {
            return new PagedList<T>(source, index, pageSize, itemCount);
        }

        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }
}