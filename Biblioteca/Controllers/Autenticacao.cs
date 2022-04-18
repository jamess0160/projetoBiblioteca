using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Biblioteca.Controllers
{
    public class Autenticacao
    {
        public static void CheckLogin(Controller controller)
        {   
            if(string.IsNullOrEmpty(controller.HttpContext.Session.GetString("user")))
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }

        public static void CheckLoginAdmin(Controller controller)
        {   
            if(controller.HttpContext.Session.GetString("user") != "admin")
            {
                controller.Request.HttpContext.Response.Redirect("/Home/Login");
            }
        }
    }
}