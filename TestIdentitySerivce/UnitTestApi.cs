using IdentityService.Application.Infrastructure;
using IdentityService.Domain.Models;
using IdentityService.Persistence.Users.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestIdentitySerivce
{
    [TestClass]
    public class UnitTestApi
    {
        [TestMethod]
        public void TestResult()
        {
            var mockMediator = new Moq.Mock<IMediator>();

            IdentityService.Api.Controllers.UsersController usersController = new IdentityService.Api.Controllers.UsersController(mockMediator.Object);

            Task<IActionResult> result = usersController.GetCreateToken(Moq.It.IsAny<string>() , Moq.It.IsAny<string>());

            Assert.IsInstanceOfType(result, typeof(Task<IActionResult>));

        }

        [TestMethod]
        public void TestCreateToken()
        {
            User user = new User()
            {
                Id = Guid.Parse("3e149267-7e49-41d5-b709-b4e8eb3c8736"),
                UserName= "hamid",
                FirstName = "jalalat",
                LastName = "jalalat",
                EmailAddress = "ewede",
                Services= "pd,is",
                Role="admin",
                Password="123",
            };

            var resultToken= JwtUtility.GenerateJwtToken(user, 120);

            string expected = "";
            string actual = resultToken;

            Assert.AreNotEqual(expected,actual);

        }
    }
}