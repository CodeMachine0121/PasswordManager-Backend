using PasswordManager.Models.Domains;
using PasswordManager.Services.Interfaces;

namespace PasswordManager.Services;

public class PasswordService: IPasswordService
{
    public async Task<PasswordDomain> GetByDomain(string domain)
    {
        var passwordDomain = new PasswordDomain()
        {
            Domain = domain,
            Id = "2314",
            Password = "password"
        };

        return passwordDomain;
    }
}