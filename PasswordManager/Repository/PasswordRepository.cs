using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Repository.Interfaces;

namespace PasswordManager.Repository;

public class PasswordRepository: IPasswordRepository
{
    public PasswordDomain GetBy(PasswordDto any)
    {
        throw new NotImplementedException();
    }
}