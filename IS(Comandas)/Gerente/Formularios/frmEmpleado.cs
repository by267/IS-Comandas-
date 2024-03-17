using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Comandas_.Gerente
{
    public partial class frmEmpleado : Form
    {
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void btnAddEmpleado_Click(object sender, EventArgs e)
        {
            frmAddEmpleado frm = new frmAddEmpleado();
            frm.Show();
            this.Close();
        }
        private void btnDelEmpleado_Click(object sender, EventArgs e)
        {
            frmDelEmpleado frmAEmp = new frmDelEmpleado();
            frmAEmp.Show();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMainGerente frm = new frmMainGerente();
            frm.Show();
            this.Hide();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmEdtEmpleado frm = new frmEdtEmpleado();
            frm.Show();
            this.Hide();
        }

        private void btnLstEmpleados_Click(object sender, EventArgs e)
        {
            frmLstEmpleado frm = new frmLstEmpleado();
            frm.Show();
            this.Hide();
        }
    }
}
