using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orus.Logica;
using Orus.Datos;

namespace Orus.Presentacion
{
    public partial class Personal : UserControl
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            panel_AgregarCargo.Visible = false;
            panel_Paginado.Visible = false;
            panel_AgregarRegistro.Visible = true;
            panel_AgregarRegistro.Dock = DockStyle.Fill;
            btn_GuardarPersonal.Visible = true;
            btn_GuardarCambiosPersonal.Visible = false;
            LimpiarCampos();
            MostrarCargos();
            panel_AgregarCargo.SendToBack();
        }

        private void LimpiarCampos()
        {
            txt_Nombres.Clear();
            txt_Identificacion.Clear();
            comboBox_Pais.Text = string.Empty;
            txt_Cargo.Clear();
            txt_SueldoPorHora.Clear();
        }

        private void btn_GuardarPersonal_Click(object sender, EventArgs e)
        {

        }

        private void InsertarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();

            parametros.Nombres = txt_Nombres.Text;
            parametros.Identificacion = txt_Identificacion.Text;
            parametros.Pais = comboBox_Pais.Text;
        }

        private void btn_GuardarCargo_Click(object sender, EventArgs e)
        {
            InsertarCargo();
        }

        private void InsertarCargo()
        {
            if (!string.IsNullOrEmpty(txt_NuevoCargo.Text))
            {
                if (!string.IsNullOrEmpty(txt_NuevoSueldoPorHora.Text))
                {
                    Lcargo parametros = new Lcargo();
                    Dcargo funcion = new Dcargo();

                    parametros.Cargo = txt_NuevoCargo.Text;
                    parametros.SueldoPorHora = Convert.ToDouble(txt_NuevoSueldoPorHora.Text);

                    if (funcion.InsertarCargo(parametros))
                    {
                        txt_Cargo.Clear();
                        MostrarCargos();
                        panel_AgregarCargo.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Agregue un sueldo", "Falta el sueldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Agregue un cargo","Falta el cargo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void MostrarCargos()
        {
            DataTable dt = new DataTable();
            Dcargo funcion = new Dcargo();

            funcion.BuscarCargo(ref dt, txt_Cargo.Text);
            dataGridView_Cargos.DataSource = dt;
            Configuraciones.DisenoDgv(ref dataGridView_Cargos);
        }

        private void txt_Cargo_TextChanged(object sender, EventArgs e)
        {
            MostrarCargos();
        }

        private void btn_AgregarCargo_Click(object sender, EventArgs e)
        {
            panel_AgregarCargo.Visible = true;
            panel_AgregarCargo.Dock = DockStyle.Fill;
            panel_AgregarCargo.BringToFront();
            btn_GuardarCargo.Visible = true;
            btn_GuardarCambiosCargo.Visible = false;
            txt_NuevoCargo.Clear();
            txt_NuevoSueldoPorHora.Clear();
        }

        private void txt_NuevoSueldoPorHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            Configuraciones.ValidacionDecimales(txt_NuevoSueldoPorHora, e);
        }

        private void txt_SueldoPorHora_KeyPress(object sender, KeyPressEventArgs e)
        {
            Configuraciones.ValidacionDecimales(txt_SueldoPorHora, e);
        }
    }
}
