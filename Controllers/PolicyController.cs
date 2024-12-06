using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Attributes;
using JricaStudioWebApi.Extentions;
using JricaStudioWebApi.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JricaStudioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyController(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        [AdminKey]
        [HttpPost]
        public async Task<ActionResult<PolicyAdminDto>> PostPolicy(AddPolicyDto addPolicyDto)
        {
            try
            {
                var policy = await _policyRepository.CreatePolicy(addPolicyDto);

                if (policy == null)
                {
                    return BadRequest();
                }

                var policyDto = policy.ConvertToAdminDto();

                return Ok(policyDto);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PolicyAdminDto>> DeletePolicy(Guid id)
        {
            try
            {
                var policy = await _policyRepository.DeletePolicy(id);

                if (policy == null)
                {
                    return NotFound();
                }

                var policyDto = policy.ConvertToAdminDto();

                return Ok(policyDto);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<PolicyDto>> GetPolices()
        {
            try
            {
                var policies = await _policyRepository.GetPolicies();

                if (policies == null)
                {
                    return NoContent();
                }

                var policyDtos = policies.ConvertToDtos();

                return Ok(policyDtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpGet("admin")]
        public async Task<ActionResult<IEnumerable<PolicyAdminDto>>> GetAdministratorPolicies()
        {
            try
            {
                var policies = await _policyRepository.GetPolicies();

                if (policies == null)
                {
                    return NoContent();
                }

                var policyDtos = policies.ConvertToDtos();

                return Ok(policyDtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
