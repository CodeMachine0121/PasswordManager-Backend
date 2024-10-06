using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Repository.Interfaces;

public interface IPasswordRepository
{
    Task<List<PasswordDomain>> GetBy(PasswordDto dto);
    Task Insert(PasswordDto dto);
    Task Update(PasswordDto dto);
    Task Delete(string domainName);
}