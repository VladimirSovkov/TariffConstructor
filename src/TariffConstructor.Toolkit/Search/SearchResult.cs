using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TariffConstructor.Toolkit.Search
{
    [DataContract]
    public class SearchResult<T>
    {
        [DataMember(Name = "items")]
        public IEnumerable<T> Items { get; set; }

        [DataMember(Name = "totalCount")]
        public int TotalCount { get; set; }

        [DataMember(Name = "filteredCount")]
        public int FilteredCount { get; set; }
    }
}
