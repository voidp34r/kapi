using AutoFixture;
using Service.Kapi.BLL.Tests.Helpers;
using Xunit;
using Service.Kapi.DAL.MySql.Models;
using System;
using Newtonsoft.Json;
using Service.Kapi.BLL.Models;

namespace Service.Kapi.BLL.Tests
{
    public class UsersServiceTests
    {
        [Theory]
        [InlineData("Mercedes", UserType.Owner)]
        [InlineData("BMW", UserType.Admin)]
        [InlineData("Toyota", UserType.Editor)]
        public void CreateUser_Test(string name, UserType userType)
        {
            //Arrange
            var fixture = new Fixture();
          
            var user = Fixtures.UserFixture(name, userType);
            var mapper = Mapper.GetAutoMapper();
            var usersRepoMoq = Moqs.UsersReposirotyMoq(mapper.Map<UserEntity>(user));
            var userSvc = new UsersService(mapper, usersRepoMoq.Object);

            //Act
            var newUser = userSvc.CreateUserAsync(user).Result;

            //Assert
            var actual = JsonConvert.SerializeObject(user);
            var expected = JsonConvert.SerializeObject(newUser);
            Assert.Equal(expected.Trim(), actual.Trim());
        }

        [Fact]       
        public void GetUser_Test()
        {
            //Arrange
            var fixture = new Fixture();

            var user = Fixtures.UserFixture();
            var mapper = Mapper.GetAutoMapper();
            var usersRepoMoq = Moqs.UsersReposirotyMoq(mapper.Map<UserEntity>(user));
            var userSvc = new UsersService(mapper, usersRepoMoq.Object);

            //Act
            var result = userSvc.GetUserAsync(fixture.Create<Guid>()).Result;

            //Assert
            var actual = JsonConvert.SerializeObject(user);
            var expected = JsonConvert.SerializeObject(result);            
            Assert.Equal(expected.Trim(), actual.Trim());
        }
    }
}
