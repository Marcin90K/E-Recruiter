using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Utilities
{
    public class PagedList<T> : List<T>
    {
        public PagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            AddRange(items);
        }

        public PagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            AddRange(items);
        }
    }
}
