using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitarioExcepciones
    {
        /// <summary>
        /// Test unitario para la exception ArchivoException.
        /// </summary>
        [TestMethod]
        public void ValidarArchivosException()
        {
            try
            {
                Alumno a1 = new Alumno(12, "Palmiro", "Perez", "95000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(5, "La Mona", "Jimenez", "91000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
                Profesor p1 = new Profesor(16, "Mathias", "Bustamante", "12415612", Persona.ENacionalidad.Argentino);
                Jornada j1 = new Jornada(Universidad.EClases.SPD, p1);
                Jornada.Guardar(j1);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Test unitario para la excepcion NacionalidadInvalidadException.
        /// </summary>
        [TestMethod]
        public void ValidarNacionalidadException()
        {
            try
            {
                Alumno a1 = new Alumno(12, "Chicho", "Telechea", "91000000", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(5, "Carlos", "Benitez", "70000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Programacion);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        } 
    }
}
