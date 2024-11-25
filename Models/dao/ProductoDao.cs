using P03_01_DI_Productos_TAPIADOR_rodrigo.Models.dao.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P03_01_DI_Productos_TAPIADOR_rodrigo.Models.dao
{


    public class ProductoDao : IDao<Producto>
    {
        public ProductoDao()
        {
            Productos = new();
        }

        public List<Producto> Productos { get; set; }

        public void Anadir(Producto producto)
        {
                Productos.Add(producto);
            
        }

        public void Borrar(string nombre)
        {
            int posicion = buscarPosicion(nombre);
            if (posicion != -1)
            {
                Productos.RemoveAt(posicion);
            }
        }

        private int buscarPosicion(string nombre)
        {
            return Productos.FindIndex(c => c.Nombre.Equals(nombre));
        }

        public Producto Consultar(string nombre)
        {
            foreach (var producto in Productos)
            {
                if (producto.Nombre.Equals(nombre))
                {
                    return producto;
                }
            }

            return null;
        }

        public void Modificar(string nombre,Producto producto)
        {
            int posicion = buscarPosicion(nombre);
            if (posicion != -1)
            {
                Productos[posicion] = producto;
            }
        }
    }
}
