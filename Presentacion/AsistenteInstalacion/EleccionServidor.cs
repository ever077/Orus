using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion.AsistenteInstalacion
{
    public partial class EleccionServidor : Form
    {
        public EleccionServidor()
        {
            InitializeComponent();
        }

        private void EleccionServidor_Load(object sender, EventArgs e)
        {
            centrarPaneles();
        }

        private void centrarPaneles()
        {
            panel_Eleccion.Location = new Point((Width - panel_Eleccion.Width) / 2, (Height - panel_Eleccion.Height) / 2);
        }

        private void btn_Principal_Click(object sender, EventArgs e)
        {
            Dispose();
            InstalacionBD frm = new InstalacionBD();
            frm.ShowDialog();
        }

        private void btn_PuntoDeControl_Click(object sender, EventArgs e)
        {
            Dispose();
            ConexionRemota frm = new ConexionRemota();
            frm.ShowDialog();
        }
    }
}
