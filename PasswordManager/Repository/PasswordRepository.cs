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

    public async Task Insert(PasswordDto dto)
    {
        await _accountRecord.AddAsync(new AccountRecord()
        {
            DomainName = dto.DomainName,
            AccountName = dto.AccountName,
            CreatedOn = DateTimeOffset.Now,
            ModifiedOn = DateTimeOffset.Now,
            CreatedBy = "system",
            ModifiedBy = "system"
        });
        await dbContext.SaveChangesAsync();
        
        await vaultClient.V1.Secrets.KeyValue.V2.WriteSecretAsync($"{dto.DomainName}", new Dictionary<string, object>
        {
            {dto.AccountName, dto.Password}
        });
    }

    public Task Update(PasswordDto dto)
    {
        throw new NotImplementedException();
    }
}