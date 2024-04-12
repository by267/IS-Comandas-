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
    public partial class frmEdtCategoria : Form
    {
        public frmEdtCategoria()
        {
            InitializeComponent();
        }
        private void cargarComboN()
        {
            cmbCategoria.Text = "Selecciona una opcion";
            dbCategoria db = new dbCategoria();

            cmbCategoria.DataSource = db.ConsultarU("nombre");
            cmbCategoria.DisplayMember = "nombre";
            cmbCategoria.ValueMember = "idCategorias";
        }
        private void hab()
        {
            txtNombre.Enabled = true;
            btnGuardar.Enabled = true;
            cmbCategoria.Enabled = false;
            btnBuscar.Enabled = false;
        }
        private void Uhab()
        {
            txtNombre.Enabled = false;
            btnBuscar.Enabled = true;
            cmbCategoria.Enabled = true;

            txtNombre.Text = null;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dbCategoria database = new dbCategoria();
            ClassCategoria obj = new ClassCategoria();
            DataTable datos = new DataTable();
            if (cmbCategoria.Text != "")
            {
                obj.Nombre = cmbCategoria.Text;
                datos = database.ConsultarCodigo(obj);
                if (datos.Rows.Count > 0)
                {
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    hab();
                }
            }
            else MessageBox.Show("Seleccione una opcion valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dbCategoria database = new dbCategoria();
            ClassCategoria obj = new ClassCategoria();
            obj.Id = int.Parse(cmbCategoria.SelectedValue.ToString());
            obj.Nombre = txtNombre.Text;
            Uhab();
            tComboID.Start();
            database.Actualizar(obj);
            MessageBox.Show("La categoria se actualizo con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tComboID.Stop();
        }
        private void tComboID_Tick(object sender, EventArgs e)
        {
            cargarComboN();
        }
        private void frmEdtCategoria_Load(object sender, EventArgs e)
        {
            cargarComboN();
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.Show();
            this.Close();
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Validar si la tecla presionada es una letra o un espacio.
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
            // Convertir la primera letra a mayúscula.
            if (txtNombre.SelectionStart == 0 && char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }
    }
}
