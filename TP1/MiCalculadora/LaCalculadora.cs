using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        #region Constructores
        /// <summary>
        /// Inicializa la calculadora.
        /// </summary>
        public LaCalculadora()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Realiza la operacion entre dos números según el operador que se pase por parámetro
        /// </summary>
        /// <param name="numero1">Primer operando</param>
        /// <param name="numero2">Segundo operando</param>
        /// <param name="operador">Operador con que se va a realizar la operacion entre los numeros pasados por parámetro</param>
        /// <returns>La operación entre los números pasados por parámetro</returns>
        public static double Operar(string numero1, string numero2, string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }
        /// <summary>
        /// Deja en vacío los TextBox donde van los números, el Label donde va el resultado y
        /// El ComboBox donde se asignan los operadores.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.lblResultado.Text = String.Empty;
            this.cmbOperador.Text = String.Empty;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Obtiene de los TextBox los numeros en formato alfanumérico, los parsea a fraccionario de poder
        /// y los opera segun el operador que se seleccione.
        /// Cabe aclarar que de no haber numeros el numero por defecto es 0 y de poner un operador erroneo el operador por 
        /// defecto es el "+".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = LaCalculadora.Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();
        }
        /// <summary>
        /// Convierte el resultado de haber y poder a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
        }
        /// <summary>
        /// Convierte el resultado de haber y poder a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
        }
        /// <summary>
        /// Cierra la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Limpia la calculadora.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        #endregion

    }
}
