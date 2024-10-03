using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;

namespace PasswordManager.Repository;

public interface IPasswordRepository
{
    PasswordDomain GetBy(PasswordDto any);
}