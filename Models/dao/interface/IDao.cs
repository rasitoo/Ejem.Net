using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_01_DI_Productos_TAPIADOR_rodrigo.Models.dao.@interface
{
    public interface IDao<T>
    {
        void Anadir(T objeto);
        void Modificar(string nombre, T objeto);
        T Consultar(string nombre);
        void Borrar(string nombre);
    }
}
