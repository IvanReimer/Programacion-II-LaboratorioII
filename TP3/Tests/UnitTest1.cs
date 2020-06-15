using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using EntidadesAbstractas;
using Archivos;
using Excepciones;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestAgregoUnDniNoValidoYSaleEsaExcepcion()
        {
            Alumno alumnoPrueba = new Alumno(123, "Jhon", "Doe", "DNI INVALIDO", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);

        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestAgregoUnAlumnoRepetidoYSaleExcepcion()
        {
            Alumno alumnoPrueba = new Alumno(123, "Jhon", "Doe", "2", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Alumno alumnoRepetido = new Alumno(123, "Jhon", "Doe", "1", Persona.ENacionalidad.Argentino, Universidad.EClases.SPD);
            Universidad u = new Universidad();
            u = u + alumnoPrueba;
            u= u + alumnoRepetido;
        }

        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestAgregoUnaClaseYNoHayProfesoresParaDarla()
        {
            Universidad u = new Universidad();
            u += Universidad.EClases.SPD;
        }


        [TestMethod]
        //[ExpectedException(typeof(SinProfesorException))]
        public void TestInstancioUnaUniversidadYMeFijoQueSusListasEstenInstanciadas()
        {
            Universidad u = new Universidad();
            Assert.IsNotNull(u.Alumnos);
        }



    }
}
