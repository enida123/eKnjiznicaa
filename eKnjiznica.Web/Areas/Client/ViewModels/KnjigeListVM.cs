using eKnjiznica.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Client.ViewModels
{
    public class KnjigeListVM
    {
        public List<Books> books { get; set; }
        public string kategorija { get; set; }
       
    }
}
