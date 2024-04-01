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
    public partial class frmEdtEmpleado : Form
    {
        public frmEdtEmpleado()
        {
            InitializeComponent();
        }
        private void cargarComboN()
        {
            cmbEmpleado.Text = "Selecciona una opcion";
            dbEmpleado db = new dbEmpleado();

            cmbEmpleado.DataSource = db.ConsultarU("NombreCompleto");
            cmbEmpleado.DisplayMember = "NombreCompleto";
            cmbEmpleado.ValueMember = "idEmpleado";
        }
        private void hab()
        {
            txtNombre.Enabled = true;
            txtUsuario.Enabled = true;
            txtPass.Enabled = true;
            cmbPuesto.Enabled = true;
            btnModificar.Enabled = true;
        
            btnBuscar.Enabled = false;
            cmbEmpleado.Enabled = false;
        }
        private void Uhab()
        {
            txtUsuario.Enabled = false;
            txtPass.Enabled = false;
            cmbPuesto.Enabled = false;
            txtNombre.Enabled=false;
            btnBuscar.Enabled = true;
            cmbEmpleado.Enabled = true;

            txtNombre.Text = null;
            txtPass.Text = null;
            txtUsuario.Text = null;
            cmbPuesto.Text = null;
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.Show();
            this.Close();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            obj.Id = int.Parse(cmbEmpleado.SelectedValue.ToString());
            obj.Nombre = txtNombre.Text;
            obj.Usuario = txtUsuario.Text;
            obj.Password = txtPass.Text;
            obj.Puesto = cmbPuesto.Text;
            Uhab();
            tComboId.Start();
            database.Actualizar(obj);
            MessageBox.Show("La informacion se actualizo con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            tComboId.Stop();

        }
        private void frmEdtEmpleado_Load(object sender, EventArgs e)
        {
            cargarComboN();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            DataTable datos = new DataTable();
            if (cmbEmpleado.Text != "")
            {
                obj.Nombre = cmbEmpleado.Text;
                datos = database.ConsultarCodigoH(obj);
                if (datos.Rows.Count > 0)
                {
                    txtNombre.Text = datos.Rows[0]["NombreCompleto"].ToString();
                    txtPass.Text = datos.Rows[0]["Password"].ToString();
                    txtUsuario.Text = datos.Rows[0]["Usuario"].ToString();
                    cmbPuesto.Items.Add(datos.Rows[0]["Puesto"].ToString());
                    cmbPuesto.StartIndex = 0;
                    hab();
                }
            }
            else
            {
                MessageBox.Show("Rellene correctamente los campos", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        private void tComboId_Tick(object sender, EventArgs e)
        {
            cargarComboN();
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
    }
    
}
