using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static Entidades.Universidad;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region Atributos
        private EEstadoCuenta estadoCuenta;

        private EClases clasesQueToma;
        #endregion

        #region Sobreescrituras
        /// <summary>
        /// Sobreescritura del método ParticiparEnClase de Universitario
        /// </summary>
        /// <returns>Retorna un string indicando las clases que toma (atributo de la clase alumno)</returns>
        protected override string ParticiparEnClase()
        {
            return String.Format("Toma clase de {0}", this.clasesQueToma);
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor necesario para serializar y deserializar
        /// </summary>
        public Alumno()
        {

        }
        /// <summary>
        /// Constructor que inicializa los atributos legajo, nombre, apellido, dni, nacionalidad y clasesQue toma
        /// </summary>
        /// <param name="legajo">Legajo a inicializar</param>
        /// <param name="nombre">Nombre a inicializar</param>
        /// <param name="apellido">Apellido a inicializar</param>
        /// <param name="dni">DNI a inicializar</param>
        /// <param name="nacionalidad">Nacionalidad a inicializar</param>
        /// <param name="clasesQueToma">Clase a inicializar</param>
        public Alumno(int legajo, String nombre, String apellido, String dni, ENacionalidad nacionalidad, EClases clasesQueToma):base(legajo,nombre,apellido,dni,nacionalidad)
        {
            this.clasesQueToma = clasesQueToma;
        }
        /// <summary>
        /// Constructor que inicializa atributos legajo, nombre, apellido, dni, nacionalidad, clases que toma y estado de cuenta
        /// </summary>
        /// <param name="legajo">Legajo a inicializar</param>
        /// <param name="nombre">Nombre a inicializar</param>
        /// <param name="apellido">Apellido a inicializar</param>
        /// <param name="dni">DNI a inicializar</param>
        /// <param name="nacionalidad">Nacionalidad a inicializar</param>
        /// <param name="clasesQueToma">Clases a inicializar</param>
        /// <param name="estadoCuenta">Estado de la cuenta a inicializar</param>
        public Alumno(int legajo, String nombre, String apellido, String dni, ENacionalidad nacionalidad, EClases clasesQueToma,EEstadoCuenta estadoCuenta) : this(legajo, nombre, apellido, dni, nacionalidad,clasesQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un alumno sera igual a una clase si su estado de cuenta es distinto de deudor y la clase que toma es igual a esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si cumple con los requisitos especificados en el summary</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            return a.clasesQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor;
        }
        /// <summary>
        /// Un alumno es distinto de una clase si no es igual a la sobrecarga anterior.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si es distinto false si es igual. (Se especifica en el summary de la sobrecarga de igualacion)</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            return !(a.clasesQueToma == clase);
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>Los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }

        #endregion

        #region Sobreescrituras
        /// <summary>
        /// Retorna el metodo mostrar datos
        /// </summary>
        /// <returns>Los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

    }
}
