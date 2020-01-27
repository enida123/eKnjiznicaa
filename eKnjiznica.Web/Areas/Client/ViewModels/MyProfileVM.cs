using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Client.ViewModels
{
    public class MyProfileVM
    {
        public string ImePrezime { get; set; }
        public string Email { get; set; }
        public string DatumRodjenja { get; set; }
        public string TrenutnoStanje { get; set; }
    }
}
