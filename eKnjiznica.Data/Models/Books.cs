using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eKnjiznica.Data.Models
{
    public  class Books
    {
        [Key]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DatePublished { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public Categories Categories { get; set; }
        [ForeignKey(nameof(Categories))]
        public int CategorieId { get; set; }

        
    }
}
