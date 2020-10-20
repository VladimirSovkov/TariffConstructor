using TariffConstructor.Domain.Abstractions;
using TariffConstructor.Toolkit.Aggregate;

namespace Billing.Services.Ordering.Domain.Marketing.TermsOfUseAggregate
{
    public class TermsOfUse : Entity, IAggregateRoot
    {
        public TermsOfUse( string publicId, string documentName )
        {
            PublicId = publicId;
            DocumentName = documentName;
        }

        public string PublicId { get; private set; }

        public string DocumentName { get; private set; }

        protected TermsOfUse()
        {
        }
    }
}
