using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2018
{
    public class Snacks : Producto
    {
        /// <summary>
        /// Constructor de Snacks que inicializa con parametros los atributos de la clase heradada Producto.
        /// </summary>
        /// <param name="marca"> Marca del producto de tipo Snacks. </param>
        /// <param name="patente"> Código de barras del producto de tipo Snacks. </param>
        /// <param name="color"> Color del paquete del producto de tipo Snacks. </param>
        public Snacks(EMarca marca, string patente, ConsoleColor color) : base(patente, marca, color)
        {
        }
        /// <summary>
        /// Los snacks tienen 104 calorías.
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 104;
            }
        }
        /// <summary>
        /// Muestra los datos del objeto Snacks.
        /// </summary>
        /// <returns> Retorna una string con los datos apilados del objeto Snacks. </returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SNACKS");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
