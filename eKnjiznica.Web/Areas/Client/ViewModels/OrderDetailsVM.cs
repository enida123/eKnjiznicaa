using eKnjiznica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Client.ViewModels
{
    public class OrderDetailsVM
    {
        public Orders Order { get; set; }
        public List<OrderItems> items { get; set; }
        public decimal Total { get; set; }
        public string Message { get; set; }
        public bool IsError { get; set; }
        public int Id { get; set; }
        public string Naslov { get; set; }
    }
}
