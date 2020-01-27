using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKnjiznica.Data.EF;
using eKnjiznica.Data.Models;
using eKnjiznica.Web.Areas.Administrator.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eKnjiznica.Web.Areas.Administrator.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Administrator")]
    public class KupovineController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly MyContext _context;

        public KupovineController(UserManager<ApplicationUser> userManager,
            MyContext context,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public IActionResult Index(string korisnik=null)
        {
            OrderIndexVM model = new OrderIndexVM();

            if (String.IsNullOrEmpty(korisnik))
            {
                model.order = _context.Orders.Where(x => x.IsProcessed).Include(a => a.ApplicationUser).ToList();

            }
            else
            {
                model.order = _context.Orders.Where(x => x.IsProcessed).Include(a => a.ApplicationUser).
                    Where(a=>a.ApplicationUser.FullName.Contains(korisnik)).ToList();

            }
            return View(model);
        }
        public IActionResult Details(int Id, string naslov=null,string autor=null)
        {
            KupovineDetailsVM model = new KupovineDetailsVM
            {
                Id = Id
            };
            if (String.IsNullOrEmpty(naslov) && String.IsNullOrEmpty(autor))
            {
                model.orderItems= _context.OrderItems.Where(x => x.OrderId == Id).Include(a => a.Orders.ApplicationUser)
                .Include(b => b.Books.Categories).ToList();
                return View(model);

            }
            if (!String.IsNullOrEmpty(naslov) && !String.IsNullOrEmpty(autor))
            {
                model.orderItems = _context.OrderItems.Include(x => x.Books.Categories).Include(a => a.Orders.ApplicationUser)
                    .Where(x=>x.OrderId==Id)
                    .Where(s => s.Books.Title.Contains(naslov) && s.Books.AuthorName.Contains(autor)).ToList();
                return View(model);

            }
            else
            {
                model.orderItems = _context.OrderItems.Include(x => x.Books.Categories).Include(a => a.Orders.ApplicationUser)
                                        .Where(x => x.OrderId == Id)

                    .Where(s => s.Books.Title.Contains(naslov) || s.Books.AuthorName.Contains(autor)).ToList();
                return View(model);

            }
            

        }
    }
}