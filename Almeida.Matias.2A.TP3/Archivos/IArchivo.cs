using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Metodo de interfaz generico para guardar cualquier tipo de dato.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);
        /// <summary>
        /// Metodo de interfaz generico para leer cualquier tipo de dato.
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);
    }
}
