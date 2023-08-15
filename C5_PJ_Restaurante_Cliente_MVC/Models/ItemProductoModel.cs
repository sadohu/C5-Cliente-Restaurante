using System.ComponentModel.DataAnnotations;

namespace C5_PJ_Restaurante_Cliente_MVC.Models
{
    public class ItemProductoModel
    {
        [Display(Name = "Código")]
        public int id_producto { get; set; }
        [Display(Name = "Producto")]
        public string? nom_producto { get; set; }
        [Display(Name = "Descripción")]
        public string? des_producto { get; set; }
        [Display(Name = "Categoria")]
        public string? des_categoria_producto { get; set; }
        //comparar con el precio del otro modelo
        [Display(Name = "Precio")]
        public decimal preciouni_producto { get; set; }
        [Display(Name = "Unidades Disponibles")]
        public int stock_producto { get; set; }
        [Display(Name = "Monto")]
        public decimal monto { get { return preciouni_producto * stock_producto; } }
    }
}
