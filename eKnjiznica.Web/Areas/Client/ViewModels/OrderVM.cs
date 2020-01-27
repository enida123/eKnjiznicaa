using eKnjiznica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Client.ViewModels
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }

        List<OrderItems> orderItems { get; set; }
        List<string> bookIds { get; set; }
    }
}
