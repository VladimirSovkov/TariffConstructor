using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Domain.BillingSettingModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;

namespace TariffConstructor.Domain.SettingModel
{
    /// <summary>
    ///     Агрегат, представляющий зафиксированный набор настроек приложений и продуктов
    /// </summary>
    public class SettingsSet : Entity, IAggregateRoot
    {
        public SettingsSet( 
            IDictionary<int, string> billingSettingSets = null,
            IDictionary<int, string> applicationSettingSets = null )
        {
            if ( billingSettingSets != null && billingSettingSets.Any() )
            {
                foreach ( var billingSettingSet in billingSettingSets )
                {
                    AddBillingSettingSet( billingSettingSet.Key, billingSettingSet.Value );
                }
            }

            if ( applicationSettingSets != null && applicationSettingSets.Any() )
            {
                foreach ( var applicationSettingSet in applicationSettingSets )
                {
                    AddApplicationSettingSet( applicationSettingSet.Key, applicationSettingSet.Value );
                }
            }
        }

        private readonly List<BillingSettingSet> _billingSettingSets = new List<BillingSettingSet>();

        public virtual IReadOnlyCollection<BillingSettingSet> BillingSettingSets =>
            _billingSettingSets.AsReadOnly();

        private readonly List<ApplicationSettingSet> _applicationSettingSets =
            new List<ApplicationSettingSet>();

        public virtual IReadOnlyCollection<ApplicationSettingSet> ApplicationSettingSets =>
            _applicationSettingSets.AsReadOnly();

        public void AddBillingSettingSet( int billingSettingId, string value )
        {
            if ( _billingSettingSets.Any( x => x.BillingSettingId == billingSettingId ) )
            {
                throw new InvariantViolationException(
                    ValidationMessage.AlreadyExists( $"Billing setting [id:{billingSettingId}]" ) );
            }

            _billingSettingSets.Add( new BillingSettingSet( billingSettingId, value ) );
        }

        public void AddApplicationSettingSet( int applicationSettingId, string value )
        {
            if ( _applicationSettingSets.Any( x => x.ApplicationSettingId == applicationSettingId ) )
            {
                throw new InvariantViolationException(
                    ValidationMessage.AlreadyExists( $"Application setting [id:{applicationSettingId}]" ) );
            }

            _applicationSettingSets.Add( new ApplicationSettingSet( applicationSettingId, value ) );
        }

        protected SettingsSet()
        {
        }
    }
}
