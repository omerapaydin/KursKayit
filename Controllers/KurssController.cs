using Kurs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Kurs.Controllers
{
    public class KurssController : Controller
    {
        private readonly DataContext _dataContext;

        public KurssController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Kurslar.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Ogretmenler = new SelectList( _dataContext.Ogretmenler.ToList(),"OgretmenId","Ad");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kurss model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Kurslar.Add(model);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            var kurs = _dataContext.Kurslar.FirstOrDefault(p => p.KursId == id);
            return View(kurs);
        }

        [HttpPost]
        public IActionResult Edit(Kurss kurs, int? id)
        {
            if (id != kurs.KursId)
            {
                return NotFound();
            }
            else
            {
                _dataContext.Kurslar.Update(kurs);
                _dataContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            var krs = _dataContext.Kurslar.FirstOrDefault(p => p.KursId == id);
            if (krs == null)
            {
                return NotFound();
            }

            _dataContext.Kurslar.Remove(krs);
            _dataContext.SaveChanges();

            return RedirectToAction("Index");
        }


          public IActionResult Incele(int? id)
        {
            
            var kurs = _dataContext.Kurslar.Include(p=>p.Ogretmen)
        .Include(k => k.KursKayitlari) 
        .ThenInclude(kayit => kayit.Ogrenci)
        .FirstOrDefault(p => p.KursId == id);

            return View(kurs);
        }
    }
}