using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region Enumerados
        public enum ETipo { Monovolumen, Sedan }
        #endregion

        #region Atributos
        private ETipo tipo;
        #endregion

        #region Constructores
        /// <summary>
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca">Marca del automovil</param>
        /// <param name="chasis">Chasis del automovil</param>
        /// <param name="color">Color del automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color) : this(marca, chasis, color,ETipo.Monovolumen)
        {
        }
        /// <summary>
        /// Se le agrega constructor con parámetro tipo para poder settearlo mejor.
        /// </summary>
        /// <param name="marca">Marca del automovil</param>
        /// <param name="chasis">Chasis del automovil</param>
        /// <param name="color">Color del automovil</param>
        /// <param name="tipo">Tipo del automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : base(marca, chasis, color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Agrega datos del automovil al método Mostrar de vehiculo.
        /// </summary>
        /// <returns>Los datos del vehiculo</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }
        #endregion

    }
}
