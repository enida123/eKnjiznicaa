using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKnjiznica.Data.EF;
using eKnjiznica.Data.Models;
using eKnjiznica.Web.Models;
using eKnjiznica.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net.Mail;
using System.Net.Mime;
using MimeKit;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace eKnjiznica.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AccountController> _logger;
        private readonly MyContext _context;

        public AccountController(SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<AccountController> logger,
            MyContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _logger = logger;
            _context = context;
        }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> Test()
        {
           
          

            IdentityRole role1 = new IdentityRole { Id = "1",  Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "A" };
            IdentityRole role2 = new IdentityRole { Id = "2",  Name = "Client", NormalizedName = "CLIENT", ConcurrencyStamp = "CL" };
            TransactionTypes transactionType1 = new TransactionTypes { Name = "Uplata" };
            TransactionTypes transactionType2 = new TransactionTypes { Name = "Naplata" };
            var tipovi = _context.TransactionTypes.ToList();
            var role = _context.Roles.ToList();

            if (!role.Any())
            {
                _context.Roles.Add(role1);
                _context.Roles.Add(role2);
            }
          
            if (!tipovi.Any())
            {
                _context.TransactionTypes.Add(transactionType1);
                _context.TransactionTypes.Add(transactionType2);
            }


            _context.SaveChanges();
            var user = new ApplicationUser { UserName = "admin", Email = "admin@hotmail.com",FirstName="Enida",LastName="Obradovic"};
            var result = await _userManager.CreateAsync(user, "Test123$");
            if(result.Succeeded)
            {
                var roleResult = _userManager.AddToRoleAsync(user, "Admin").Result;
            }

            return RedirectToAction(nameof(Login));
        }
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
            ViewData["ReturnUrl"] = returnUrl;

            return View();
        }
        [HttpGet]
        public ActionResult UserLocation()
        {
            var user = _userManager.GetUserAsync(User).Result;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password,false,  lockoutOnFailure: false);
                if (result.Succeeded)
                {

                    var user = await _userManager.FindByNameAsync(model.Username);

                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                        return Redirect("/Administrator/Home/Index");

                    else if (await _userManager.IsInRoleAsync(user, "Client"))
                    {
                        return Redirect("/Client/Home/Index");
                    }

                    //return RedirectToAction("Index", "Home", new { area = "SaloonOwner" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            
            ViewData["ReturnUrl"] = returnUrl;
            return PartialView("Register", new RegisterVM());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username,PhoneNumber=model.PhoneNumber, Email = model.Email, FirstName=model.FirstName,LastName=model.LastName, BirthDate=model.BirthDate };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        model.ErrorMessage = error.Description;
                    }
                    //return RedirectToAction("ChangePassword",new { id = model.Id});


                    return View(model);
                }
                else
                {

                    var user1 = _userManager.FindByEmailAsync(model.Email).Result;
                    var user2 = await _userManager.FindByEmailAsync(model.Email);
                    try
                    {


                        _logger.LogInformation("User created a new account with password.");

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        //var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                        //await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);
                        await _userManager.AddToRoleAsync(user, "Client");

                        await _signInManager.SignInAsync(user, isPersistent: false);

                        _logger.LogInformation("User created a new account with password.");


                        return Redirect("/Client/Home/Index");
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.InnerException.Message);
                    }
                }
                
            }

            // If we got this far, something failed, redisplay form
            return PartialView(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Login");
        }
    }
}