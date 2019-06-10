using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        /// <summary>
        /// Enumerados del estado de cuenta para el atributo estadoCuenta.
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
        /// <summary>
        /// Constructor de instancia por default de Alumno.
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor de instancia por parametros de Alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        /// <summary>
        /// Constructor de instancia por parametro de Alumno.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        /// <summary>
        /// Override del metodo virtual MostrarDatos() para Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder(base.MostrarDatos());
            string aux = null;

            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    aux = "Cuota al día";
                    break;
                case EEstadoCuenta.Becado:
                    aux = "Está becado";
                    break;
                case EEstadoCuenta.Deudor:
                    aux = "Deudor";
                    break;
                default:
                    break;
            }

            sb.AppendLine();
            sb.AppendLine();
            sb.Append("ESTADO DE CUENTA: ");
            sb.AppendLine(aux);

            return sb.ToString();
        }
        /// <summary>
        /// Override del metodo abstracto ParticiparEnClase() de Alumno.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE " + this.claseQueToma.ToString();
        }
        /// <summary>
        /// Override del metodo ToString() para mostrar los datos del alumno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos() + this.ParticiparEnClase();
        }
        /// <summary>
        /// Sobrecarga del operador == para Alumno.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma == clase && a.estadoCuenta != Alumno.EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Sobrecarga del operador != para Alumno.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return a.claseQueToma != clase;
        }
    }
}
