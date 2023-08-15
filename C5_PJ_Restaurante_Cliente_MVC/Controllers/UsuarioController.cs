using C5_PJ_Restaurante_Cliente_MVC.Business;
using C5_PJ_Restaurante_Cliente_MVC.Dao;
using C5_PJ_Restaurante_Cliente_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace C5_PJ_Restaurante_Cliente_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private IUsuario iUsuario;
        private const string SessionLogin = "_Login";
        public UsuarioController()
        {
            iUsuario = new UsuarioDao();
        }
        public IActionResult Index()
        {
            string? login = HttpContext.Session.GetString(SessionLogin);
            if (login == null)
                return View(new Usuario());
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.email_usuario) || string.IsNullOrEmpty(usuario.password_usuario))
            {
                ModelState.AddModelError("", "Ingrese los datos solicitados");
            }
            else
            {
                Usuario existeUsuario = await iUsuario.Login(usuario);
                if (existeUsuario.id_usuario > 0)
                {
                    var jsonUsuario = JsonConvert.SerializeObject(existeUsuario);
                    HttpContext.Session.SetString(SessionLogin, jsonUsuario);
                    return RedirectToAction("Portal", "Producto");
                }
                else
                {
                    ModelState.AddModelError("", "Datos ingresador no son válidos.");
                }
            }
            return View(usuario);
        }

        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Remove(SessionLogin);
            return RedirectToAction("Index");
        }
    }
}
