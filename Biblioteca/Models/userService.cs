using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Biblioteca.Models
{
    public class userService
    {
        public int CreateUser(usuario novoUsuario)
        {
            using (var context = new BibliotecaContext())
            {
                context.Add(novoUsuario);
                context.SaveChanges();
                return novoUsuario.id;
            }
        }

        public List<usuario> getUsers()
        {
            using (var context = new BibliotecaContext())
            {
                List<usuario> usuarios = context.usuarios.ToList();
                return usuarios;
            }
        }

        public void updateUser(usuario User)
        {
            using (var context = new BibliotecaContext())
            {
                usuario registro = context.usuarios.Find(User.id);
                if (registro != null)
                {
                    registro.nome = User.nome;
                    registro.senha = User.senha;

                    context.SaveChanges();
                }
            }
        }

        public void deleteUser(int id)
        {
            using (var context = new BibliotecaContext())
            {
                usuario registro = context.usuarios.Find(id);
                if (registro != null)
                {
                    context.usuarios.Remove(registro);
                    context.SaveChanges();
                }
            }
        }

    }
}
