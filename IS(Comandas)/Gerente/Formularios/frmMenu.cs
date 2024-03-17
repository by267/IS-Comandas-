using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Comandas_.Gerente.Formularios
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddMenu frm = new frmAddMenu();
            frm.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            frmDelMenu frm = new frmDelMenu();
            frm.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmLstMenu frm = new frmLstMenu();
            frm.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmEdtMenu frm = new frmEdtMenu();
            frm.Show();
            this.Close();
        }
    }
}
