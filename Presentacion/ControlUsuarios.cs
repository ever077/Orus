using Orus.Datos;
using Orus.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class ControlUsuarios : UserControl
    {
        // Cantidad de columnas agreagadas por defecto en dataGridView_Usuarios.
        private const int _ColumnasFijasDgvUsuarios = 2;
        // Cantidad de columnas agreagadas por defecto en dataGridView_Modulos.
        private const int _ColumnasFijasDgvModulos = 1;
        int idUsuario;

        public ControlUsuarios()
        {
            InitializeComponent();
        }

        private void ControlUsuarios_Load(object sender, EventArgs e)
        {
            CrearColumnaCheckBox();
            //Logica.Configuraciones.DisenoDgv(ref dataGridView_Modulos);

            MostrarUsuario();
        }

        private void CrearColumnaCheckBox()
        {
            // Creo una columna dinamicamente la cual se encarga de poder seleccionar un permiso.
            // Es del tipo CheckBox.

            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.Name = "Marcar";
            chkColumn.HeaderText = "Marcar";
            chkColumn.ReadOnly = false;
            dataGridView_Modulos.Columns.Add(chkColumn);
        }

        private void DisenoDgvUsuario()
        {
            Configuraciones.DisenoDgv(ref dataGridView_Usuarios);
            Configuraciones.DisenoDgvEliminado(ref dataGridView_Usuarios);

            // Oculto las columnas que no voy a mostrar.
            dataGridView_Usuarios.Columns[_ColumnasFijasDgvUsuarios + 0].Visible = false;
            dataGridView_Usuarios.Columns[_ColumnasFijasDgvUsuarios + 3].Visible = false;
            dataGridView_Usuarios.Columns[_ColumnasFijasDgvUsuarios + 4].Visible = false;
        }

        private void DisenoDgvModulo()
        {
            // Oculto las columnas que no voy a mostrar.
            dataGridView_Modulos.Columns[_ColumnasFijasDgvModulos + 0].Visible = false;

            /*
             * Pongo el DGV readonly en false para que se pueda checkear
             * el CheckBox de la columna "Marcar" (Automaticamente no lo hace).
             * Luego selecciono que columnas quiero que sean editables y cuales no.
            */
            dataGridView_Modulos.ReadOnly = false;
            dataGridView_Modulos.Columns[0].ReadOnly = false;
            dataGridView_Modulos.Columns[2].ReadOnly = true;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarPanelesAlAgregar();
            MostrarModulos();
        }

        private void LimpiarCampos()
        {
            txt_Nombre.Clear();
            txt_Usuario.Clear();
            txt_Pass.Clear();
            pictureBox_Icono.Image = null;
        }

        private void HabilitarPanelesAlAgregar()
        {
            panel_Registro.Visible = true;
            lbl_AnuncioIcono.Visible = true;
            panel_Icono.Visible = false;
            panel_Registro.Dock = DockStyle.Fill;
            panel_Registro.BringToFront();
            btn_Guardar.Visible = true;
            btn_Actualizar.Visible = false;
            btn_VolverRegistro.Visible = true;
        }

        private void HabilitarPanelesAlEditar()
        {
            panel_Registro.Visible = true;
            lbl_AnuncioIcono.Visible = false;
            panel_Icono.Visible = false;
            panel_Registro.Dock = DockStyle.Fill;
            panel_Registro.BringToFront();
            btn_Guardar.Visible = false;
            btn_Actualizar.Visible = true;
            btn_VolverRegistro.Visible = true;
        }

        private void MostrarModulos()
        {
            Dmodulo funcion = new Dmodulo();
            DataTable dt = new DataTable();

            funcion.MostrarModulos(ref dt);
            dataGridView_Modulos.DataSource = dt;

            DisenoDgvModulo();
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nombre.Text))
            {
                if (!string.IsNullOrEmpty(txt_Usuario.Text))
                {
                    if (!string.IsNullOrEmpty(txt_Pass.Text))
                    {
                        if (lbl_AnuncioIcono.Visible == false)
                        {
                            InsertarUsuario();
                        }
                        else
                        {
                            MessageBox.Show("Escoja una imagen", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una contraseña", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un usuario", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre","Validacion de campos",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void InsertarUsuario()
        {
            Lusuario parametros = new Lusuario();
            Dusuario funcion = new Dusuario();

            parametros.Nombres = txt_Nombre.Text;
            parametros.Login = txt_Usuario.Text;
            parametros.Password = txt_Pass.Text;

            MemoryStream ms = new MemoryStream();
            pictureBox_Icono.Image.Save(ms, pictureBox_Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();

            if (funcion.InsertarUsuario(parametros) == true)
            {
                ObtenerIdUsuario();
                InsertarPermiso();
            }
        }

        private void ObtenerIdUsuario()
        {
            Dusuario funcion = new Dusuario();

            funcion.ObtenerIdUsuario(ref idUsuario, txt_Usuario.Text);
        }

        private void InsertarPermiso()
        {
            Lpermiso parametros = new Lpermiso();
            Dpermiso funcion = new Dpermiso();

            foreach (DataGridViewRow row in dataGridView_Modulos.Rows)
            {
                int idModulo = Convert.ToInt32(row.Cells["Id_modulo"].Value);
                bool seleccionado = Convert.ToBoolean(row.Cells["Marcar"].Value);

                if (seleccionado == true)
                {
                    parametros.Id_modulo = idModulo;
                    parametros.Id_Usuario = idUsuario;

                    funcion.InsertarPermiso(parametros);
                }
            }
            MostrarUsuario();

            panel_Registro.Visible = false;
        }

        private void MostrarUsuario()
        {
            Dusuario funcion = new Dusuario();
            DataTable dt = new DataTable();

            funcion.MostrarUsuario(ref dt);
            dataGridView_Usuarios.DataSource = dt;

            DisenoDgvUsuario();
        }

        private void OcultarPanelIconos()
        {
            panel_Icono.Visible = false;
            lbl_AnuncioIcono.Visible = false;
            pictureBox_Icono.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox3.Image;
            OcultarPanelIconos();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox4.Image;
            OcultarPanelIconos();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox5.Image;
            OcultarPanelIconos();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox6.Image;
            OcultarPanelIconos();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox7.Image;
            OcultarPanelIconos();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox8.Image;
            OcultarPanelIconos();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox9.Image;
            OcultarPanelIconos();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            pictureBox_Icono.Image = pictureBox10.Image;
            OcultarPanelIconos();
        }

        private void pictureBox_AgregarImagen_Click(object sender, EventArgs e)
        {
            Dialog_1.InitialDirectory = "";
            Dialog_1.Filter = "Imagenes|*.jpg;*.png";
            Dialog_1.FilterIndex = 2;
            Dialog_1.Title = "Cargador de imagenes";
            if (Dialog_1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Icono.Image = null;
                pictureBox_Icono.Image = new Bitmap(Dialog_1.FileName);

                OcultarPanelIconos();
            }
        }

        private void lbl_AnuncioIcono_Click(object sender, EventArgs e)
        {
            MostrarPanelIconos();
        }

        private void pictureBox_Icono_Click(object sender, EventArgs e)
        {
            MostrarPanelIconos();
        }

        private void MostrarPanelIconos()
        {
            panel_Icono.Visible = true;
            panel_Icono.Dock = DockStyle.Fill;
            panel_Icono.BringToFront();
        }

        private void txt_Pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btn_VolverRegistro_Click(object sender, EventArgs e)
        {
            panel_Registro.Visible = false;
        }

        private void btn_VolverIcono_Click(object sender, EventArgs e)
        {
            panel_Icono.Visible = false;
            pictureBox_Icono.Visible = true;
        }

        private void dataGridView_Usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Usuarios.Columns["Column_Editar"].Index)
            {
                string estado = obtenerEstado();

                if (estado == "ELIMINADO")
                {
                    DialogResult dlg_Resultado = MessageBox.Show("Este usuario se ELIMINO. ¿Desea activarlo?", "Restauracion de usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dlg_Resultado == DialogResult.OK)
                    {
                        restaurarUsuario();
                    }
                }
                else
                {
                    cargarDatos();
                }
            }
            if (e.ColumnIndex == dataGridView_Usuarios.Columns["Column_Eliminar"].Index)
            {
                // Eliminar usuario
            }
        }

        private string obtenerEstado()
        {
            return dataGridView_Usuarios.SelectedCells[_ColumnasFijasDgvUsuarios + 5].Value.ToString();
        }

        private string obtenerLogin()
        {
            return dataGridView_Usuarios.SelectedCells[_ColumnasFijasDgvUsuarios + 2].Value.ToString();
        }

        private void restaurarUsuario()
        {
            Lusuario parametros = new Lusuario();
            Dusuario funcion = new Dusuario();

            // Obtengo el Login del usuario para luego obtener su ID.
            string loginUsuario = obtenerLogin();
            funcion.ObtenerIdUsuario(ref idUsuario, loginUsuario);

            parametros.Id_usuario = idUsuario;

            if (funcion.RestaurarUsuario(parametros) == true)
            {
                MostrarUsuario();
            }
        }

        private void cargarDatos()
        {
            Dusuario funcion = new Dusuario();

            LimpiarCampos();

            // Obtengo el Login del usuario para luego obtener su ID.
            string loginUsuario = obtenerLogin();
            funcion.ObtenerIdUsuario(ref idUsuario, loginUsuario);

            txt_Nombre.Text = dataGridView_Usuarios.SelectedCells[_ColumnasFijasDgvUsuarios + 1].Value.ToString();
            txt_Usuario.Text = dataGridView_Usuarios.SelectedCells[_ColumnasFijasDgvUsuarios + 2].Value.ToString();
            txt_Pass.Text = dataGridView_Usuarios.SelectedCells[_ColumnasFijasDgvUsuarios + 3].Value.ToString();

            pictureBox_Icono.BackgroundImage = null;
            byte[] b = (byte[])(dataGridView_Usuarios.SelectedCells[_ColumnasFijasDgvUsuarios + 4].Value);
            MemoryStream ms = new MemoryStream(b);
            pictureBox_Icono.Image = Image.FromStream(ms);

            HabilitarPanelesAlEditar();

            MostrarModulos();
            mostrarPermisos();
        }

        private void mostrarPermisos()
        {
            Lpermiso parametros = new Lpermiso();
            Dpermiso funcion = new Dpermiso();
            DataTable dtPermisos = new DataTable();

            parametros.Id_Usuario = idUsuario;
            funcion.MostrarPermiso(ref dtPermisos, parametros);

            foreach (DataRow rowPermiso in dtPermisos.Rows)
            {
                string moduloUsuario = Convert.ToString(rowPermiso["Modulo"]);

                foreach (DataGridViewRow rowModulo in dataGridView_Modulos.Rows)
                {
                    string modulo = Convert.ToString(rowModulo.Cells["Modulo"].Value);
                    
                    if (modulo == moduloUsuario)
                    {
                        rowModulo.Cells["Marcar"].Value = true;
                    }
                }
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_Nombre.Text))
            {
                if (!string.IsNullOrEmpty(txt_Usuario.Text))
                {
                    if (!string.IsNullOrEmpty(txt_Pass.Text))
                    {
                        if (lbl_AnuncioIcono.Visible == false)
                        {
                            if (actualizarUsuario() == true)
                            {
                                actualizarPermisos();
                                panel_Registro.Visible = false;
                                MostrarUsuario();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Escoja una imagen", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese una contraseña", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un usuario", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre", "Validacion de campos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool actualizarUsuario()
        {
            Lusuario parametros = new Lusuario();
            Dusuario funcion = new Dusuario();

            parametros.Id_usuario = idUsuario;
            parametros.Nombres = txt_Nombre.Text;
            parametros.Login = txt_Usuario.Text;
            parametros.Password = txt_Pass.Text;

            MemoryStream ms = new MemoryStream();
            pictureBox_Icono.Image.Save(ms, pictureBox_Icono.Image.RawFormat);
            parametros.Icono = ms.GetBuffer();

            return (funcion.EditarUsuario(parametros));
        }

        private void actualizarPermisos()
        {
            Lpermiso parametros = new Lpermiso();
            Dpermiso funcion = new Dpermiso();

            // Primero elimino todos los permisos del usuario
            parametros.Id_Usuario = idUsuario;
            funcion.EliminarPermiso(parametros);

            // Luego inserto los nuevos permisos que elijio
            foreach (DataGridViewRow row in dataGridView_Modulos.Rows)
            {
                int idModulo = Convert.ToInt32(row.Cells["Id_modulo"].Value);
                bool seleccionado = Convert.ToBoolean(row.Cells["Marcar"].Value);

                if (seleccionado == true)
                {
                    parametros.Id_modulo = idModulo;
                    // *** Fijarme si anda sin esto, debido a que cuando elimino los permisos
                    // *** filas mas arriba, ya guardo el id en parametros.
                    //parametros.Id_Usuario = idUsuario;

                    funcion.EditarPermiso(parametros);
                }
            }
        }
    }
}
