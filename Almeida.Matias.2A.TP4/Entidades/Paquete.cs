using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Propiedad de lectura y escritura de direccionEntrega.
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de estado.
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        /// <summary>
        /// Propiedad de lectura y escritura de trackingID.
        /// </summary>
        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        /// <summary>
        /// Firma del delegado para el evento InformaEstado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);

        /// <summary>
        /// Enumerado para el estado de los paquetes.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        /// <summary>
        /// Constructor de instancia para Paquete.
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Cambia el estado del paquete cada 4 segundos hasta que llega a estado Ingresado, genera
        /// los eventos que informan dichos estados, y llama al metodo Insertar() de la clase 
        /// PaqueteDAO para sumarlo a la base de datos.
        /// </summary>
        public void MockCicloDeVida()
        {
            this.Estado = EEstado.Ingresado;
            this.InformaEstado(this, new EventArgs());

            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(4000);
                if (i == 0)
                    this.Estado = EEstado.EnViaje;
                else
                    this.Estado = EEstado.Entregado;

                this.InformaEstado(this, new EventArgs());
            }

            try
            {
                if (!PaqueteDAO.Insertar(this))
                    throw new Exception("No se pudo cargar el paquete a la base de datos.");
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }

        /// <summary>
        /// Override del metodo ToString() para Paquete que llama a MostrarDatos().
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador == entre dos paquetes que devuelve true si su 
        /// Tracking ID es el mismo, false en caso contrario.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Sobrecarga del operador != entre dos paquetes que devuelve true si su 
        /// Tracking ID NO es el mismo, false en caso contrario.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
