using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region Enumerados
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region Atributos
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region Constructores
        /// <summary>
        /// Se declara este constructor para inicializar los datos del vehiculo.
        /// </summary>
        /// <param name="marca">Marca del vehiculo</param>
        /// <param name="chasis">Chasis del vehiculo</param>
        /// <param name="color">Color del vehiculo</param>
        public Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.marca = marca;
            this.chasis = chasis;
            this.color = color;
        }

        #endregion

        #region Propiedades
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio
        {
            get;
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (String)this;
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Expone los datos del vehículo.
        /// </summary>
        /// <param name="p">Vehículo a mostrar.</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("CHASIS: {0}\r\n", p.chasis));
            sb.AppendLine(String.Format("MARCA : {0}\r\n", p.marca.ToString()));
            sb.AppendLine(String.Format("COLOR : {0}\r\n", p.color.ToString()));
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }

        #endregion

    }
}
