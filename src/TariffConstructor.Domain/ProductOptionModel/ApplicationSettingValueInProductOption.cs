using TariffConstructor.Domain.ApplicationSettingModel;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ProductOptionModel
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
