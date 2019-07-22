using Service.Kapi.API.Models;
using Swashbuckle.AspNetCore.Filters;
using System;

namespace Service.Kapi.API.Swagger
{
    public class UserModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var dnow = DateTime.UtcNow;
            return new User
            {
                Id = Guid.NewGuid(),
                Name = "Void",
                UserType = UserType.Admin,
                Email = "void@exaple.com",
                Password = "password",
                Cpf = "01533097330",
                Birth = dnow,
                Telephone = "048999122216",
                Deleted = false,
                CreatedOn = dnow,
                ModifiedOn = dnow,
                DeletedOn = dnow,
            };
        }
    }
}
