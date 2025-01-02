using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    public class HomeController:Controller
    {
        private DataContext _dataContext;
        public HomeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
         public IActionResult Index()
        {
            return View(_dataContext.Ogrenciler.ToList());
        }
         public IActionResult Create()
        {
            return View();
        }
         [HttpPost]
        public IActionResult Create(Ogrenci model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Ogrenciler.Add(model);
                _dataContext.SaveChanges(); 
                return RedirectToAction("Index");
            }
            return View(model); 
        }
         public IActionResult Edit(int? id)
        {
            var ogr = _dataContext.Ogrenciler.FirstOrDefault(p=>p.OgrenciId==id);
            return View(ogr);
        }
        [HttpPost]
         public IActionResult Edit(Ogrenci ogrenci,int? id)
        {
             if(id!=ogrenci.OgrenciId)
             {
                NotFound();
             }else{
                _dataContext.Ogrenciler.Update(ogrenci);
                _dataContext.SaveChanges();
             }


             return RedirectToAction("Index");

        }
        public IActionResult Delete(int? id)
        {
            var ogr = _dataContext.Ogrenciler.FirstOrDefault(p=>p.OgrenciId==id);

            _dataContext.Ogrenciler.Remove(ogr);
                _dataContext.SaveChanges();

            return View();
        }


    }
}