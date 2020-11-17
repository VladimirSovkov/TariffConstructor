using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace TariffConstructor.Infrastructure.Data
{
    public class DateTimeNowGenerator : ValueGenerator<DateTime>
    {
        public override DateTime Next(EntityEntry entry)
        {
            return DateTime.Now;
        }

        public override bool GeneratesTemporaryValues { get; } = false;
    }
}
