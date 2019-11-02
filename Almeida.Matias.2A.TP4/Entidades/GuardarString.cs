using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Guarda los datos de el o los paquetes en un arhivo de texto en el escritorio.
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool flag = false;

            try
            {
                StreamWriter file = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) 
                    + "\\" + archivo, true);
                file.WriteLine(texto);
                file.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
            flag = true;

            return flag;
        }
    }
}
