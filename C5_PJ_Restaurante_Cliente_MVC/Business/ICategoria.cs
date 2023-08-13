using C5_PJ_Restaurante_Cliente_MVC.Models;

namespace C5_PJ_Restaurante_Cliente_MVC.Business
{
    public interface ICategoria
    {
        Task<List<tb_categoria_producto>> GetCategoriaProductos();
    }
}
