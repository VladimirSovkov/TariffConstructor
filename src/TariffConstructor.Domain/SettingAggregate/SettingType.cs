namespace TariffConstructor.Domain.SettingAggregate
    public enum SettingType
    {
        Unknown = 0,
        AccumulativeInteger = 1,
        AccumulativeBoolean = 2,
        ExclusiveInteger = 3,
        ExclusiveBoolean = 4,
        AccumulativeMultiEnum = 5,
        AccumulativeMoney = 6,
        ExclusiveEnum = 7,
        ExclusiveString = 8
    }
}
