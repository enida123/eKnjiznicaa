using eKnjiznica.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class KnjigaAddEditVM
    {
        public Books books { get; set; }
        public List<SelectListItem> kategorije { get; set; }
    }
}
