using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Universidad;

namespace Entidades
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático que inicializa el atributo estático random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }
        /// <summary>
        /// Constructor por defecto necesario para la serializacion y deserialización. 
        /// Cabe aclarar que se inicializa dos veces la Queue para que no tire excepciones al momento de deserializar.
        /// </summary>
        public Profesor()
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
            this._randomClases();
        }
        /// <summary>
        /// Constructor que inicializa atributos heredados de Universitario. Además inicializa los atributos propios del profesor.
        /// </summary>
        /// <param name="id">Parametro para inicializar atributo id</param>
        /// <param name="nombre">Parametro nombre para inicializar el atributo nombre</param>
        /// <param name="apellido">Parametro apellido para inicializar el atributo apellido</param>
        /// <param name="dni">Parametro DNI para inicializar el atributo DNI</param>
        /// <param name="nacionalidad">Parametro nacionalidad para inicializar el atributo nacionalidad</param>
        public Profesor(int id, String nombre, String apellido, String dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            this._randomClases();
            this._randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que encola una clase random a la lista de clases que da.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((EClases)Profesor.random.Next(1, 4));
        }

        #endregion

        #region Sobrescrituras
        /// <summary>
        /// Sobrescritura que sirve para mostrar los datos del profesor.
        /// </summary>
        /// <returns>Un string con los datos del profesor.</returns>
        protected override String MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }
        /// <summary>
        /// Sobrescritura que sirve para mostrar todas las clases que dicta el profesor.
        /// </summary>
        /// <returns>Un String con todas las clases que dicta el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder clasesQueDa = new StringBuilder();
            clasesQueDa.AppendLine("CLASES DEL DÍA:");
            foreach (EClases clases in this.clasesDelDia)
            {
                clasesQueDa.AppendLine(clases.ToString());
            }
            return clasesQueDa.ToString();
        }
        /// <summary>
        /// Sobrescritura del ToString, llama a la sobrescritura de MostrarDatos para devolver todos los datos del profesor.
        /// </summary>
        /// <returns>Un String con todos los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un profesor va a ser igual a una clase siempre y cuando se encuentre en la cola de clases que dicta.
        /// </summary>
        /// <param name="i">Profesor que se pasa por parámetro</param>
        /// <param name="clase">Clase que se pasa por parámetro</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            bool profeCoincideConClase = false;
            foreach (EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    profeCoincideConClase = true;
                }
            }
            return profeCoincideConClase;
        }
        /// <summary>
        /// Un profesor va a ser distinto de una clase, si esa clase no pertenece a la cola de clases que el da.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }



        #endregion

    }
}
