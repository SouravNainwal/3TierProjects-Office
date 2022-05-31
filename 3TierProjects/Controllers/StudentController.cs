using _3TierProjects1.BAL;
using _3TierProjects3.DAL.model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _3TierProjects.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _db;

        public StudentController(StudentContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel objUser)
        {
            var res = _db.LoginTable.Where(a => a.Email == objUser.Email).FirstOrDefault();

            if (res == null)
            {

                TempData["Invalid"] = "Email is not found";
            }

            else
            {
                if (res.Email == objUser.Email && objUser.Password == objUser.Password)
                {

                    var claims = new[] { /*new Claim(ClaimTypes.Name, res.Name),*/
                                        new Claim(ClaimTypes.Email, res.Email) };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true
                    };
                    HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity),
                    authProperties);

                    TempData["UserName"] = objUser.Name;
                    //HttpContext.Session.SetString("Name", objUser.Email);

                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.Inv = "Wrong Email Id or password";

                    return View("Login");
                }
            }
            return View("Login");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(LoginModel abc)
        {

            _db.LoginTable .Add(abc);
            _db.SaveChanges();

            return RedirectToAction("Login");
        }


        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return View("Login");
        }
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var employeeModelClass = await _db.EmployeeTable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeModelClass == null)
            {
                return NotFound();
            }

            return View(employeeModelClass);
        }
    }
}
