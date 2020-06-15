using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor de clase derivada de Exception, en este caso se pasa solo el mensaje por parámetro.
        /// </summary>
        /// <param name="mensaje">Mensaje que se pasa por parámetro a la clase base para imprimirse.</param>
        public DniInvalidoException(String mensaje) : this(mensaje, null)
        {

        }
        /// <summary>
        /// Sobrecarga del constructor de DniInvalidoException, con dos parámetros
        /// </summary>
        /// <param name="mensaje">Parámetro que se pasa a la clase base para imprimir su contenido</param>
        /// <param name="e">Excepcion anterior que se le pasa a la clase base para ser almacenado</param>
        public DniInvalidoException(String mensaje , Exception e) : base(mensaje, e)
        {

        }
        /// <summary>
        /// Constructor por defecto de DniInvalidoException
        /// </summary>
        public DniInvalidoException() : this("DNI invalido.",null)
        {

        }
        /// <summary>
        /// Sobrecarga del constructor de DniInvalidoException. 
        /// </summary>
        /// <param name="e">Se pasa por parámetro la excepcion para ser almacenada en la clase base.</param>
        public DniInvalidoException(Exception e):this("DNI invalido",e)
        {

        }
    }
}
