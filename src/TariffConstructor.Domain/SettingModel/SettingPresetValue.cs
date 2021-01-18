using System;
using System.Collections.Generic;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.SettingModel
{
    public class SettingPresetValue : ValueObject<SettingPresetValue>
    {
        public string DefaultValue { get; private set; }

        public string MinValue { get; private set; }

        public string MaxValue { get; private set; }

        public SettingPresetValue( 
            string defaultValue, 
            string minValue = null, 
            string maxValue = null )
        {
            DefaultValue = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public bool IsEmpty()
        {
            return String.IsNullOrEmpty( DefaultValue ) 
                   && String.IsNullOrEmpty( MinValue ) 
                   && String.IsNullOrEmpty( MaxValue );
        }

        public static SettingPresetValue Empty()
        {
            return new SettingPresetValue( String.Empty, String.Empty, String.Empty );
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DefaultValue;
            yield return MinValue;
            yield return MaxValue;
        }

        protected SettingPresetValue()
        {
        }
    }
}
