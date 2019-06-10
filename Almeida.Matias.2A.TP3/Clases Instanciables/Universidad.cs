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

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i]; }
            set { this.jornada[i] = value; }
        }

        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;
            return archivo.Guardar(path + @"Universidad.xml", uni);
        }

        public static string Leer()
        {
            Xml<Universidad> archivo = new Xml<Universidad>();
            string path = AppDomain.CurrentDomain.BaseDirectory;

            if (!archivo.Leer(path + @"Universidad.xml", out Universidad datos))
                datos = null;

            return datos.ToString();
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
                u.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return u;
        }

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

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
                u.Instructores.Add(i);

            return u;
        }

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

        public override string ToString()
        {
            /*string aux = null;
            foreach(Profesor item in this.Instructores)
            {
                aux += item.ToString();
            }

            return aux;*/
            return Universidad.MostrarDatos(this);
        }
    }
}
