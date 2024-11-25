


public class View
{
    private Controller controlador;

    internal void SetController(Controller controlador) => this.controlador = controlador;

    public void PresentarMenu()
    {
        Console.WriteLine("""
                            1. Añadir Producto
                            2. Añadir Categoría
                            3. Consultar Producto
                            4. Consultar Categoría
                            5. Modificar Producto
                            6. Modificar Categoría
                            7. Eliminar Producto
                            8. Eliminar Categoría
                            9. Listar productos por categorías
                            0. Salir
                            """);
        var entrada = Console.ReadLine();
        controlador.SeleccionMenu(entrada);
    }
    public void ActualizaVista(string salida) => Console.WriteLine(salida);


}