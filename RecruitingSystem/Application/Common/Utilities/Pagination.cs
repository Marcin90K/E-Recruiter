using System;

namespace Application.Common.Utilities
{
    public class Pagination
    {
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages 
        {
            get
            {
                return (int)Math.Ceiling(TotalCount / (double)PageSize); 
            }
        }
        public bool HasPrevious
        {
            get { return (CurrentPage > 1); }
        }
        public bool HasNext
        {
            get { return (CurrentPage < TotalPages); }
        }

        public Pagination(int currentPage, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
    }
}
