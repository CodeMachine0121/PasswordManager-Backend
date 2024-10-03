using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services.Interfaces;

namespace PasswordManager.Controllers;

[Route("api/[controller]")]
public class PasswordController(IPasswordService passwordService) : ControllerBase
{
    [HttpGet("/domain/{domain}")]
    public async Task<ApiResponse> GetByDomain(string domain)
    {
        var passwords = await passwordService.GetByDomainName(domain);
        return ApiResponse.SuccessWithData(passwords);
    }
}