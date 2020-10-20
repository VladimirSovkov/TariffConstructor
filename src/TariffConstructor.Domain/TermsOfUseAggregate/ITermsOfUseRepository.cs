using System.Threading.Tasks;

namespace TariffConstructor.Domain.TermsOfUseAggregate
{
    public interface ITermsOfUseRepository
    {
        Task<TermsOfUse[]> GetTermsOfUse( params int[] termsOfUseIds );

        Task<TermsOfUse> GetTermsOfUse( int termsOfUseId );
    }
}
