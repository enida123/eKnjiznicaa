using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class UserDetailsVM
    {
        public string Id { get; set; }
        public string TrenutnoStanjeKredita { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
    }
}
