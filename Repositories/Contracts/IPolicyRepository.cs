using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IPolicyRepository
    {
        Task<Policy?> CreatePolicy(AddPolicyDto addPolicyDto);
        Task<Policy?> DeletePolicy(Guid id);
        Task<IEnumerable<Policy>?> GetPolicies();
    }
}
