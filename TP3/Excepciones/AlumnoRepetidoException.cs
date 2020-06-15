using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        /// <summary>
        /// Excepcion de alumno repetido, se le pasa por parámetro el mensaje alumno repetido.
        /// </summary>
        public AlumnoRepetidoException() :base("Alumno repetido")
        {

        }


    }
}
