using Microsoft.EntityFrameworkCore;
using PasswordManager.Apis;
using PasswordManager.Apis.Interfaces;
using PasswordManager.DataBases;
using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Models.Entities;
using PasswordManager.Repository.Interfaces;
using VaultSharp.Core;

namespace PasswordManager.Repository;

public class PasswordRepository(PasswordManagerDbContext dbContext, IVaultApi vaultApi) : IPasswordRepository
{
    private readonly DbSet<AccountRecord> _accountRecord = dbContext.AccountRecord;

    public async Task<List<PasswordDomain>> GetBy(PasswordDto dto)
    {
        var accountRecord = await _accountRecord.FirstAsync(x => x.DomainName == dto.DomainName);

        var secretData = await vaultApi.GetBy(dto.DomainName);

        return secretData.Select(x => new PasswordDomain
        {
            DomainName = accountRecord.DomainName,
            AccountName = x.Key,
            Password = x.Value.ToString()!
        }).ToList();
    }

    public async Task Insert(PasswordDto dto)
    {
        await _accountRecord.AddAsync(new AccountRecord
        {
            DomainName = dto.DomainName,
            AccountName = dto.AccountName,
            CreatedOn = DateTimeOffset.Now,
            ModifiedOn = DateTimeOffset.Now,
            CreatedBy = "system",
            ModifiedBy = "system"
        });


        if (await vaultApi.IsDataExist(dto.DomainName))
        {
           await vaultApi.InsertSecretAsync(dto); 
        }
        else
        {
            await vaultApi.FirstInsertSecretAsync(dto);
        }

        await dbContext.SaveChangesAsync();
    }

    public async Task Update(PasswordDto dto)
    {
        var accountRecord = await _accountRecord.FirstAsync(x => x.DomainName == dto.DomainName);
        accountRecord.AccountName = dto.AccountName;
        accountRecord.ModifiedOn = DateTimeOffset.Now;
        accountRecord.ModifiedBy = "system";

        await vaultApi.FirstInsertSecretAsync(dto);
        
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(string domainName)
    {
        var accountRecord = await _accountRecord.FirstAsync(x => x.DomainName == domainName);
        _accountRecord.Remove(accountRecord);
        await dbContext.SaveChangesAsync();
        
        await vaultApi.DeleteSecretAsync(domainName);
    }
}