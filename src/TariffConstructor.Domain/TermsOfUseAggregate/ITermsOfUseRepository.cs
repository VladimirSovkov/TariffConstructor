using System.Threading.Tasks;

namespace Billing.Services.Ordering.Domain.Marketing.TermsOfUseAggregate
{
    public interface ITermsOfUseRepository
    {
        Task<TermsOfUse[]> GetTermsOfUse( params int[] termsOfUseIds );

        Task<TermsOfUse> GetTermsOfUse( int termsOfUseId );
    }
}
