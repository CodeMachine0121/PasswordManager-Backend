using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Services.Interfaces;

namespace PasswordManager.Controllers;

[Route("api/[controller]")]
public class PasswordRecordController(IPasswordRecordService passwordRecordService) : ControllerBase
{
    [HttpGet("/domain/{domainName}")]
    public async Task<ApiResponse> GetByDomainName(string domainName)
    {
        var passwords = await passwordRecordService.GetByDomainName(domainName);
        return ApiResponse.SuccessWithData(passwords);
    }
}
