using PasswordManager.Models.Dtos;

namespace PasswordManager.Apis.Interfaces;

public interface IVaultApi
{
    Task FirstInsertSecretAsync(PasswordDto dto);
    Task<bool> IsDataExist(string domainName);
    Task InsertSecretAsync(PasswordDto dto);
    Task<IDictionary<string, object>> GetBy(string domainName);
    Task DeleteSecretAsync(string domainName);
}