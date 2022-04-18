using Biblioteca.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class usuarios : Controller
    {
        public IActionResult listagem()
        {
            Autenticacao.CheckLoginAdmin(this);
            new banco();
            List<usuario> result;
            result = banco.selectUsuarios();
            return View(result);
        }

        public IActionResult novo()
        {
            Autenticacao.CheckLoginAdmin(this);
            return View();
        }

        [HttpPost]
        public IActionResult novo(string nome, string senha)
        {
            Autenticacao.CheckLoginAdmin(this);
            new banco();
            banco.novoUsuario(nome, senha);
            return RedirectToAction("listagem");
        }

        public IActionResult editar(int id)
        {
            Autenticacao.CheckLoginAdmin(this);
            ViewBag.id = id;
            new banco();
            List<usuario> result;
            result = banco.selectUsuarios();
            return View(result);
        }

        [HttpPost]
        public IActionResult editar(int id, string nome, string senha)
        {
            Autenticacao.CheckLoginAdmin(this);
            new banco();
            usuario usuario = new usuario(id, nome, senha);
            banco.updateUsuario(id, usuario);
            return RedirectToAction("listagem");
        }

        public IActionResult apagar(int id)
        {
            Autenticacao.CheckLoginAdmin(this);
            new banco();
            banco.deleteUsuario(id);
            return RedirectToAction("listagem");
        }
    }
}