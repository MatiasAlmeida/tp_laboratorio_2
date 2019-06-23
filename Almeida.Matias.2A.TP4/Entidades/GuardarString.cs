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
