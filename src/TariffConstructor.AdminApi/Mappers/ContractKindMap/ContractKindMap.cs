﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TariffConstructor.AdminApi.Dto.ContractKind;
using TariffConstructor.Domain.ContractKindModel;

namespace TariffConstructor.AdminApi.Mappers.ContractKindMap
{
    public static class ContractKindMap
    {
        public static ContractKindDto Map(this ContractKind contractKind)
        {
            if (contractKind == null)
            {
                return null;
            }
            else
            {
                return new ContractKindDto
                {
                    Id = contractKind.Id,
                    Name = contractKind.Name,
                    PublicId = contractKind.PublicId,
                };
            }
        }

        public static IReadOnlyList<ContractKindDto> Map(this IEnumerable<ContractKind> contractKinds)
        {
            return contractKinds == null ? new List<ContractKindDto>() : contractKinds.Select(Map).ToList();
        }
    }
}
