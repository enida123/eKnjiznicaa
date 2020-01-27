using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKnjiznica.Data;
using eKnjiznica.Data.EF;
using eKnjiznica.Web.Areas.Administrator.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eKnjiznica.Web.Areas.Administrator.Controllers
{
    [Area("Administrator")]

    public class KategorijeController : Controller
    {
        private readonly MyContext _context;

        public KategorijeController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.Categories.ToList();
            return View(new KategorijaListVM {
                categories = list
            });
        }
        public IActionResult Dodaj()
        {
            KategorijaAddEditVM model = new KategorijaAddEditVM {
                kategorija = new Categories()
            };

            return View(model);
        }
        public IActionResult Edit(int Id)
        {

            KategorijaAddEditVM model = new KategorijaAddEditVM
            {
                kategorija = _context.Categories.Find(Id)
            };
            return View(nameof(Dodaj), model);
        }
        public IActionResult Snimi(KategorijaAddEditVM model)
        {
            Categories categorie = null;
            if (model.kategorija.Id != 0)
            {
                categorie = model.kategorija;
               


                _context.Categories.Update(categorie);
                _context.SaveChanges();
            }
            else
            {
                categorie = new Categories
                {
                    Id = model.kategorija.Id,
                    Name=model.kategorija.Name,
                    IsActive=true

                };
                _context.Categories.Add(categorie);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
           
        }

        public IActionResult Disable(int Id)
        {
            var categorie = _context.Categories.Find(Id);
            categorie.IsActive = false;
            _context.Categories.Update(categorie);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}