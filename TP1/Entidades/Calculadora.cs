using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        #region Métodos
        /// <summary>
        /// Lo que hace este método es tomar dos numeros y operarlos.
        /// En caso de que se le pase un 0 al segundo operador y se divida,
        /// se va a retornar el menor numero contenido en double.
        /// </summary>
        /// <param name="num1"> Primer número a operar</param>
        /// <param name="num2"> Segundo número a operar</param>
        /// <param name="operador"> Operador en formato String con el que se va a operar</param>
        /// <returns>El resultado de operar esos dos numeros. </returns>

        public static double Operar(Numero num1, Numero num2, string operador)
        {
            // Inicializo porque no me deja retornar sino.
            double result = 0;
            switch (Calculadora.ValidarOperador(operador))
            {
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
                case "+":
                    result = num1 + num2;
                    break;
            }
            return result;
        }
        /// <summary>
        /// Este método lo que va a hacer es validar que el operador que se le pase por parámetro
        /// corresponda con un operador algebráico.
        /// Si bien, este método me parece redundante, porque con un solo switch bastaría,
        /// lo implemento porque lo pide la documentación.
        /// </summary>
        /// <param name="operador">Es el operador a validar</param>
        /// <returns>El operador validado.</returns>
        private static string ValidarOperador(string operador)
        {
            string operadorValidado;
            switch (operador)
            {
                case "-":
                    operadorValidado = "-";
                    break;
                case "*":
                    operadorValidado = "*";
                    break;
                case "/":
                    operadorValidado = "/";
                    break;
                default:
                    operadorValidado = "+";
                    break;
            }
            return operadorValidado;
        }

        #endregion

    }
}
