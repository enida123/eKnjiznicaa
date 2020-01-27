using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKnjiznica.Web.Areas.Administrator.ViewModels
{
    public class DisableVM
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
    }
}
