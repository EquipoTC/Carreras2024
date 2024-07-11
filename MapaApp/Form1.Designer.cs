namespace Mapa
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gmapControl = new GMap.NET.WindowsForms.GMapControl();
            this.MapTimer = new System.Windows.Forms.Timer(this.components);
            this.CronometroTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lapListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtPotencia = new System.Windows.Forms.TextBox();
            this.labelPotencia = new System.Windows.Forms.Label();
            this.txtEnergia = new System.Windows.Forms.TextBox();
            this.labelEnergia = new System.Windows.Forms.Label();
            this.txtTension = new System.Windows.Forms.TextBox();
            this.labelTension = new System.Windows.Forms.Label();
            this.txtVelGPSPromedio = new System.Windows.Forms.TextBox();
            this.labelVelGPSProm = new System.Windows.Forms.Label();
            this.txtVelGPS = new System.Windows.Forms.TextBox();
            this.labelVelGPS = new System.Windows.Forms.Label();
            this.txtCorriente = new System.Windows.Forms.TextBox();
            this.txtVelDisp = new System.Windows.Forms.TextBox();
            this.labelCorriente = new System.Windows.Forms.Label();
            this.labelVelDisp = new System.Windows.Forms.Label();
            this.lapBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.cronometroLabel = new System.Windows.Forms.Label();
            this.cronometroTextBox = new System.Windows.Forms.TextBox();
            this.labelZoom = new System.Windows.Forms.Label();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.checkPinPos = new System.Windows.Forms.CheckBox();
            this.comboDisp = new System.Windows.Forms.ComboBox();
            this.labelLatitud = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.labelLongitud = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gmapControl
            // 
            this.gmapControl.Bearing = 0F;
            this.gmapControl.CanDragMap = true;
            this.gmapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapControl.GrayScaleMode = false;
            this.gmapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapControl.LevelsKeepInMemmory = 5;
            this.gmapControl.Location = new System.Drawing.Point(0, 0);
            this.gmapControl.MarkersEnabled = true;
            this.gmapControl.MaxZoom = 2;
            this.gmapControl.MinZoom = 2;
            this.gmapControl.MouseWheelZoomEnabled = true;
            this.gmapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmapControl.Name = "gmapControl";
            this.gmapControl.NegativeMode = false;
            this.gmapControl.PolygonsEnabled = true;
            this.gmapControl.RetryLoadTile = 0;
            this.gmapControl.RoutesEnabled = true;
            this.gmapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmapControl.ShowTileGridLines = false;
            this.gmapControl.Size = new System.Drawing.Size(984, 561);
            this.gmapControl.TabIndex = 0;
            this.gmapControl.Zoom = 0D;
            // 
            // MapTimer
            // 
            this.MapTimer.Enabled = true;
            this.MapTimer.Interval = 2000;
            this.MapTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CronometroTimer
            // 
            this.CronometroTimer.Tick += new System.EventHandler(this.Cronometro_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lapListBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(453, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 561);
            this.panel1.TabIndex = 17;
            // 
            // lapListBox
            // 
            this.lapListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lapListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lapListBox.FormattingEnabled = true;
            this.lapListBox.ItemHeight = 16;
            this.lapListBox.Location = new System.Drawing.Point(0, 327);
            this.lapListBox.Name = "lapListBox";
            this.lapListBox.Size = new System.Drawing.Size(531, 234);
            this.lapListBox.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtPotencia);
            this.panel2.Controls.Add(this.labelPotencia);
            this.panel2.Controls.Add(this.txtEnergia);
            this.panel2.Controls.Add(this.labelEnergia);
            this.panel2.Controls.Add(this.txtTension);
            this.panel2.Controls.Add(this.labelTension);
            this.panel2.Controls.Add(this.txtVelGPSPromedio);
            this.panel2.Controls.Add(this.labelVelGPSProm);
            this.panel2.Controls.Add(this.txtVelGPS);
            this.panel2.Controls.Add(this.labelVelGPS);
            this.panel2.Controls.Add(this.txtCorriente);
            this.panel2.Controls.Add(this.txtVelDisp);
            this.panel2.Controls.Add(this.labelCorriente);
            this.panel2.Controls.Add(this.labelVelDisp);
            this.panel2.Controls.Add(this.lapBtn);
            this.panel2.Controls.Add(this.playBtn);
            this.panel2.Controls.Add(this.cronometroLabel);
            this.panel2.Controls.Add(this.cronometroTextBox);
            this.panel2.Controls.Add(this.labelZoom);
            this.panel2.Controls.Add(this.trackZoom);
            this.panel2.Controls.Add(this.checkPinPos);
            this.panel2.Controls.Add(this.comboDisp);
            this.panel2.Controls.Add(this.labelLatitud);
            this.panel2.Controls.Add(this.txtLatitud);
            this.panel2.Controls.Add(this.labelLongitud);
            this.panel2.Controls.Add(this.txtLongitud);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 327);
            this.panel2.TabIndex = 31;
            // 
            // txtPotencia
            // 
            this.txtPotencia.Location = new System.Drawing.Point(333, 175);
            this.txtPotencia.Name = "txtPotencia";
            this.txtPotencia.ReadOnly = true;
            this.txtPotencia.Size = new System.Drawing.Size(100, 20);
            this.txtPotencia.TabIndex = 56;
            // 
            // labelPotencia
            // 
            this.labelPotencia.AutoSize = true;
            this.labelPotencia.Location = new System.Drawing.Point(333, 159);
            this.labelPotencia.Name = "labelPotencia";
            this.labelPotencia.Size = new System.Drawing.Size(49, 13);
            this.labelPotencia.TabIndex = 55;
            this.labelPotencia.Text = "Potencia";
            // 
            // txtEnergia
            // 
            this.txtEnergia.Location = new System.Drawing.Point(227, 175);
            this.txtEnergia.Name = "txtEnergia";
            this.txtEnergia.ReadOnly = true;
            this.txtEnergia.Size = new System.Drawing.Size(100, 20);
            this.txtEnergia.TabIndex = 54;
            // 
            // labelEnergia
            // 
            this.labelEnergia.AutoSize = true;
            this.labelEnergia.Location = new System.Drawing.Point(224, 159);
            this.labelEnergia.Name = "labelEnergia";
            this.labelEnergia.Size = new System.Drawing.Size(45, 13);
            this.labelEnergia.TabIndex = 53;
            this.labelEnergia.Text = "Energía";
            // 
            // txtTension
            // 
            this.txtTension.Location = new System.Drawing.Point(121, 175);
            this.txtTension.Name = "txtTension";
            this.txtTension.ReadOnly = true;
            this.txtTension.Size = new System.Drawing.Size(100, 20);
            this.txtTension.TabIndex = 52;
            // 
            // labelTension
            // 
            this.labelTension.AutoSize = true;
            this.labelTension.Location = new System.Drawing.Point(118, 159);
            this.labelTension.Name = "labelTension";
            this.labelTension.Size = new System.Drawing.Size(45, 13);
            this.labelTension.TabIndex = 51;
            this.labelTension.Text = "Tensión";
            // 
            // txtVelGPSPromedio
            // 
            this.txtVelGPSPromedio.Location = new System.Drawing.Point(121, 128);
            this.txtVelGPSPromedio.Name = "txtVelGPSPromedio";
            this.txtVelGPSPromedio.ReadOnly = true;
            this.txtVelGPSPromedio.Size = new System.Drawing.Size(100, 20);
            this.txtVelGPSPromedio.TabIndex = 50;
            // 
            // labelVelGPSProm
            // 
            this.labelVelGPSProm.AutoSize = true;
            this.labelVelGPSProm.Location = new System.Drawing.Point(119, 99);
            this.labelVelGPSProm.Name = "labelVelGPSProm";
            this.labelVelGPSProm.Size = new System.Drawing.Size(79, 26);
            this.labelVelGPSProm.TabIndex = 49;
            this.labelVelGPSProm.Text = "Velocidad GPS\r\n(Promedio)";
            // 
            // txtVelGPS
            // 
            this.txtVelGPS.Location = new System.Drawing.Point(15, 128);
            this.txtVelGPS.Name = "txtVelGPS";
            this.txtVelGPS.ReadOnly = true;
            this.txtVelGPS.Size = new System.Drawing.Size(100, 20);
            this.txtVelGPS.TabIndex = 48;
            // 
            // labelVelGPS
            // 
            this.labelVelGPS.AutoSize = true;
            this.labelVelGPS.Location = new System.Drawing.Point(14, 112);
            this.labelVelGPS.Name = "labelVelGPS";
            this.labelVelGPS.Size = new System.Drawing.Size(79, 13);
            this.labelVelGPS.TabIndex = 47;
            this.labelVelGPS.Text = "Velocidad GPS";
            // 
            // txtCorriente
            // 
            this.txtCorriente.Location = new System.Drawing.Point(15, 175);
            this.txtCorriente.Name = "txtCorriente";
            this.txtCorriente.ReadOnly = true;
            this.txtCorriente.Size = new System.Drawing.Size(100, 20);
            this.txtCorriente.TabIndex = 46;
            // 
            // txtVelDisp
            // 
            this.txtVelDisp.Location = new System.Drawing.Point(227, 128);
            this.txtVelDisp.Name = "txtVelDisp";
            this.txtVelDisp.ReadOnly = true;
            this.txtVelDisp.Size = new System.Drawing.Size(100, 20);
            this.txtVelDisp.TabIndex = 45;
            // 
            // labelCorriente
            // 
            this.labelCorriente.AutoSize = true;
            this.labelCorriente.Location = new System.Drawing.Point(12, 159);
            this.labelCorriente.Name = "labelCorriente";
            this.labelCorriente.Size = new System.Drawing.Size(49, 13);
            this.labelCorriente.TabIndex = 44;
            this.labelCorriente.Text = "Corriente";
            // 
            // labelVelDisp
            // 
            this.labelVelDisp.AutoSize = true;
            this.labelVelDisp.Location = new System.Drawing.Point(224, 99);
            this.labelVelDisp.Name = "labelVelDisp";
            this.labelVelDisp.Size = new System.Drawing.Size(74, 26);
            this.labelVelDisp.TabIndex = 43;
            this.labelVelDisp.Text = "Velocidad del \r\nDispositivo";
            // 
            // lapBtn
            // 
            this.lapBtn.Location = new System.Drawing.Point(327, 297);
            this.lapBtn.Name = "lapBtn";
            this.lapBtn.Size = new System.Drawing.Size(75, 23);
            this.lapBtn.TabIndex = 42;
            this.lapBtn.Text = "Lap";
            this.lapBtn.UseVisualStyleBackColor = true;
            this.lapBtn.Click += new System.EventHandler(this.lapBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(225, 297);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 41;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // cronometroLabel
            // 
            this.cronometroLabel.AutoSize = true;
            this.cronometroLabel.Location = new System.Drawing.Point(77, 274);
            this.cronometroLabel.Name = "cronometroLabel";
            this.cronometroLabel.Size = new System.Drawing.Size(61, 13);
            this.cronometroLabel.TabIndex = 40;
            this.cronometroLabel.Text = "Cronometro";
            // 
            // cronometroTextBox
            // 
            this.cronometroTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cronometroTextBox.Location = new System.Drawing.Point(16, 290);
            this.cronometroTextBox.Multiline = true;
            this.cronometroTextBox.Name = "cronometroTextBox";
            this.cronometroTextBox.ReadOnly = true;
            this.cronometroTextBox.Size = new System.Drawing.Size(203, 31);
            this.cronometroTextBox.TabIndex = 39;
            this.cronometroTextBox.Text = "00:00:00:0000";
            this.cronometroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(13, 222);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(37, 13);
            this.labelZoom.TabIndex = 37;
            this.labelZoom.Text = "Zoom:";
            // 
            // trackZoom
            // 
            this.trackZoom.Location = new System.Drawing.Point(56, 222);
            this.trackZoom.Maximum = 18;
            this.trackZoom.Minimum = 1;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(104, 45);
            this.trackZoom.TabIndex = 36;
            this.trackZoom.Value = 18;
            this.trackZoom.ValueChanged += new System.EventHandler(this.zoomTrack_Changed);
            // 
            // checkPinPos
            // 
            this.checkPinPos.AutoSize = true;
            this.checkPinPos.Checked = true;
            this.checkPinPos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPinPos.Location = new System.Drawing.Point(224, 71);
            this.checkPinPos.Name = "checkPinPos";
            this.checkPinPos.Size = new System.Drawing.Size(81, 17);
            this.checkPinPos.TabIndex = 35;
            this.checkPinPos.Text = "Pin Position";
            this.checkPinPos.UseVisualStyleBackColor = true;
            this.checkPinPos.CheckedChanged += new System.EventHandler(this.checkPinPosition_Changed);
            // 
            // comboDisp
            // 
            this.comboDisp.DisplayMember = "1";
            this.comboDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisp.FormattingEnabled = true;
            this.comboDisp.Location = new System.Drawing.Point(12, 7);
            this.comboDisp.Name = "comboDisp";
            this.comboDisp.Size = new System.Drawing.Size(121, 21);
            this.comboDisp.TabIndex = 34;
            this.comboDisp.ValueMember = "0";
            this.comboDisp.SelectedIndexChanged += new System.EventHandler(this.Combo_Dispositivo_Changed);
            // 
            // labelLatitud
            // 
            this.labelLatitud.AutoSize = true;
            this.labelLatitud.Location = new System.Drawing.Point(13, 52);
            this.labelLatitud.Name = "labelLatitud";
            this.labelLatitud.Size = new System.Drawing.Size(39, 13);
            this.labelLatitud.TabIndex = 33;
            this.labelLatitud.Text = "Latitud";
            // 
            // txtLatitud
            // 
            this.txtLatitud.Location = new System.Drawing.Point(13, 68);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.ReadOnly = true;
            this.txtLatitud.Size = new System.Drawing.Size(100, 20);
            this.txtLatitud.TabIndex = 32;
            // 
            // labelLongitud
            // 
            this.labelLongitud.AutoSize = true;
            this.labelLongitud.Location = new System.Drawing.Point(119, 52);
            this.labelLongitud.Name = "labelLongitud";
            this.labelLongitud.Size = new System.Drawing.Size(48, 13);
            this.labelLongitud.TabIndex = 31;
            this.labelLongitud.Text = "Longitud";
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(118, 68);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.ReadOnly = true;
            this.txtLongitud.Size = new System.Drawing.Size(100, 20);
            this.txtLongitud.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gmapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private System.Windows.Forms.Timer MapTimer;
        private System.Windows.Forms.Timer CronometroTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lapListBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtVelGPSPromedio;
        private System.Windows.Forms.Label labelVelGPSProm;
        private System.Windows.Forms.TextBox txtVelGPS;
        private System.Windows.Forms.Label labelVelGPS;
        private System.Windows.Forms.TextBox txtCorriente;
        private System.Windows.Forms.TextBox txtVelDisp;
        private System.Windows.Forms.Label labelCorriente;
        private System.Windows.Forms.Label labelVelDisp;
        private System.Windows.Forms.Button lapBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Label cronometroLabel;
        private System.Windows.Forms.TextBox cronometroTextBox;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.CheckBox checkPinPos;
        private System.Windows.Forms.ComboBox comboDisp;
        private System.Windows.Forms.Label labelLatitud;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.Label labelLongitud;
        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.TextBox txtTension;
        private System.Windows.Forms.Label labelTension;
        private System.Windows.Forms.TextBox txtPotencia;
        private System.Windows.Forms.Label labelPotencia;
        private System.Windows.Forms.TextBox txtEnergia;
        private System.Windows.Forms.Label labelEnergia;
    }
}

