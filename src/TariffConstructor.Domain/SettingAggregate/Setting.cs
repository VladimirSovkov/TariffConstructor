using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;

namespace TariffConstructor.Domain.SettingAggregate
{
    /// <summary>
    ///     Агрегат, представляющий абстрактную настройку с определенными характеристиками
    /// </summary>
    public class Setting : Entity, IAggregateRoot
    {
        public Setting( 
            SettingType type, 
            string code, 
            string name, 
            bool isComputing = false,
            string description = null )
        {
            Type = type;
            Code = code;
            Name = name;
            IsComputing = isComputing;
            Description = description;
        }

        public SettingType Type { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool IsComputing { get; private set; }
        public DateTime CreationDate { get; private set; }

        private readonly List<SettingEnumValue> _enumValues = new List<SettingEnumValue>();

        public virtual IReadOnlyCollection<SettingEnumValue> EnumValues =>
            _enumValues.AsReadOnly();

        public void AddEnumValue( string valueCode, string valueName )
        {
            if ( _enumValues.Any( x => x.Code == valueCode ) )
            {
                throw new InvariantViolationException( ValidationMessage.AlreadyExists( $"'{valueCode}' value" ) );
            }

            _enumValues.Add( new SettingEnumValue( valueCode, valueName ) );
        }

        protected Setting()
        {
        }
    }
}
