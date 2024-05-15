using IS_Comandas_.Gerente;
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

namespace IS_Comandas_
{
    public partial class frmAddMesa : Form
    {
        public frmAddMesa()
        {
            InitializeComponent();
        }
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            ReturnfrmMesa();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            DataTable datos = new DataTable();
            database.Agregar(obj);
            MessageBox.Show("La mesa se agregó con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnfrmMesa();
        }
        private void ReturnfrmMesa()
        {
            this.Close();
            frmMesa frm = new frmMesa();
            frm.Show();
        }
    }
}
