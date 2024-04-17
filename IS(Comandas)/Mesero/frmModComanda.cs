using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_Comandas_.Mesero
{
    public partial class frmModComanda : Form
    {
        public frmModComanda()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMainMesero frm = new frmMainMesero();
            frm.Show();
            this.Close();
        }
    }
}
