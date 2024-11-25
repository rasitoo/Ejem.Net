using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03_01_DI_Productos_TAPIADOR_rodrigo.Models
{
    public class Categoria
    {
        public override string ToString()
        {
            return $"{nameof(Nombre)}: {Nombre}";
        }

        public Categoria(string nombre)
        {
            Nombre = nombre;
        }

        public string Nombre { get; set; }
    }
}
