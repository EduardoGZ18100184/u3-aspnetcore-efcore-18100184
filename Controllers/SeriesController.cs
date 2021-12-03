using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using u3_aspnetcore_efcore_18100184.Models;

namespace u3_aspnetcore_efcore_18100184.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SeriesContext db;

        public SeriesController(SeriesContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var listadoSeries = db.Series.ToList();
            return View(listadoSeries);
        }
        
        public IActionResult AgregarProductoras()
        {
            Productora productora = new Productora { NombreProductora = "Grupo Secuoya" };
            //insertar en la bd
            db.Add(productora);
            db.SaveChanges();

            Productora productora2 = new Productora { NombreProductora = "Fox Film Corporation" };
            //insertar en la bd
            db.Add(productora2);
            db.SaveChanges();

            Productora productora3 = new Productora { NombreProductora = "BBC Film" };
            //insertar en la bd
            db.Add(productora3);
            db.SaveChanges();

            Productora productora4 = new Productora { NombreProductora = "DC Films" };
            //insertar en la bd
            db.Add(productora4);
            db.SaveChanges();

            Productora productora5 = new Productora { NombreProductora = "Pixar" };            //insertar en la bd
            db.Add(productora5);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult NuevaSerie()
        {
            ViewBag.Productora = new SelectList(db.Productoras, "IdProductora", "NombreProductora");
            return View();
        }

        [HttpPost]
        public IActionResult NuevaSerie(Serie serie)
        {
            if (ModelState.IsValid)
            {
                //insertar en la bd
                db.Add(serie);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(serie);

        }

        public IActionResult EditarSerie(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var serie = db.Series.Find(id);

            if (serie == null)
            {
                return NotFound();
            }

            ViewBag.Productora = new SelectList(db.Productoras, "IdProductora", "NombreProductora");
            return View(serie);

        }
        [HttpPost]
        public IActionResult EditarSerie(Serie serie)
        {

            if (ModelState.IsValid)
            {
                //Actualiza en la bd
                db.Update(serie);
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        public IActionResult EliminarSerie(int id)
        {
            var serie = db.Series.Find(id);

            if (serie == null)
            {
                return NotFound();
            }

            db.Remove(serie);
            db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
