using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKnjiznica.Data.EF;
using eKnjiznica.Data.Models;
using eKnjiznica.Web.Areas.Client.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eKnjiznica.Web.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Client")]

    public class ProfilController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly MyContext _context;

        public ProfilController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MyContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            //var user = _userManager.GetUsersInRoleAsync("Client").Result.ToList();
            var user = _userManager.GetUserAsync(User).Result;
            var userCredit = _context.UserCredits.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();
            var model = new MyProfileVM
            {
                ImePrezime = user.FirstName + " " + user.LastName,
                DatumRodjenja = user.BirthDate.ToShortDateString(),
                Email = user.Email,

            };
            if (userCredit != null)
                model.TrenutnoStanje = userCredit.Balance.ToString();
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(new ChangePasswordVM());


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (ModelState.IsValid)
            {


                var user = _userManager.GetUserAsync(User).Result;


                // ChangePasswordAsync changes the user password
                var result = await _userManager.ChangePasswordAsync(user,
                    model.CurrentPassword, model.NewPassword);

                // The new password did not meet the complexity rules or
                // the current password is incorrect. Add these errors to
                // the ModelState and rerender ChangePassword view
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        model.ErroMessage = error.Description;
                    }


                    return View("ChangePassword", model);

                }

                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfrimation");
            }

            return View(model);
        }
    }
}