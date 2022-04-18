using Biblioteca.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class usuarios : Controller
    {
        public IActionResult listagem()
        {
            userService service = new userService();
            List<usuario> usuarios = service.getUsers();
            return View(usuarios);
        }

        public IActionResult novo()
        {
            Autenticacao.CheckLoginAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult novo(usuario novoUsuario)
        {
            userService service = new userService();
            service.CreateUser(novoUsuario);
            return RedirectToAction("listagem");
        }

        public IActionResult editar(int id)
        {
            Autenticacao.CheckLoginAdmin(this);
            ViewBag.id = id;
            userService service = new userService();
            return View(service.getUsers());
        }

        [HttpPost]
        public IActionResult editar(usuario update)
        {
            userService service = new userService();
            service.updateUser(update);
            return RedirectToAction("listagem");
        }

        public IActionResult apagar(int id)
        {
            Autenticacao.CheckLoginAdmin(this);
            userService service = new userService();
            service.deleteUser(id);
            return RedirectToAction("listagem");
        }
    }
}