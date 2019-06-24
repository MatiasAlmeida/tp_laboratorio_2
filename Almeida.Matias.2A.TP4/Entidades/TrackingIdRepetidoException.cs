using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TrackingIdRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion para notificar que el Tracking ID se repitio en otro paquete.
        /// </summary>
        /// <param name="mensaje"></param>
        public TrackingIdRepetidoException(string mensaje) : base(mensaje) { }

        /// <summary>
        /// Excepcion para notificar que el Tracking ID se repitio en otro paquete + un innerException.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="e"></param>
        public TrackingIdRepetidoException(string mensaje, Exception e) : base(mensaje, e) { }
    }
}
