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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.panel_DataGridView = new System.Windows.Forms.Panel();
            this.dataGridView_PersonalDisponible = new System.Windows.Forms.DataGridView();
            this.btn_BuscarPersonal = new System.Windows.Forms.Button();
            this.panel_BaseBuscador = new System.Windows.Forms.Panel();
            this.txt_Buscador = new System.Windows.Forms.TextBox();
            this.lbl_NumeroSemana = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer_Todos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer_PersonalId = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mostrar_asistencias_diarias_idBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetReporte = new Orus.Presentacion.Reportes.DataSetReporte();
            this.mostrar_asistencias_diariasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mostrarasistenciasdiariasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mostrarasistenciasdiariasidBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mostrar_asistencias_diarias_idTableAdapter = new Orus.Presentacion.Reportes.DataSetReporteTableAdapters.mostrar_asistencias_diarias_idTableAdapter();
            this.mostrarasistenciasdiariasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mostrar_asistencias_diariasTableAdapter = new Orus.Presentacion.Reportes.DataSetReporteTableAdapters.mostrar_asistencias_diariasTableAdapter();
            this.panel1.SuspendLayout();
            this.panel_DataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PersonalDisponible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_asistencias_diarias_idBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_asistencias_diariasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasidBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.dateTimePickerHasta);
            this.panel1.Controls.Add(this.dateTimePickerDesde);
            this.panel1.Controls.Add(this.panel_DataGridView);
            this.panel1.Controls.Add(this.btn_BuscarPersonal);
            this.panel1.Controls.Add(this.panel_BaseBuscador);
            this.panel1.Controls.Add(this.txt_Buscador);
            this.panel1.Controls.Add(this.lbl_NumeroSemana);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1152, 238);
            this.panel1.TabIndex = 0;
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerHasta.Location = new System.Drawing.Point(402, 35);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(213, 30);
            this.dateTimePickerHasta.TabIndex = 10;
            this.dateTimePickerHasta.Value = new System.DateTime(2023, 11, 29, 1, 19, 1, 0);
            this.dateTimePickerHasta.CloseUp += new System.EventHandler(this.dateTimePickerHasta_CloseUp);
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePickerDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDesde.Location = new System.Drawing.Point(121, 36);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(213, 30);
            this.dateTimePickerDesde.TabIndex = 9;
            this.dateTimePickerDesde.Value = new System.DateTime(2023, 11, 29, 1, 17, 22, 0);
            // 
            // panel_DataGridView
            // 
            this.panel_DataGridView.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_DataGridView.Controls.Add(this.dataGridView_PersonalDisponible);
            this.panel_DataGridView.Location = new System.Drawing.Point(701, 118);
            this.panel_DataGridView.Name = "panel_DataGridView";
            this.panel_DataGridView.Size = new System.Drawing.Size(373, 136);
            this.panel_DataGridView.TabIndex = 2;
            this.panel_DataGridView.Visible = false;
            // 
            // dataGridView_PersonalDisponible
            // 
            this.dataGridView_PersonalDisponible.AllowUserToAddRows = false;
            this.dataGridView_PersonalDisponible.AllowUserToDeleteRows = false;
            this.dataGridView_PersonalDisponible.AllowUserToResizeRows = false;
            this.dataGridView_PersonalDisponible.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_PersonalDisponible.ColumnHeadersVisible = false;
            this.dataGridView_PersonalDisponible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_PersonalDisponible.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_PersonalDisponible.Name = "dataGridView_PersonalDisponible";
            this.dataGridView_PersonalDisponible.ReadOnly = true;
            this.dataGridView_PersonalDisponible.RowHeadersWidth = 51;
            this.dataGridView_PersonalDisponible.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dataGridView_PersonalDisponible.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_PersonalDisponible.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dataGridView_PersonalDisponible.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView_PersonalDisponible.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView_PersonalDisponible.RowTemplate.Height = 30;
            this.dataGridView_PersonalDisponible.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_PersonalDisponible.Size = new System.Drawing.Size(373, 136);
            this.dataGridView_PersonalDisponible.TabIndex = 20;
            this.dataGridView_PersonalDisponible.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_PersonalDisponible_CellClick);
            // 
            // btn_BuscarPersonal
            // 
            this.btn_BuscarPersonal.BackgroundImage = global::Orus.Properties.Resources.Boton_2;
            this.btn_BuscarPersonal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BuscarPersonal.FlatAppearance.BorderSize = 0;
            this.btn_BuscarPersonal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_BuscarPersonal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_BuscarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_BuscarPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_BuscarPersonal.ForeColor = System.Drawing.Color.Black;
            this.btn_BuscarPersonal.Location = new System.Drawing.Point(662, 75);
            this.btn_BuscarPersonal.Name = "btn_BuscarPersonal";
            this.btn_BuscarPersonal.Size = new System.Drawing.Size(166, 55);
            this.btn_BuscarPersonal.TabIndex = 8;
            this.btn_BuscarPersonal.Text = "Buscar";
            this.btn_BuscarPersonal.UseVisualStyleBackColor = true;
            this.btn_BuscarPersonal.Click += new System.EventHandler(this.btn_BuscarPersonal_Click);
            // 
            // panel_BaseBuscador
            // 
            this.panel_BaseBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.panel_BaseBuscador.Location = new System.Drawing.Point(69, 118);
            this.panel_BaseBuscador.Name = "panel_BaseBuscador";
            this.panel_BaseBuscador.Size = new System.Drawing.Size(373, 3);
            this.panel_BaseBuscador.TabIndex = 7;
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
            this.txt_Buscador.TextChanged += new System.EventHandler(this.txt_Buscador_TextChanged);
            this.txt_Buscador.MouseEnter += new System.EventHandler(this.txt_Buscador_MouseEnter);
            this.txt_Buscador.MouseLeave += new System.EventHandler(this.txt_Buscador_MouseLeave);
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
            // reportViewer_Todos
            // 
            reportDataSource5.Name = "DataSetAsistenciaPersonalTodos";
            reportDataSource5.Value = this.mostrarasistenciasdiariasBindingSource1;
            this.reportViewer_Todos.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer_Todos.LocalReport.ReportEmbeddedResource = "Orus.Presentacion.Reportes.ReporteAsistenciaPersonalTodos.rdlc";
            this.reportViewer_Todos.Location = new System.Drawing.Point(23, 264);
            this.reportViewer_Todos.Name = "reportViewer_Todos";
            this.reportViewer_Todos.ServerReport.BearerToken = null;
            this.reportViewer_Todos.Size = new System.Drawing.Size(443, 359);
            this.reportViewer_Todos.TabIndex = 1;
            this.reportViewer_Todos.Visible = false;
            // 
            // reportViewer_PersonalId
            // 
            reportDataSource6.Name = "DataSetAsistenciaPersonal";
            reportDataSource6.Value = this.mostrar_asistencias_diarias_idBindingSource;
            this.reportViewer_PersonalId.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer_PersonalId.LocalReport.ReportEmbeddedResource = "Orus.Presentacion.Reportes.ReporteAsistenciaPersonal.rdlc";
            this.reportViewer_PersonalId.Location = new System.Drawing.Point(592, 264);
            this.reportViewer_PersonalId.Name = "reportViewer_PersonalId";
            this.reportViewer_PersonalId.ServerReport.BearerToken = null;
            this.reportViewer_PersonalId.Size = new System.Drawing.Size(447, 362);
            this.reportViewer_PersonalId.TabIndex = 2;
            this.reportViewer_PersonalId.Visible = false;
            // 
            // mostrar_asistencias_diarias_idBindingSource
            // 
            this.mostrar_asistencias_diarias_idBindingSource.DataMember = "mostrar_asistencias_diarias_id";
            this.mostrar_asistencias_diarias_idBindingSource.DataSource = this.dataSetReporte;
            // 
            // dataSetReporte
            // 
            this.dataSetReporte.DataSetName = "DataSetReporte";
            this.dataSetReporte.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // mostrar_asistencias_diariasBindingSource
            // 
            this.mostrar_asistencias_diariasBindingSource.DataMember = "mostrar_asistencias_diarias";
            this.mostrar_asistencias_diariasBindingSource.DataSource = this.dataSetReporte;
            // 
            // mostrarasistenciasdiariasBindingSource
            // 
            this.mostrarasistenciasdiariasBindingSource.DataMember = "mostrar_asistencias_diarias";
            this.mostrarasistenciasdiariasBindingSource.DataSource = this.dataSetReporte;
            // 
            // mostrarasistenciasdiariasidBindingSource
            // 
            this.mostrarasistenciasdiariasidBindingSource.DataMember = "mostrar_asistencias_diarias_id";
            this.mostrarasistenciasdiariasidBindingSource.DataSource = this.dataSetReporte;
            // 
            // mostrar_asistencias_diarias_idTableAdapter
            // 
            this.mostrar_asistencias_diarias_idTableAdapter.ClearBeforeFill = true;
            // 
            // mostrarasistenciasdiariasBindingSource1
            // 
            this.mostrarasistenciasdiariasBindingSource1.DataMember = "mostrar_asistencias_diarias";
            this.mostrarasistenciasdiariasBindingSource1.DataSource = this.dataSetReporte;
            // 
            // mostrar_asistencias_diariasTableAdapter
            // 
            this.mostrar_asistencias_diariasTableAdapter.ClearBeforeFill = true;
            // 
            // PrePlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer_PersonalId);
            this.Controls.Add(this.reportViewer_Todos);
            this.Controls.Add(this.panel1);
            this.Name = "PrePlanilla";
            this.Size = new System.Drawing.Size(1152, 650);
            this.Load += new System.EventHandler(this.PrePlanilla_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_DataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_PersonalDisponible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_asistencias_diarias_idBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_asistencias_diariasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasidBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mostrarasistenciasdiariasBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_NumeroSemana;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_BaseBuscador;
        private System.Windows.Forms.TextBox txt_Buscador;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_Todos;
        private System.Windows.Forms.Button btn_BuscarPersonal;
        private System.Windows.Forms.DataGridView dataGridView_PersonalDisponible;
        private System.Windows.Forms.Panel panel_DataGridView;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private Reportes.DataSetReporte dataSetReporte;
        private System.Windows.Forms.BindingSource mostrarasistenciasdiariasidBindingSource;
        private Reportes.DataSetReporteTableAdapters.mostrar_asistencias_diarias_idTableAdapter mostrar_asistencias_diarias_idTableAdapter;
        private System.Windows.Forms.BindingSource mostrarasistenciasdiariasBindingSource;
        private System.Windows.Forms.BindingSource mostrar_asistencias_diariasBindingSource;
        private System.Windows.Forms.BindingSource mostrar_asistencias_diarias_idBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer_PersonalId;
        private System.Windows.Forms.BindingSource mostrarasistenciasdiariasBindingSource1;
        private Reportes.DataSetReporteTableAdapters.mostrar_asistencias_diariasTableAdapter mostrar_asistencias_diariasTableAdapter;
    }
}
