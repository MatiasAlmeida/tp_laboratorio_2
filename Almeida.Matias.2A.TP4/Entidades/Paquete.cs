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

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        public delegate void DelegadoEstado(object sender, EventArgs e);

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

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

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {

            return string.Format("{0} para {1}", this.TrackingID, this.DireccionEntrega);
        }

        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
    }
}
