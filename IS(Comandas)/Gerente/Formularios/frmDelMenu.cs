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

namespace IS_Comandas_.Gerente
{
    public partial class frmDelMenu : Form
    {
        public frmDelMenu()
        {
            InitializeComponent();
        }
        private void cargarCombo()
        {
            cmbMenu.Text = "Selecciona una opcion";
            dbMenu db = new dbMenu();

            cmbMenu.DataSource = db.ConsultarU("nombre");
            cmbMenu.DisplayMember = "nombre";
            cmbMenu.ValueMember = "nombre";
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMenu database = new dbMenu();
            ClassMenu obj = new ClassMenu();

            if (cmbMenu.Text == "")
            {
                MessageBox.Show("Seleccion no valida", "Sistema");

            }
            else
            {
                obj.Nombre = cmbMenu.SelectedValue.ToString();

                tCombo.Start();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("Se elimino con exito", "Sistema");

                tCombo.Stop();
            }
        }
        private void frmDelMenu_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
    
}
