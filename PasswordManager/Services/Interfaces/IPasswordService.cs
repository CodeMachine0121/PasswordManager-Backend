using PasswordManager.Controllers;
using PasswordManager.Models.Domains;

namespace PasswordManager.Services.Interfaces;

public interface IPasswordService
{
    Task<PasswordDomain> GetByDomain(string domain);
}