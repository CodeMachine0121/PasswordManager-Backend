using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Services.Interfaces;

public interface IPasswordRecordService
{
    Task<PasswordDomain> GetByDomainName(string domainName);
    Task Insert(PasswordDto passwordDto);
    Task Update(PasswordDto passwordDto);
    Task Delete(string domainName);
}