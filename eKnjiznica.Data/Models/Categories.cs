using System;
using System.ComponentModel.DataAnnotations;

namespace eKnjiznica.Data
{
    public class Categories
    {
        [Key]
        public  int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

    }
}
