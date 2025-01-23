// Ignore Spelling: Jrica

using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioWebAPI.Entities;

namespace JricaStudioWebAPI.Repositories.Contracts
{
    public interface IPolicyRepository
    {

        #region Create
        /// <summary>
        /// Add a policy to the database.
        /// </summary>
        /// <param name="addPolicyDto">Police Details</param>
        /// <returns>The created policy.</returns>
        Task<Policy?> CreatePolicy(AddPolicyDto addPolicyDto);

        #endregion

        #region Read
        /// <summary>
        /// Get all existing policies, for populating the policy page of the website.
        /// </summary>
        /// <returns>Collection of policy objects.</returns>
        Task<IEnumerable<Policy>?> GetPolicies();
        #endregion

        #region Update

        #endregion

        #region Delete
        /// <summary>
        /// Remove a policy from the database.
        /// </summary>
        /// <param name="id">A policies Id</param>
        /// <returns>The affected policy.</returns>
        Task<Policy?> DeletePolicy(Guid id);
        #endregion
    }
}
