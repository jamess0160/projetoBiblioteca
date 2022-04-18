using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Autenticacao.CheckLogin(this);
            ViewBag.usuario = HttpContext.Session.GetString("user");
            return View();
        }

        public IActionResult Login()
        {
            return View(true);
        }

        [HttpPost]
        public IActionResult Login(string login, string senha)
        {
            new banco();
            string validacao = banco.checkLogin(login, senha);
            if (validacao == "correto")
            {
                HttpContext.Session.SetString("user", login);
                return RedirectToAction("Index");
            }
            else
            {
                return View(false);

            }

        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
