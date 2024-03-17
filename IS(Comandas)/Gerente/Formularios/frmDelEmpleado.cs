﻿using IS_Comandas_.Gerente.Clases;
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
    public partial class frmDelEmpleado : Form
    {
        public frmDelEmpleado()
        {
            InitializeComponent();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();

            if (cmbEmpleado.Text == "")
            {
                MessageBox.Show("Seleccion no valida", "Sistema");

            }
            else
            {
                obj.Usuario = cmbEmpleado.SelectedValue.ToString();

                tCombo.Start();
                DataTable datos = new DataTable();
                database.EliminarE(obj);

                MessageBox.Show("Se elimino con exito", "Sistema");

                tCombo.Stop();
            }
        }
        private void cargarCombo()
        {
            cmbEmpleado.Text = "Selecciona una opcion";
            dbEmpleado db = new dbEmpleado();

            cmbEmpleado.DataSource = db.ConsultarU("usuario");
            cmbEmpleado.DisplayMember = "Usuario";
            cmbEmpleado.ValueMember = "Usuario";
        }
        private void tCombo_Tick(object sender, EventArgs e)
        {
            cargarCombo();
        }

        private void frmDelEmpleado_Load(object sender, EventArgs e)
        {
            cargarCombo();
        }
    }
}
