using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Services.Interfaces;

namespace PasswordManager.Services;

public class PasswordRecordService(IPasswordRepository passwordRepository) : IPasswordRecordService
{
    public async Task<PasswordDomain> GetByDomainName(string domainName)
    {
        var passwordDomain = await passwordRepository.GetBy(new PasswordDto()
        {
            DomainName = domainName
        });

        return passwordDomain;
    }

    public async Task Insert(PasswordDto passwordDto)
    {
         await passwordRepository.Insert(passwordDto);
    }

    public async Task Update(PasswordDto passwordDto)
    {
        await passwordRepository.Update(passwordDto);
    }

    public Task Delete(string domainName)
    {
        throw new NotImplementedException();
    }
}