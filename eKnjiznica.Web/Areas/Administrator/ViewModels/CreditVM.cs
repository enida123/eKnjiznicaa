using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class CreditVM
    {
        public string UserId { get; set; }
        public string Description { get; set; }
        public decimal Uplata { get; set; }
        public string User { get; set; }
    }
}
