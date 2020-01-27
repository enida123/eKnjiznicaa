using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKnjiznica.Data.EF;
using eKnjiznica.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eKnjiznica.Web.Areas.Client.Controllers
{

    [Area("Client")]
    [Authorize(Roles = "Client")]
    public class KupovineController : Controller
    {

        private readonly MyContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public KupovineController(MyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            var orderItems = _context.OrderItems.Where(x => x.Orders.ApplicationUser.Id==user.Id && x.Orders.IsProcessed).Include(x => x.Books.Categories).Include(x => x.Orders).ToList();
            
            return View(orderItems);
        }
    }
}