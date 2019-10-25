using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using System.IO;

namespace EntidadesInstanciables 
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        /// <summary>
        /// Propiedad de lectura y escritura del atributo alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor.
        /// </summary>
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto txt.
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivo = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return archivo.Guardar(path + @"Jornada.txt", jornada.ToString());
        }
        /// <summary>
        /// Lee los datos de la jornada en un archivo de texto txt.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto archivo = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!archivo.Leer(path + @"Jornada.txt", out string datos))
                datos = null;

            return datos;
        }
        /// <summary>
        /// Constructor de instancia privado de Jornada.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor de instancia con parametros de Jornada.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        /// <summary>
        /// Sobrecarga del operador != para Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sobrecarga del operador + para Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            bool flag = false;

            foreach(Alumno item in j.Alumnos)
            {
                if(j == a && item == a)
                {
                    flag = true;
                    break;
                }
            }

            if (!flag)
                j.Alumnos.Add(a);

            return j;
        }
        /// <summary>
        /// Sobrecarga del operadaor == para Jornada.
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }
        /// <summary>
        /// Override del metodo ToString() para mostrar los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clase.ToString(), this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno item in this.Alumnos)
            {
                sb.AppendLine(item.ToString());               
            }
            sb.AppendLine("<----------------------------------------------------->");

            return sb.ToString();
        }

    }
}
