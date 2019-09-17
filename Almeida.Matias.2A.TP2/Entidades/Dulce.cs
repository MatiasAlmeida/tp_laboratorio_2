using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Dulce : Producto
    {
        /// <summary>
        /// Constructor de Dulce que inicializa con parametros los atributos de la clase heradada Producto.
        /// </summary>
        /// <param name="marca"> Marca del producto de tipo Dulce. </param>
        /// <param name="codigo"> Código de barras del producto de tipo Dulce. </param>
        /// <param name="color"> Color del empaque del producto de tipo Dulce. </param>
        public Dulce(EMarca marca, string codigo, ConsoleColor color) : base(codigo, marca, color)
        {
        }

        /// <summary>
        /// Los dulces tienen 80 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 80;
            }
        }
        /// <summary>
        /// Muestra los datos del producto de tipo Dulce.
        /// </summary>
        /// <returns> Retorna una string con los datos apilados del producto. </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("DULCE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
