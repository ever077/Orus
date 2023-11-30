using Orus.Datos;
using Orus.Logica;
using Orus.Presentacion.Reportes;
using Orus.Presentacion.Reportes.DataSetReporteTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Orus.Presentacion
{
    public partial class PrePlanilla : UserControl
    {
        private int idPersonalSeleccionado;
        private bool hayPersonalEspecificado;

        public PrePlanilla()
        {
            InitializeComponent();
            idPersonalSeleccionado = 0;
            hayPersonalEspecificado = false;
        }

        private void PrePlanilla_Load(object sender, EventArgs e)
        {
            configurarDgvPersonalDisponible();
            calcularNumeroSemana();
            generarReporte();
            txt_Buscador.Text = "Buscar personal..";
            txt_Buscador.ForeColor = Color.LightGray;
            txt_Buscador.Focus();
        }

        private void configurarDgvPersonalDisponible()
        {
            Configuraciones.DisenoDgv(ref dataGridView_PersonalDisponible);
            panel_DataGridView.Location = new Point(panel_BaseBuscador.Location.X, panel_BaseBuscador.Location.Y);
            panel_DataGridView.Size = new Size(373, 87);
            panel_DataGridView.Visible = false;
        }

        private void calcularNumeroSemana()
        {
            DateTime fechaHasta = dateTimePickerHasta.Value;
            lbl_NumeroSemana.Text = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fechaHasta, CalendarWeekRule.FirstDay, fechaHasta.DayOfWeek).ToString();
        }

        private void generarReporte()
        {
            DateTime desde = dateTimePickerDesde.Value;
            DateTime hasta = dateTimePickerHasta.Value;
            int semana = Convert.ToInt32(lbl_NumeroSemana.Text);

            this.mostrar_asistencias_diariasTableAdapter.Fill(this.dataSetReporte.mostrar_asistencias_diarias, desde, hasta, semana);
            this.reportViewer_Todos.RefreshReport();

            this.reportViewer_Todos.Visible = true;
            this.reportViewer_Todos.Dock = DockStyle.Fill;
            this.reportViewer_Todos.BringToFront();
            this.reportViewer_PersonalId.Visible = false;
            this.reportViewer_PersonalId.Dock = DockStyle.None;
            this.reportViewer_PersonalId.SendToBack();
        }

        private void generarReporteId()
        {
            DateTime desde = dateTimePickerDesde.Value;
            DateTime hasta = dateTimePickerHasta.Value;
            int semana = Convert.ToInt32(lbl_NumeroSemana.Text);

            this.mostrar_asistencias_diarias_idTableAdapter.Fill(this.dataSetReporte.mostrar_asistencias_diarias_id, desde, hasta, semana, idPersonalSeleccionado);
            this.reportViewer_PersonalId.RefreshReport();

            this.reportViewer_PersonalId.Visible = true;
            this.reportViewer_PersonalId.Dock = DockStyle.Fill;
            this.reportViewer_PersonalId.BringToFront();
            this.reportViewer_Todos.Visible = false;
            this.reportViewer_Todos.Dock = DockStyle.None;
            this.reportViewer_Todos.SendToBack();
        }

        private void txt_Buscador_TextChanged(object sender, EventArgs e)
        {
            if (txt_Buscador.Text.Length == 18 && txt_Buscador.Text.Contains("Buscar personal.."))
            {
                txt_Buscador.Text = txt_Buscador.Text[0].ToString();
                txt_Buscador.Select(txt_Buscador.Text.Length, 0);
            }

            Dpersonal funcion = new Dpersonal();
            DataTable dt = new DataTable();

            funcion.BuscarPersonalNombre(ref dt, txt_Buscador.Text);

            dataGridView_PersonalDisponible.DataSource = dt;
            // Oculto el Id_usuario
            dataGridView_PersonalDisponible.Columns[0].Visible = false;
            
            if (dataGridView_PersonalDisponible.Rows.Count != 0)
            {
                panel_DataGridView.Visible = true;
            }
            if (txt_Buscador.Text == "")
            {
                panel_DataGridView.Visible = false;
                hayPersonalEspecificado = false;
            }
        }

        private void dataGridView_PersonalDisponible_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView_PersonalDisponible.Columns["Nombres"].Index)
            {
                idPersonalSeleccionado = Convert.ToInt32(dataGridView_PersonalDisponible.SelectedCells[0].Value);
                txt_Buscador.Text = dataGridView_PersonalDisponible.SelectedCells[1].Value.ToString();
                panel_DataGridView.Visible = false;
                hayPersonalEspecificado = true;
            }
        }

        private void btn_BuscarPersonal_Click(object sender, EventArgs e)
        {
            if (hayPersonalEspecificado == true)
            {
                generarReporteId();
            }
            else
            {
                generarReporte();
            }
        }

        private void dateTimePickerHasta_CloseUp(object sender, EventArgs e)
        {
            calcularNumeroSemana();
        }

        private void txt_Buscador_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "Buscar personal..")
            {
                txt_Buscador.Text = "";
                txt_Buscador.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txt_Buscador_MouseLeave(object sender, EventArgs e)
        {
            if (txt_Buscador.Text == "")
            {
                txt_Buscador.Text = "Buscar personal..";
                txt_Buscador.ForeColor = Color.LightGray;
                //txt_Buscador.Focus();
            }
        }
    }
}
