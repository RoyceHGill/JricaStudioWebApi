﻿using JricaStudioSharedLibrary.Dtos.Admin;
using JricaStudioWebAPI.Data;
using JricaStudioWebAPI.Entities;
using JricaStudioWebAPI.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace JricaStudioWebAPI.Repositories.SqLite
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly JaysLashesDbContext _dbContext;

        public PolicyRepository(JaysLashesDbContext jaysLashesDbContext)
        {
            _dbContext = jaysLashesDbContext;
        }

        public async Task<Policy?> DeletePolicy(Guid id)
        {
            try
            {
                var policy = await _dbContext.Policies.SingleOrDefaultAsync(p => p.Id == id);

                if (policy == null)
                {
                    return default;
                }

                var result = _dbContext.Policies.Remove(policy);

                await _dbContext.SaveChangesAsync();

                return result.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<Policy>?> GetPolicies()
        {
            try
            {
                var policies = await _dbContext.Policies.ToListAsync();

                if (policies == null || policies.Count == 0 )
                {
                    return default;
                }

                return policies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Policy?> CreatePolicy(AddPolicyDto addPolicyDto)
        {
            try
            {
                var policy = new Policy()
                {
                    PolicyArticle = addPolicyDto.PolicyArticle,
                    PolicyTitle = addPolicyDto.PolicyTitle,
                    Updated = DateTime.UtcNow,
                };

                var result = await _dbContext.Policies.AddAsync(policy);

                return result.Entity;
            }
            catch (Exception)
            {
                return default;
            }

        }
    }
}
