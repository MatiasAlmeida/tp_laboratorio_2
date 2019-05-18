using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Setter que asigna el valor al atributo this.numero desde el constructor.
        /// </summary>
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Recibe un string que este en binario y la transforma a un numero decimal, siempre que sea un valor valido.
        /// </summary>
        /// <param name="binario"> Es la string con el numero binario. </param>
        /// <returns> Retorna la conversion decimal del binario. Si fuera un valor no conversible, retornara 
        /// "Valor inválido". </returns>
        public string BinarioDecimal(string binario)
        {
            double decimalNum = 0;
            byte exponente = 0;
            short i = 0;

            if (binario != "Valor inválido")
            {
                for (i = 0; i < binario.Length; i++)
                {
                    exponente = byte.Parse(binario.Substring(i, 1));

                    if (exponente != 0 && exponente != 1)
                        break;
                    else if (exponente == 1)
                        decimalNum += Math.Pow(2, binario.Length - i - 1);
                    // Recorre desde el mas significativo al menos significativo
                }
            }

            if (i != binario.Length)
                binario = "Valor inválido";
            else
                binario = decimalNum.ToString();

            return binario;
        }

        /// <summary>
        /// Recibe un numero tipo double y retorna la conversion binaria de este.
        /// </summary>
        /// <param name="numero"> Numero a convertir en binario. </param>
        /// <returns> Retorna una string que es la representacion binaria del numero recibido. En caso
        /// de ser un valor no conversible, retornara "Valor inválido". </returns>
        public string DecimalBinario(double numero)
        {
            short i;
            char[] resto = new char[128];
            string binario = "";
            int numeroCasteado = (int)Math.Abs(numero);

            if (numeroCasteado.ToString().Any(char.IsDigit) && numeroCasteado >= 0)
            {
                if (numeroCasteado <= 1)
                    binario = numeroCasteado.ToString();
                else
                {
                    for (i = 0; numeroCasteado > 1; i++)
                    {
                        resto[i] = char.Parse((numeroCasteado % 2).ToString());
                        numeroCasteado /= 2;

                        if (numeroCasteado == 1)
                            resto[i + 1] = char.Parse(numeroCasteado.ToString());
                    }

                    while (i >= 0)
                    {
                        if (resto[i] != '\0')
                            binario += resto[i];

                        i--;
                    }
                }
            }
            else
                binario = "Valor inválido";

            return binario;
        }

        /// <summary>
        /// Recibe un numero tipo string y retorna la conversion binaria de este.
        /// </summary>
        /// <param name="numero"> Numero a convertir en binario. </param>
        /// <returns> Retorna una string que es la representacion binaria del numero recibido. En caso
        /// de ser un valor no conversible, retornara "Valor inválido". </returns>
        public string DecimalBinario(string numero)
        {
            if (numero != "Valor inválido")
                numero = DecimalBinario(double.Parse(numero));

            return numero;
        }

        /// <summary>
        /// Constructor de Numero por defecto. Inicializa el atributo this.numero en 0.
        /// </summary>
        public Numero() : this(0)
        {
        }

        /// <summary>
        /// Constructor de Numero con parametro. Le pasa el numero recibido al atributo this.numero.
        /// </summary>
        /// <param name="numero"> Es el valor que se le dara a this.numero. </param>
        public Numero(double numero) : this(numero.ToString())
        {
        }

        /// <summary>
        /// Constructor de Numero con parametro. Le pasa el numero recibido al atributo this.numero.
        /// </summary>
        /// <param name="strNumero"> Es el valor que se le dara a this.numero. </param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Sobrecarga de operador que me permite restar los atributos entre los distintos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"> Primer operando del tipo Numero. </param>
        /// <param name="n2"> Segundo operando del tipo Numero. </param>
        /// <returns> Retornara la resta entre los atributos this.numero de los objetos tipo Numero recibido. </returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador que me permite multiplicar los atributos entre los distintos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"> Primer operando del tipo Numero. </param>
        /// <param name="n2"> Segundo operando del tipo Numero. </param>
        /// <returns> Retornara la multiplicacion entre los atributos this.numero de los objetos tipo Numero recibido. </returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador que me permite dividir los atributos entre los distintos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"> Primer operando del tipo Numero. </param>
        /// <param name="n2"> Segundo operando del tipo Numero. </param>
        /// <returns> Retornara la division entre los atributos this.numero de los objetos tipo Numero recibido. </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Sobrecarga de operador que me permite sumar los atributos entre los distintos objetos del tipo Numero.
        /// </summary>
        /// <param name="n1"> Primer operando del tipo Numero. </param>
        /// <param name="n2"> Segundo operando del tipo Numero. </param>
        /// <returns> Retornara la suma entre los atributos this.numero de los objetos tipo Numero recibido. </returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Recibe el numero que se va a settear en el constructor de numero y valida que sea un numero.
        /// </summary>
        /// <param name="strNumero"> String con el numero a validar. </param>
        /// <returns> Retorna el mismo numero. Caso contrario, retornara 0. </returns>
        private double ValidarNumero(string strNumero)
        {
            if (double.TryParse(strNumero, out double numero) == false)
                numero = 0;

            return numero;
        }
    }
}
