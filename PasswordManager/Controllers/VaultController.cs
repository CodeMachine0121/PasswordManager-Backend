using Microsoft.AspNetCore.Mvc;
using PasswordManager.Apis.Interfaces;
using PasswordManager.Models;
using PasswordManager.Models.Requests;

namespace PasswordManager.Controllers;

[Route("api/[controller]")]
public class VaultController(IVaultApi vaultApi): ControllerBase 
{
    [HttpGet("seal/status")]
    public async Task<ApiResponse> GetSealStatus()
    {
        var sealStatus = await vaultApi.GetSealStatus();
        return ApiResponse.SuccessWithData(sealStatus);
    }
    
    [HttpPost("seal/unseal")]
    public async Task<ApiResponse> Unseal([FromBody] UnsealRequest request)
    {
        await vaultApi.UnsealAsync(request.Key);
        return ApiResponse.Success();
    }
    
}