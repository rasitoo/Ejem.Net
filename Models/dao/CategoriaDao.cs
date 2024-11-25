using P03_01_DI_Productos_TAPIADOR_rodrigo.Models.dao.@interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_01_DI_Productos_TAPIADOR_rodrigo.Models.dao
{
    public class CategoriaDao : IDao<Categoria>
    {
        public CategoriaDao()
        {
            Categorias = new();
            Anadir(new Categoria("Otros"));
        }

        public List<Categoria> Categorias { get; set; }

        public void Anadir(Categoria categoria)
        {
            Categorias.Add(categoria);
        }

        public void Borrar(string nombre)
        {
            int posicion = buscarPosicion(nombre);
            if (posicion != -1)
            {
                Categorias.RemoveAt(posicion);
            }
        }

        public Categoria Consultar(string nombre)
        {
            foreach (var categoria in Categorias)
            {
                if (categoria.Nombre.Equals(nombre))
                {
                    return categoria;
                }
            }

            return null;
        }

        public int buscarPosicion(string nombre)
        {
            return  Categorias.FindIndex(c => c.Nombre.Equals(nombre));
        }

        public void Modificar( string nombre,Categoria categoria)
        {
            int posicion = buscarPosicion(nombre);
            if (posicion != -1)
            {
                Categorias[posicion] = categoria;
            }
        }
    }
}
