using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de lectura y escritura de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        /// <summary>
        /// Constructor de instancia de correo.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Finaliza o termina los subprocesos presentes en la lista de hilos mockPaquetes.
        /// </summary>
        public void FinEntrega()
        {
            foreach(Thread item in mockPaquetes)
            {
                if (item != null && item.IsAlive)
                    item.Abort();
            }
        }

        /// <summary>
        /// Muestra los datos del o los paquetes con su estado actual.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string aux = null;
            foreach (Paquete item in this.Paquetes)
            {
                aux += string.Format("{0} para {1} ({2})\n", item.TrackingID, item.DireccionEntrega, item.Estado.ToString());
            }

            return aux;
        }

        /// <summary>
        /// Sobrecarga para el operador + de la clase Correo que agrega un paquete si 
        /// no se encuentra en la lista.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if (c.Paquetes != null)
            {
                if(c.Paquetes.Count == 0)
                {
                    c.Paquetes.Add(p);
                    if (c.mockPaquetes != null)
                    {
                        try
                        {
                            c.mockPaquetes.Add(new Thread(p.MockCicloDeVida));
                            c.mockPaquetes.Last().Start();
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                    }
                    else
                    {
                        c.Paquetes.Remove(c.Paquetes.Last());
                    }
                }
                else
                {
                    foreach (Paquete item in c.Paquetes)
                    {
                        if (item == p)
                            throw new TrackingIdRepetidoException(string.Format("El Tracking ID {0} ya figura en la lista de envios.", p.TrackingID));
                        else
                        {
                            c.Paquetes.Add(p);
                            if (c.mockPaquetes != null)
                            {
                                try
                                {
                                    c.mockPaquetes.Add(new Thread(p.MockCicloDeVida));
                                    c.mockPaquetes.Last().Start();
                                }
                                catch (Exception e)
                                {
                                    throw e;
                                }

                                break;
                            }
                            else
                            {
                                c.Paquetes.Remove(c.Paquetes.Last());
                            }
                        }
                    }
                }               
            }

            return c;
        }
    }
}
