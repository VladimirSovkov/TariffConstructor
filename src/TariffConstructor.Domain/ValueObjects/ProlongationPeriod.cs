using System;
using System.Collections.Generic;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ValueObjects
{
    public class ProlongationPeriod : ValueObject<ProlongationPeriod>
    {
        public static ProlongationPeriod Empty => new ProlongationPeriod();

        public int Value { get; private set; }

        public PeriodUnit Unit { get; private set; }

        public ProlongationPeriod( int value, PeriodUnit unit )
        {
            if ( value == 0 )
            {
                throw new InvalidOperationException( "Must specify prolongation period value" );
            }
            Value = value;
            Unit = unit;
        }

        public override string ToString()
        {
            return $"{Value} {Enum.GetName( typeof( PeriodUnit ), Unit )}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Unit;
        }

        protected ProlongationPeriod()
        {

        }
    }
}
