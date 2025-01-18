using JricaStudioWebApi.Extentions;
using JricaStudioWebApi.Repositories.Contracts;
using JricaStudioWebApi.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using JricaStudioSharedLibrary.Dtos;
using JricaStudioWebApi.Attributes;
using JricaStudioSharedLibrary.Dtos.Admin;

namespace JricaStudioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailSenderService _emailSenderService;

        public UserController(IUserRepository userRepository, IEmailSenderService emailSenderService)
        {
            _userRepository = userRepository;
            _emailSenderService = emailSenderService;
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UserDto>> DisposeTemporaryUser(Guid id)
        {
            try
            {
                var user = await _userRepository.DeleteTemporaryUser(id);

                if (user == null)
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Not a temporary user.");
                }

                var userDto = user.ConvertToDto();

                return userDto;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<UserIndemnityDto>> SignIn(UserSignInDto dto)
        {
            try
            {

                var user = await _userRepository.SignIn(dto);

                if (user == null)
                {
                    return NotFound();
                }

                var userDto = user.ConvertToIndemnityDto();

                return Ok(userDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<AdminUserDetailsDto>>> SearchUsers(UserFilterDto filter)
        {
            try
            {
                var users = await _userRepository.SearchUsers(filter);

                if (users == null) { return StatusCode(StatusCodes.Status204NoContent); }

                return Ok(users.ConvertToAdminDetailsDtos());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Post(UserToAddDto userDto)
        {
            try
            {



                var user = await _userRepository.CreateNew(userDto);

                if (user == null)
                {
                    throw new Exception("An Error has occurred when trying to Create the Resource.");
                }

                var userDtoResult = user.ConvertToDto();

                return CreatedAtAction(nameof(Get), new { Id = userDtoResult.Id }, userDtoResult);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpPost("contact")]
        public async Task<ActionResult<ContactFormResult>> PostUserContact(ContactFormSubmitDto dto)
        {
            try
            {
                var htmlMessage = "<html>" +
                    "<body>" +
                        "<div>" +
                            $"A new contact message made thought Website portal" +
                            $"<br/>" +
                            $"Name: {dto.Name}" +
                            $"<br/>" +
                            $"Email: {dto.Email}" +
                            $"<br/>" +
                            $"Subject: {dto.Subject}" +
                            $"<br/>" +
                            $"Message: {dto.Message}" +
                        "</div>" +
                        "<br>" +
                        "<a href=\"https://www.JRicaStudio.com/Login\">" +
                            $" JricaStudio.com/Login" +
                        "</a>" +
                    "</body>" +
                "</html>";

                await _emailSenderService.SendContactEmail(dto.Email, $"New User Contact, Subject:{dto.Subject}", htmlMessage);

                await _emailSenderService.SentConfirmContactMadeEmail(dto.Email, "Thank you", "<html>" +
                    "<body>" +
                        "<div>" +
                            $" Thank you for submitting a message on our contact form. <br/> Your message has been received and  we will reach out to you as soon as possible." +
                        "</div>" +
                        "<br>" +
                    "</body>" +
                "</html>");

                return Ok(new ContactFormResult
                {
                    Email = dto.Email,
                    IsSuccessful = true,
                });

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPost("Admin")]
        public async Task<ActionResult<AdminUserDto>> Post(UserAdminAddDto userDto)
        {
            try
            {
                if (!userDto.Validate())
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "User Data Failed Validation");
                }

                var result = await _userRepository.CreateNew(userDto);

                if (result == null)
                {
                    throw new Exception("An Error has occurred when trying to Create the Resource.");
                }


                var userDtoResult = result.ConvertToAdminDto();

                return CreatedAtAction(nameof(Get), new { Id = userDtoResult.Id }, userDtoResult);
            }
            catch (InvalidOperationException ope)
            {
                if (ope.Message == "Sequence contains more than one element.")
                {
                    return StatusCode(StatusCodes.Status409Conflict, ope.Message);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }


        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> Get(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NoContent();
                }


                var userDto = user.ConvertToDto();

                return Ok(userDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Indemnity/{id:guid}")]
        public async Task<ActionResult<UserIndemnityDto>> GetuserIndemnity(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NoContent();
                }

                var userDto = user.ConvertToIndemnityDto();

                return Ok(userDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut("Indemnity")]
        public async Task<ActionResult<UserIndemnityDto>> Put(UpdateUserDto userUpdateDto)
        {
            try
            {
                var user = await _userRepository.UpdateUser(userUpdateDto);

                if (user == null)
                {
                    return NotFound();
                }

                var userDto = user.ConvertToDto();

                return Ok(userDto);
            }

            catch (InvalidOperationException oe)
            {
                return StatusCode(StatusCodes.Status409Conflict, oe.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpGet("Waiver/{id:guid}")]
        public async Task<ActionResult<UserWaiverDto>> GetUserWaiver(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NoContent();
                }



                var userDto = user.ConvertToWaiverDto();

                return Ok(userDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("Waiver")]
        public async Task<ActionResult<UserWaiverDto>> PatchAcceptWaiver(UserWaiverPatchDto patchDto)
        {
            if (patchDto.IsAccepted)
            {
                try
                {
                    var user = await _userRepository.UpdateUserWaiver(patchDto.Id, patchDto.IsAccepted);

                    if (user == null)
                    {
                        return NotFound();
                    }



                    var userDto = user.ConvertToWaiverDto();

                    return Ok(userDto);
                }
                catch (Exception e)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
                }

            }
            return BadRequest();
        }

        [AdminKey]
        [HttpDelete("admin/{id:guid}")]
        public async Task<ActionResult<UserDto>> DeleteUserById(Guid id)
        {
            try
            {
                var user = await _userRepository.DeleteUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                var dto = user.ConvertToDto();

                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpGet("admin/{id:guid}")]
        public async Task<ActionResult<AdminUserDto>> GetAdminUser(Guid id)
        {
            try
            {
                var user = await _userRepository.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                var dto = user.ConvertToAdminDto();

                return Ok(dto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult<AdminUserDto>> UpdateUser(Guid id, UpdateUserDto dto)
        {
            try
            {
                var user = await _userRepository.UpdateUserById(id, dto);

                if (user == null)
                {
                    return NotFound();
                }

                var adminDto = user.ConvertToAdminDto();

                return Ok(dto);
            }
            catch (ArgumentException ae)
            {
                return Conflict(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
