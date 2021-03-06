﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor que llama a Exception con un mensaje por defecto.
        /// </summary>
        public NacionalidadInvalidaException() : base("La nacionalidad no se condice con el numero de DNI") { }
        /// <summary>
        /// Constructor que llama a Exception con un mensaje pasado por parametro.
        /// </summary>
        /// <param name="message"></param>
        public NacionalidadInvalidaException(string message) : base(message) { }
    }
}
