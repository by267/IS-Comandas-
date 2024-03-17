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

namespace IS_Comandas_.Gerente.Formularios
{
    public partial class frmLstMenu : Form
    {
        public frmLstMenu()
        {
            InitializeComponent();
        }
        private void cargarDatos()
        {
            dbMenu database = new dbMenu();
            DataTable datos = new DataTable();
            datos = database.ConsultarTodos();
            dgvMenu.DataSource = datos;
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Close();
        }
        private void frmLstMenu_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
    }
}
