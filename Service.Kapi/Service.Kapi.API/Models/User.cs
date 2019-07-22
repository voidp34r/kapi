using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Kapi.API.Models
{
    /// <summary>
    /// User type
    /// </summary>
    public class User
    {
        /// <summary>
        /// User id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// User  name
        /// </summary>
        [Required]
        [StringLength(45, MinimumLength = 1)]
        public string Name { get; set; }        
        /// <summary>
        /// User type
        /// </summary>
        [Required]
        public UserType UserType { get; set; }
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        public String Email { get; set; }
        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// User cpf
        /// </summary>
        [Required]
        public string Cpf { get; set; }
        /// <summary>
        /// User birth 
        /// </summary>
        [Required]
        public DateTime Birth { get; set; }
        /// <summary>
        /// User telephone
        /// </summary>
        [Required]
        public string Telephone { get; set; }
        /// <summary>
        /// Deleted
        /// </summary>
        [Required]
        public Boolean Deleted { get; set; }
        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// ModifiedOn
        /// </summary>
        public DateTime ModifiedOn { get; set; }
        /// <summary>
        /// DeletedOn
        /// </summary>
        public DateTime DeletedOn { get; set; }
    }
}
