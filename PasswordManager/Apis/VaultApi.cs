using PasswordManager.Apis.Interfaces;
using PasswordManager.Models.Dtos;
using VaultSharp;

namespace PasswordManager.Apis;

public class VaultApi(IVaultClient vaultClient): IVaultApi
{
    public async Task FirstInsertSecretAsync(PasswordDto dto)
    {
        await vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync($"{dto.DomainName}",
            new Dictionary<string, object>
            {
                { dto.AccountName, dto.Password }
            }, mountPoint: "secret");
    }

    public async Task<bool> IsDataExist(string domainName)
    {
        try
        {
            await GetByAsync(domainName);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task InsertSecretAsync(PasswordDto dto)
    {
        var secretData = await GetByAsync(dto.DomainName);
        secretData.Add(dto.AccountName, dto.Password);
            
        await vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync($"{dto.DomainName}", secretData, mountPoint: "secret");
    }

    public async Task<IDictionary<string, object>> GetByAsync(string domainName)
    {
        var secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync($"{domainName}", mountPoint: "secret");
        return secret.Data.Data;
    }

    public async Task DeleteSecretAsync(PasswordDto dto)
    {
        var originalSecret = await GetByAsync(dto.DomainName);
        originalSecret.Remove(dto.AccountName);
        await vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync($"{dto.DomainName}", originalSecret, mountPoint: "secret");
    }

    public async Task UpdateSecretAsync(PasswordDto dto)
    {
        var originalSecret = await GetByAsync(dto.DomainName);
        originalSecret[dto.AccountName] = dto.Password;
        await vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync($"{dto.DomainName}", originalSecret, mountPoint: "secret");
    }
}