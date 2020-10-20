using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.Abstractions;
using Billing.Services.Ordering.Domain.Subscriptions.SettingAggregate;
using TariffConstructor.Toolkit.Aggregate;

namespace TariffConstructor.Domain.ApplicationSettingAggregate
{
    /// <summary>
    ///     Агрегат, связывающий абстрактную настройку с настройкой определенного приложения
    /// </summary>
    public class ApplicationSetting : Entity, IAggregateRoot
    {
        public ApplicationSetting( 
            int applicationId, 
            int settingId, 
            string[] values = null,
            string publicId = null )
        {
            ApplicationId = applicationId;
            SettingId = settingId;

            if ( values != null )
            {
                foreach ( string value in values )
                {
                    AddValue( value );
                }
            }

            PublicId = String.IsNullOrEmpty( publicId ) ? Guid.NewGuid().ToString() : publicId;
        }

        public int ApplicationId { get; private set; }
        public int SettingId { get; private set; }
        public string DefaultValue { get; private set; }
        public virtual Setting Setting { get; protected set; }
        public DateTime CreationDate { get; private set; }
        public string PublicId { get; private set; }

        private readonly List<ApplicationSettingValue> _settingValues =
            new List<ApplicationSettingValue>();

        public virtual IReadOnlyCollection<ApplicationSettingValue> SettingValues =>
            _settingValues.AsReadOnly();

        public void AddValue( string value )
        {
            if ( _settingValues.Any( x => x.Value == value ) )
            {
                return;
            }

            _settingValues.Add( new ApplicationSettingValue( value ) );
        }

        protected ApplicationSetting()
        {
        }
    }
}
