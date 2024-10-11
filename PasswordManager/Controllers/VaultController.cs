using Microsoft.AspNetCore.Mvc;
using PasswordManager.Apis.Interfaces;
using PasswordManager.Models;

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
    
}