using System.Collections.Generic;

namespace TariffConstructor.Toolkit.Abstractions
{
    public class ValueObject<T>
    {
        virtual protected IEnumerable<object> GetEqualityComponents()
        {
            return new List<object>();
        }
    }
}
