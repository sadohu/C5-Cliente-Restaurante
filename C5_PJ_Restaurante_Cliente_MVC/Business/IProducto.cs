using C5_PJ_Restaurante_Cliente_MVC.Models;

namespace C5_PJ_Restaurante_Cliente_MVC.Business
{
    public interface IProducto
    {
        Task<List<ProductoPortal>> GetProductosPortal();
        Task<List<tb_producto>> GetProductos();
        Task<ProductoPortal> BuscarAsync(int id);

    }
}
