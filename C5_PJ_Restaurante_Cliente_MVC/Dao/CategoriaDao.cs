using C5_PJ_Restaurante_Cliente_MVC.Business;
using C5_PJ_Restaurante_Cliente_MVC.Models;
using Newtonsoft.Json;

namespace C5_PJ_Restaurante_Cliente_MVC.Dao
{
    public class CategoriaDao : ICategoria
    {
        public Task<List<tb_categoria_producto>> GetCategoriaProductos()
        {
            return getCategoriaProductos();
        }

        async Task<List<tb_categoria_producto>> getCategoriaProductos()
        {
            List<tb_categoria_producto> lista = new List<tb_categoria_producto>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/categoria/");
                HttpResponseMessage mensaje = await client.GetAsync("getCategoria");
                string cadena = await mensaje.Content.ReadAsStringAsync();
                lista = JsonConvert.DeserializeObject<List<tb_categoria_producto>>(cadena).Select(
                c => new tb_categoria_producto
                {
                    id_categoria_producto = c.id_categoria_producto,
                    des_categoria_producto = c.des_categoria_producto,
                }).ToList();
            }
            return lista;
        }
    }
}
