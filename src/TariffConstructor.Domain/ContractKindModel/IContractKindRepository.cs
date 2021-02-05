using System.Collections.Generic;
using System.Threading.Tasks;
using TariffConstructor.Toolkit.Abstractions;
using TariffConstructor.Toolkit.Search;

namespace TariffConstructor.Domain.ContractKindModel
{
    public interface IContractKindRepository : IRepository<ContractKind>
    {
        Task<ContractKind> GetContractKind(int id);
        Task<ContractKind> GetContractKind(string publicId);
        Task<List<ContractKind>> GetContractKinds();
        Task<SearchResult<ContractKind>> Search(ContractKindSearchPattern searchPattern);
    }
}
