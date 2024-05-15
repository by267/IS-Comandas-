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
    public partial class frmAddEmpleado : Form
    {
        private string asd;
        public frmAddEmpleado()
        {
            InitializeComponent();
            txtNombre.Focus();
        }
        private void Limpiar()
        {
            txtNombre.Text = null;
            txtUsuario.Text = null;
            txtPass.Text = null;
            cmbPuesto.Text = null;
        }
        private void frmAddEmpleado_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.Show();
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            obj.Nombre = txtNombre.Text;
            obj.Usuario = txtUsuario.Text;
            obj.Puesto = cmbPuesto.Text;
            obj.Password = txtPass.Text;
            asd = cmbPuesto.Text;

            DataTable datos = new DataTable();
            datos = database.ConsultarCodigoH(obj);
            if (datos.Rows.Count > 0)
            {
                MessageBox.Show("El empleado ya existe.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombre.Text != "" && txtUsuario.Text != "" && txtPass.Text != "" && cmbPuesto.Text != "")
                {
                    database.Agregar(obj);
                    MessageBox.Show("El empleado se agregó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Rellene los campos correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(txtNombre.Text);
            int cursorPos = txtNombre.SelectionStart;
            for (int i = 1; i < sb.Length && i >= 1; i++)
            {
                if (sb[i - 1] == ' ' && char.IsLower(sb[i]))
                {
                    sb[i] = char.ToUpper(sb[i]);
                }
            }
            txtNombre.Text = sb.ToString();
            txtNombre.SelectionStart = cursorPos;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancelar la pulsación de la tecla.
                e.Handled = true;
            }
        }
    }
}
