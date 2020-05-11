using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region Constructores
        /// <summary>
        /// Constructor necesario para inicializar atributos base.
        /// </summary>
        /// <param name="marca">Marca de la moto</param>
        /// <param name="codigo">Código de la moto.</param>
        /// <param name="color">Color de la moto.</param>
        public Moto(EMarca marca, string codigo, ConsoleColor color) : base(marca, codigo, color)
        {

        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Agrega, además de los datos de Vehículo, los datos adicionales de la moto.
        /// </summary>
        /// <returns>Los datos de la moto.</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(String.Format("TAMAÑO : {0}", this.Tamanio));
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion

    }
}
