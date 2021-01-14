﻿using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Domain.PaginationPattern;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Pagination;

namespace TariffConstructor.Domain.ApplicationSettingAggregate
{
    public interface IApplicationSettingRepository : IRepository<ApplicationSetting>
    {
        Task<ApplicationSetting> GetApplicationSetting(int id);
        Task<List<ApplicationSetting>> GetApplicationSettings();
        Task<PaginationResult<ApplicationSetting>>Pagination(ApplicationSettingPaginationPattern searchPattern);
    }
}
