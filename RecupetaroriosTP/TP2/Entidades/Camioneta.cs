using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {

        #region Constructores
        /// <summary>
        /// Constructor necesario para inicializar atributos base.
        /// </summary>
        /// <param name="marca">Marca del camion</param>
        /// <param name="codigo">Codigo del camion</param>
        /// <param name="color">Color del camion</param>
        public Camioneta(EMarca marca, string codigo, ConsoleColor color) : base(marca, codigo, color)
        {
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las camionetas son grandes
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega, además de los datos de Vehículo, los datos adicionales de la camioneta.
        /// </summary>
        /// <returns>Los datos de la camioneta en forma de string</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");
            return sb.ToString();
        }

        #endregion

    }
}
