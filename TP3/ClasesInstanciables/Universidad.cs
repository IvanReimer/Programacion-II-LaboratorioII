using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
namespace Entidades
{
    public class Universidad
    {
        #region Enumerados
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que además de inicializar las listas, es necesario para serializar y deserializar.
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }
        #endregion

        #region Propiedades e indexadores
        /// <summary>
        /// Inicializa y retorna la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Inicializa y retorna la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornada
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Inicializa y retorna la lista de profesores
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Indexador.Si el indice esta dentro de los valores comprendidos entre 0 y la cantidad de 
        /// jornadas que tiene, se puede asignar y retornar un valor.
        /// </summary>
        /// <param name="index">Indice de la jornada especificada.</param>
        /// <returns></returns>
        public Jornada this[int index]
        {
            get
            {
                if (index >= 0 && index < this.jornada.Count)
                {
                    return this.jornada[index];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (index >= 0 && index < this.jornada.Count)
                {
                    this.jornada[index] = value;
                }
            }
        }

        #endregion

        #region Sobrecargas de operadores
        /// <summary>
        /// Una universidad va a ser igual a un alumno, si esta lo contiene.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si la universidad contiene al alumno.</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool alumnoPerteneceAFacultad = false;
            foreach (Alumno item in g.alumnos)
            {
                if (item.Equals(a))
                {
                    alumnoPerteneceAFacultad = true;
                }
            }
            return alumnoPerteneceAFacultad;
        }
        /// <summary>
        /// Un alumno va a ser distinto a una universidad si esta no lo contiene.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>True si la universidad no contiene al alumno</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Un profesor va a ser igual a una universidad si esta lo contiene.
        /// </summary>
        /// <param name="u">Univeridad a comprar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>True si la universidad contiene al profesor</returns>
        public static bool operator ==(Universidad u, Profesor i)
        {
            bool profesorPerteneceAFacultad = false;
            foreach (Profesor item in u.profesores)
            {
                if (item == i)
                {
                    profesorPerteneceAFacultad = true;
                }
            }
            return profesorPerteneceAFacultad;
        }
        /// <summary>
        /// Una universidad va a ser distinta a un profesor si esta no lo contiene.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns>True si la universidad no contiene al profesor</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Una universidad va a agregar a un alumno si esta no lo contiene.
        /// </summary>
        /// <param name="u">Universidad que va a agregar al alumno</param>
        /// <param name="a">Alumno que se va a agregar</param>
        /// <returns>La universidad con el alumno agregado si no pertenece.</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Una universidad va a agregar a un profesor si esta no lo contiene.
        /// </summary>
        /// <param name="u">Universidad que va a agregar al profesor.</param>
        /// <param name="i">Profesor a ser agregado.</param>
        /// <returns>La universidad con el profesor agregado si no esta agregado.</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }
        /// <summary>
        /// Esta sobrecarga compara la universidad con la clase. Va a dar al primer profesor de la facultad que pueda dar esa clase.
        /// </summary>
        /// <param name="u">Universidad a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>El primer profesor de la facultad que da esa clase. Caso contrario arroja una excepcion</returns>
        public static Profesor operator ==(Universidad u , EClases clase)
        {
            Profesor profeQueDaLaClase= null;
            foreach (Profesor item in u.profesores)
            {
                if (item == clase)
                {
                    profeQueDaLaClase = item;
                    break;
                }
            }
            if (profeQueDaLaClase is null)
            {
                throw new SinProfesorException();
            }
            return profeQueDaLaClase;
        }
        /// <summary>
        /// Esta comparacion retorna un profesor que se encuentre en la facultad y no de esa clase.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>El primer profesor de la facultad que no da esa clase.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor profeQueNoDaEsaClase = null;
            foreach (Profesor item in g.profesores)
            {
                if (item != clase)
                {
                    profeQueNoDaEsaClase = item;
                    break;
                }
            }
            return profeQueNoDaEsaClase;
        }
        /// <summary>
        /// Se genera una nueva jornada para la clase pasada por parámetro en la que se van a agregar los alumnos que cursan esa materia
        /// y el primer profesor que la dicta.
        /// </summary>
        /// <param name="g">Universidad pasada por parámetro</param>
        /// <param name="clase">Clase pasada por parámetro</param>
        /// <returns>La universidad actualizada.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada j = new Jornada(clase, g == clase);
            foreach (Alumno item in g.alumnos)
            {
                if (item == clase)
                {
                    j.Alumnos.Add(item);
                }
            }
            g.jornada.Add(j);
            return g;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Método que muestra los datos de la todas las jornadas de una universidad pasada por parámetro.
        /// </summary>
        /// <param name="uni">Universidad a mostrar.</param>
        /// <returns>Los datos de la universidad en formato String.</returns>
        private static String MostrarDatos(Universidad uni)
        {
            StringBuilder datosUniversidad = new StringBuilder();
            foreach (Jornada jornada in uni.jornada)
            {
                datosUniversidad.AppendLine(jornada.ToString());
            }
            return datosUniversidad.ToString();
        }
        /// <summary>
        /// Método para guardar en forma XML el objeto universidad.
        /// </summary>
        /// <param name="uni">Universidad a serializar.</param>
        /// <returns>Booleano que indica si pudo guardar o no.</returns>
        public static bool Guardar(Universidad uni)
        {
            bool pudoGuardar = false;
            Xml<Universidad> archivoASerializar = new Xml<Universidad>();
            if (archivoASerializar.Guardar("universidad.xml", uni))
            {
                pudoGuardar = true;
            }
            return pudoGuardar;
        }
        /// <summary>
        /// Método que sirve para deserializar en formato XML una universidad.
        /// </summary>
        /// <returns>La universidad leida en el formato XML.</returns>
        public static Universidad Leer()
        {
            Xml<Universidad> archivoADeserializar = new Xml<Universidad>();
            Universidad aux = null;
            archivoADeserializar.Leer("universidad.xml", out aux);
            return aux;
        }
        #endregion

        #region Sobreescrituras
        /// <summary>
        /// Hace público el método MostrarDatos por medio de la sobrescritura del ToString()
        /// </summary>
        /// <returns>Los datos de la universidad en formato String</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

    }
}
