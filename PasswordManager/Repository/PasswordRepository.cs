using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Repository.Interfaces;

namespace PasswordManager.Repository;

public class PasswordRepository: IPasswordRepository
{
    public Task<PasswordDomain> GetBy(PasswordDto any)
    {
        throw new NotImplementedException();
    }
}