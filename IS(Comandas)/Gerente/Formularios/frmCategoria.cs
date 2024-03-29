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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDelCategoria frm = new frmDelCategoria();
            frm.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCategoria frm = new frmAddCategoria();
            frm.Show();
            this.Close();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmLstCategorias frm = new frmLstCategorias();
            frm.Show();
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            frmEdtCategoria frm = new frmEdtCategoria();
            frm.Show();
            this.Close();
        }
    }
}
