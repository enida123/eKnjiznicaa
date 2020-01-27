using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Client.ViewModels
{
    public class KnjigeDetaljiVM
    {
        public string id { get; set; }
        public string kategorija { get; set; }
        public string opis { get; set; }
        public string naziv { get; set; }
        public decimal cijena { get; set; }
    }
}
