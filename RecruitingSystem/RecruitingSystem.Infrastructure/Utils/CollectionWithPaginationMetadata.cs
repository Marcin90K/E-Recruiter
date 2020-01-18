using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Utils
{
    public class CollectionWithPaginationMetadata<T>
    {
        public IEnumerable<T> SourceCollection { get; private set; } = new List<T>();
        public PagingInformationWrapper Metadata { get; set; }

        public CollectionWithPaginationMetadata(IEnumerable<T> sourceCollection, 
            PagingInformationWrapper metadata)
        {
            SourceCollection = sourceCollection;
            Metadata = metadata;
        }
    }
}
