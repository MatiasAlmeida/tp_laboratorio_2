using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitario
{
    [TestClass]
    public class TestUnitarioValNull
    {
        /// <summary>
        /// Test unitario para validar que las listas de Universidad no sean nulas.
        /// </summary>
        [TestMethod]
        public void ValidarListasNoNulasUniversidad()
        {
            Universidad uni = new Universidad();

            Assert.IsNotNull(uni.Alumnos);
            Assert.IsNotNull(uni.Instructores);
            Assert.IsNotNull(uni.Jornadas);
        }
    }
}
