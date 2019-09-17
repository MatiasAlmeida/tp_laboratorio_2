using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2018
{
    public class Leche : Producto
    {
        public enum ETipo { Entera, Descremada }
        private ETipo tipo;

        /// <summary>
        /// Constructor de Leche que inicializa con parametros los atributos de la clase heradada Producto.
        /// </summary>
        /// <param name="marca"> Marca del producto de tipo Leche. </param>
        /// <param name="codigo"> Código de barras del producto de tipo Leche. </param>
        /// <param name="color"> Color del empaque del producto de tipo Leche. </param>
        /// <param name="tipo"> Tipo de leche. </param>
        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color)
        {
            this.tipo = tipo;
        }
        /// <summary>
        /// Por defecto, TIPO será ENTERA.
        /// </summary>
        /// <param name="marca"> Marca del producto de tipo Leche. </param>
        /// <param name="codigo"> Código de barras del producto de tipo Leche. </param>
        /// <param name="color"> Color del empaque del producto de tipo Leche. </param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : this(marca, codigo, color, ETipo.Entera)
        {
        }

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }
        /// <summary>
        /// Muestra los datos del producto de tipo Leche.
        /// </summary>
        /// <returns> Retorna una string con los datos apilados del producto. </returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("CALORIAS : {0}", this.CantidadCalorias);
            sb.AppendLine("TIPO : " + this.tipo.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
