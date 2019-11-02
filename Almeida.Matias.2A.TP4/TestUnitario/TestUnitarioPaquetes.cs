using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.IO;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitarioPaquetes
    {
        /*[TestMethod]
        public void VerificarExistenciaArchivoDeTexto()
        {
            Paquete p = new Paquete("san martin 3561", "123456");
            GuardaString.Guardar(p.MostrarDatos(p),"archivoDeSalida.txt");

            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\archivoDeSalida.txt"))
            {
                Assert.Fail("No se encontro el archivo con los datos del paquete.");
            }
        }*/

        /// <summary>
        /// Test para verificar si la instancia de la lista de paquetes de correos es nula.
        /// </summary>
        [TestMethod]
        public void VerificarInstanciaPaquete()
        {
            Correo correo = new Correo();

            if (correo.Paquetes == null)
                Assert.Fail("La instancia del paquete es null.");
        }

        /// <summary>
        /// Test para verificar si se lanza una excepcion para los paquetes con mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void VerificarPaquetesConIgualTrackingId()
        {
            try
            {
                Paquete p1 = new Paquete("san martin 3561","123456");
                Paquete p2 = new Paquete("santaolalla 242", "123456");
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));
            }
        }
    }
}
