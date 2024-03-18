using IS_Comandas_.Gerente.Clases;
using MySqlX.XDevAPI;
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
    public partial class frmEdtMenu : Form
    {
        public frmEdtMenu()
        {
            InitializeComponent();
        }
        private void cargarComboID()
        {
            cmbIdProducto.Text = "Selecciona una opcion";
            dbMenu db = new dbMenu();

            cmbIdProducto.DataSource = db.ConsultarU("nombre");
            cmbIdProducto.DisplayMember = "nombre";
            cmbIdProducto.ValueMember = "idMenu";
        }
        private void cargarComboP()
        {
            cmbIdProducto.Text = "Selecciona una opcion";
            dbCategoria db = new dbCategoria();

            cmbCategoria.DataSource = db.ConsultarU("nombre");
            cmbCategoria.DisplayMember = "nombre";
            cmbCategoria.ValueMember = "nombre";
        }
        private void hab()
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            cmbCategoria.Enabled = true;
            cmbIdProducto.Enabled = false;
        }
        private void Uhab()
        {
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            cmbCategoria.Enabled = false;
            cmbIdProducto.Enabled = true;

            txtNombre.Text=null;
            txtDescripcion.Text=null;
            txtPrecio.Text=null;
            cmbCategoria.Text=null;
        }
        private void tComboID_Tick(object sender, EventArgs e)
        {
            cargarComboID();
        }
        private void frmEdtMenu_Load(object sender, EventArgs e)
        {
            cargarComboID();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dbMenu database = new dbMenu();
            ClassMenu obj = new ClassMenu();
            DataTable datos = new DataTable();
            if (cmbIdProducto.Text != "")
            {
                obj.Nombre = cmbIdProducto.Text;
                datos = database.ConsultarCodigoH(obj);
                if (datos.Rows.Count > 0)
                {
                    txtNombre.Text = datos.Rows[0]["nombre"].ToString();
                    txtDescripcion.Text = datos.Rows[0]["descripcion"].ToString();
                    txtPrecio.Text = datos.Rows[0]["precio"].ToString();
                    cmbCategoria.Items.Add(datos.Rows[0]["categoria"].ToString());
                    cmbCategoria.StartIndex = 0;
                    hab();
                }      
            }
            else MessageBox.Show("Falto capturar informacion");
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Close();
        }
        private void cmbCategoria_Click(object sender, EventArgs e)
        {
            cargarComboP();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMenu database = new dbMenu();
            ClassMenu obj = new ClassMenu();
            obj.Id = int.Parse(cmbIdProducto.SelectedValue.ToString());
            obj.Nombre = txtNombre.Text;
            obj.Descripcion = txtDescripcion.Text;
            obj.Precio = float.Parse(txtPrecio.Text);
            obj.Categoria = cmbCategoria.Text;
            Uhab();
            tComboID.Start();
            database.Actualizar(obj);
            MessageBox.Show("Se actualizo la informacion con exito", "Sistema");
            tComboID.Stop();
        }
    }
}
