using System;
using System.Collections.Generic;
using System.Linq;

namespace AIronMan.Common.Pagging
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        public PagedList(IEnumerable<T> source, int index, int pageSize)
        {
            ItemCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.Skip((index - 1)*pageSize).Take(pageSize).ToList());
            PageCount = (int) Math.Ceiling((double) ItemCount/PageSize);
        }

        public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            ItemCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.Skip((index - 1)*pageSize).Take(pageSize).ToList());
            PageCount = (int) Math.Ceiling((double) ItemCount/PageSize);
        }

        public PagedList(List<T> source, int index, int pageSize)
        {
            ItemCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.Skip(index*pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int index, int pageSize, int itemCount)
        {
            ItemCount = itemCount;
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.ToList());
            PageCount = (int) Math.Ceiling((double) ItemCount/PageSize);
        }

        public int ItemCount { get; set; }

        public int PageCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public bool IsPreviousPage
        {
            get { return (PageIndex > 1); }
        }

        public bool IsNextPage
        {
            get { return (PageIndex)*PageSize < ItemCount; }
        }
    }
}