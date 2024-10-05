using Microsoft.EntityFrameworkCore;
using PasswordManager.DataBases;
using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Models.Entities;
using PasswordManager.Repository.Interfaces;
using VaultSharp;

namespace PasswordManager.Repository;

public class PasswordRepository(PasswordManagerDbContext dbContext, IVaultClient vaultClient) : IPasswordRepository
{
    private readonly DbSet<AccountRecord> _accountRecord = dbContext.AccountRecord;

    public async Task<PasswordDomain> GetBy(PasswordDto dto)
    {
        var accountRecord = await _accountRecord.FirstAsync(x => x.DomainName == dto.DomainName);
        
        var secret = await vaultClient.V1.Secrets.KeyValue.V2.ReadSecretAsync($"{accountRecord.DomainName}");

        return new PasswordDomain()
        {
            DomainName = dto.DomainName,
            AccountName = accountRecord.AccountName,
            Password = secret.Data.Data[accountRecord.AccountName].ToString()!
        };
    }

    public Task Insert(PasswordDto dto)
    {
        throw new NotImplementedException();
    }
}