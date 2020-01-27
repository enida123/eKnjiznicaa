using eKnjiznica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class PurchasedBooks
    {
        public List<OrderItems> items { get; set; }
    }
}
