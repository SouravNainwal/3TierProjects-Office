using _3TierProjects.Models;
using _3TierProjects1.BAL;
using _3TierProjects2.Service.IServices;
using _3TierProjects3.DAL.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _3TierProjects1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:44380");
        HttpClient Client;

        private readonly IStudent _StudentServices;
        private readonly ILogger<HomeController> _log;
        public HomeController(IStudent _StudentServices, ILogger<HomeController> log)
        {
            Client = new HttpClient();
            Client.BaseAddress = baseAddress;

            this._StudentServices = _StudentServices;
            _log = log;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult Table()
        {
            _log.LogInformation("Hello you are accesing the Employee Detail");
            List<StudentModel> Stlist = new List<StudentModel>();
            HttpResponseMessage response = Client.GetAsync(Client.BaseAddress + "Test/GetDetail").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                Stlist = JsonConvert.DeserializeObject<List<StudentModel>>(data);
            }
            return View(Stlist);

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

            string data = JsonConvert.SerializeObject(obj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage res = Client.PostAsync(Client.BaseAddress + "Test/SetDetail", content).Result;            
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Table");

            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View();
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
        public IActionResult Update(StudentModel emp,int Id)
        {
            _StudentServices.Edit(emp,Id);
            return RedirectToAction("Table");
        }

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
