namespace C5_PJ_Restaurante_Cliente_MVC.Models;

public class tb_producto
{
	public int id_producto { get; set; }
	public int id_categoria_producto { get; set; }
	public string? nom_producto { get; set; }
	public string? des_producto { get; set; }
	public decimal preciouni_producto { get; set; }
	public int stock_producto { get; set; }
	public string? imagen_producto { get; set; }
}
