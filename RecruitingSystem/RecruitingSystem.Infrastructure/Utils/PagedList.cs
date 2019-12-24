using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecruitingSystem.Infrastructure.Utils
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }

        public bool HasPrevious
        {
            get { return (CurrentPage > 1); }
        }

        public bool HasNext
        {
            get { return (CurrentPage < TotalPages); }
        }

        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(source.Count() / (double)pageSize);
            var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
            AddRange(items);
        }

        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(source.Count() / (double)pageSize);
            var items = source.Skip((CurrentPage - 1) * PageSize).Take(PageSize);
            AddRange(items);
        }

        public PagingInformationWrapper CreateInfo()
        {
            return new PagingInformationWrapper(CurrentPage, TotalPages, PageSize, TotalCount, HasPrevious, HasNext)
        }
    }
}
