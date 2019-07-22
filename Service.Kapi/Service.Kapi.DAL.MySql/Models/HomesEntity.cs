using System;

namespace Service.Kapi.DAL.MySql.Models
{
    public class HomeEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public int Number { get; set; }
        public int HomeType { get; set; }
        public string Lives { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
