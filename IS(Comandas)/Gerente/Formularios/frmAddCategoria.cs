using IS_Comandas_.Gerente.Clases;
using IS_Comandas_.Gerente.Formularios;
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
        private void Limpiar()
        {
            txtNombre.Text = null;
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.Show();
            this.Close();
        }
        private void frmAddCategoria_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbCategoria database = new dbCategoria();
            ClassCategoria obj = new ClassCategoria();
            obj.Nombre = txtNombre.Text;

            DataTable datos = new DataTable();
            datos = database.ConsultarCodigo(obj);
            if (datos.Rows.Count > 0)
            {
                MessageBox.Show("El categoria ya existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombre.Text != "")
                {
                    database.Agregar(obj);
                    MessageBox.Show("La categoria se creo con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
