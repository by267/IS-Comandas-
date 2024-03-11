using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Comandas_
{
    public partial class frmAddEmpleado : Form
    {
        public frmAddEmpleado()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMainGerente frmMGer = new frmMainGerente();
            frmMGer.Show();

            this.Hide();
        }
    }
}
