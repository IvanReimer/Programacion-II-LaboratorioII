using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        #region Atributos
        /// <summary>
        /// La clase numero va a tener un double que va a ser nuúmero con el que se van
        /// a realizar las operaciones.
        /// </summary>
        private double numero;
        #endregion

        #region Constructores
        /// <summary>
        /// El constructor por defecto va a inicializar el numero con un 0.
        /// </summary>
        public Numero() : this(0)
        {

        }
        /// <summary>
        /// La sobrecarga del constructor va a inicializar el numero con el parámetro que se le pase.
        /// Previo llamado al constructor por defecto.
        /// </summary>
        /// <param name="numero">Va a ser el numero con el que se va a cargar el atributo numero.</param>
        public Numero(double numero) 
        {
            this.numero = numero;
        }
        /// <summary>
        /// Esta sobrecarga del constructor va a parsear el número que se 
        /// le pase por parámetro de ser posible, sino es posible, le carga un 0.
        /// Aclaro que el :this() esta de más. Lo uso solo para darle utilidad a 
        /// los otros dos constructores porque sino, no se usan en todo el programa.
        /// </summary>
        /// <param name="strNumero">Cadena de caracteres a parsear.</param>
        public Numero(string strNumero) : this()
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// La propiedad de solo escritura SetNumero va a validar que el valor pasado por parámetro 
        /// sea "parseable", si lo es lo parsea, sino, le asigna un 0.
        /// </summary>
        public string SetNumero
        {
            set
            {
                this.numero = this.ValidarNumero(value);
            }
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// La sobrecarga del operador + realiza la suma de los atributos de dos objetos Numero
        /// </summary>
        /// <param name="n1">Primer sumando</param>
        /// <param name="n2">Segundo sumando</param>
        /// <returns>La suma entre los dos atributos de los parametros Numero recibidos</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }
        /// <summary>
        /// La sobrecarga del operador - realiza la diferencia de los atributos de dos objetos Numero
        /// </summary>
        /// <param name="n1">Minuendo</param>
        /// <param name="n2">Sustraendo</param>
        /// <returns>La diferencia entre el atributo del objeto n1, y el atributo del objeto n2</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }
        /// <summary>
        /// La sobrecarga del operador * realiza la multiplicacion de los atributos de dos objetos Numero
        /// </summary>
        /// <param name="n1">Primer producto</param>
        /// <param name="n2">Segundo producto</param>
        /// <returns>La multiplicacion entre el atributo del objeto n1, y el atributo del objeto n2</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
        /// <summary>
        /// La sobrecarga del operador / realiza la division de los atributos de dos objetos Numero.
        /// </summary>
        /// <param name="n1">Dividendo</param>
        /// <param name="n2">Divisor</param>
        /// <returns>
        /// La division entre el atributo del objeto n1 y el atributo del objeto n2 SIEMPRE Y CUANDO el divisor sea distinto de 0.
        /// Si es igual a 0, retornara el minimo número fraccionario que el valor tipo double pueda retornar.
        /// </returns>
        public static double operator /(Numero n1, Numero n2)
        {
            return n2.numero == 0 ? double.MinValue : n1.numero / n2.numero;
        }


        #endregion

        #region Metodos

        /// <summary>
        /// Este método va a validar que el string pasado por parámetro sea un double, 
        /// si es double lo parsea. Sino el número inicializado por defecto
        /// </summary>
        /// <param name="strNumero">Cadena de caractéres a validar.</param>
        /// <returns>El número validado</returns>
        private double ValidarNumero(string strNumero)
        {
            double.TryParse(strNumero, out double numeroValidado);
            return numeroValidado;
        }
        /// <summary>
        /// Valida que el alfanumérico pasado por parámetro este compuesta por "1" o "0" y que no sea un vacío. 
        /// </summary>
        /// <param name="cadena">Valor alfanumérico a validar</param>
        /// <returns>
        /// "Operacion invalida" en caso de que no sea un binario o un vacio. Caso contrario retorna el valor convertido
        /// a binario en forma alfanumérica.
        /// </returns>
        public static string BinarioDecimal(string cadena)
        {
            short i = 0;
            string resultado = "Operacion invalida";
            while (i < cadena.Length && (cadena[i] == '0' || cadena[i] == '1'))
            {
                i++;
            }
            if (i == cadena.Length && cadena != String.Empty)
            {
                resultado = Convert.ToUInt32(cadena, 2).ToString();
            }
            return resultado;
        }
        /// <summary>
        /// Valida que el alfanumerico pasado por parámetro sea convertible a fraccionario.
        /// Si es posible lo parsea y convierte a binario, sino no lo convierte.
        /// </summary>
        /// <param name="numero">Alfanumérico a operar</param>
        /// <returns>
        /// "Operacion invalida" en caso de que no se pueda convertir a fraccionario, 
        /// en caso que pueda ser parseado a fraccionario, retorna su valor en binario de forma alfanumérica.     
        /// </returns>
        public static string DecimalBinario(string numero)
        {
            string resultado = "Operacion invalida";
            if (double.TryParse(numero, out double operacion))
            {
                resultado = Numero.DecimalBinario(operacion);
            }
            return resultado;
        }
        /// <summary>
        /// Convierte un fraccionario a natural redondeando su primer valor con coma. Luego lo convierte a binario.
        /// Cabe destacar aqui, que se convierte el valor a Unsigned Int porque el compilador no me deja convertir 
        /// a binario sin pasarlo antes a ese tipo de valor.
        /// </summary>
        /// <param name="numero">Numero a convertir</param>
        /// <returns>El numero convertido a binario en forma alfanumérica.</returns>
        public static string DecimalBinario(double numero)
        {
            return Convert.ToString((uint)Math.Abs(Math.Round(numero)), 2);
        }

        #endregion

    }
}
