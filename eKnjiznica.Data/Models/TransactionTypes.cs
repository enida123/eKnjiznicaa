using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eKnjiznica.Data.Models
{
    public class TransactionTypes
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
