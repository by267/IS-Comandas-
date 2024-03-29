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
    public partial class frmAddMenu : Form
    {
        public frmAddMenu()
        {
            InitializeComponent();
        }
        private void cargarCombo()
        {
            cmbCategoria.Text = "Selecciona una opcion";
            dbCategoria db = new dbCategoria();

            cmbCategoria.DataSource = db.ConsultarU("nombre");
            cmbCategoria.DisplayMember = "nombre";
            cmbCategoria.ValueMember = "nombre";
        }
        private void Limpiar()
        {
            txtNombre.Text = null;
            txtDescripcion.Text = null;
            txtPrecio.Text = null;
            cmbCategoria.Text = null;
        }
        private void frmAddMenu_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            dbMenu database = new dbMenu();
            ClassMenu obj = new ClassMenu();
            obj.Nombre = txtNombre.Text;
            obj.Descripcion = txtDescripcion.Text;
            obj.Precio = float.Parse(txtPrecio.Text);
            obj.Categoria = cmbCategoria.Text;

            DataTable datos = new DataTable();
            datos = database.ConsultarCodigoH(obj);
            if (datos.Rows.Count > 0)
            {
                MessageBox.Show("El producto ya existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombre.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "" && cmbCategoria.Text != "")
                {
                    database.Agregar(obj);
                    MessageBox.Show("El producto se agrego con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();

            this.Close();
        }
    }
}
