using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ApplicationModel
{
    public class Application : Entity, IAggregateRoot
    {
        public Application(string publicId, string name)
        {
            PublicId = publicId;
            Name = name;
        }

        public string PublicId { get; private set; }
        public string Name { get; private set; }

        public void SetPublicId(string publicId)
        {
            PublicId = publicId;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        protected Application()
        {
        }
    }
}
