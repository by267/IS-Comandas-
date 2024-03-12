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
    public partial class frmAddMesa : Form
    {
        public frmAddMesa()
        {
            InitializeComponent();
        }

        public static implicit operator frmAddMesa(frmAddEmpleado v)
        {
            throw new NotImplementedException();
        }

        private void frmAddMesa_Load(object sender, EventArgs e)
        {

        }

        private void btnRechazar_Click(object sender, EventArgs e)
        {
            frmMainGerente frm = new frmMainGerente();
            frm.Show();
            this.Hide();
        }
    }
}
