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
    public partial class Form2 : Form
    {
        FachadaCuentas iFachada = new FachadaCuentas();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double iSaldo = Convert.ToDouble(textBox1.Text);
            int pCuenta;
            if (comboBox1.Text == "Caja de Ahorro a Cuenta Corriente")
            {
                pCuenta = 1;
            }
            else
            {
                pCuenta = 2;
            }
            if (iFachada.Transferir(pCuenta, iSaldo))
                MessageBox.Show("Transferencia Completa ");
                else
                MessageBox.Show("Error. No se pudo realizar transferencia");

        
           
        }
    }
}
