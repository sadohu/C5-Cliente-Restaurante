using System.ComponentModel.DataAnnotations;

namespace C5_PJ_Restaurante_Cliente_MVC.Models
{
    public class ProductoPortal
    {
        [Display(Name = "Código")]
        public int id_producto { get; set; }
        [Display(Name = "Producto")]
        public string? nom_producto { get; set; }
        [Display(Name = "Descripción")]
        public string? des_producto { get; set; }
        [Display(Name = "Categoria")]
        public string? des_categoria_producto { get; set; }
        [Display(Name = "Precio")]
        public decimal preciouni_producto { get; set; }
        [Display(Name = "Unidades Disponibles")]
        public int stock_producto { get; set; }
        public string? imagen_producto { get; set; }
    }
}
