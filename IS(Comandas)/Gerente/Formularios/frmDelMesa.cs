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
    public partial class frmDelMesa : Form
    {
        public frmDelMesa()
        {
            InitializeComponent();
        }
        private void cargarCombo()
        {
            cmbMesa.Text = "Selecciona una opcion";
            dbMesa db = new dbMesa();

            cmbMesa.DataSource = db.ConsultarU("idmesas");
            cmbMesa.DisplayMember = "idmesas";
            cmbMesa.ValueMember = "idmesas";
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            frmMesa frm = new frmMesa();
            frm.Show();
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();

            if (cmbMesa.Text == "")
            {
                MessageBox.Show("Seleccion no valida", "Sistema");

            }
            else
            {
                obj.Id = int.Parse(cmbMesa.SelectedValue.ToString());

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
        private void frmDelMesa_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
