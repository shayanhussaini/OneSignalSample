using OneSignalApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace OneSignalApp.Controllers
{
    public class HomeController : Controller
    {
        private IAppRestService _carsService;
       
        public HomeController()
        {
            var container = new UnityContainer();
            _carsService = container.Resolve<AppRestService>();
        }
        [Authorize(Roles = "Admin,User")]
        public ActionResult Index()
        {            
            var list = _carsService.Get();
            return View(list);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "name, site_name")]AppModel app)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _carsService.Create(app);
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            //return View(app);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
             return View(_carsService.GetById(id));            
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id, AppModel app)
        {
            var updateapp = _carsService.Update(app);
            return RedirectToAction("Index");
        }
    }
}