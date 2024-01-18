using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SztuderWiniecki.BikesApp.BLC;
using SztuderWiniecki.BikesApp.Interfaces;
using SztuderWiniecki.BikesApp.WebInterface.ProxyModels;

namespace SztuderWiniecki.BikesApp.WebInterface.Controllers
{
    public class ProducersController : Controller
    {
        private readonly BLC.BLC _blc;

        public ProducersController(BLC.BLC blc)
        {
            _blc = blc;
        }

        // GET: ProducersController
        public ActionResult Index(string searchString)
        {
            var producers = _blc.GetProducers();

            if (!String.IsNullOrEmpty(searchString))
            {
                producers = producers.Where(s => s.Name!.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase) || s.Address!.Contains(searchString, System.StringComparison.CurrentCultureIgnoreCase));
            }

            ViewBag.SearchString = searchString;

            return View(producers);
        }

        // GET: ProducersController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IProducer? producer = _blc.GetProducer((int)id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // GET: ProducersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProducersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id, Name, Address")] ProxyProducer producer)
        {
            if (ModelState.IsValid)
            {
                IProducer daoProducer = _blc.CreateProducer().CopyFrom(producer);

                _blc.AddProducer(daoProducer);
                _blc.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }

        // GET: ProducersController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IProducer? producer = _blc.GetProducer((int)id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: ProducersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id, Name, Address")] ProxyProducer producer)
        {
            if (id != producer.Id)
            {
                return NotFound();
            }

            // cannot bind to interface, so create proxy object and rewrite its values to DAO object
            IProducer? daoProducer = _blc.GetProducer(producer.Id);
            if (daoProducer == null)
            {
                return NotFound();
            }

            daoProducer.CopyFrom(producer);

            if (ModelState.IsValid)
            {
                try
                {
                    _blc.UpdateProducer(daoProducer);
                    _blc.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
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
            return View(daoProducer);
        }

        // GET: ProducersController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IProducer? producer = _blc.GetProducer((int)id);
            if (producer == null)
            {
                return NotFound();
            }

            return View(producer);
        }

        // POST: ProducersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("Id, Name, Address")] ProxyProducer producer)
        {
            _blc.RemoveProducer(id);
            _blc.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
