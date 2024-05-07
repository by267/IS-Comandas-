using IS_Comandas_.Gerente.Clases;
using IS_Comandas_.Mesero.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IS_Comandas_.Mesero
{
    public partial class frmDelComanda3 : Form
    {
        public frmDelComanda3()
        {
            InitializeComponent();
        }
        private void cargarCombo()
        {
            cmbNoComanda.Text = "Selecciona una opcion";
            dbcomandas db = new dbcomandas();

            cmbNoComanda.DataSource = db.ConsultarO("noComanda");
            cmbNoComanda.DisplayMember = "noComanda";
            cmbNoComanda.ValueMember = "noComanda";
        }
        private void desMesa()
        {
            dbMesa database = new dbMesa();
            ClassMesa obj = new ClassMesa();
            obj.Id = int.Parse(cmbNoComanda.Text);
            database.desactivarMesa(obj);
            //MessageBox.Show("La mesa se activó con éxito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dbcomandas database = new dbcomandas();
            clasecomanda obj = new clasecomanda();

            if (cmbNoComanda.Text == "")
            {
                MessageBox.Show("Seleccione una opcion valida", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                obj.noComanda = cmbNoComanda.Text;

                tCombo.Start();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("La comanda se elimino con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                desMesa();
                tCombo.Stop();
            }
        }
        private void frmDelComanda3_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
