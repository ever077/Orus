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
        private int idCargo = 0;
        // Cantidad de columnas agreagadas por defecto en dataGridView_Cargos.
        private static int _ColumnasFijasDgvCargos = 1;
        private static int _ColumnasFijasDgvPersonal = 2;
        private int desde = 1;
        private int hasta = 10;
        private int contadorPersonal;
        private int idPersonal;
        private int itemsPorPagina = 10;
        private string estado;
        private int totalPaginas;

        public Personal()
        {
            InitializeComponent();
        }

        private void Personal_Load(object sender, EventArgs e)
        {
            ReiniciarPaginado();
            MostrarPesronal();
            LocalizarDgvCargos();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            panel_AgregarCargo.Visible = false;
            panel_Paginado.Visible = false;
            panel_AgregarRegistro.Visible = true;
            panel_AgregarRegistro.Dock = DockStyle.Fill;
            btn_GuardarPersonal.Visible = true;
            btn_GuardarCambiosPersonal.Visible = false;
            txt_Nombres.Focus();
            LimpiarCampos();
            //LocalizarDgvCargos();
            MostrarCargos();
            //panel_AgregarCargo.SendToBack();
        }

        private void LocalizarDgvCargos()
        {
            dataGridView_Cargos.Location = new Point(txt_SueldoPorHora.Location.X, txt_SueldoPorHora.Location.Y);
            dataGridView_Cargos.Size = new Size(469, 141);
            dataGridView_Cargos.Visible = true;
            lbl_SueldoPorHora.Visible = false;
            flowLayoutPanel_GuardarPersonal.Visible = false;
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
            InsertarPersonal();
        }

        private void InsertarPersonal()
        {
            if (ValidarPersonal())
            {
                Lpersonal parametros = new Lpersonal();
                Dpersonal funcion = new Dpersonal();

                parametros.Nombres = txt_Nombres.Text;
                parametros.Identificacion = txt_Identificacion.Text;
                parametros.Pais = comboBox_Pais.Text;
                parametros.Id_cargo = idCargo;
                parametros.SueldoPorHora = Convert.ToDouble(txt_SueldoPorHora.Text);
                if (funcion.InsertarPersonal(parametros) == true)
                {
                    ReiniciarPaginado();
                    MostrarPesronal();
                    panel_AgregarRegistro.Visible = false;
                }
            }
            
        }

        private bool ValidarPersonal()
        {
            if (idCargo > 0 &&
                !string.IsNullOrEmpty(txt_Nombres.Text) &&
                !string.IsNullOrEmpty(txt_Identificacion.Text) &&
                !string.IsNullOrEmpty(comboBox_Pais.Text) &&
                !string.IsNullOrEmpty(txt_Cargo.Text) &&
                !string.IsNullOrEmpty(txt_SueldoPorHora.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MostrarPesronal()
        {
            DataTable dt = new DataTable();
            Dpersonal funcion = new Dpersonal();
            funcion.MostrarPersonal(ref dt, desde, hasta);
            dataGridView_Personal.DataSource = dt;
            DisenarDgvPersonal();
        }

        private void DisenarDgvPersonal()
        {
            Configuraciones.DisenoDgv(ref dataGridView_Personal);
            Configuraciones.DisenoDgvEliminado(ref dataGridView_Personal);
            dataGridView_Personal.Columns[_ColumnasFijasDgvPersonal + 0].Visible = false;
            dataGridView_Personal.Columns[_ColumnasFijasDgvPersonal + 5].Visible = false;
            panel_Paginado.Visible = true;
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

            dataGridView_Cargos.Columns[_ColumnasFijasDgvCargos + 0].Visible = false;
            dataGridView_Cargos.Columns[_ColumnasFijasDgvCargos + 2].Visible = false;
            dataGridView_Cargos.Visible = true;
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

        private void dataGridView_Cargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Cargos.Columns["EditarCargo"].Index)
            {
                ObtenerCargoEditar();
            }
            if (e.ColumnIndex == dataGridView_Cargos.Columns["Cargo"].Index)
            {
                ObtenerDatosCargo();
            }
        }

        private void ObtenerCargoEditar()
        {
            idCargo = Convert.ToInt32(dataGridView_Cargos.SelectedCells[(_ColumnasFijasDgvCargos + 0)].Value);
            txt_NuevoCargo.Text = dataGridView_Cargos.SelectedCells[(_ColumnasFijasDgvCargos + 1)].Value.ToString();
            txt_NuevoSueldoPorHora.Text = dataGridView_Cargos.SelectedCells[(_ColumnasFijasDgvCargos + 2)].Value.ToString();

            btn_GuardarCargo.Visible = false;
            btn_GuardarCambiosCargo.Visible = true;
            txt_NuevoCargo.Focus();
            txt_NuevoCargo.SelectAll();
            panel_AgregarCargo.Visible = true;
            panel_AgregarCargo.Dock = DockStyle.Fill;
            panel_AgregarCargo.BringToFront();
        }

        private void ObtenerDatosCargo()
        {
            idCargo = Convert.ToInt32(dataGridView_Cargos.SelectedCells[(_ColumnasFijasDgvCargos + 0)].Value);
            txt_Cargo.Text = dataGridView_Cargos.SelectedCells[(_ColumnasFijasDgvCargos + 1)].Value.ToString();
            txt_SueldoPorHora.Text = dataGridView_Cargos.SelectedCells[(_ColumnasFijasDgvCargos + 2)].Value.ToString();

            dataGridView_Cargos.Visible = false;
            lbl_SueldoPorHora.Visible = true;
            flowLayoutPanel_GuardarPersonal.Visible = true;
        }

        private void btn_Volver_AgregarCargo_Click(object sender, EventArgs e)
        {
            panel_AgregarCargo.Visible = false;
        }

        private void btn_Volver_AgregarRegistro_Click(object sender, EventArgs e)
        {
            panel_AgregarRegistro.Visible = false;
            panel_Paginado.Visible = true;
        }

        private void btn_GuardarCambiosCargo_Click(object sender, EventArgs e)
        {
            EdicionCargo();
        }

        private void EdicionCargo()
        {
            Lcargo parametros = new Lcargo();
            Dcargo funcion = new Dcargo();
            parametros.Id_cargo = idCargo;
            parametros.Cargo = txt_NuevoCargo.Text;
            parametros.SueldoPorHora = Convert.ToDouble(txt_NuevoSueldoPorHora.Text);
            if (funcion.EditarCargo(parametros) == true)
            {
                txt_Cargo.Clear();
                MostrarCargos();
                panel_AgregarCargo.Visible = false;
            }
        }

        private void dataGridView_Personal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_Personal.Columns["Column_Eliminar"].Index)
            {
                DialogResult result = MessageBox.Show("Solo se cambiara el estado para que no pueda acceder, ¿Desea continuar?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    EliminarPersonal();
                }
                
            }
            if (e.ColumnIndex == dataGridView_Personal.Columns["Column_Editar"].Index)
            {
                ObtenerDatos();
            }
        }

        private void ObtenerDatos()
        {
            idPersonal = Convert.ToInt32(dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 0].Value);
            estado = Convert.ToString(dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 6].Value);
            if (estado == "ELIMINADO")
            {
                RestaurarPersonal();
            }
            else
            {
                txt_Nombres.Text = dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 1].Value.ToString();
                txt_Identificacion.Text = dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 2].Value.ToString();
                comboBox_Pais.Text = dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 8].Value.ToString();
                txt_Cargo.Text = dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 4].Value.ToString();
                idCargo = Convert.ToInt32(dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 5].Value);
                txt_SueldoPorHora.Text = dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 3].Value.ToString();

                panel_Paginado.Visible = false;
                panel_AgregarRegistro.Visible = true;
                panel_AgregarRegistro.Dock = DockStyle.Fill;
                dataGridView_Cargos.Visible = false;
                lbl_SueldoPorHora.Visible = true;
                flowLayoutPanel_GuardarPersonal.Visible = true;
                btn_GuardarPersonal.Visible = false;
                btn_GuardarCambiosPersonal.Visible = true;
                panel_AgregarCargo.Visible = false;
            }
        }

        private void RestaurarPersonal()
        {
            DialogResult result = MessageBox.Show("Este personal se encuentra ELIMINADO. ¿Desea volver a habilitarlo?", "Restauracion de registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                HabilitarPersonal();
            }
        }

        private void HabilitarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();

            parametros.Id_personal = idPersonal;
            if (funcion.RestaurarPersonal(parametros) == true)
            {
                MostrarPesronal();
            }
        }

        private void EliminarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();

            idPersonal = Convert.ToInt32(dataGridView_Personal.SelectedCells[_ColumnasFijasDgvPersonal + 0].Value);
            parametros.Id_personal = idPersonal;
            
            if (funcion.EliminarPersonal(parametros) == true)
            {
                MostrarPesronal();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DisenarDgvPersonal();
            timer1.Stop();
        }

        private void btn_GuardarCambiosPersonal_Click(object sender, EventArgs e)
        {
            EditarPersonal();
        }

        private void EditarPersonal()
        {
            Lpersonal parametros = new Lpersonal();
            Dpersonal funcion = new Dpersonal();

            parametros.Id_personal = idPersonal;
            parametros.Nombres = txt_Nombres.Text;
            parametros.Identificacion = txt_Identificacion.Text;
            parametros.Pais = comboBox_Pais.Text;
            parametros.Id_cargo = idCargo;
            parametros.SueldoPorHora = Convert.ToDouble(txt_SueldoPorHora.Text);

            if (funcion.EditarPersonal(parametros) == true)
            {
                MostrarPesronal();
                panel_AgregarRegistro.Visible = false;
            }
        }

        private void btn_PaginaSiguiente_Click(object sender, EventArgs e)
        {
            desde += 10;
            hasta += 10;

            MostrarPesronal();
            ContarFilas();

            if (contadorPersonal > hasta)
            {
                btn_PaginaSiguiente.Visible = true;
                btn_PaginaAnterior.Visible = true;
            }
            else
            {
                btn_PaginaSiguiente.Visible = false;
                btn_PaginaAnterior.Visible = true;
            }

            Paginar();
        }

        private void ContarFilas()
        {
            Dpersonal funcion = new Dpersonal();
            funcion.ContarPersonal(ref contadorPersonal);
        }

        private void Paginar()
        {
            try
            {
                lbl_PaginaActual.Text = (hasta / itemsPorPagina).ToString();
                lbl_TotalPaginas.Text = Math.Ceiling(Convert.ToSingle(contadorPersonal) / itemsPorPagina).ToString();
                totalPaginas = Convert.ToInt32(lbl_TotalPaginas.Text);
            }
            catch (Exception)
            {

            }
        }

        private void ReiniciarPaginado()
        {
            desde = 1;
            hasta = 10;

            ContarFilas();

            if (contadorPersonal > hasta)
            {
                btn_PaginaSiguiente.Visible = true;
                btn_PaginaAnterior.Visible = false;
                btn_UltimaPagina.Visible = true;
                btn_PrimeraPagina.Visible = true;
            }
            else
            {
                btn_PaginaSiguiente.Visible = false;
                btn_PaginaAnterior.Visible = false;
                btn_UltimaPagina.Visible = false;
                btn_PrimeraPagina.Visible = false;
            }

            Paginar();
        }

        private void btn_PaginaAnterior_Click(object sender, EventArgs e)
        {
            desde -= 10;
            hasta -= 10;

            MostrarPesronal();
            ContarFilas();

            if (contadorPersonal > hasta)
            {
                btn_PaginaSiguiente.Visible = true;
                btn_PaginaAnterior.Visible = true;
            }
            else
            {
                btn_PaginaSiguiente.Visible = false;
                btn_PaginaAnterior.Visible = true;
            }

            if (desde == 1)
            {
                ReiniciarPaginado();
            }

            Paginar();
        }

        private void btn_UltimaPagina_Click(object sender, EventArgs e)
        {
            hasta = totalPaginas * itemsPorPagina;
            desde = hasta - 9;

            MostrarPesronal();
            ContarFilas();

            if (contadorPersonal > hasta)
            {
                btn_PaginaSiguiente.Visible = true;
                btn_PaginaAnterior.Visible = true;
            }
            else
            {
                btn_PaginaSiguiente.Visible = false;
                btn_PaginaAnterior.Visible = true;
            }

            Paginar();
        }

        private void btn_PrimeraPagina_Click(object sender, EventArgs e)
        {
            ReiniciarPaginado();
            MostrarPesronal();
        }

        private void txt_Buscador_TextChanged(object sender, EventArgs e)
        {
            BuscarPersonal();
        }

        private void BuscarPersonal()
        {
            Dpersonal funcion = new Dpersonal();
            DataTable dt = new DataTable();

            funcion.BuscarPersonal(ref dt, desde, hasta, txt_Buscador.Text);
            dataGridView_Personal.DataSource = dt;
            DisenarDgvPersonal();
        }

        private void btn_MostrarTodos_Click(object sender, EventArgs e)
        {
            ReiniciarPaginado();
            MostrarPesronal();
            txt_Buscador.Clear();
        }
    }
}
