using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ApplicationModel;

namespace TariffConstructor.AdminApi.Modules.ApplicationModule
{
    public static class ApplicationMap
    {
        public static ApplicationDto Map(this Application application)
        {
            if (application == null)
            {
                return null;
            }
            else
            {
                return new ApplicationDto
                {
                    Id = application.Id,
                    PublicId = application.PublicId,
                    Name = application.Name
                };
            }
        }

        public static IReadOnlyList<ApplicationDto> Map(this IEnumerable<Application> applications)
        {
            return applications == null ? new List<ApplicationDto>() : applications.Select(Map).ToList();
        }
    }
}
