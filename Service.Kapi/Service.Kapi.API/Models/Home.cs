using System;
using System.ComponentModel.DataAnnotations;

namespace Service.Kapi.API.Models
{
    /// <summary>
    /// Home type
    /// </summary>
    public class Home
    {
        /// <summary>
        /// Home id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Home name
        /// </summary>
        [Required]
        [StringLength(45, MinimumLength = 1)]
        public string Name { get; set; }
        /// <summary>
        /// Home number
        /// </summary>
        public string Block { get; set; }
        /// <summary>
        /// Home number
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Home type
        /// </summary>
        [Required]
        public HomeType HomeType { get; set; }
        /// <summary>
        /// Home Lives
        /// </summary>
        public string Lives { get; set; }
        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime CreatedOn { get; set; }
        /// <summary>
        /// ModifiedOn
        /// </summary>
        public DateTime ModifiedOn { get; set; }
    }
}
