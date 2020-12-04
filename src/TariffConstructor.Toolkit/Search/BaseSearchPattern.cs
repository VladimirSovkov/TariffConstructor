using System;
using System.Runtime.Serialization;

namespace TariffConstructor.Toolkit.Search
{
    [DataContract]
    public abstract class BaseSearchPattern
    {
        protected BaseSearchPattern(int pageNumber = 1, int onPage = 25)
        {
            if (pageNumber < 1)
            {
                throw new InvalidOperationException($"Incorrect page number: {pageNumber}");
            }

            if (onPage < 1)
            {
                throw new InvalidOperationException($"Incorrect on page count: {onPage}");
            }

            PageNumber = pageNumber;
            OnPage = onPage;
        }

        [DataMember(Name = "pageNumber")]
        public int PageNumber { get; set; }

        [DataMember(Name = "onPage")]
        public int OnPage { get; set; }

        [DataMember(Name = "searchString")]
        public string SearchString { get; set; }

        public int Skip()
        {
            return (PageNumber - 1) * OnPage;
        }

        public int Take()
        {
            return OnPage;
        }
    }
}
