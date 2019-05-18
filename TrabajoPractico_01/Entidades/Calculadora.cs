using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Obtiene los operandos y el tipo de operacion que se va a efectuar entre ellos.
        /// </summary>
        /// <param name="num1"> Operando izquierdo que recibe el primer textBox de la calculadora. </param>
        /// <param name="num2"> Operando derecho que recibe el segundo textBox de la calculadora. </param>
        /// <param name="operador"> Operador que indica la operacion a realizar entre los dos operandos. </param>
        /// <returns> Retorna el resultado, dependiendo del operador que se haya asignado. Retorna double.MinValue
        /// en caso de que se elija la operacion "/" y el segundo operando sea 0. </returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            Numero auxNum2 = new Numero();
            double resultado = double.MinValue;

            switch (ValidarOperador(operador))
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;

                    if (num1 / num2 == num1 / auxNum2)
                        resultado = double.MinValue;

                    break;
                default:
                    break;
            }

            return resultado;
        } 

        /// <summary>
        /// Valida que los operadores ingresados sean los que pide la aplicacion.
        /// </summary>
        /// <param name="operador"> El operador que se va a comparar. </param>
        /// <returns> El mismo operador si corresponde al que pide la aplicacion, caso contrario
        /// retorna "+". </returns>
        private static string ValidarOperador(string operador)
        {
            if (operador != "/" && operador != "+" && operador != "-" && operador != "*")
                operador = "+";

            return operador;
        }
    }
}
