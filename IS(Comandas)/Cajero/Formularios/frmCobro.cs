using IS_Comandas_.Gerente.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static IS_Comandas_.frmMainCajero;
using static System.Net.Mime.MediaTypeNames;

namespace IS_Comandas_.Cajero.Formularios
{
    public partial class frmCobro : Form
    {
        float total;
        float feria;
        
        public frmCobro()
        {
            InitializeComponent();
        }
        public void labelFeria()
        { 
            float dinero = float.Parse(txtIngreso.Text);
            feria = dinero - total;
            lblCambio.Text = feria.ToString();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
            int ingreso = int.Parse(txtIngreso.Text);
            
            if (ingreso > total)
            {
                labelFeria();
                timer1.Start();
            }
            else
            {
                MessageBox.Show("No te alcanza, che pobre");
            }
            
        }
        private void frmCobro_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(total);
            lblTotal2.Text = total.ToString();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
