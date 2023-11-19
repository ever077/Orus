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
        public PrePlanilla()
        {
            InitializeComponent();
        }

        private void PrePlanilla_Load(object sender, EventArgs e)
        {
            calcularNumeroSemana();
            generarReporte();
        }

        private void dateTimePicker_Desde_ValueChanged(object sender, EventArgs e)
        {
            calcularNumeroSemana();
            generarReporte();
        }

        private void dateTimePicker_Hasta_ValueChanged(object sender, EventArgs e)
        {
            calcularNumeroSemana();
            generarReporte();
        }

        private void calcularNumeroSemana()
        {
            DateTime fechaHasta = dateTimePicker_Hasta.Value;
            lbl_NumeroSemana.Text = CultureInfo.CurrentUICulture.Calendar.GetWeekOfYear(fechaHasta, CalendarWeekRule.FirstDay, fechaHasta.DayOfWeek).ToString();
        }

        private void generarReporte()
        {
            DateTime desde = dateTimePicker_Desde.Value;
            DateTime hasta = dateTimePicker_Hasta.Value;
            int semana = Convert.ToInt32(lbl_NumeroSemana.Text);

            this.mostrar_asistencias_diariasTableAdapter.Fill(this.dataSetReporte.mostrar_asistencias_diarias, desde, hasta, semana);
            this.reportViewer1.RefreshReport();
        }
    }
}
