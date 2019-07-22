using System;

namespace Service.Kapi.DAL.MySql.Models
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }      
        public int UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public DateTime Birth { get; set; }
        public string Telephone { get; set; }
        public Boolean Deleted { get; set; }
        public DateTime CreatedOn { get; set; }   
        public DateTime ModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }
    }

}
