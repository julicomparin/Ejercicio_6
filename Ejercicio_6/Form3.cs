using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio_6
{
    public partial class Form3 : Form
    {
        FachadaCuentas iFachada = new FachadaCuentas();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pCuenta;
            if (comboBox1.Text == "Caja de Ahorro")
            {
                pCuenta = 1;
            }
            else
            {
                pCuenta = 2;
            }

            if (comboBox2.Text == "Acreditar")
            {
                try
                {
                    double pSaldo = Convert.ToDouble(textBox1.Text);
                    iFachada.AcreditarCuenta(pCuenta, pSaldo);
                    MessageBox.Show("Saldo Acreditado");
                }
                catch (FormatException E) //EL USUARIO INGRESA CADENA DE STRING O CADENAS QUE NO SON CONVERTIBLES A DOUBLE
                {
                    MessageBox.Show("Ingrese Monto Correcto");
                }
            }

            else
            {
                try
                {
                    double pSaldo = Convert.ToDouble(textBox1.Text);
                    if (iFachada.DebitarCuenta(pCuenta, pSaldo))
                    {
                        MessageBox.Show("Saldo Debitado.");
                    }
                    else { MessageBox.Show("Operación Fallida, cuenta al Descubierto."); };

                }
                catch (FormatException E) //EL USUARIO INGRESA CADENA DE STRING O CADENAS QUE NO SON CONVERTIBLES A DOUBLE
                {
                    MessageBox.Show("Ingrese Monto Correcto");
                }
                catch (ExcepcionDeMonto E)
                {
                    MessageBox.Show(E.Message);
                }

            }
        }
    }
}
