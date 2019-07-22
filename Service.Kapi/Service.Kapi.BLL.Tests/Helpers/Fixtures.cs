using AutoFixture;
using Service.Kapi.BLL.Models;

namespace Service.Kapi.BLL.Tests.Helpers
{
    public static class Fixtures
    {
        public static User UserFixture(string name = null, UserType userType = 0)
        {
            var fixture = new Fixture();

            var user = fixture.Build<User>();

            if(!string.IsNullOrEmpty(name))
            {
                user.With(s => s.Name, name);
            }

            if (userType > 0)
            {
                user.With(s => s.UserType, userType);
            }           

            return user.Create();
        }
    }
}
