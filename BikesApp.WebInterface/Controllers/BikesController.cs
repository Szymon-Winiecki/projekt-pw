using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Core;
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
        public ActionResult Index(string searchString, string typeFilter)
        {
            var bikes = _blc.GetBikes();
            if (!String.IsNullOrEmpty(searchString))
            {
                bikes = bikes.Where(s => s.Name!.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase) || s.Producer.Name!.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase));
            }

            if(!String.IsNullOrEmpty(typeFilter))
            {
                bikes = bikes.Where(s => s.Type.ToString() == typeFilter);
            }

            ViewBag.SearchString = searchString;

            return View(bikes);
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
            ViewBag.Types = Enum.GetNames(typeof(BikeType));
            return View(_blc.CreateBike());
        }

        // POST: BikesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,ReleaseYear,Type")] ProxyBike bike, [Bind("Producer")] int Producer)
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
            ViewBag.Types = Enum.GetNames(typeof(BikeType));

            return View(bike);
        }

        // POST: BikesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,ReleaseYear,Type")] ProxyBike bike, [Bind("Producer")] int Producer)
        {
            if (id != bike.Id)
            {
                return NotFound();
            }

            // cannot bind to interface, so we create proxy object and rewrite its values to DAO object
            IBike? daoBike = _blc.GetBike(bike.Id);
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
                    /*if (!BikeExists(bike.Id))
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IBike? bike = _blc.GetBike((int)id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: BikesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("Id,Name,ReleaseYear,Type,Producer")] ProxyBike bike)
        {
            _blc.RemoveBike(id);
            _blc.SaveChanges();
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
