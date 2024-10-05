using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Repository.Interfaces;

public interface IPasswordRepository
{
    Task<PasswordDomain> GetBy(PasswordDto dto);
    Task Insert(PasswordDto dto);
    Task Update(PasswordDto dto);
}