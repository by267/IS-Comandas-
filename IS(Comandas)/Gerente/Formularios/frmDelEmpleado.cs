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
    public partial class frmDelEmpleado : Form
    {
        public frmDelEmpleado()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();

            if (cmbEmpleado.Text == "")
            {
                MessageBox.Show("Seleccione una opcion valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                obj.Nombre = cmbEmpleado.SelectedValue.ToString();

                tCombo.Start();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("El empleado se elimino con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tCombo.Stop();
            }
        }
        private void cargarCombo()
        {
            cmbEmpleado.Text = "Selecciona una opcion";
            dbEmpleado db = new dbEmpleado();

            cmbEmpleado.DataSource = db.ConsultarU("NombreCompleto");
            cmbEmpleado.DisplayMember = "NombreCompleto";
            cmbEmpleado.ValueMember = "NombreCompleto";
        }
        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void frmDelEmpleado_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
