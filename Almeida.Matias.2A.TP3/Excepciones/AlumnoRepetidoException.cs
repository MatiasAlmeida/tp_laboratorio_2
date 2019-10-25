﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Constructor que llama a Exception con un mensaje por defecto.
        /// </summary>
        public AlumnoRepetidoException() : base("Alumno repetido.") { }
    }
}
