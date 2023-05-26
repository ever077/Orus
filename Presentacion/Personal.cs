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
        }

        private void LimpiarCampos()
        {
            txt_Nombres.Clear();
            txt_Identificacion.Clear();
            txt_Cargo.Clear();
            txt_SueldoPorHora.Clear();
        }
    }
}
