using System.Collections.Generic;

namespace Billing.Services.Ordering.Domain.Subscriptions.Settings
{
    public interface ISettingsContainer
    {
        /// <summary>
        ///     Возвращает настройки приложения в формате JSON
        /// </summary>
        /// <returns>JSON строка</returns>
        string ToJson();

        /// <summary>
        ///     Возвращает настройки приложения в формате Dictionary
        /// </summary>
        /// <returns></returns>
        IDictionary<string, object> ToDictionary();
    }
}
