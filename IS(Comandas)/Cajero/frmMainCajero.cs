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
    public partial class frmMainCajero : Form
    {
        public frmMainCajero()
        {
            InitializeComponent();
        }

        private void btniCerrar_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();

            this.Hide();
        }
    }
}
