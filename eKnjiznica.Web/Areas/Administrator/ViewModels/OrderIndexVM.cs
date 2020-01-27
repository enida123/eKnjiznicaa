using eKnjiznica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class OrderIndexVM
    {
        public List<Orders> order { get; set; }
        public string korisnik { get; set; }
    }
}
