using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ApplicationSettingAggregate;
using TariffConstructor.Domain.BillingSettingAggregate;
using TariffConstructor.Domain.Settings;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;

namespace TariffConstructor.Domain.SettingAggregate
{
    /// <summary>
    ///     Агрегат, представляющий шаблон настроек со значениями по-умолчанию и границами допустимых значений.
    /// </summary>
    public class SettingsPreset : Entity, IAggregateRoot
    {
        public SettingsPreset( string name )
        {
            Name = name;
        }

        public string Name { get; private set; }

        private readonly List<BillingSettingPreset> _billingSettingPresets = new List<BillingSettingPreset>();

        public virtual IReadOnlyCollection<BillingSettingPreset> BillingSettingPresets =>
            _billingSettingPresets.AsReadOnly();

        private readonly List<ApplicationSettingPreset> _applicationSettingPresets =
            new List<ApplicationSettingPreset>();

        public virtual IReadOnlyCollection<ApplicationSettingPreset> ApplicationSettingPresets =>
            _applicationSettingPresets.AsReadOnly();

        /// <summary>
        ///     Создает на основе текущего пресета готовый вариант настроек с переопределенными значениями по-умолчанию
        /// </summary>
        /// <param name="redefinitions">Переопределения значений по-умолчанию для настроек</param>
        /// <returns>Собранный и готовый к использованию объект настроек</returns>
        /// <exception cref="InvariantViolationException">Когда новое значение настройки не вписывается 
        /// в заданные рамки текущего пресета</exception>
        public SettingsSet Make( SettingRedefinition[] redefinitions = null )
        {
            SettingsSet set = new SettingsSet();

            AddSettingsSet( 
                BillingSettingPresets,
                redefinitions,
                ( settingId, value ) => set.AddBillingSettingSet( settingId, value ) );

            AddSettingsSet(
                ApplicationSettingPresets,
                redefinitions,
                ( settingId, value ) => set.AddApplicationSettingSet( settingId, value ) );

            return set;
        }

        public void AddBillingSettingPreset( BillingSettingPreset billingSettingPreset )
        {
            if ( _billingSettingPresets.Any( x => x.BillingSettingId == billingSettingPreset.BillingSettingId ) )
            {
                throw new InvariantViolationException(
                    ValidationMessage.AlreadyExists( $"Billing setting [id:{billingSettingPreset.BillingSettingId}]" ) );
            }

            _billingSettingPresets.Add( billingSettingPreset );
        }

        public void AddApplicationSettingPreset( ApplicationSettingPreset applicationSettingPreset )
        {
            if ( _applicationSettingPresets.Any( x => x.ApplicationSettingId == applicationSettingPreset.ApplicationSettingId ) )
            {
                throw new InvariantViolationException(
                    ValidationMessage.AlreadyExists( $"Application setting [id:{applicationSettingPreset.ApplicationSettingId}]" ) );
            }

            _applicationSettingPresets.Add( applicationSettingPreset );
        }

        private static void AddSettingsSet( 
            IEnumerable<ISettingPreset> settingPresets,
            SettingRedefinition[] redefinitions,
            Action<int, string> addSettingAction )
        {
            foreach ( ISettingPreset settingPreset in settingPresets )
            {
                SettingRedefinition redefinition =
                    redefinitions?.FirstOrDefault( x =>
                        x.SettingPublicId == settingPreset.SettingPublicId );

                if ( redefinition != null )
                {
                    SettingImplement settingImplement = new SettingImplement(
                        settingPreset.Setting.Type,
                        settingPreset.Setting.Code,
                        redefinition.NewValue );

                    if ( !settingImplement.IsValid(
                        settingPreset.Value.MinValue,
                        settingPreset.Value.MaxValue,
                        settingPreset.IsRequired ) )
                    {
                        throw new InvariantViolationException(
                            $"Invalid value definition ('{redefinition.NewValue}') " +
                            $"for settings preset ({settingPreset.GetSettingPresetType()}:'{settingPreset.PresetId}'," +
                            $"min:'{settingPreset.Value.MinValue}',max:'{settingPreset.Value.MaxValue}')",
                            SettingsPresetErrorCode.SettingValueDefinitionIsInvalid );
                    }
                }

                string value = redefinition != null
                    ? redefinition.NewValue
                    : settingPreset.Value.DefaultValue;

                addSettingAction( settingPreset.SettingId, value );
            }
        }

        protected SettingsPreset()
        {
        }
    }
}
