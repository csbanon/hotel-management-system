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
    public class ClientController : Controller
    {
        private const string sessionKey = "client_login";
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IActionResult Login()
        {
            var model = new ClientLoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(ClientLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = _clientRepository.Login(model.Username, model.Password);
                if (client == null)
                {
                    ModelState.AddModelError("Password", "Username or password are not valid");
                }
                else
                {
                    HttpContext.Session.SetString(sessionKey, client.ClientId.ToString());
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public IActionResult SignUp()
        {
            var model = new Client();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(Client model)
        {
            if (ModelState.IsValid)
            {
                var newClient = _clientRepository.Create(model);
                if (newClient != null && newClient.ClientId > 0)
                {
                    HttpContext.Session.SetString(sessionKey, newClient.ClientId.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Firstname", "Error creating the user. Please Contact Support.");
                }
            }
            return View();
        }

    }
}