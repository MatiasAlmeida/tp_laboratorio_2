using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        /// <summary>
        /// Inicializa el atributo clasesDelDia con dos clases aleatorias.
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (random.Next(4))
                {
                    case 0:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                    default:
                        break;
                }
            }
        }
    
        /// <summary>
        /// Override del metodo virtual MostrarDatos() para Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos();
        }
        /// <summary>
        /// Sobrecarga del operador == para Profesor.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool flag = false;

            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if(item == clase)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
        /// <summary>
        /// Sobrecarga del operador != para Profesor.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        /// <summary>
        /// Override del metodo abstracto ParticiparEnClase() para Profesor.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA:");
            foreach (Universidad.EClases item in clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Constructor de instancia privado de Profesor.
        /// </summary>
        private Profesor()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        /// <summary>
        /// Constructor de clase para Profesor.
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }
        /// <summary>
        /// Constructor de instancia con parametros para Profesor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Profesor().clasesDelDia;
        }
        /// <summary>
        /// Override del metodo ToString() que muestra los datos del profesor.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(this.MostrarDatos());
            sb.AppendLine();
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }
    }
}
