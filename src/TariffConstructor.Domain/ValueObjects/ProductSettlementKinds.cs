using System;

namespace TariffConstructor.Domain.ValueObjects
{
    [Flags]
    public enum ProductSettlementKinds : byte
    {
        Subscription = 1 << 0,      // 1
        Commission = 1 << 1,        // 2
        Acquiring = 1 << 2,         // 4
    }
}
