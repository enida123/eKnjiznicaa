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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eKnjiznica.Web.Areas.Client.Controllers
{
    [Area("Client")]
    [Authorize(Roles = "Client")]

    public class KnjigeController : Controller
    {
        private readonly MyContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public KnjigeController(MyContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        public IActionResult Index(string kategorija=null)
        {
            var model = new KnjigeListVM();
           
            if (!String.IsNullOrEmpty(kategorija))
            {
               model.books=  _context.Books.Include(x => x.Categories).Where(x => x.IsActive && x.Categories.Name.Contains(kategorija)).ToList();
                return View(model);

            }
            else
            {
                model.books = _context.Books.Include(x => x.Categories).Where(x => x.IsActive).ToList();
                return View(model);

            }

        }
        public IActionResult Details(int Id)
        {
            var book = _context.Books.Where(x=>x.Id==Id).Include(c=>c.Categories).SingleOrDefault();

            return View(new KnjigeDetaljiVM {
                id = book.Id.ToString(),
                kategorija = book.Categories.Name,
                opis = book.Description,
                naziv = book.Title
            });
        }

        [HttpGet]
        public IActionResult Order(string id)
        {
            var bookId = Int32.Parse(id);
            var book = _context.Books.FirstOrDefault(x => x.Id == bookId);
            var user = _userManager.GetUserAsync(User).Result;
            Orders order = new Orders();
            order = _context.Orders.Where(x => x.ApplicationUserId == user.Id && x.IsProcessed == false).FirstOrDefault();

            if (order == null)
            {
                order = new Orders
                {
                    ApplicationUserId = user.Id,
                    OrderDate = DateTime.Now
                };
                _context.Orders.Add(order);
                _context.SaveChanges();

                
            }

            var orderItem = new OrderItems
            {
               OrderId = order.Id,
               BookId = book.Id,
               Price = book.Price
           };

            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();

          



            //var orderModel = new OrderVM
            //{
            //    OrderId = order.Id,
            //    BookId = book.Id,
            //    Title = book.Title,
            //    Price = book.Price
            //};

            return RedirectToAction(nameof(Index));
        }

     

        [HttpPost]
        public IActionResult ConfirmOrder(OrderVM model)
        {


            return Ok();
        }

        
    }
}