namespace TariffConstructor.Toolkit.Abstractions
{
    public abstract class MultitenancyEntity : Entity
    {
        public int TenantId { get; set; }
    }
}
