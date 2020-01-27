using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eKnjiznica.Data.Models
{
    public class OrderItems
    {

        [Key]
        public int Id { get; set; }

        public Orders Orders { get; set; }
        [ForeignKey(nameof(Orders))]
        public int OrderId { get; set; }

        public Books Books { get; set; }
        [ForeignKey(nameof(Books))]
        public int BookId { get; set; }

        public decimal Price { get; set; }

    }
}
