using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.TariffAggragate
{
    [DataContract]
    public class TariffTestPeriodDto
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "unit")]
        public int Unit { get; set; }
    }
}
