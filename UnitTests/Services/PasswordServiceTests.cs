using FluentAssertions;
using NSubstitute;
using PasswordManager.Models.Domains;
using PasswordManager.Models.Dtos;
using PasswordManager.Repository.Interfaces;
using PasswordManager.Services;

namespace UnitTests.Services;

[TestFixture]
public class PasswordServiceTests
{
    private IPasswordRepository _passwordRepository;
    private PasswordService _passwordService;

    [SetUp]
    public void SetUp()
    {
        _passwordRepository = Substitute.For<IPasswordRepository>();
        _passwordService = new PasswordService(_passwordRepository);
    }

    [Test]
    public async Task should_call_repo_get_data()
    {
        GivenPasswordDomain(new PasswordDomain
        {
            DomainName = "any-domain-name",
            Id = "any-id",
            Password = "any-password"
        });

        var passwordDomain = await _passwordService.GetByDomainName("domain");

        _passwordRepository.Received().GetBy(Arg.Any<PasswordDto>());
        passwordDomain.Should().BeEquivalentTo(new PasswordDomain
        {
            DomainName = "any-domain-name",
            Id = "any-id",
            Password = "any-password"
        });
    }

    private void GivenPasswordDomain(PasswordDomain passwordDomain)
    {
        _passwordRepository.GetBy(Arg.Any<PasswordDto>()).Returns(passwordDomain);
    }
}