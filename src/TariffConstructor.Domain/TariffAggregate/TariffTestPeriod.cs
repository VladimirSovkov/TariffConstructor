using System;
using System.Collections.Generic;
using TariffConstructor.Domain.ValueObjects;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.TariffAggregate
{
    public class TariffTestPeriod : ValueObject<TariffTestPeriod>
    {
        public int Value { get; private set; }

        public TariffTestPeriodUnit Unit { get; private set; }

        public TariffTestPeriod( int value
            , TariffTestPeriodUnit unit 
            )
        {
            if ( value == 0 )
            {
                throw new InvalidOperationException( "Must specify period value" );
            }
            Value = value;
            Unit = unit;
        }

        public bool IsEmpty()
        {
            return Value == default(int) && Unit == default(TariffTestPeriodUnit);
        }

        public static TariffTestPeriod Empty()
        {
            return new TariffTestPeriod();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }

        protected TariffTestPeriod()
        {
        }
    }
}
