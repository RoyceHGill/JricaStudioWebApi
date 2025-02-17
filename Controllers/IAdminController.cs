using JricaStudioSharedLibrary.Dtos.Admin;
using Microsoft.AspNetCore.Mvc;

namespace JricaStudioWebAPI.Controllers
{
    public interface IAdminController
    {
        Task<ActionResult<AdminUserLoginDto>> Login( AdminLoginRequestDto dto );
        Task<ActionResult> ResetPassword( [FromHeader] Guid requestKey, [FromBody] ResetPasswordDto dto );
        Task<ActionResult> ResetRequest( PasswordResetRequestDto dto );
        Task<ActionResult<AdminUserLoginDto>> UpdateAdmin( Guid id );
        Task<ActionResult<AdminUserLoginDto>> UpdateAdmin( Guid id, UserCredentialsUpdateDto dto );
    }
}