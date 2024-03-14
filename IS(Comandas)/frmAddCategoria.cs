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
    public partial class frmAddCategoria : Form
    {
        public frmAddCategoria()
        {
            InitializeComponent();
            txtNombre.Focus();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void frmAddCategoria_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
    }
}
