using System.Collections.Generic;
using TariffConstructor.Toolkit.PageApp;

namespace TariffConstructor.Domain.TariffAggregate.Toolkit
{
    public class TariffPaginator
    {
        public IEnumerable<Tariff> Tariffs { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
