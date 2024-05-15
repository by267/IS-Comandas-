using IS_Comandas_.Gerente.Clases;
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
    public partial class frmDelMesa : Form
    {
        public frmDelMesa()
        {
            InitializeComponent();
        }
        private void volver()
        {
            frmMesa frm = new frmMesa();
            frm.Show();
            this.Close();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            volver();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();

            database.Eliminar();
            MessageBox.Show("La mesa se eliminó con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            volver();
        }
    }
}
