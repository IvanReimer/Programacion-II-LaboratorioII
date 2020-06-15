using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor necesario para serializar y deserializar
        /// </summary>
        public Universitario()
        {

        }
        /// <summary>
        /// Constructor que inicializa los valores legajo, nombre, apellido, dni y nacionalidad.
        /// </summary>
        /// <param name="legajo">Legajo a inicializar</param>
        /// <param name="nombre">Nombre a inicializar</param>
        /// <param name="apellido">Apellido a inicializar</param>
        /// <param name="dni">DNI a inicializar previa validacion</param>
        /// <param name="nacionalidad">Nacionalidad a inicializar</param>
        public Universitario(int legajo, String nombre, String apellido, String dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Método abstracto que se implementa en sus clases derivadas.
        /// </summary>
        /// <returns></returns>
        protected abstract String ParticiparEnClase();
        /// <summary>
        /// Método que se utiliza para mostrar los datos.
        /// </summary>
        /// <returns>Los datos de un Universitario</returns>
        protected virtual String MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.ToString());
            datos.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return datos.ToString();
        }
        /// <summary>
        /// Sobreescritura del método equals de object. 
        /// Pregunta si el objeto pasado por parámetro es Universitario y si su DNI es igual a su DNI o su legajo es igual a su legajo.
        /// </summary>
        /// <param name="obj">Objeto a comparar.</param>
        /// <returns>True si su DNI o legajo son iguales al objeto que DEBE ser Universitario para compararse.</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario && (((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo);
        }


        #endregion

    }
}
