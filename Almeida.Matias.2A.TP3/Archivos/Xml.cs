using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml <T> : IArchivo <T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool flag = false;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamWriter file = new StreamWriter(archivo);
                ser.Serialize(file, datos);
                file.Close();
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            flag = true;

            return flag;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool flag = false;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StreamReader file = new StreamReader(archivo);
                datos = (T)ser.Deserialize(file);
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
