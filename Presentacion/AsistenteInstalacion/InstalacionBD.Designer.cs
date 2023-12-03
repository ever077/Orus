namespace Orus.Presentacion.AsistenteInstalacion
{
    partial class InstalacionBD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstalacionBD));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Programador = new System.Windows.Forms.Panel();
            this.txtServidor = new System.Windows.Forms.Label();
            this.textBox_ArgumentosIni = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_CrearUsuarioDB = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_CrearProcedimientos = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_EliminarBaseDeDatos = new System.Windows.Forms.RichTextBox();
            this.textBox_NombreScript = new System.Windows.Forms.TextBox();
            this.textBox_BaseDeDatos = new System.Windows.Forms.TextBox();
            this.textBox_Pass = new System.Windows.Forms.TextBox();
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.textBox_NombreInstancia = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer_CrearArchivoConfigIni = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer_EliminarScriptCreacionBd = new System.Windows.Forms.Timer(this.components);
            this.panel_Instalacion = new System.Windows.Forms.Panel();
            this.panel_Instalando = new System.Windows.Forms.Panel();
            this.panel_Cargando = new System.Windows.Forms.Panel();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel_Temporizador = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label_min = new System.Windows.Forms.Label();
            this.label_seg = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label_InfoInstalacion = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.btn_InstalarServidor = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_Programador.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_Instalacion.SuspendLayout();
            this.panel_Instalando.SuspendLayout();
            this.panel_Cargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel_Temporizador.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 125);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Orus.Properties.Resources._4E___Fondo_Negro___Final;
            this.pictureBox1.Location = new System.Drawing.Point(153, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(91, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Orus";
            // 
            // panel_Programador
            // 
            this.panel_Programador.Controls.Add(this.txtServidor);
            this.panel_Programador.Controls.Add(this.textBox_ArgumentosIni);
            this.panel_Programador.Controls.Add(this.groupBox3);
            this.panel_Programador.Controls.Add(this.groupBox2);
            this.panel_Programador.Controls.Add(this.groupBox1);
            this.panel_Programador.Controls.Add(this.textBox_NombreScript);
            this.panel_Programador.Controls.Add(this.textBox_BaseDeDatos);
            this.panel_Programador.Controls.Add(this.textBox_Pass);
            this.panel_Programador.Controls.Add(this.textBox_Usuario);
            this.panel_Programador.Controls.Add(this.textBox_NombreInstancia);
            this.panel_Programador.Controls.Add(this.label12);
            this.panel_Programador.Controls.Add(this.label11);
            this.panel_Programador.Controls.Add(this.label10);
            this.panel_Programador.Controls.Add(this.label9);
            this.panel_Programador.Controls.Add(this.label8);
            this.panel_Programador.Location = new System.Drawing.Point(931, 149);
            this.panel_Programador.Name = "panel_Programador";
            this.panel_Programador.Size = new System.Drawing.Size(968, 882);
            this.panel_Programador.TabIndex = 4;
            this.panel_Programador.Visible = false;
            // 
            // txtServidor
            // 
            this.txtServidor.AutoSize = true;
            this.txtServidor.ForeColor = System.Drawing.Color.White;
            this.txtServidor.Location = new System.Drawing.Point(410, 213);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(30, 16);
            this.txtServidor.TabIndex = 14;
            this.txtServidor.Text = ".text";
            // 
            // textBox_ArgumentosIni
            // 
            this.textBox_ArgumentosIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_ArgumentosIni.Location = new System.Drawing.Point(54, 568);
            this.textBox_ArgumentosIni.Name = "textBox_ArgumentosIni";
            this.textBox_ArgumentosIni.Size = new System.Drawing.Size(523, 288);
            this.textBox_ArgumentosIni.TabIndex = 13;
            this.textBox_ArgumentosIni.Text = resources.GetString("textBox_ArgumentosIni.Text");
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_CrearUsuarioDB);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(603, 284);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(340, 453);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Servira para crear un Usuario para el Servidor - NO TOCAR";
            // 
            // textBox_CrearUsuarioDB
            // 
            this.textBox_CrearUsuarioDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CrearUsuarioDB.Location = new System.Drawing.Point(6, 38);
            this.textBox_CrearUsuarioDB.Name = "textBox_CrearUsuarioDB";
            this.textBox_CrearUsuarioDB.Size = new System.Drawing.Size(328, 395);
            this.textBox_CrearUsuarioDB.TabIndex = 0;
            this.textBox_CrearUsuarioDB.Text = resources.GetString("textBox_CrearUsuarioDB.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_CrearProcedimientos);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(47, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(537, 264);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pega tu Script para crear las tablas y los procedimientos";
            // 
            // textBox_CrearProcedimientos
            // 
            this.textBox_CrearProcedimientos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_CrearProcedimientos.Location = new System.Drawing.Point(7, 37);
            this.textBox_CrearProcedimientos.Name = "textBox_CrearProcedimientos";
            this.textBox_CrearProcedimientos.Size = new System.Drawing.Size(523, 221);
            this.textBox_CrearProcedimientos.TabIndex = 0;
            this.textBox_CrearProcedimientos.Text = resources.GetString("textBox_CrearProcedimientos.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_EliminarBaseDeDatos);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(468, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 213);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Script para Eliminar la Base de Datos";
            // 
            // textBox_EliminarBaseDeDatos
            // 
            this.textBox_EliminarBaseDeDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_EliminarBaseDeDatos.Location = new System.Drawing.Point(6, 21);
            this.textBox_EliminarBaseDeDatos.Name = "textBox_EliminarBaseDeDatos";
            this.textBox_EliminarBaseDeDatos.Size = new System.Drawing.Size(463, 186);
            this.textBox_EliminarBaseDeDatos.TabIndex = 0;
            this.textBox_EliminarBaseDeDatos.Text = "alter database BASEADACURSO set single_user with rollback immediate\nDROP DATABASE" +
    " BASEADACURSO";
            // 
            // textBox_NombreScript
            // 
            this.textBox_NombreScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NombreScript.Location = new System.Drawing.Point(237, 209);
            this.textBox_NombreScript.Name = "textBox_NombreScript";
            this.textBox_NombreScript.Size = new System.Drawing.Size(162, 26);
            this.textBox_NombreScript.TabIndex = 9;
            this.textBox_NombreScript.Text = "ScriptORUS";
            // 
            // textBox_BaseDeDatos
            // 
            this.textBox_BaseDeDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_BaseDeDatos.Location = new System.Drawing.Point(237, 167);
            this.textBox_BaseDeDatos.Name = "textBox_BaseDeDatos";
            this.textBox_BaseDeDatos.Size = new System.Drawing.Size(162, 26);
            this.textBox_BaseDeDatos.TabIndex = 8;
            this.textBox_BaseDeDatos.Text = "ORUS";
            // 
            // textBox_Pass
            // 
            this.textBox_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Pass.Location = new System.Drawing.Point(237, 125);
            this.textBox_Pass.Name = "textBox_Pass";
            this.textBox_Pass.Size = new System.Drawing.Size(162, 26);
            this.textBox_Pass.TabIndex = 7;
            this.textBox_Pass.Text = "orus";
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Usuario.Location = new System.Drawing.Point(237, 83);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.Size = new System.Drawing.Size(162, 26);
            this.textBox_Usuario.TabIndex = 6;
            this.textBox_Usuario.Text = "orus";
            // 
            // textBox_NombreInstancia
            // 
            this.textBox_NombreInstancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_NombreInstancia.Location = new System.Drawing.Point(237, 41);
            this.textBox_NombreInstancia.Name = "textBox_NombreInstancia";
            this.textBox_NombreInstancia.Size = new System.Drawing.Size(162, 26);
            this.textBox_NombreInstancia.TabIndex = 5;
            this.textBox_NombreInstancia.Text = "SQLEXPRESS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(50, 215);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Nombre de Script:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(50, 173);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Base de datos:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(50, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(139, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Contraseña SQL:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(50, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Usuario:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(50, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre de instancia:";
            // 
            // timer_CrearArchivoConfigIni
            // 
            this.timer_CrearArchivoConfigIni.Interval = 10;
            this.timer_CrearArchivoConfigIni.Tick += new System.EventHandler(this.timer_CrearArchivoConfigIni_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer_EliminarScriptCreacionBd
            // 
            this.timer_EliminarScriptCreacionBd.Interval = 1000;
            this.timer_EliminarScriptCreacionBd.Tick += new System.EventHandler(this.timer_EliminarScriptCreacionBd_Tick);
            // 
            // panel_Instalacion
            // 
            this.panel_Instalacion.BackColor = System.Drawing.Color.Black;
            this.panel_Instalacion.Controls.Add(this.panel_Instalando);
            this.panel_Instalacion.Controls.Add(this.btn_InstalarServidor);
            this.panel_Instalacion.Location = new System.Drawing.Point(246, 149);
            this.panel_Instalacion.Name = "panel_Instalacion";
            this.panel_Instalacion.Size = new System.Drawing.Size(594, 666);
            this.panel_Instalacion.TabIndex = 5;
            // 
            // panel_Instalando
            // 
            this.panel_Instalando.Controls.Add(this.panel_Cargando);
            this.panel_Instalando.Controls.Add(this.panel_Temporizador);
            this.panel_Instalando.Controls.Add(this.label_InfoInstalacion);
            this.panel_Instalando.Controls.Add(this.pictureBox4);
            this.panel_Instalando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Instalando.Location = new System.Drawing.Point(0, 78);
            this.panel_Instalando.Name = "panel_Instalando";
            this.panel_Instalando.Size = new System.Drawing.Size(594, 588);
            this.panel_Instalando.TabIndex = 2;
            // 
            // panel_Cargando
            // 
            this.panel_Cargando.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel_Cargando.Controls.Add(this.pictureBox5);
            this.panel_Cargando.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Cargando.Location = new System.Drawing.Point(0, 399);
            this.panel_Cargando.Name = "panel_Cargando";
            this.panel_Cargando.Size = new System.Drawing.Size(594, 189);
            this.panel_Cargando.TabIndex = 5;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox5.Image = global::Orus.Properties.Resources.loading_12;
            this.pictureBox5.Location = new System.Drawing.Point(225, 44);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(145, 145);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // panel_Temporizador
            // 
            this.panel_Temporizador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel_Temporizador.Controls.Add(this.panel7);
            this.panel_Temporizador.Controls.Add(this.label18);
            this.panel_Temporizador.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Temporizador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Temporizador.Location = new System.Drawing.Point(0, 296);
            this.panel_Temporizador.Name = "panel_Temporizador";
            this.panel_Temporizador.Size = new System.Drawing.Size(594, 103);
            this.panel_Temporizador.TabIndex = 4;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label_min);
            this.panel7.Controls.Add(this.label_seg);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(297, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(297, 103);
            this.panel7.TabIndex = 1;
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_min.ForeColor = System.Drawing.Color.White;
            this.label_min.Location = new System.Drawing.Point(88, 57);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(34, 25);
            this.label_min.TabIndex = 4;
            this.label_min.Text = "00";
            // 
            // label_seg
            // 
            this.label_seg.AutoSize = true;
            this.label_seg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_seg.ForeColor = System.Drawing.Color.White;
            this.label_seg.Location = new System.Drawing.Point(164, 57);
            this.label_seg.Name = "label_seg";
            this.label_seg.Size = new System.Drawing.Size(34, 25);
            this.label_seg.TabIndex = 2;
            this.label_seg.Text = "00";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(163, 26);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 20);
            this.label16.TabIndex = 1;
            this.label16.Text = "seg";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(87, 26);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "min";
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Left;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(297, 103);
            this.label18.TabIndex = 0;
            this.label18.Text = "Tiempo estimado: 6 minutos";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_InfoInstalacion
            // 
            this.label_InfoInstalacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label_InfoInstalacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_InfoInstalacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InfoInstalacion.ForeColor = System.Drawing.Color.White;
            this.label_InfoInstalacion.Location = new System.Drawing.Point(0, 115);
            this.label_InfoInstalacion.Name = "label_InfoInstalacion";
            this.label_InfoInstalacion.Size = new System.Drawing.Size(594, 181);
            this.label_InfoInstalacion.TabIndex = 3;
            this.label_InfoInstalacion.Text = "Instalando Servidor...\r\n\r\nNo cierre ésta ventana, se cerrará automáticamente cuan" +
    "do este todo listo";
            this.label_InfoInstalacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox4.Image = global::Orus.Properties.Resources.advertencia;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(594, 115);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 2;
            this.pictureBox4.TabStop = false;
            // 
            // btn_InstalarServidor
            // 
            this.btn_InstalarServidor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btn_InstalarServidor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_InstalarServidor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_InstalarServidor.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InstalarServidor.ForeColor = System.Drawing.Color.White;
            this.btn_InstalarServidor.Location = new System.Drawing.Point(0, 0);
            this.btn_InstalarServidor.Name = "btn_InstalarServidor";
            this.btn_InstalarServidor.Size = new System.Drawing.Size(594, 78);
            this.btn_InstalarServidor.TabIndex = 1;
            this.btn_InstalarServidor.Text = "Instalar Servidor";
            this.btn_InstalarServidor.UseVisualStyleBackColor = false;
            this.btn_InstalarServidor.Visible = false;
            this.btn_InstalarServidor.Click += new System.EventHandler(this.btn_InstalarServidor_Click);
            // 
            // InstalacionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.panel_Instalacion);
            this.Controls.Add(this.panel_Programador);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InstalacionBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstalacionBD_FormClosing);
            this.Load += new System.EventHandler(this.InstalacionBD_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_Programador.ResumeLayout(false);
            this.panel_Programador.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel_Instalacion.ResumeLayout(false);
            this.panel_Instalando.ResumeLayout(false);
            this.panel_Cargando.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel_Temporizador.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Programador;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_NombreScript;
        private System.Windows.Forms.TextBox textBox_BaseDeDatos;
        private System.Windows.Forms.TextBox textBox_Pass;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.TextBox textBox_NombreInstancia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox textBox_CrearUsuarioDB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox textBox_CrearProcedimientos;
        private System.Windows.Forms.RichTextBox textBox_EliminarBaseDeDatos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RichTextBox textBox_ArgumentosIni;
        private System.Windows.Forms.Timer timer_CrearArchivoConfigIni;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer_EliminarScriptCreacionBd;
        private System.Windows.Forms.Label txtServidor;
        private System.Windows.Forms.Panel panel_Instalacion;
        private System.Windows.Forms.Panel panel_Instalando;
        private System.Windows.Forms.Panel panel_Cargando;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel_Temporizador;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label_seg;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label_InfoInstalacion;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btn_InstalarServidor;
        private System.Windows.Forms.Label label_min;
    }
}