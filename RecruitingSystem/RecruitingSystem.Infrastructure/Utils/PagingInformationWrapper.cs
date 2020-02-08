using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Utils
{
    public class PagingInformationWrapper
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious { get; private set; }
        public bool HasNext { get; private set; }

        public PagingInformationWrapper(int currentPage, int totalPages, int pageSize, int totalCount,
            bool hasPrev, bool hasNext)
        {
            CurrentPage = currentPage;
            TotalCount = totalCount;
            PageSize = pageSize;
            TotalPages = totalPages;
            TotalCount = totalCount;
            HasPrevious = hasPrev;
            HasNext = hasNext;
        }
    }
}
