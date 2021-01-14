﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.SearchPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.ApplicationModel
{
    public interface IApplicationRepository : IRepository<Application>
    {
        Task<Application> GetApplication(int id);
        Task<List<Application>> GetApplications();
        Task<SearchResult<Application>> Search(ApplicationSearchPattern searchPattern);
    }
}
