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
    public partial class frmMainGerente : Form
    {
        public frmMainGerente()
        {
            InitializeComponent();
        }
        private void btniCerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Hide();
        }
        private void btnAddEmpleado_Click_1(object sender, EventArgs e)
        {
            frmAddEmpleado frmAEmp = new frmAddEmpleado();
            frmAEmp.Show();

            this.Hide();
        }

        private void btnAddMesa_Click(object sender, EventArgs e)
        {
            frmAddMesa frmAEmp = new frmAddMesa();
            this.Enabled = false;
            frmAEmp.Show();
        }
    }
}
