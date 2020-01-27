using eKnjiznica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class KupovineDetailsVM
    {
        public List<OrderItems> orderItems { get; set; }
        public string naslov { get; set; }
        public string autor { get; set; }
        public string korisnik { get; set; }
        public int Id { get; set; }
    }
}
