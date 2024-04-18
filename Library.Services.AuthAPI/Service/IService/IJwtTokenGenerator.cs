using Library.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity.Data;

namespace Library.Services.AuthAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(LoginRequestDto loginRequestDto); 
    }
}
