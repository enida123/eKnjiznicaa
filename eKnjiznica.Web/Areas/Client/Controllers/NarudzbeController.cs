using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using eKnjiznica.Data.EF;
using eKnjiznica.Data.Models;
using eKnjiznica.Web.Areas.Client.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;

namespace eKnjiznica.Web.Areas.Client.Controllers
{
    [Authorize(Roles="Client")]
    [Area("Client")]
    public class NarudzbeController : Controller
    {
        private readonly MyContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public NarudzbeController(MyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: Narudzbe
        public ActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;

            var orders = _context.Orders.Where(x => x.IsProcessed == false && x.ApplicationUserId==user.Id).ToList();

            return View(orders);
        }



        // GET: Narudzbe/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            var order = _context.Orders.Where(x => x.Id == id).FirstOrDefault();
            var orderItems = _context.OrderItems.Where(x => x.OrderId == order.Id).Include(x=>x.Books.Categories).ToList();

            var model = new OrderDetailsVM();

            
            model.Order = order;
            model.items = orderItems;
            foreach (var x in orderItems)
            {

                model.Total += x.Price;
               
            }

            return View(model);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(OrderDetailsVM model)
        {
            var order = _context.Orders.Where(x => x.Id == model.Order.Id).FirstOrDefault();
            var orderItems = _context.OrderItems
                .Include(x => x.Books)
                .Include(x => x.Orders)
                .Where(x => x.OrderId == order.Id)
                .ToList();
            var user = _userManager.GetUserAsync(User).Result;
            var userCredit = _context.UserCredits.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();
            var userCreditBefore = _context.UserCredits.Where(x => x.ApplicationUserId == user.Id).FirstOrDefault();
           

            var total = model.Total;
            if (userCredit != null)
            {
                if (userCredit.Balance < total)
                {
                    model.Order = order;
                    model.Id = order.Id;
                    model.items = orderItems;
                    model.IsError = true;
                    model.Message = "You don't have enough money";
                    return View("Details", model);
                    //     return RedirectToAction("Details", new { id=model.Id});
                }
            }
            else
            {
                model.Id = order.Id;
                model.items = orderItems;
                model.IsError = true;
                model.Message = "Nemate evidentiran kredit! Molimo Vas posjetite poslovnicu!";
                return View("Details", model);

            }

            order.IsProcessed = true;
            order.PriceTotal = total;
            _context.Orders.Update(order);
            userCredit.Balance -= total;

            var transaction = new Transactions
            {
                OrderId = order.Id,
                TransactionTypeId = _context.TransactionTypes.Where(x => x.Name == "Naplata").Select(x => x.Id).FirstOrDefault(),
                UserCreditId = userCredit.Id,
                ApplicationUserId = user.Id,
                CurrentCredit = userCredit.Balance,
                PreviousCredit =userCredit.Balance+total,
                DateCreated = DateTime.Now
            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("enida.obradovic30@hotmail.com"));
                message.To.Add(new MailboxAddress("bookstore.Mostar123@outlook.com"));
                message.Subject = "Knjige";
              
                message.Body = new TextPart("plain")
                    {
                        Text ="test"
                    };
                
                
                //Attachment data = new Attachment(
                //             "PATH_TO_YOUR_FILE",
                //             MediaTypeNames.Application.Octet);

                using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
                {
                    emailClient.ServerCertificateValidationCallback = (object sender,
                      X509Certificate certificate,
                      X509Chain chain,
                      SslPolicyErrors sslPolicyErrors) => true;
                    //     emailClient.Connect("smtp.live.com", 587, false);
                    // emailClient.SslProtocols = System.Security.Authentication.SslProtocols.Tls11;
                    await emailClient.ConnectAsync("smtp.live.com", 587, false);
                    emailClient.Authenticate("enida.obradovic30@hotmail.com", "LjepotaIslam123");
                    // emailClient.SslProtocols = System.Security.Authentication.SslProtocols.Ssl3;
                    await emailClient.SendAsync(message);
                    await emailClient.DisconnectAsync(true);
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return Redirect("/Client/Kupovine/Index");
        }
        public IActionResult RemoveFromCart(int Id)
        {
            var Item = _context.OrderItems.Find(Id);
            int orderId = Item.OrderId;
            _context.OrderItems.Remove(Item);
            _context.SaveChanges();
            return Redirect("/Client/Narudzbe/Details?="+orderId);
        }
        public IActionResult RemoveOrder(int Id)
        {
            var order = _context.Orders.Find(Id);
            _context.Orders.Remove(order);
            _context.SaveChanges();
            var orderItems = _context.OrderItems
                .Include(x => x.Books)
                .Include(x => x.Orders)
                .Where(x => x.OrderId == Id)
                .ToList();

            foreach(var i in orderItems)
            {
                _context.OrderItems.Remove(i);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
       
    

        
    }
}