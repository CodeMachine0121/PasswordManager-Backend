using PasswordManager.Models.Domains;

namespace PasswordManager.Services.Interfaces;

public interface IPasswordRecordService
{
    Task<PasswordDomain> GetByDomainName(string domainName);
}