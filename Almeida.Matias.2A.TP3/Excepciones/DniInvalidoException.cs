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

        public DniInvalidoException() : base("Error. El DNI debe contener entre 1 y 8 caracteres, " +
            "ser un entero positivo y ademas debe contener SOLO numeros.") { }
        public DniInvalidoException(Exception e)
        {
            this.mensajeBase = "Error. El DNI debe contener entre 1 y 8 caracteres, ser un " +
                "entero positivo y ademas debe contener SOLO numeros.";
            throw new DniInvalidoException(this.mensajeBase, e);
        }
        public DniInvalidoException(string message) : base(message) { }
        public DniInvalidoException(string message, Exception e) : base(message, e) { }
    }
}
