using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;
        /// <summary>
        /// Override del metodo Equals() para que compare si el tipo del otro objeto es Universitario.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario && (((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo);
        }
        /// <summary>
        /// Metodo virtual que devuelve los dato de Universitario.
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("LEGAJO NÚMERO: {0}", this.legajo);

            return base.ToString() + sb.ToString();
        }
        /// <summary>
        /// Firma del metodo abstracto ParticiparEnClase.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        /// <summary>
        /// Sobrecarga del operador == que devuelve un booleano.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }
        /// <summary>
        /// Sobrecarga del operador != que devuelve un booleano.
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Constructor de instancia por default de Universitario.
        /// </summary>
        public Universitario() : base()
        {

        }
        /// <summary>
        /// Constructor de instancia con parametros de Universitario.
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
    }
}
