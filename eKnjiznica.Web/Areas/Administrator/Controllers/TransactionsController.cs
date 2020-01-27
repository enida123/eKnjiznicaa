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

    public class TransactionsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly MyContext _context;

        public TransactionsController(UserManager<ApplicationUser> userManager,
            MyContext context,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }
        public IActionResult Index(string administrator = null, string korisnik = null)
        {
            TransactionsListVM model = new TransactionsListVM();
            if (String.IsNullOrEmpty(administrator) && String.IsNullOrEmpty(korisnik))
            {
                model.transactions = _context.Transactions.Include(x => x.ApplicationUser)
                               .Include(z => z.Admin)
                               .Include(t => t.TransactionTypes).Include(x => x.UserCredit.ApplicationUser).ToList();
                return View(model);

            }
            if (!String.IsNullOrEmpty(administrator) && !String.IsNullOrEmpty(korisnik))
            {
                model.transactions = _context.Transactions.Include(x => x.ApplicationUser)
                             .Include(z => z.Admin).Include(t => t.TransactionTypes).Include(x => x.UserCredit.ApplicationUser)
                             .Where(a => a.Admin.FullName.Contains(administrator)
                             && a.UserCredit.ApplicationUser.FullName.Contains(korisnik)).ToList();


                return View(model);
            }

            if (!String.IsNullOrEmpty(korisnik))
            {
                model.transactions = _context.Transactions.Include(x => x.ApplicationUser)
                             .Include(z => z.Admin).Include(t => t.TransactionTypes).Include(x => x.UserCredit.ApplicationUser)
                             .Where(a => a.ApplicationUser.FullName.Contains(korisnik)
                             || a.UserCredit.ApplicationUser.FullName.Contains(korisnik)).ToList();


                return View(model);
            }
            else if(!String.IsNullOrEmpty(administrator))
            {
                model.transactions = _context.Transactions.Include(x => x.ApplicationUser)
                             .Include(z => z.Admin).Include(t => t.TransactionTypes).Include(x => x.UserCredit.ApplicationUser)
                             .Where(a => a.Admin.FullName.Contains(administrator)).ToList();

                return View(model);

            }
            return View(model);

        }
    }
}