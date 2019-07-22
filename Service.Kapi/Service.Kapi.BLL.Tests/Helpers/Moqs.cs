using AutoFixture;
using Moq;
using Service.Kapi.BLL.Contracts;
using Service.Kapi.BLL.Models;
using Service.Kapi.DAL.MySql.Contract;
using Service.Kapi.DAL.MySql.Models;
using System;

namespace Service.Kapi.BLL.Tests.Helpers
{
    public static class Moqs
    {
        public static Mock<IUsersService> UsersServiceMoq()
        {
            var fixture = new Fixture();           

            var moq = new Mock<IUsersService>(MockBehavior.Strict);
            moq.Setup(s => s.CreateUserAsync(It.IsAny<User>()))
              .ReturnsAsync(fixture.Build<User>().Create());
            moq.Setup(s => s.GetUserAsync(It.IsAny<Guid>()))
             .ReturnsAsync(fixture.Build<User>().Create());
            moq.Setup(s => s.UpdateUserAsync(It.IsAny<User>()))
              .ReturnsAsync(true);
            moq.Setup(s => s.DeleteUserAsync(It.IsAny<Guid>()))
            .ReturnsAsync(true);
            moq.Setup(s => s.GetUsersListAsync(It.IsAny<int>(), It.IsAny<int>()))
             .ReturnsAsync(fixture.Build<User>().CreateMany(20));           

            return moq;
        }

        public static Mock<IUsersRepository> UsersReposirotyMoq(UserEntity userEntity)
        {
            var fixture = new Fixture();

            var moq = new Mock<IUsersRepository>(MockBehavior.Strict);
            moq.Setup(s => s.CreateUserAsync(It.IsAny<UserEntity>()))
              .ReturnsAsync(userEntity);
            moq.Setup(s => s.GetUserAsync(It.IsAny<Guid>()))
             .ReturnsAsync(userEntity);
            moq.Setup(s => s.UpdateUserAsync(It.IsAny<UserEntity>()))
              .ReturnsAsync(true);
            moq.Setup(s => s.DeleteUserAsync(It.IsAny<Guid>()))
            .ReturnsAsync(true);
            moq.Setup(s => s.GetUsersListAsync(It.IsAny<int>(), It.IsAny<int>()))
             .ReturnsAsync(fixture.Build<UserEntity>().CreateMany(20));

            return moq;
        }
    }
}
