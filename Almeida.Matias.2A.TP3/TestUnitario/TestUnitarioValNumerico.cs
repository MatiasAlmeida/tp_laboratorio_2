using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitarioValNumerico
    {
        /// <summary>
        /// Test unitario para validar que el atributo dni sea entero.
        /// </summary>
        [TestMethod]
        public void ValidarIntDni()
        {
            try
            {
                Alumno a1 = new Alumno(12, "Chicho", "Telechea", "asd2144", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(5, "Carlos", "Benitez", "1241241251231512", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }
    }
}
