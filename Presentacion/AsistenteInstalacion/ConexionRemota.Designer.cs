namespace Orus.Presentacion.AsistenteInstalacion
{
    partial class ConexionRemota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConexionRemota));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Conexion = new System.Windows.Forms.Panel();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.textBox_Ip = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel_Conexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 38F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1173, 179);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conectandose a la PC principal...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(40, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese la IP:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel_Conexion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 431);
            this.panel1.TabIndex = 2;
            // 
            // panel_Conexion
            // 
            this.panel_Conexion.Controls.Add(this.label2);
            this.panel_Conexion.Controls.Add(this.btn_Conectar);
            this.panel_Conexion.Controls.Add(this.textBox_Ip);
            this.panel_Conexion.Location = new System.Drawing.Point(192, 81);
            this.panel_Conexion.Name = "panel_Conexion";
            this.panel_Conexion.Size = new System.Drawing.Size(775, 217);
            this.panel_Conexion.TabIndex = 6;
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btn_Conectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Conectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Conectar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Conectar.Location = new System.Drawing.Point(227, 113);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(321, 73);
            this.btn_Conectar.TabIndex = 5;
            this.btn_Conectar.Text = "Conectar";
            this.btn_Conectar.UseVisualStyleBackColor = false;
            this.btn_Conectar.Click += new System.EventHandler(this.btn_Conectar_Click);
            // 
            // textBox_Ip
            // 
            this.textBox_Ip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Ip.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_Ip.Location = new System.Drawing.Point(182, 48);
            this.textBox_Ip.Name = "textBox_Ip";
            this.textBox_Ip.Size = new System.Drawing.Size(563, 30);
            this.textBox_Ip.TabIndex = 2;
            // 
            // ConexionRemota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1173, 647);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConexionRemota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConexionRemota_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Conexion.ResumeLayout(false);
            this.panel_Conexion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_Ip;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Panel panel_Conexion;
    }
}