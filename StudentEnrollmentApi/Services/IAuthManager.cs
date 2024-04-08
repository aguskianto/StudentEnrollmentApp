using Microsoft.AspNetCore.Identity;
using StudentEnrollmentApi.DTOs.Authentication;

namespace StudentEnrollmentApi.Services
{
    public interface IAuthManager
    {
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<IEnumerable<IdentityError>> Register(RegisterDto registerDto);
    }
}
