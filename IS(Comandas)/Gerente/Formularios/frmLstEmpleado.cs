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
    public partial class frmLstEmpleado : Form
    {
        public frmLstEmpleado()
        {
            InitializeComponent();
        }

        private void frmLstEmpleado_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            dbEmpleado database = new dbEmpleado();
            DataTable datos = new DataTable();
            datos = database.ConsultarTodos();
            dgvEmpleados.DataSource = datos;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.Show();
            this.Close();
        }
    }
}
