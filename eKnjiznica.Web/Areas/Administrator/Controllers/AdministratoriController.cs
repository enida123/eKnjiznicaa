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

namespace eKnjiznica.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]

    public class AdministratoriController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly MyContext _context;

        public AdministratoriController(UserManager<ApplicationUser> userManager,
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
            var user = _userManager.GetUsersInRoleAsync("Admin").Result.ToList();
          
            return View(user);
        }
        public IActionResult Dodaj()
        {
            return View(new AdminAddEditVM());
                
        }
        public async Task<IActionResult> Snimi(AdminAddEditVM model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        model.ErrorMessage = error.Description;
                    }


                    return View("Dodaj", model);
                }
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Index");

            }
            return View("Dodaj", model);


        }

        [HttpGet]
        public IActionResult Disable(string Id)
        {

            var model = new DisableVM
            {
                Id = Id
            };
            var user = _context.Users.FirstOrDefault(x => x.Id == Id);
            var result = _userManager.IsInRoleAsync(user, "Admin").Result;

            if(result)
            {
                var role = _context.Roles.Where(x => x.Name == "Admin").FirstOrDefault();
                model.Role = role.Name;
                model.RoleId = role.Id;
            } else
            {
                var role = _context.Roles.Where(x => x.Name == "Client").FirstOrDefault();
                model.Role = role.Name;
                model.RoleId = role.Id;
            }


            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Disable(DisableVM model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == model.Id);

            if (user == null)
                return NotFound("User not found");


            var result = _userManager.RemoveFromRoleAsync(user, model.Role).Result;

            if(result.Succeeded)
            {
                model.ErrorMessage = "Uspjesno ste dekativirali račun!";
                return View(model);
            }
           
            model.ErrorMessage = "Error";
            return View(model);
        }

        [HttpGet]
        public IActionResult ChangePassword(string Id)
        {
                
            
                return View(new ChangePasswordVM {
                    Id=Id
                });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {

            if(!ModelState.IsValid)
            {
                return View(model);
            }
            if (ModelState.IsValid)
            {

            
                var user = await _userManager.FindByIdAsync(model.Id);


              

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

                // Upon successfully changing the password refresh sign-in cookie
                await _signInManager.RefreshSignInAsync(user);
                return View("ChangePasswordConfrimation");
            }

            return View(model);
        }
    }
}