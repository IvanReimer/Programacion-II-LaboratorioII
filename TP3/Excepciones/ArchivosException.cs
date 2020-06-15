using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Excepcion que se lanza cuando hay errores en la lectura y escritura de archivos con el mensaje de su innerException.
        /// </summary>
        /// <param name="innerException">Excepcion anterior</param>
        public ArchivosException(Exception innerException):base(innerException.Message,innerException)
        {

        }
    }
}
