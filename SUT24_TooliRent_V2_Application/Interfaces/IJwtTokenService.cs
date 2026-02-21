using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SUT24_TooliRent_V2_Application.DTOs.AuthDTOs;
using SUT24_TooliRent_V2_Domain;

namespace SUT24_TooliRent_V2_Application.Interfaces;

public interface IJwtTokenService
{
    Task<AuthTokenResult> GenerateTokenAsync(AuthUserDto user);
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}