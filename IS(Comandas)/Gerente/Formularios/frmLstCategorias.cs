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
    public partial class frmLstCategorias : Form
    {
        public frmLstCategorias()
        {
            InitializeComponent();
        }

        private void frmLstCategorias_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            dbCategoria database = new dbCategoria();
            DataTable datos = new DataTable();
            datos = database.ConsultarTodos();
            dgvCategorias.DataSource = datos;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.Show();
            this.Close();
        }
    }
}
