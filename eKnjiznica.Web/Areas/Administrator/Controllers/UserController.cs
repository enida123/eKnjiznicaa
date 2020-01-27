
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
    public class UserController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly MyContext _context;

        public UserController(UserManager<ApplicationUser> userManager,
            MyContext context,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUsersInRoleAsync("Client").Result.ToList();

            return View(user);
        }
        public IActionResult Details(string Id)
        {
            var user = _context.Users.Where(x => x.Id == Id).FirstOrDefault();
            var userCredit = _context.UserCredits.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();

            UserDetailsVM model = new UserDetailsVM();

            model.Username = user.UserName;
            model.PhoneNumber = user.PhoneNumber;
            model.Id = user.Id;
            if (userCredit != null)
            {
                model.TrenutnoStanjeKredita = userCredit.Balance.ToString();
            }
           
            return View(model);
        }
        public IActionResult Books(string Id)
        {
        
            var orderItems= _context.OrderItems.Include(c => c.Books.Categories).
                Include(x=>x.Orders.ApplicationUser).Where(o=>o.Orders.ApplicationUserId==Id).ToList();
            PurchasedBooks model = new PurchasedBooks();
            model.items = orderItems;
          
            
            return View(model);
        }
        [HttpGet]
        public IActionResult AddCredit(string Id)
        {
            var user = _context.Users.Find(Id);
            return View(new CreditVM {

                UserId = Id,
                User = user.FirstName+" "+ user.LastName
            });
        }
        [HttpPost]
        public IActionResult AddCredit(CreditVM model)
        {
            var userAdmin = _userManager.GetUserAsync(User).Result;

            var user = _context.Users.Where(x => x.Id == model.UserId).FirstOrDefault();
            var credit = _context.UserCredits.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();
            UserCredit userCredit;
            if (credit == null)
            {
                userCredit = new UserCredit
                {

                    ApplicationUserId = user.Id,
                    Description = model.Description,
                    Balance = model.Uplata,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                    DateModified = DateTime.Now
                };
                _context.UserCredits.Add(userCredit);
                _context.SaveChanges();
                Transactions transactions = new Transactions
                {
                    AdminId = userAdmin.Id,
                    PreviousCredit = userCredit.Balance,
                    CurrentCredit = userCredit.Balance,
                    TransactionTypeId = _context.TransactionTypes.Where(x => x.Name == "Uplata").Select(u => u.Id).FirstOrDefault(),
                    UserCreditId = userCredit.Id,
                    DateCreated = DateTime.Now

                };
                _context.Transactions.Add(transactions);
                _context.SaveChanges();

            }
            else
            {
                userCredit = _context.UserCredits.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();
                userCredit.Balance += model.Uplata;
                userCredit.IsActive = true;
                userCredit.DateCreated = DateTime.Now;
                _context.UserCredits.Update(userCredit);
                _context.SaveChanges();

                Transactions transactionss = new Transactions
                {
                    AdminId = userAdmin.Id,
                    PreviousCredit = userCredit.Balance-model.Uplata,
                    CurrentCredit = userCredit.Balance,
                    TransactionTypeId = _context.TransactionTypes.Where(x => x.Name == "Uplata").Select(u => u.Id).FirstOrDefault(),
                    UserCreditId = userCredit.Id,
                    DateCreated = DateTime.Now

                };
                _context.Transactions.Add(transactionss);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}