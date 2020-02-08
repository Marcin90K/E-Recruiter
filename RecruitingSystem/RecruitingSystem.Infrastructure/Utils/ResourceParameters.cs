using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Utils
{
    public class ResourceParameters
    {
        private const int maxPageSize = 20;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value > maxPageSize) pageSize = maxPageSize;
                else pageSize = value;
            }
        }
        public int PageNumber { get; set; } = 1;
        public string Search { get; set; }
    }
}
