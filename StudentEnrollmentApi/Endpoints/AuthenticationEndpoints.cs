using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using StudentEnrollmentApi.DTOs.Course;
using StudentEnrollmentData.Contracts;
using StudentEnrollmentData;
using StudentEnrollmentApi.DTOs.Authentication;
using Microsoft.AspNetCore.Identity;
using StudentEnrollmentApi.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
using StudentEnrollmentApi.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace StudentEnrollmentApi.Endpoints
{
    public static class AuthenticationEndpoints
    {
        public static void MapAuthenticationEndpoints(this IEndpointRouteBuilder routes)
        {
            // UserManager<SchoolUser> userManager
            routes.MapPost("/api/login/", [AllowAnonymous] async Task<Results<Ok<AuthResponseDto>, UnauthorizedHttpResult>> (LoginDto loginDto, IAuthManager authManager) =>
            {
                //var user = await userManager.FindByEmailAsync(loginDto.EmailAddress);

                //bool isValidCredential = await userManager.CheckPasswordAsync(user, loginDto.Password);

                //if (user is null || !isValidCredential)
                //{
                //    return TypedResults.Unauthorized();
                //}

                // generate token here

                //return TypedResults.Ok();

                var response = await authManager.Login(loginDto);

                if (response is null)
                {
                    return TypedResults.Unauthorized();
                }

                return TypedResults.Ok(response);
            })
            .WithTags("Authentication")
            .WithName("Login");

            routes.MapPost("/api/register/", [AllowAnonymous] async Task<Results<Ok, BadRequest<List<ErrorResponseDto>>>> (RegisterDto registerDto, IAuthManager authManager) => {
                var response = await authManager.Register(registerDto);

                if (!response.Any())
                {
                    return TypedResults.Ok();
                }

                var errors = new List<ErrorResponseDto>();

                foreach (var error in response)
                {
                    errors.Add(new ErrorResponseDto
                    {
                        Code = error.Code,
                        Description = error.Description
                    });
                }

                return TypedResults.BadRequest(errors);
            })
            .WithTags("Authentication")
            .WithName("Register");
        }
    }
}
