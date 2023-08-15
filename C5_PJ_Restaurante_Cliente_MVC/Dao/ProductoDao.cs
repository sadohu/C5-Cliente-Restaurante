using C5_PJ_Restaurante_Cliente_MVC.Business;
using C5_PJ_Restaurante_Cliente_MVC.Models;
using Newtonsoft.Json;
using System.Text;

namespace C5_PJ_Restaurante_Cliente_MVC.Dao
{
    public class ProductoDao : IProducto
    {
        public Task<List<ProductoPortal>> GetProductosPortal()
        {
            return getProductoPortal();
        }
        public Task<List<tb_producto>> GetProductos()
        {
            return getProductos();
        }

        public Task<ProductoPortal> BuscarAsync(int id)
        {
            return buscarAsync(id);
        }

		public Task<string> Comprar(Pedido pedido)
		{
			return comprar(pedido);
		}

		private async Task<List<tb_producto>> getProductos()
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
        }

        private async Task<List<ProductoPortal>> getProductoPortal()
        {
            List<ProductoPortal> pro = new List<ProductoPortal>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/producto/"); //TODO
                HttpResponseMessage mensaje = await client.GetAsync("getProductosPortal");
                string cadena = await mensaje.Content.ReadAsStringAsync();
                pro = JsonConvert.DeserializeObject<List<ProductoPortal>>(cadena).Select(
                    p => new ProductoPortal
                    {
                        id_producto = p.id_producto,
                        nom_producto = p.nom_producto,
                        des_producto = p.des_producto,
                        des_categoria_producto = p.des_categoria_producto,
                        preciouni_producto = p.preciouni_producto,
                        stock_producto = p.stock_producto,
                        imagen_producto = p.imagen_producto
                    }).ToList();
            }
            return pro;
        }

        private async Task<ProductoPortal> buscarAsync(int id)
        {
            List<ProductoPortal> productos = await getProductoPortal();
            var producto = productos.Where(p => p.id_producto == id).FirstOrDefault();
            if (producto == null)
            {
                producto = new ProductoPortal();
            }
            return producto;
        }

		private async Task<string> comprar(Pedido pedido)
		{
			string respuesta = "";
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("https://localhost:7165/api/Pedido/");
				StringContent content = new(JsonConvert.SerializeObject(pedido), Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync("savePedido", content);
				respuesta = await response.Content.ReadAsStringAsync();
			}
			return respuesta;
		}
	}
}
