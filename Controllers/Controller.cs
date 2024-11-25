

using P03_01_DI_Productos_TAPIADOR_rodrigo.Models;
using System.Collections;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Controller
{
    private Model modelo;
    private View vista;

    public List<Producto> Productos { get; set; }
    public List<Categoria> Categorias { get; set; }

    public Controller(Model modelo, View vista)
    {
        this.modelo = modelo;
        this.vista = vista;
        vista.SetController(this);
    }

    internal void SeleccionMenu(string? entrada)
    {
        switch (entrada)
        {
            case "1":
                this.AnadirProducto();
                break;
            case "2":
                this.AnadirCategoria();
                break;
            case "3":
                this.ConsultarProducto();
                break;
            case "4":
                this.ConsultarCategoria();
                break;
            case "5":
                this.ModificarProducto();
                break;
            case "6":
                this.ModificarCategoria();
                break;
            case "7":
                this.EliminarProducto();
                break;
            case "8":
                this.EliminarCategoria();
                break;
            case "9":
                this.ListarOrdenado();
                break;
            case "0":
                vista.ActualizaVista("Saliendo del programa...");
                return;
            default:
                vista.ActualizaVista("Opción no válida.");
                break;
        }
        vista.PresentarMenu();
    }

    private void ListarOrdenado()
    {

        List<Categoria> categorias = modelo.Categoria.Categorias;
        List<Producto> productos = modelo.Producto.Productos;
        foreach (var categoria in categorias)
        {
            vista.ActualizaVista(categoria.ToString());
            for (int i = 0; i < productos.Count; i++)
            {
                if (productos[i].Categoria.Nombre.Equals(categoria.Nombre))
                {
                    vista.ActualizaVista("\t" + productos[i].ToString());
                    productos.RemoveAt(i);
                }
            }
        }
    }


    private void EliminarCategoria()
    {

        vista.ActualizaVista("Introduce el nombre de la categoria: ");
        string strCategoria = Console.ReadLine();
        if (!(modelo.Categoria.Consultar(strCategoria) is null))
        {
            modelo.Categoria.Borrar(strCategoria);
            vista.ActualizaVista($"Categoria {strCategoria} eliminado");
        }
        else
        {
            vista.ActualizaVista("La categoria introducida no existe");
        }
    }

    private void EliminarProducto()
    {
        vista.ActualizaVista("Introduce el nombre del producto: ");
        string nombre = Console.ReadLine();
        if (!(modelo.Producto.Consultar(nombre) is null))
        {
            modelo.Producto.Borrar(nombre);
            vista.ActualizaVista($"Producto {nombre} eliminado");

        }
        else
        {
            vista.ActualizaVista("El producto no existe");
        }
    }


    private void ModificarCategoria()
    {
        vista.ActualizaVista("Introduce el nombre de la categoria que quieras modificar: ");
        string strCategoria = Console.ReadLine();
        vista.ActualizaVista("Introduce el nuevo nombre de la categoria: ");
        string strCategorianueva = Console.ReadLine();
        if (!(modelo.Categoria.Consultar(strCategoria) is null))
        {
            modelo.Categoria.Modificar(strCategoria, new Categoria(strCategorianueva));
            vista.ActualizaVista($"Categoria {strCategoria} modificada a {strCategorianueva}");
            List<Producto> lista = modelo.Producto.Productos;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Categoria.Nombre.Equals(strCategoria))
                {
                    modelo.Producto.Modificar(lista[i].Nombre, new Producto(lista[i].Nombre, lista[i].Descripcion, lista[i].Precio, (modelo.Categoria.Consultar(strCategorianueva))));
                }

            }
            vista.ActualizaVista($"Productos de categoria {strCategoria} modificados a {strCategorianueva}");

        }
        else
        {
            vista.ActualizaVista("La categoria introducida no existe");
        }
    }

    private void ModificarProducto()
    {
        vista.ActualizaVista("Introduce el nombre del producto que quieras modificar: ");
        string strProducto = Console.ReadLine();
        Producto anteriorProd = modelo.Producto.Consultar(strProducto);
        if (!string.IsNullOrEmpty(strProducto))
        {


            vista.ActualizaVista(
                "Para mantener cualquiera de los datos anteriores deja el espacio en blanco en el atributo deseado ");
            vista.ActualizaVista($"Introduce el nuevo nombre de la categoria (antes {anteriorProd.Nombre}): ");
            string strProductoNuevo = Console.ReadLine();
            if (string.IsNullOrEmpty(strProductoNuevo))
            {
                strProductoNuevo = anteriorProd.Nombre;
            }

            if (anteriorProd.Nombre.Equals(strProductoNuevo) || (modelo.Producto.Consultar(strProductoNuevo) is null))
            {

                vista.ActualizaVista(
                    $"Introduce una breve descripción del producto (antes {anteriorProd.Descripcion}): ");
                string desc = Console.ReadLine();
                if (string.IsNullOrEmpty(desc))
                {
                    desc = anteriorProd.Descripcion;
                }

                vista.ActualizaVista($"Introduce el precio del producto (antes {anteriorProd.Precio}): ");
                string precioStr = Console.ReadLine();
                double prec = 0;
                if (string.IsNullOrEmpty(precioStr))
                {
                    precioStr = null;
                    prec = anteriorProd.Precio;
                }

                if (precioStr is null || double.TryParse(precioStr, out prec))
                {
                    vista.ActualizaVista($"Introduce la categoria del producto (antes {anteriorProd.Categoria}): ");
                    string strCategoria = Console.ReadLine();
                    Categoria categoria = null;

                    if (string.IsNullOrEmpty(strCategoria))
                    {
                        categoria = anteriorProd.Categoria;
                    }
                    else if (!(modelo.Categoria.Consultar(strCategoria) is null))
                    {
                        categoria = modelo.Categoria.Consultar(strCategoria);
                    }
                    else
                    {
                        vista.ActualizaVista("La categoria introducida no existe");
                    }

                    if (categoria != null)
                    {
                        modelo.Producto.Modificar(strProducto, new Producto(strProductoNuevo, desc, prec, categoria));
                        vista.ActualizaVista("Producto modificado satisfactoriamente");

                    }
                }
                else
                {
                    vista.ActualizaVista("El precio introducido no es válido.");
                }
            }
            else
            {
                vista.ActualizaVista("El producto ya existe");
            }
        }
        else
        {
            vista.ActualizaVista("Nombre no valido");
        }
    }

    private void ConsultarCategoria()
    {
        vista.ActualizaVista("Introduce el nombre de la categoria (Dejar en blanco para todas las categorias): ");
        string nombre = Console.ReadLine(); //Deberia comprobar si la categoria ya existe

        if (string.IsNullOrEmpty(nombre))
        {
            List<Categoria> categorias = modelo.Categoria.Categorias;
            foreach (var categoria in categorias)
            {
                vista.ActualizaVista(categoria.ToString());
            }
        }
        else
        {
            vista.ActualizaVista(modelo.Producto.Consultar(nombre).ToString());
        }
    }

    private void ConsultarProducto()
    {
        vista.ActualizaVista("Introduce el nombre del producto (Dejar en blanco para todos los productos): ");
        string nombre = Console.ReadLine(); //Deberia comprobar si el producto ya existe

        if (string.IsNullOrEmpty(nombre))
        {
            foreach (var producto in modelo.Producto.Productos)
            {
                vista.ActualizaVista(producto.ToString());
            }
        }
        else
        {
            vista.ActualizaVista(modelo.Producto.Consultar(nombre).ToString());
        }
    }

    private void AnadirCategoria()
    {
        vista.ActualizaVista("Introduce el nombre de la categoria: ");
        string nombre = Console.ReadLine(); //Deberia comprobar si la categoria ya existe
        if ((modelo.Categoria.Consultar(nombre) is null))
        {
            modelo.Categoria.Anadir(new Categoria(nombre));
        }
        else
        {
            vista.ActualizaVista("La categoria introducida ya existe");
        }

        vista.ActualizaVista("categoria añadida satisfactoriamente");

    }

    private void AnadirProducto()
    {
        vista.ActualizaVista("Introduce el nombre del producto: ");
        string nombre = Console.ReadLine();
        if ((modelo.Producto.Consultar(nombre) is null))
        {
            vista.ActualizaVista("Introduce una breve descripción del producto: ");
            string desc = Console.ReadLine();
            vista.ActualizaVista("Introduce el precio del producto: ");
            string precioStr = Console.ReadLine();
            if (double.TryParse(precioStr, out double prec))
            {
                vista.ActualizaVista("Introduce la categoria del producto (en blanco para predeterminado): ");
                string strCategoria = Console.ReadLine();
                Categoria categoria = null;

                if (string.IsNullOrEmpty(strCategoria))
                {
                    categoria = modelo.Categoria.Categorias[0];
                }
                else if (!(modelo.Categoria.Consultar(strCategoria) is null))
                {
                    categoria = modelo.Categoria.Consultar(strCategoria);
                }
                else
                {
                    vista.ActualizaVista("La categoria introducida no existe");
                }

                if (categoria != null)
                {
                    modelo.Producto.Anadir(new Producto(nombre, desc, prec, categoria));
                    vista.ActualizaVista("Producto añadido satisfactoriamente");

                }
            }
            else
            {
                vista.ActualizaVista("El precio introducido no es válido.");
            }
        }
        else
        {
            vista.ActualizaVista("El producto ya existe");
        }
    }
}

