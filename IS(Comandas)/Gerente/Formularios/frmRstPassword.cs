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
        private void cargarCombo()
        {
            cmbUsuario.Text = "Selecciona una opcion";
            dbEmpleado db = new dbEmpleado();

            cmbUsuario.DataSource = db.ConsultarU("usuario");
            cmbUsuario.DisplayMember = "Usuario";
            cmbUsuario.ValueMember = "Usuario";
        }
        private void limpiar()
        {
            txtNewPass.Text = null;
            txtRePass.Text = null;
            //cmbUsuario.Text = null;
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
            if (txtNewPass.Text == txtRePass.Text)
            {
                obj.Password = txtNewPass.Text;

                if (cmbUsuario.Text != "")
                {
                    obj.Usuario = cmbUsuario.SelectedValue.ToString();

                    DataTable datos = new DataTable();
                    datos = database.ConsultarCodigo(obj);
                    if (txtNewPass.Text != "" && txtRePass.Text != "")
                    {
                        database.Actualizar(obj);
                        MessageBox.Show("Se realizo el cambio con exito", "Sistema");                       

                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Falto capturar informacion", "Sistema"); 
                    }
                }
                else
                {
                    MessageBox.Show("Seleccion no valida", "Sistema");
                }
            }
            else
            {
                MessageBox.Show("La contraseña no coincide");
            }
        }
        private void frmEdtEmpleado_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
