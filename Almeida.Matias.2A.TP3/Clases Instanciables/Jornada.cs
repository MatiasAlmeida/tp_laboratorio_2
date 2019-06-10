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

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto archivo = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return archivo.Guardar(path + @"Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto archivo = new Texto();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!archivo.Leer(path + @"Jornada.txt", out string datos))
                datos = null;

            return datos;
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

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

        public static bool operator ==(Jornada j, Alumno a)
        {
            return a == j.Clase;
        }

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
