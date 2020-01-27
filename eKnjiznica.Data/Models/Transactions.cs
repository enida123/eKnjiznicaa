using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace eKnjiznica.Data.Models
{
    public class Transactions
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Order))]
        public int? OrderId { get; set; }

        [ForeignKey(nameof(Admin))]
        public string AdminId { get; set; }

        public DateTime DateCreated { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey(nameof(ApplicationUser))]
        public string ApplicationUserId { get; set; }

        public UserCredit UserCredit { get; set; }
        [ForeignKey(nameof(UserCredit))]
        public int UserCreditId { get; set; }

        public TransactionTypes TransactionTypes { get; set; }
        [ForeignKey(nameof(TransactionTypes))]
        public int TransactionTypeId { get; set; }

        public Orders Order { get; set; }
        public ApplicationUser Admin { get; set; }

        public decimal CurrentCredit { get; set; }
        public decimal PreviousCredit { get; set; }


    }
}
