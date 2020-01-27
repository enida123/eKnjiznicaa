using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eKnjiznica.Data.Models
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public decimal PriceTotal { get; set; }

        public bool IsProcessed { get; set; }

    }
}
