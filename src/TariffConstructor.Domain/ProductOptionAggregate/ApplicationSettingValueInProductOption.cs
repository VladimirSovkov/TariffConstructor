using TariffConstructor.Domain.ApplicationSettingAggregate;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ProductOptionAggregate
{
    public class ApplicationSettingValueInProductOption : Entity
    {
        public ApplicationSettingValueInProductOption(int applicationSettingValueId)
        {
            ApplicationSettingValueId = applicationSettingValueId;
        }

        public int ApplicationSettingValueId { get; private set; }
        public virtual ApplicationSettingValue ApplicationSettingValue { get; private set; }

        protected ApplicationSettingValueInProductOption()
        {
        }
    }
}
