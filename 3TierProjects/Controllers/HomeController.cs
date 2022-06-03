using _3TierProjects.Models;
using _3TierProjects1.BAL;
using _3TierProjects2.Service.IServices;
using _3TierProjects3.DAL.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _3TierProjects1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudent _StudentServices;
        private readonly ILogger<HomeController> _log;
        public HomeController(IStudent _StudentServices, ILogger<HomeController> log)
        {
            this._StudentServices = _StudentServices;
            _log = log;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Table()
        {
            _log.LogInformation("Hello you are accesing the Employee Detail");
            var res = _StudentServices.TableShow();
            return View(res);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Form()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Form(StudentModel obj)
        {
            _log.LogInformation("Enter the detail of the Employee Working on Your Team");
            _StudentServices.Save(obj);
            return RedirectToAction("Table");
        }

        
        public IActionResult Delete(int Id)
        {
            _log.LogTrace("Is this Log Trace");
            _StudentServices.delete(Id);

            return RedirectToAction("Table");
        }

        public JsonResult GetbyID(int ID)
        {
            var Employee = _StudentServices.TableShow().Find(x => x.Id.Equals(ID));
            return Json(Employee);
        }       
        [AcceptVerbs("Post")]
        public JsonResult Update(StudentModel emp)
        {
            _StudentServices.Save(emp);
            return Json("Success");
        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
