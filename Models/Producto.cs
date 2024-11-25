using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_01_DI_Productos_TAPIADOR_rodrigo.Models
{
    public class Producto
    {
        public override string ToString()
        {
            return
                $"""
                 
                 {nameof(Nombre)}: {Nombre}
                     {nameof(Descripcion)}: {Descripcion}
                     {nameof(Precio)}: {Precio}
                     {nameof(Categoria)}:
                        {Categoria.ToString()}
                 
                 """;
        }

        public Producto(string nombre, string descripcion, double precio, Categoria? categoria)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Categoria = categoria;
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public Categoria Categoria { get; set; }
    }
}
