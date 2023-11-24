namespace Orus.Presentacion
{
    partial class CopiaBd
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_GenerarCopiaBd = new System.Windows.Forms.Panel();
            this.lbl_BuscarRuta = new System.Windows.Forms.Label();
            this.btn_GenerarCopia = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox_BuscarRuta = new System.Windows.Forms.PictureBox();
            this.textBox_Ruta = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_GenerarCopiaBd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BuscarRuta)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1018, 99);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft PhagsPa", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copia de Seguridad";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_GenerarCopiaBd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1018, 665);
            this.panel2.TabIndex = 1;
            // 
            // panel_GenerarCopiaBd
            // 
            this.panel_GenerarCopiaBd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_GenerarCopiaBd.Controls.Add(this.lbl_BuscarRuta);
            this.panel_GenerarCopiaBd.Controls.Add(this.btn_GenerarCopia);
            this.panel_GenerarCopiaBd.Controls.Add(this.label3);
            this.panel_GenerarCopiaBd.Controls.Add(this.pictureBox_BuscarRuta);
            this.panel_GenerarCopiaBd.Controls.Add(this.textBox_Ruta);
            this.panel_GenerarCopiaBd.Location = new System.Drawing.Point(43, 46);
            this.panel_GenerarCopiaBd.Name = "panel_GenerarCopiaBd";
            this.panel_GenerarCopiaBd.Size = new System.Drawing.Size(915, 578);
            this.panel_GenerarCopiaBd.TabIndex = 5;
            // 
            // lbl_BuscarRuta
            // 
            this.lbl_BuscarRuta.AutoSize = true;
            this.lbl_BuscarRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BuscarRuta.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_BuscarRuta.Location = new System.Drawing.Point(37, 34);
            this.lbl_BuscarRuta.Name = "lbl_BuscarRuta";
            this.lbl_BuscarRuta.Size = new System.Drawing.Size(549, 46);
            this.lbl_BuscarRuta.TabIndex = 0;
            this.lbl_BuscarRuta.Text = "Ruta de la copia de seguridad";
            this.lbl_BuscarRuta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_BuscarRuta.Click += new System.EventHandler(this.lbl_BuscarRuta_Click);
            // 
            // btn_GenerarCopia
            // 
            this.btn_GenerarCopia.BackColor = System.Drawing.Color.Goldenrod;
            this.btn_GenerarCopia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_GenerarCopia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_GenerarCopia.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_GenerarCopia.Location = new System.Drawing.Point(45, 452);
            this.btn_GenerarCopia.Name = "btn_GenerarCopia";
            this.btn_GenerarCopia.Size = new System.Drawing.Size(763, 81);
            this.btn_GenerarCopia.TabIndex = 4;
            this.btn_GenerarCopia.Text = "Generar Copia";
            this.btn_GenerarCopia.UseVisualStyleBackColor = false;
            this.btn_GenerarCopia.Click += new System.EventHandler(this.btn_GenerarCopia_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(40, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(767, 102);
            this.label3.TabIndex = 1;
            this.label3.Text = "Guarda copias de seguridad de la Base de Datos para no perder ningún Dato de tu e" +
    "mpresa.\r\nPodrás recuperar toda la información en el caso de que tu PC tenga algú" +
    "n problema.";
            // 
            // pictureBox_BuscarRuta
            // 
            this.pictureBox_BuscarRuta.Image = global::Orus.Properties.Resources.lupa1;
            this.pictureBox_BuscarRuta.Location = new System.Drawing.Point(817, 140);
            this.pictureBox_BuscarRuta.Name = "pictureBox_BuscarRuta";
            this.pictureBox_BuscarRuta.Size = new System.Drawing.Size(51, 49);
            this.pictureBox_BuscarRuta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_BuscarRuta.TabIndex = 3;
            this.pictureBox_BuscarRuta.TabStop = false;
            this.pictureBox_BuscarRuta.Click += new System.EventHandler(this.pictureBox_BuscarRuta_Click);
            // 
            // textBox_Ruta
            // 
            this.textBox_Ruta.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ruta.Location = new System.Drawing.Point(45, 140);
            this.textBox_Ruta.Name = "textBox_Ruta";
            this.textBox_Ruta.Size = new System.Drawing.Size(763, 49);
            this.textBox_Ruta.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CopiaBd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CopiaBd";
            this.Size = new System.Drawing.Size(1018, 764);
            this.Load += new System.EventHandler(this.CopiaBd_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_GenerarCopiaBd.ResumeLayout(false);
            this.panel_GenerarCopiaBd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_BuscarRuta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_Ruta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_BuscarRuta;
        private System.Windows.Forms.Button btn_GenerarCopia;
        private System.Windows.Forms.PictureBox pictureBox_BuscarRuta;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel_GenerarCopiaBd;
    }
}
