using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        private int idUsuario;
        private string loginV;
        private Image iconoUsuario;

        public void set_idUsuario(int id)
        {
            idUsuario = id;
        }
        public void set_loginV(string log)
        {
            loginV = log;
        }

        public void set_iconoUsuario(Image icono)
        {
            iconoUsuario = icono;
        }

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panel_Bienvenida.Dock = DockStyle.Fill;
            validarPermisos();
        }

        private void validarPermisos()
        {
            Lpermiso parametros = new Lpermiso();
            Dpermiso funcion = new Dpermiso();
            DataTable dtPermisos = new DataTable();

            parametros.Id_Usuario = idUsuario;
            funcion.MostrarPermiso(ref dtPermisos, parametros);

            // Inhabilito todos los botones del Menu Principal.
            btn_Consultas.Enabled = false;
            btn_Personal.Enabled = false;
            btn_Registro.Enabled = false;
            btn_Usuarios.Enabled = false;
            btn_RestaurarBd.Enabled = false;
            btn_Respaldos.Enabled = false;
            btn_Estaciones.Enabled = false;

            foreach (DataRow rowPermiso in dtPermisos.Rows)
            {
                string modulo = Convert.ToString(rowPermiso["Modulo"]);

                if (modulo == "PrePlanillas")
                {
                    btn_Consultas.Enabled = true;
                }
                if (modulo == "Personal")
                {
                    btn_Personal.Enabled = true;
                }
                if (modulo == "Registro")
                {
                    btn_Registro.Enabled = true;
                }
                if (modulo == "Usuarios")
                {
                    btn_Usuarios.Enabled = true;
                }
                if (modulo == "RestauracionBD")
                {
                    btn_RestaurarBd.Enabled = true;
                }
                if (modulo == "Respaldos")
                {
                    btn_Respaldos.Enabled = true;
                }
                if (modulo == "Estaciones")
                {
                    btn_Estaciones.Enabled = true;
                }
            }
        }

        private void btn_Personal_Click(object sender, EventArgs e)
        {
            panel_Padre.Controls.Clear();
            Personal controlPersonal = new Personal();
            controlPersonal.Dock = DockStyle.Fill;
            panel_Padre.Controls.Add(controlPersonal);
        }

        private void btn_Usuarios_Click(object sender, EventArgs e)
        {
            panel_Padre.Controls.Clear();
            ControlUsuarios controlUsuario = new ControlUsuarios();
            controlUsuario.Dock = DockStyle.Fill;
            panel_Padre.Controls.Add(controlUsuario);
        }
    }
}
