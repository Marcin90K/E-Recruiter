using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Utils
{
    public class ResourceParameters
    {
        const int maxPageSize = 20;
        private int pageSize;
        public int PageNumber
        {
            get { return pageSize; }
            set
            {
                if (value > maxPageSize) pageSize = maxPageSize;
                else pageSize = value;
            }
        }
        public int PageSize { get; set; } = 10;
        public string SearchQuery { get; set; }
    }
}
