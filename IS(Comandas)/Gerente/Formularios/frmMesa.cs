using IS_Comandas_.Gerente.Formularios;
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
    public partial class frmMesa : Form
    {
        public frmMesa()
        {
            InitializeComponent();
        }

        private void btnAddEmpleado_Click(object sender, EventArgs e)
        {
            frmAddMesa frm = new frmAddMesa();
            frm.Show();
            this.Close();
        }
        private void btnDelEmpleado_Click(object sender, EventArgs e)
        {
            frmDelMesa frm = new frmDelMesa();
            frm.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLstMesas_Click(object sender, EventArgs e)
        {
            frmLstMesas frm = new frmLstMesas();
            frm.Show();
            this.Close();
        }
    }
}
