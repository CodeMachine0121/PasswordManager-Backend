using Microsoft.EntityFrameworkCore;
using PasswordManager.DataBases;
using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Models.Entities;
using PasswordManager.Repository.Interfaces;

namespace PasswordManager.Repository;

public class PasswordRepository(PasswordManagerDbContext dbContext) : IPasswordRepository
{
    public DbSet<StoredPassword> StoredPasswords = dbContext.StoredPasswords;

    public async Task<PasswordDomain> GetBy(PasswordDto dto)
    {
        var storedPassword = await StoredPasswords.FirstOrDefaultAsync(x => x.DomainName == dto.DomainName);
        
        return new PasswordDomain()
        {
            DomainName = dto.DomainName,
            Password = storedPassword?.Password ?? string.Empty
        };
    }
}