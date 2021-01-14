﻿using System.Collections.Generic;
using System.Linq;
using TariffConstructor.AdminApi.Dto.TermsOfUse;
using TariffConstructor.Domain.TermsOfUseAggregate;

namespace TariffConstructor.AdminApi.Mappers.TermsOfUseMap
{
    public static class TermsOfUseMap
    {
        public static TermsOfUseDto Map(this TermsOfUse termsOfUse)
        {
            if (termsOfUse == null)
            {
                return null;
            }
            else
            {
                return new TermsOfUseDto
                {
                    Id = termsOfUse.Id,
                    PublicId = termsOfUse.PublicId,
                    DocumentName = termsOfUse.DocumentName
                };
            }
        }

        public static IReadOnlyList<TermsOfUseDto> Map(this IEnumerable<TermsOfUse> termsOfUses)
        {
            return termsOfUses == null ? new List<TermsOfUseDto>() : termsOfUses.Select(Map).ToList();
        }

    }
}
