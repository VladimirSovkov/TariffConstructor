using System.Runtime.Serialization;

namespace TariffConstructor.AdminApi.Dto.ValueObject
{
    [DataContract]
    public class ProlongationPeriodDto
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "periodUnit")]
        public int periodUnit { get; set; }
    }
}
