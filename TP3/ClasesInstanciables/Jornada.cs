using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using static Entidades.Universidad;

namespace Entidades
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de escritura y lectura para el valor de la lista de alumnos.
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
        /// Propiedad de escritura y lectura para el valor del atributo profesor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura para el valor del atributo Clase
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Constructor por defecto que inicializa los atributos clase y profesor
        /// </summary>
        /// <param name="clase">Valor del atributo clase</param>
        /// <param name="instructor">Valor del atributo instructor</param>
        public Jornada(EClases clase, Profesor instructor) : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Sobrecarga de operadores
        /// <summary>
        /// Una jornada va a ser igual a un alumno, si este pertenece a esta.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si el alumno pertenece a la jornada</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool alumnoPerteneceAJornada = false;
            foreach (Alumno item in j.alumnos)
            {
                if (item == a)
                {
                    alumnoPerteneceAJornada = true;
                    break;
                }
            }
            return alumnoPerteneceAJornada;
        }
        /// <summary>
        /// Una jornada a ver distinta a un alumno si éste último no pertenece a esta.
        /// </summary>
        /// <param name="j">Jornada a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si el alumno no pertenece a la jornada</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Una jornada va a sumar un alumno, si este no pertenece a esta última
        /// </summary>
        /// <param name="j">Jornada a agregar el alumno</param>
        /// <param name="a">Alumno a agregar si es que este no pertenece a la jornada</param>
        /// <returns>La jornada actualizada.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            return j;
        }

        #endregion

        #region Sobreescrituras
        /// <summary>
        /// Sobrescritura del método heredado de Object para mostrar los datos de la jornada.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder datosJornada = new StringBuilder();
            datosJornada.Append($"CLASE DE {this.clase} POR ");
            datosJornada.AppendLine(instructor.ToString());
            datosJornada.AppendLine("ALUMNOS: ");
            foreach (Alumno alumno in this.alumnos)
            {
                datosJornada.AppendLine(alumno.ToString());
            }
            return datosJornada.ToString();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método que lee un archivo de texto con los datos de una jornada.
        /// </summary>
        /// <returns>Un String con los datos de una jornada.</returns>
        public static String Leer()
        {
            String lectorDeJornada = String.Empty;
            Texto archivoALeer = new Texto();
            archivoALeer.Leer("jornadas.txt", out lectorDeJornada);
            return lectorDeJornada;
        }
        /// <summary>
        /// Método que guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>True si pudo guardar el archivo de texto, False en caso contrario.</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoAGuargar = new Texto();
            return archivoAGuargar.Guardar("jornadas.txt", jornada.ToString());
        }

        #endregion


    }
}
