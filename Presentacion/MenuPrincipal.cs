﻿using System;
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
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panel_Bienvenida.Dock = DockStyle.Fill;
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
