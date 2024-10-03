using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Repository;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Services.Interfaces;

namespace PasswordManager.Services;

public class PasswordService(IPasswordRepository passwordRepository) : IPasswordService
{
    public async Task<PasswordDomain> GetByDomainName(string domainName)
    {
        var passwordDomain = passwordRepository.GetBy(new PasswordDto()
        {
            DomainName = domainName
        });

        return passwordDomain;
    }
}