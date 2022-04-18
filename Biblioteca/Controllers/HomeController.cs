using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

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
        public IActionResult Login(usuario credenciais)
        {
            CriarMD5 md5 = new CriarMD5();
            credenciais.id = 3;
            credenciais.senha = md5.RetornarMD5(credenciais.senha);
            userService service = new userService();
            List<usuario> usuarios = service.getUsers();
            var validacao = false;
            foreach(usuario item in usuarios){
                if(item.nome == credenciais.nome && item.senha == credenciais.senha){
                   validacao = true;
                }
            }
            if (validacao)
            {
                HttpContext.Session.SetString("user", credenciais.nome);
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
