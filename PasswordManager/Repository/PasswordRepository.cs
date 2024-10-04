using Microsoft.EntityFrameworkCore;
using PasswordManager.DataBases;
using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Models.Entities;
using PasswordManager.Repository.Interfaces;

namespace PasswordManager.Repository;

public class PasswordRepository(PasswordManagerDbContext dbContext) : IPasswordRepository
{
    private readonly DbSet<AccountRecord> _accountRecord = dbContext.AccountRecord;

    public async Task<PasswordDomain> GetBy(PasswordDto dto)
    {
        var accountRecord = await _accountRecord.FirstOrDefaultAsync(x => x.DomainName == dto.DomainName);
        
        return new PasswordDomain()
        {
            DomainName = dto.DomainName,
            AccountName = accountRecord!.AccountName,
            Password = "//TODO: Implement password retrieval"
        };
    }
}