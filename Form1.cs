using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prGestionAhorros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            desactivarControles();
        }
        private double monto;
        private void activarControles()
        {
            txtCliente.Enabled = false; //Cuando se ingrese un valor se desactiva
            btnAbrir.Enabled = false;
            txtMonto.Enabled = false;
            btnDeposito.Enabled = true; //Cuando se desactiven los valores de arriba solo quedan activos estos
            btnRetiro.Enabled = true;
        }
        private void desactivarControles()
        {
            txtCliente.Enabled = true; 
            btnAbrir.Enabled = true;
            txtMonto.Enabled = true;
            btnDeposito.Enabled = false; 
            btnRetiro.Enabled = false;
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            string cliente;
            //Leer datos
            cliente = txtCliente.Text;
            monto = Convert.ToDouble(txtMonto.Text);//Casteo

            if (monto > 0)
            {
                activarControles();
            }
            else
            {
                MessageBox.Show("El monto debe ser mayor o igual que cero", "Gestión de ahorros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Double leer(string mensaje)
        {
            Double cantidad;
            cantidad = Convert.ToDouble(Microsoft.VisualBasic.Interaction.InputBox("Ingrese monto a: " + mensaje, "Gestión de ahorros", "0", 100, 0));
            return cantidad;
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            Double deposito;
            deposito = leer("Depositar");
            monto = monto + deposito;
            lstDepositos.Items.Add(deposito);
            mostrar();
        }
        private void mostrar()
        {
            txtSaldo.Text = Convert.ToString(monto);
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            Double retiro;
            retiro = leer("Retirar");
            //Evaluamos
            if(retiro<=monto)
            {
                monto = monto - retiro;
                lstRetiros.Items.Add(retiro);
                mostrar();
            }
            else
            {
                MessageBox.Show("La cantidad de retiro es mayor al monto disponible", "Gestión de Ahorros", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCliente.Clear();
            txtMonto.Clear();
            txtSaldo.Clear();
            lstDepositos.Items.Clear();
            lstRetiros.Items.Clear();
            desactivarControles();
        }
    }
}
