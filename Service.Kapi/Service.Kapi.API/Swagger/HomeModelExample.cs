using System;
using Service.Kapi.API.Models;
using Swashbuckle.AspNetCore.Filters;
using Newtonsoft.Json;

namespace Service.Kapi.API.Swagger
{
    public class HomeModelExample : IExamplesProvider
    {
        public object GetExamples()
        {
            var dnow = DateTime.UtcNow;
            var voidUSer = new User
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

            var voidUserJson = JsonConvert.SerializeObject(voidUSer, Formatting.Indented);
            Console.WriteLine(voidUserJson);

            return new Home
            {
                Id = Guid.NewGuid(),
                Name = "Void Sweet Home ",
                Block = "WEB PAGE",
                Number = 66,
                Lives = voidUserJson,
                HomeType = HomeType.House,               
                CreatedOn = dnow,
                ModifiedOn = dnow
            };
        }
    }
}
