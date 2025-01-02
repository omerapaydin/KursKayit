using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Kurs.Controllers
{
    public class KursKayitController:Controller
    {
         private DataContext _dataContext;
        public KursKayitController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
       public async Task<IActionResult> Index()
        {
            var krst = await _dataContext.KursKayitlari.Include(x=>x.Ogrenci).Include(y=>y.Kurs).ToListAsync();
            return View(krst);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Ogrenciler = new SelectList(await _dataContext.Ogrenciler.ToListAsync(),"OgrenciId","AdSoyad");
            ViewBag.Kurslar = new SelectList(await _dataContext.Kurslar.ToListAsync(),"KursId","Baslik");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KursKayit model)
        {
            model.KayitTarihi = DateTime.Now;
            _dataContext.KursKayitlari.Add(model);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}