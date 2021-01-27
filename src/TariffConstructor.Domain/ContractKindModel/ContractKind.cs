using System;
using TariffConstructor.Toolkit.Abstractions;

namespace TariffConstructor.Domain.ContractKindModel
{
    public class ContractKind : Entity, IAggregateRoot
    {
        public ContractKind(string publicId,
            string name)
        {
            PublicId = publicId;
            Name = name;
        }
        public string PublicId { get; private set; }

        public string Name { get; private set; }

        public DateTime CreationDate { get; private set; }

        public void SetPublicId(string publicId)
        {
            PublicId = publicId;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        protected ContractKind()
        {

        }
    }
}
