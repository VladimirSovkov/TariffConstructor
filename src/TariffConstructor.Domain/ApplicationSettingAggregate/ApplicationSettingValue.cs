using System;
using TariffConstructor.Domain.Abstractions;

namespace TariffConstructor.Domain.ApplicationSettingAggregate
{
    public class ApplicationSettingValue : Entity
    {
        public ApplicationSettingValue(
            string value )
        {
            Value = value;
        }

        public int ApplicationSettingId { get; private set; }
        public virtual ApplicationSetting ApplicationSetting { get; private set; }
        public string Value { get; private set; }
        public DateTime CreationDate { get; private set; }

        protected ApplicationSettingValue()
        {
        }
    }
}
