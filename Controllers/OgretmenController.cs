using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Data;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers
{
    public class OgretmenController:Controller
    {
          private readonly DataContext _dataContext;

        public OgretmenController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            return View(_dataContext.Ogretmenler.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Ogretmen model)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Ogretmenler.Add(model);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}