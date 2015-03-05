using System.Collections.Generic;

namespace AIronMan.Common.Pagging
{
    public interface IPagedList
    {
        int ItemCount { get; set; }

        int PageCount { get; set; }

        int PageIndex { get; set; }

        int PageSize { get; set; }

        bool IsPreviousPage { get; }

        bool IsNextPage { get; }
    }

    public interface IPagedList<T> : IList<T>, IPagedList
    {
    }
}