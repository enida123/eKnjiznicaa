using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKnjiznica.Data.EF;
using eKnjiznica.Data.Models;
using eKnjiznica.Web.Areas.Administrator.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eKnjiznica.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Authorize(Roles = "Admin")]

    public class KnjigeController : Controller
    {
        private readonly MyContext _context;

        public KnjigeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index(string naslov=null, string autor=null, string kategorija = null)
        {
            KnjigaListVM model = new KnjigaListVM();
            if (String.IsNullOrEmpty(naslov) && String.IsNullOrEmpty(autor) && String.IsNullOrEmpty(kategorija)) 
            {
                model.knjige = _context.Books.Include(x => x.Categories).ToList();
                return View(model);

            }
            if(!String.IsNullOrEmpty(naslov) && !String.IsNullOrEmpty(autor) && !String.IsNullOrEmpty(kategorija))
            {
                model.knjige = _context.Books.Include(x => x.Categories).Where(s => s.Title.Contains(naslov) && s.AuthorName.Contains(autor) && s.Categories.Name.Contains(kategorija)).ToList();
                return View(model);

            }
            else
            {
                model.knjige = _context.Books.Include(x => x.Categories).Where(s => s.Title.Contains(naslov) || s.AuthorName.Contains(autor) || s.Categories.Name.Contains(kategorija)).ToList();
                return View(model);

            }
        }
        public IActionResult Dodaj()
        {
            KnjigaAddEditVM model = new KnjigaAddEditVM
            {
                books = new Books(),
                kategorije = _context.Categories.Where(x=>x.IsActive).Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return View(model);
        }
        public IActionResult Edit(int Id)
        {
            KnjigaAddEditVM model = new KnjigaAddEditVM
            {
                books = _context.Books.Find(Id),
                kategorije = _context.Categories.Where(x => x.IsActive).Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return View(nameof(Dodaj), model);
        }
        public IActionResult Snimi(KnjigaAddEditVM model)
        {


           
            Books novaKnjiga = null;
            if (model.books.Id != 0)
            {
                novaKnjiga = model.books;
                
                _context.Books.Update(novaKnjiga);
                _context.SaveChanges();

            }
            else
            {
                novaKnjiga = new Books
                {
                    CategorieId = model.books.CategorieId,
                    Title = model.books.Title,
                    AuthorName = model.books.AuthorName,
                    Price = model.books.Price,
                    DatePublished = model.books.DatePublished,
                    IsActive=true,
                    Description=model.books.Description

                };
                _context.Books.Add(novaKnjiga);
                _context.SaveChanges();
            };

            return RedirectToAction("Index");
        }

        public IActionResult Disable(int Id)
        {
            var book = _context.Books.Find(Id);
            book.IsActive = false;
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}