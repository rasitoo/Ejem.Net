using P03_01_DI_Productos_TAPIADOR_rodrigo.Models.dao;

public class Model
{
    public Model()
    {
        Producto = new();
        Categoria = new();
    }

    public ProductoDao Producto { get; set; }
    public CategoriaDao Categoria { get; set; }
}