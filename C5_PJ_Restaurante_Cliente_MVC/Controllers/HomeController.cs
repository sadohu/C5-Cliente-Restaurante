using C5_PJ_Restaurante_Cliente_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace C5_PJ_Restaurante_Cliente_MVC.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        async Task<List<tb_producto>> getProductos()
        {
            List<tb_producto> lista = new List<tb_producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/producto/");
                HttpResponseMessage mensaje = await client.GetAsync("getProductos");
                string cadena = await mensaje.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<tb_producto>>(cadena).Select(
                p => new tb_producto
                {
                    id_producto = p.id_producto,
                    id_categoria_producto = p.id_categoria_producto,
                    nom_producto = p.nom_producto,
                    des_producto = p.des_producto,
                    preciouni_producto = p.preciouni_producto,
                    stock_producto = p.stock_producto
                }).ToList();
            }
            return lista;
        }//Fin de getProductos

    }
}