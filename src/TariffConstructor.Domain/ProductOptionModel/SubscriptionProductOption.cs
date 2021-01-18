using System;
using System.Collections.Generic;
using System.Linq;
using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Exceptions;

namespace TariffConstructor.Domain.ProductOptionModel
{
    public class SubscriptionProductOption : MultitenancyEntity, IAggregateRoot
    {
        public SubscriptionProductOption(
            int productId,
            string name,
            bool isMultiple,
            string publicId)
        {
            ProductId = productId;
            Name = name;
            IsMultiple = isMultiple;
            PublicId = publicId;
        }

        public string PublicId { get; private set; }
        public string Name { get; private set; }
        public bool IsMultiple { get; private set; }
        public int ProductId { get; private set; }
        //public virtual SubscriptionProduct Product { get; private set; }
        public DateTime CreationDate { get; private set; }

        private readonly List<ApplicationSettingValueInProductOption> _includedApplicationSettings =
            new List<ApplicationSettingValueInProductOption>();

        public virtual IReadOnlyCollection<ApplicationSettingValueInProductOption> IncludedApplicationSettings =>
            _includedApplicationSettings.AsReadOnly();

        public IReadOnlyList<string> CanAddApplicationSetting(ApplicationSettingValue applicationSetting)
        {
            List<string> errors = new List<string>();

            if (applicationSetting == null)
            {
                errors.Add(ValidationMessage.MustSpecify("application setting"));
            }

            return errors;
        }

        public void AddApplicationSetting(ApplicationSettingValue applicationSetting)
        {
            if (CanAddApplicationSetting(applicationSetting).Any())
            {
                throw new InvalidOperationException();
            }

            _includedApplicationSettings.Add(new ApplicationSettingValueInProductOption(applicationSetting.Id));
        }

        protected SubscriptionProductOption()
        {
        }
    }
}
