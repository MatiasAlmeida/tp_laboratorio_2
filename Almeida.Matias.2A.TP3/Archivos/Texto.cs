using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo <string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool flag = false;

            try
            {
                StreamWriter file = new StreamWriter(archivo);
                file.Write(datos);
                file.Close();
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }

            flag = true;

            return flag;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool flag = false;

            try
            {
                StreamReader file = new StreamReader(archivo);
                datos = file.ReadToEnd();
                file.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            flag = true;

            return flag;
        }
    }
}
