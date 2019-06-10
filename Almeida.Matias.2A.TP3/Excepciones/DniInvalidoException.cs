using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private string mensajeBase;

        /// <summary>
        /// Constructor que llama a Exception con un mensaje por defecto.
        /// </summary>
        public DniInvalidoException() : base("Error. El DNI debe contener entre 1 y 8 caracteres, " +
            "ser un entero positivo y ademas debe contener SOLO numeros.") { }
        /// <summary>
        /// Constructor que llama a Exception con un mensaje por defecto mas el mensaje de InnerException.
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
        {
            this.mensajeBase = "Error. El DNI debe contener entre 1 y 8 caracteres, ser un " +
                "entero positivo y ademas debe contener SOLO numeros.";
            throw new DniInvalidoException(this.mensajeBase, e);
        }
        /// <summary>
        /// Constructor que llama a Exception con un mensaje pasado por parametro.
        /// </summary>
        /// <param name="message"></param>
        public DniInvalidoException(string message) : base(message) { }
        /// <summary>
        /// Constructor que llama a Exception con un mensaje pasado por parametro mas el mensaje de InnerException.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e) : base(message, e) { }
    }
}
