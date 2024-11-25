using System.Xml.Schema;

internal class Program
{

    //Modelo vista controlador, por lo que entiendo la vista le da la informacion al usuario,
    //este decide que hacer y se lo dice al controlador para que el controlador ejecute la orden utilizando los datos del modelo.
    //Controlador actualiza el modelo si es necesario y posteriormente actualiza la vista para que el usuario esté informado.
    //De esta forma el controlador esta en contacto con todas las partes, modelo solo con controlador y la vista muestra informacion al usuario y la recibe del controlador.
    private static void Main(string[] args)
    {
        Model modelo = new();
        View vista = new();
        Controller controlador = new(modelo, vista);

        vista.PresentarMenu();
    }

}