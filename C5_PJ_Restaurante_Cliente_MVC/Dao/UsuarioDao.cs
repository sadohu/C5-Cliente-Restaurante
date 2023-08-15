using C5_PJ_Restaurante_Cliente_MVC.Business;
using C5_PJ_Restaurante_Cliente_MVC.Models;
using Newtonsoft.Json;
using System.Text;


namespace C5_PJ_Restaurante_Cliente_MVC.Dao
{
    public class UsuarioDao : IUsuario
    {
        public Task<Usuario> Add(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Login(Usuario usuario)
        {
            return login(usuario);
        }

        private async Task<Usuario> login(Usuario usuario)
        {
            Usuario existeUsuario = new();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7165/api/Usuario/");
                StringContent content = new(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
				HttpResponseMessage response = await client.PostAsync("loginUsuario", content);
                string cadena = await response.Content.ReadAsStringAsync();
                existeUsuario = JsonConvert.DeserializeObject<Usuario>(cadena);
            }
            return existeUsuario;
        }
    }
}
