using Microsoft.AspNetCore.Mvc;
using PasswordManager.Models;
using PasswordManager.Models.Dtos;
using PasswordManager.Models.Requests;
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
    
    [HttpPost("/domain/{domainName}")]
    public async Task<ApiResponse> Insert(string domainName, [FromBody] PasswordRecordRequest request)
    {
        await passwordRecordService.Insert(new PasswordDto
        {
            DomainName = domainName,
            AccountName= request.AccountName,
            Password = request.Password
        });
        
        return ApiResponse.Success();
    }
}