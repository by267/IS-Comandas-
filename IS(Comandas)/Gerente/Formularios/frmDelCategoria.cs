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
    public partial class frmDelCategoria : Form
    {
        public frmDelCategoria()
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
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.Show();
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbCategoria database = new dbCategoria();
            ClassCategoria obj = new ClassCategoria();

            if (cmbCategoria.Text == "")
            {
                MessageBox.Show("Seleccion no valida", "Sistema");

            }
            else
            {
                obj.Nombre = cmbCategoria.SelectedValue.ToString();

                tCombo.Start();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("Se elimino con exito", "Sistema");

                tCombo.Stop();
            }
        }
        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }
        private void frmDelCategoria_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
