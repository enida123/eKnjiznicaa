using eKnjiznica.Data;
using eKnjiznica.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class KnjigaListVM
    {
     
        public List<Books> knjige { get; set; }
        public string naslov { get; set; }
        public string autor { get; set; }
        public string kategorija { get; set; }
    }
}
