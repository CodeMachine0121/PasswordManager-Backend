using FluentAssertions;
using NSubstitute;
using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Services;

namespace UnitTests.Services;

[TestFixture]
public class PasswordRecordServiceTests
{
    private IPasswordRepository _passwordRepository;
    private PasswordRecordService _passwordRecordService;

    [SetUp]
    public void SetUp()
    {
        _passwordRepository = Substitute.For<IPasswordRepository>();
        _passwordRecordService = new PasswordRecordService(_passwordRepository);
    }

    [Test]
    public async Task should_call_repo_get_data()
    {
        GivenPasswordDomain(new PasswordDomain
        {
            DomainName = "any-domain-name",
            AccountName = "any-id",
            Password = "any-password"
        });

        var passwordDomain = await _passwordRecordService.GetByDomainName("domain");

        _passwordRepository.Received().GetBy(Arg.Any<PasswordDto>());
        passwordDomain.Should().BeEquivalentTo(new PasswordDomain
        {
            DomainName = "any-domain-name",
            AccountName = "any-id",
            Password = "any-password"
        });
    }

    [Test]
    public async Task should_insert_data_by_repo()
    {
        await _passwordRecordService.Insert(new PasswordDto
        {
            DomainName = "any-domain-name",
            AccountName = "any-id",
            Password = "any-password"
        });
        
        await _passwordRepository.Received().Insert(Arg.Any<PasswordDto>());
    }

    private void GivenPasswordDomain(PasswordDomain passwordDomain)
    {
        _passwordRepository.GetBy(Arg.Any<PasswordDto>()).Returns(passwordDomain);
    }
}