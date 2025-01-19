
using JricaStudioWebAPI.Models.Dtos.Admin;
using JricaStudioWebAPI.Attributes;
using JricaStudioWebAPI.Extentions;
using JricaStudioWebAPI.Repositories.Contracts;
using JricaStudioWebAPI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace JricaStudioWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdministratorRepository _adminRepository;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IConfiguration _configuration;

        public AdminController(IAdministratorRepository adminRepository, IHttpContextAccessor httpContext, IEmailSenderService emailSenderService, IConfiguration configuration)
        {
            _adminRepository = adminRepository;
            _httpContext = httpContext;
            _emailSenderService = emailSenderService;
            _configuration = configuration;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<AdminUserLoginDto>> Login(AdminLoginRequestDto dto)
        {
            try
            {

                var admin = await _adminRepository.GetAdministratorUser(dto.Username);

                if (admin == null)
                {
                    return Unauthorized();
                }

                if (BCrypt.Net.BCrypt.Verify(dto.Password, admin.Password))
                {
                    return admin.ConvertToDto();
                }

                return Unauthorized();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPatch("update/{id:guid}")]
        public async Task<ActionResult<AdminUserLoginDto>> UpdateAdmin(Guid id, UserCredentialsUpdateDto dto)
        {
            try
            {
                var validation = ValidatePassword(dto.NewPassword);

                if (validation != null)
                {
                    return BadRequest(string.Join(", ", validation));
                }

                var admin = await _adminRepository.UpdatePassword(id, dto);

                if (admin == null)
                {
                    return Unauthorized();
                }

                var loginDto = admin.ConvertToDto();

                return loginDto;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdministratorKey]
        [HttpGet("re-verification/{id:guid}")]
        public async Task<ActionResult<AdminUserLoginDto>> UpdateAdmin(Guid id)
        {
            try
            {
                var admin = await _adminRepository.GetAdministratorUser(id);

                if (admin == null)
                {
                    throw new NullReferenceException();
                }

                return admin.ConvertToDto();

            }
            catch (NullReferenceException ne)
            {
                return StatusCode(StatusCodes.Status404NotFound, ne.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpPost("passwordresetrequest")]
        public async Task<ActionResult> ResetRequest(PasswordResetRequestDto dto)
        {
            try
            {
                var admin = await _adminRepository.GetAdministratorUser(dto.Email);

                if (admin == null)
                {
                    return Unauthorized();
                }

                var adminNewKey = await _adminRepository.InitiatePasswordReset(dto.Email);


#if DEBUG
                await _emailSenderService.SendResetEmail(adminNewKey.Username, "Jrica.Studio Password Reset",
                "<html>" +
                    "<body>" +
                        "<div>" +
                            $"A request to reset the password for the account at JayricaStudio.com for the user name {adminNewKey.Username} has been submitted. If you did not request you password to be reset please contact your Website administrator for assistance." +
                        "</div>" +
                        "</br>" +
                        "<div>" +
                            $"To reset your password please follow the link below" +
                        "</div>" +
                        "<br>" +
                        $"<a href=\"https://localhost:7247/admin/reset/{adminNewKey.ResetKey}\">" +
                            $"Reset your password here" +
                        "</a>" +
                    "</body>" +
                "</html>");
#else
                await _emailSenderService.SendResetEmail(admin.Username, "Jrica.Studio Password Reset",
                "<html>" +
                    "<body>" +
                        "<div>" +
                            $"A request to reset the password for the account at JayricaStudio.com for the user name {admin.Username} has been submitted. If you did not request you password to be reset please contact your Website administrator for assistance." +
                        "</div>" +
                        "</br>" +
                        "<div>" +
                            $"To reset your password please follow the link below" +
                        "</div>" +
                        "<br>" +
                        $"<a href=\"https://www.JricaStudio.com/admin/reset/{admin.Id}\">" +
                            $" JricaStudio.com/Login" +
                        "</a>" +
                    "</body>" +
                "</html>");
#endif

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("passwordresetrequest")]
        public async Task<ActionResult> ResetPassword([FromHeader] Guid requestKey, [FromBody] ResetPasswordDto dto)
        {
            try
            {
                var validation = ValidatePassword(dto.NewPassword);

                if (validation != null)
                {
                    return BadRequest(string.Join(", ", validation));
                }

                var admin = _adminRepository.UpdatePassword(requestKey, dto);

                if (admin == null)
                {
                    return Unauthorized();
                }

                return Ok();

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        private List<string>? ValidatePassword(string cleanPassword)
        {
            var validationErrors = new List<string>();
            var password = cleanPassword.
                Trim();

            if (string.IsNullOrEmpty(cleanPassword))
            {
                validationErrors.Add("Password can not be null.");
            }

            if (cleanPassword.Equals(cleanPassword.ToLower()))
            {
                validationErrors.Add("Password must contain at least one capital letter.");
            }

            if (cleanPassword.Equals(cleanPassword.ToUpper()))
            {
                validationErrors.Add("Password must contain at least one lowercase letter.");
            }

            if (!cleanPassword.Any(c => char.IsPunctuation(c) || char.IsSymbol(c)))
            {
                validationErrors.Add("Password must contain at least one symbol.");
            }

            if (!cleanPassword.Any(c => char.IsDigit(c)))
            {
                validationErrors.Add("Password must contain at least one number.");
            }

            if (cleanPassword.Length < 7)
            {
                validationErrors.Add("Password must be at least 7 characters long.");
            }

            if (validationErrors.Count() > 0)
            {
                return validationErrors;
            }

            return default;
        }
    }
}
