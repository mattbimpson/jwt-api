using JwtApi.Helpers;
using JwtApi.Services;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private Mock<IOptions<AppSettings>> _mockSettings = new Mock<IOptions<AppSettings>>();
        private IUsersService _usersService;

        [SetUp]
        public void Setup()
        {
            _mockSettings.Setup(x => x.Value).Returns(Settings);
            _usersService = new UsersService(_mockSettings.Object);
        }

        [Test]
        public void Invalid_Credentials_Returns_Null()
        {
            var result = _usersService.Authenticate("wrong", "credentials");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Correct_Credentials_Returns_UserWithToken()
        {
            var result = _usersService.Authenticate("test", "test");
            Assert.That(result, Is.Not.Null);
            Assert.IsNotEmpty(result.Token);
        }

        [Test]
        public void GetAll_Returns_Users()
        {
            var result = _usersService.GetAll().ToList();
            Assert.Greater(result.Count, 0);
        }

        private AppSettings Settings()
        {
            return new AppSettings
            {
                Secret = "my_test_secret_my_test_secret_my_test_secret_my_test_secret_my_test_secret"
            };
        }
    }
}