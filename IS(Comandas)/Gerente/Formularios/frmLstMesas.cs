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
    public partial class frmLstMesas : Form
    {
        public frmLstMesas()
        {
            InitializeComponent();
        }

        private void frmLstMesas_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            dbMesa database = new dbMesa();
            DataTable datos = new DataTable();
            datos = database.ConsultarTodos();
            dgvMesas.DataSource = datos;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMesa frm = new frmMesa();
            frm.Show();
            this.Close();
        }
    }
}
