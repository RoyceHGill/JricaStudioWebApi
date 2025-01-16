using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Entities;

namespace JricaStudioWebApi.Repositories.Contracts
{
    public interface IPolicyRepository
    {
        /// <summary>
        /// Add a policy to the database.
        /// </summary>
        /// <param name="addPolicyDto">Police Details</param>
        /// <returns>The created policy.</returns>
        Task<Policy?> CreatePolicy(AddPolicyDto addPolicyDto);

        /// <summary>
        /// Remove a policy from the database.
        /// </summary>
        /// <param name="id">A policies Id</param>
        /// <returns>The affected policy.</returns>
        Task<Policy?> DeletePolicy(Guid id);

        /// <summary>
        /// Get all existing policies, for populating the policy page of the website.
        /// </summary>
        /// <returns>Collection of policy objects.</returns>
        Task<IEnumerable<Policy>?> GetPolicies();
    }
}
