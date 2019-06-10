using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        /// <summary>
        /// Enumerados para el atributo clasesDelDia de los profesores que integran la lista de profesores
        /// de la universidad y para el atributo claseQueToma para los alumnos de la universidad.
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        /// <summary>
        /// Constructor de instancia para inicializar las listas de Universidad.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el atributo jornada.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para obtener un elemento y agregar un elemento del tipo Jornada
        /// al atributo jornada.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }
        /// <summary>
        /// Guarda los datos de la universidad en un archivo del tipo .xml.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return archivo.Guardar(path + @"Universidad.xml", uni);
        }
        /// <summary>
        /// Leer los datos de la universidad en un archivo del tipo .xml.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!archivo.Leer(path + @"Universidad.xml", out Universidad datos))
                datos = null;

            return datos.ToString();
        }
        /// <summary>
        /// Override del metodo virtual MostrarDatos() para Universidad.
        /// </summary>
        /// <param name="uni"></param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada item in uni.Jornadas)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Sobrecarga del operador != para Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Sobrecarga del operador != para Universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator !=(Universidad u, Universidad.EClases clase)
        {
            Profesor p = null;

            foreach (Profesor item in u.Instructores)
            {
                if(item != clase)
                {
                    p = item;
                    break;
                }
            }

            return p;
        }
        /// <summary>
        /// Sobrecarga del operador + para Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Profesor p = g == clase;

            if(p != null)
            {
                g.Jornadas.Add(new Jornada(clase, p));
            }

            int i = g.Jornadas.IndexOf(g.Jornadas.Last());

            foreach(Alumno item in g.Alumnos)
            {
                if(item == g.Jornadas[i].Clase)
                {
                    g.Jornadas[i] += item;
                }
            }

            if (g.Jornadas[i].Alumnos.Count == 0) // Si no encuentra ningun alumno para cursar la jornada, la jornada agregada se elimina.
                g.Jornadas.Remove(g.Jornadas[i]);
        
            return g;
        }
        /// <summary>
        /// Sobrecarga del operador != para Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Sobrecarga del operador + para Universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return u;
        }
        /// <summary>
        /// Sobrecarga del operador == para Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool flag = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item == a)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
        /// <summary>
        /// Sobrecarga del operador + para Universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);

            return u;
        }
        /// <summary>
        /// Sobrecarga del operador == para Universidad.
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool flag = false;
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    flag = true;
                    break;
                }
            }

            foreach (Alumno item in g.Alumnos)
            {
                if (item == i)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
        /// <summary>
        /// Sobrecarga del operador == para Universidad.
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad u, Universidad.EClases clase)
        {
            Profesor p = null;

            foreach(Profesor item in u.Instructores)
            {
                if(item == clase)
                {
                    p = item;
                    break;
                }
                else
                {
                    throw new SinProfesorException();
                }
            }

            return p;
        }
        /// <summary>
        /// Override del metodo ToString() para mostrar los datos de la universidad.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
    }
}
