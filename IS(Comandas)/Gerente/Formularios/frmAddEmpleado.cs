﻿using IS_Comandas_.Gerente;
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

namespace IS_Comandas_
{
    public partial class frmAddEmpleado : Form
    {
        private string asd;
        public frmAddEmpleado()
        {
            InitializeComponent();
            txtNombre.Focus();
        }
        private void Limpiar()
        {
            txtNombre.Text = null;
            txtUsuario.Text = null;
            txtPass.Text = null;
            cmbPuesto.Text = null;
        }
        private void frmAddEmpleado_Load(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }
        private void btnRegresar_Click_1(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.Show();
            this.Close();
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            dbEmpleado database = new dbEmpleado();
            ClassEmpleado obj = new ClassEmpleado();
            obj.Nombre = txtNombre.Text;
            obj.Usuario = txtUsuario.Text;
            obj.Puesto = cmbPuesto.Text;
            obj.Password = txtPass.Text;
            asd = cmbPuesto.Text;

            DataTable datos = new DataTable();
            datos = database.ConsultarCodigoH(obj);
            if (datos.Rows.Count > 0)
            {
                MessageBox.Show("El empleado ya existe", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtNombre.Text != "" && txtUsuario.Text != "" && txtPass.Text != "" && cmbPuesto.Text != "")
                {
                    database.Agregar(obj);
                    MessageBox.Show("El empleado se agrego con exito", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
