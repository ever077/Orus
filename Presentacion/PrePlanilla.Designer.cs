namespace Orus.Presentacion
{
    partial class PrePlanilla
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Buscador = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Hasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Desde = new System.Windows.Forms.DateTimePicker();
            this.lbl_NumeroSemana = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetReporte = new Orus.Presentacion.Reportes.DataSetReporte();
            this.mostrarasistenciasdiariasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mostrar_asistencias_diariasTableAdapter = new Orus.Presentacion.Reportes.DataSetReporteTableAdapters.mostrar_asistencias_diariasTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txt_Buscador);
            this.panel1.Controls.Add(this.dateTimePicker_Hasta);
            this.panel1.Controls.Add(this.dateTimePicker_Desde);
            this.panel1.Controls.Add(this.lbl_NumeroSemana);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 141);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.panel3.Location = new System.Drawing.Point(69, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 3);
            this.panel3.TabIndex = 7;
            // 
            // txt_Buscador
            // 
            this.txt_Buscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txt_Buscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Buscador.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txt_Buscador.Location = new System.Drawing.Point(70, 87);
            this.txt_Buscador.Name = "txt_Buscador";
            this.txt_Buscador.Size = new System.Drawing.Size(373, 27);
            this.txt_Buscador.TabIndex = 6;
            this.txt_Buscador.Text = "Buscar...";
            // 
            // dateTimePicker_Hasta
            // 
            this.dateTimePicker_Hasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Hasta.Location = new System.Drawing.Point(406, 33);
            this.dateTimePicker_Hasta.Name = "dateTimePicker_Hasta";
            this.dateTimePicker_Hasta.Size = new System.Drawing.Size(200, 32);
            this.dateTimePicker_Hasta.TabIndex = 5;
            this.dateTimePicker_Hasta.ValueChanged += new System.EventHandler(this.dateTimePicker_Hasta_ValueChanged);
            // 
            // dateTimePicker_Desde
            // 
            this.dateTimePicker_Desde.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_Desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Desde.Location = new System.Drawing.Point(128, 33);
            this.dateTimePicker_Desde.Name = "dateTimePicker_Desde";
            this.dateTimePicker_Desde.Size = new System.Drawing.Size(200, 32);
            this.dateTimePicker_Desde.TabIndex = 4;
            this.dateTimePicker_Desde.ValueChanged += new System.EventHandler(this.dateTimePicker_Desde_ValueChanged);
            // 
            // lbl_NumeroSemana
            // 
            this.lbl_NumeroSemana.AutoSize = true;
            this.lbl_NumeroSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumeroSemana.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_NumeroSemana.Location = new System.Drawing.Point(812, 36);
            this.lbl_NumeroSemana.Name = "lbl_NumeroSemana";
            this.lbl_NumeroSemana.Size = new System.Drawing.Size(26, 29);
            this.lbl_NumeroSemana.TabIndex = 3;
            this.lbl_NumeroSemana.Text = "#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(657, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 29);
            this.label3.TabIndex = 2;
            this.label3.Text = "Semana Nº:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(361, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "al";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(65, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Del";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_Asistencias";
            reportDataSource1.Value = this.mostrarasistenciasdiariasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Orus.Presentacion.Reportes.ReporteAsistencias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 141);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1152, 509);
            this.reportViewer1.TabIndex = 1;
            // 
            // dataSetReporte
            // 
            this.dataSetReporte.DataSetName = "DataSetReporte";
            this.dataSetReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mostrarasistenciasdiariasBindingSource
            // 
            this.mostrarasistenciasdiariasBindingSource.DataMember = "mostrar_asistencias_diarias";
            this.mostrarasistenciasdiariasBindingSource.DataSource = this.dataSetReporte;
            // 
            // mostrar_asistencias_diariasTableAdapter
            // 
            this.mostrar_asistencias_diariasTableAdapter.ClearBeforeFill = true;
            // 
            // PrePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "PrePlanilla";
            this.Size = new System.Drawing.Size(1152, 650);
            this.Load += new System.EventHandler(this.PrePlanilla_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Hasta;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Desde;
        private System.Windows.Forms.Label lbl_NumeroSemana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_Buscador;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource mostrarasistenciasdiariasBindingSource;
        private Reportes.DataSetReporte dataSetReporte;
        private Reportes.DataSetReporteTableAdapters.mostrar_asistencias_diariasTableAdapter mostrar_asistencias_diariasTableAdapter;
    }
}
