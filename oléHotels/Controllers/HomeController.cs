using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OleHotels.Models;
using OleHotels.ViewModels;
using Microsoft.AspNetCore.Http;

namespace OleHotels.Controllers
{
    public class HomeController : Controller
    {
        private const string sessionKey = "logged_user_firstname";
        private const string sessionKeyEmpId = "logged_employeeid";
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var loggedEmployee = _employeeRepository.Login(model.Username, model.Password);
            if (loggedEmployee == null)
            {
                ModelState.AddModelError("Password", "Username or password is not valid");
                return View(model);
            }
            ViewData["EmployeeType"] = loggedEmployee.EmployeeType;

            HttpContext.Session.SetString(sessionKey, loggedEmployee.FirstName);
            HttpContext.Session.SetString(sessionKeyEmpId, loggedEmployee.EmployeeId.ToString());

            return RedirectToAction("Index", "Admin");


        }


        public IActionResult Logout()
        {
            if (!string.IsNullOrWhiteSpace(HttpContext.Session.GetString(sessionKey)))
            {
                HttpContext.Session.SetString(sessionKey, "");
                HttpContext.Session.SetString(sessionKeyEmpId, "");

            }

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
