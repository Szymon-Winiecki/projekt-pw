using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SztuderWiniecki.BikesApp.BLC;

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
            return View();
        }

        // GET: BikesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BikesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BikesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BikesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
