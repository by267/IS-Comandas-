using IS_Comandas_.Mesero;
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
    public partial class frmMainMesero : Form
    {
        public frmMainMesero()
        {
            InitializeComponent();
        }

        private void btnActivarMesa_Click(object sender, EventArgs e)
        {
            frmActivarMesa frm = new frmActivarMesa();
            frm.Show();
        }

        private void btniCerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Close();
        }

        private void btnAddComanda_Click(object sender, EventArgs e)
        {
            frmAddComanda frm = new frmAddComanda();
            frm.Show();

            this.Hide();
        }

        private void btnEliminarComanda_Click(object sender, EventArgs e)
        {
            frmDelComanda3 frm = new frmDelComanda3();
            frm.Show();
            //this.Hide();
        }

        private void btnModificarComanda_Click(object sender, EventArgs e)
        {
            frmModComanda frm = new frmModComanda();
            frm.Show();
            this.Hide();
        }
    }
}
