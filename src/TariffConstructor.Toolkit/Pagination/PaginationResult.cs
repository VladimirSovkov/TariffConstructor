using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TariffConstructor.Toolkit.Pagination
{
    [DataContract]
    public class PaginationResult<T>
    {
        [DataMember(Name = "items")]
        public IEnumerable<T> Items { get; set; }

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }
    }
}
