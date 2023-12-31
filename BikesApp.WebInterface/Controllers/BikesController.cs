﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Interfaces;
using SztuderWiniecki.BikesApp.WebInterface.ProxyModels;

namespace SztuderWiniecki.BikesApp.WebInterface.Controllers
{
    public class BikesController : Controller
    {
        private readonly BLC.BLC _blc;

        public BikesController(BLC.BLC blc)
        {
            _blc = blc;
        }

        // GET: BikesController
        public ActionResult Index()
        {
            return View(_blc.GetBikes());
        }

        // GET: BikesController/Details/5
        public ActionResult Details(int id)
        {
            IBike? bike = _blc.GetBike(id);
            if (bike == null)
            {
                return NotFound();
            }
            
            return View(bike);
        }

        // GET: BikesController/Create
        public ActionResult Create()
        {
            ViewBag.Producers = _blc.GetProducers();
            return View(_blc.CreateBike());
        }

        // POST: BikesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("ID,Name,ReleaseYear,Type")] ProxyBike bike, [Bind("Producer")] int Producer)
        {
            // cannot bind to interface, so we create proxy object and rewrite its values to DAO object
            IBike? daoBike = _blc.CreateBike();

            daoBike.CopyFrom(bike);

            IProducer? producer = _blc.GetProducer(Producer);
            if (producer == null)
            {
                return NotFound();
            }

            daoBike.Producer = producer;


            ModelState.Remove("Producer");
            if (ModelState.IsValid)
            {
                try
                {
                    _blc.AddBike(daoBike);
                    _blc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    System.Diagnostics.Debug.WriteLine("DbUpdateConcurrencyException");
                    /*if (!BikeExists(bike.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }


        // GET: BikesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IBike? bike = _blc.GetBike((int)id);
            if(bike == null)
            {
                return NotFound();
            }

            ViewBag.Producers = _blc.GetProducers();

            return View(bike);
        }

        // POST: BikesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("ID,Name,ReleaseYear,Type")] ProxyBike bike, [Bind("Producer")] int Producer)
        {
            if (id != bike.ID)
            {
                return NotFound();
            }

            // cannot bind to interface, so we create proxy object and rewrite its values to DAO object
            IBike? daoBike = _blc.GetBike(bike.ID);
            if(daoBike == null)
            {
                return NotFound();
            }

            daoBike.CopyFrom(bike);

            IProducer? producer = _blc.GetProducer(Producer);
            if(producer == null)
            {
                return NotFound();
            }

            daoBike.Producer = producer;
            

            ModelState.Remove("Producer");
            if (ModelState.IsValid)
            {
                try
                {
                    _blc.UpdateBike(daoBike);
                    _blc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    System.Diagnostics.Debug.WriteLine("DbUpdateConcurrencyException");
                    /*if (!BikeExists(bike.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }*/
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        // GET: BikesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BikesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
