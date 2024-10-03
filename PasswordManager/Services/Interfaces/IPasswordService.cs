using PasswordManager.Models.Domains;

namespace PasswordManager.Services.Interfaces;

public interface IPasswordService
{
    Task<PasswordDomain> GetByDomainName(string domainName);
}