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

namespace IS_Comandas_.Cajero.Formularios
{
    public partial class frmCobro : Form
    {
        public static class DatosCompartidos
        {
            public static float total { get; set; }
            public static string mesa { get; set; }
        }
        string mesa = DatosCompartidos.mesa;
        float total = DatosCompartidos.total;
        public frmCobro()
        {
            InitializeComponent();
        }
        public void labelFeria()
        { 
            float dinero = float.Parse(txtIngreso.Text);
            float feria = dinero - (total);
            lblCambio.Text = feria.ToString();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            frmMainCajero frm = new frmMainCajero();
            
            //desMesa();
            frm.registrar();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            labelFeria();
        }
        private void frmCobro_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(total);
        }
    }
}
