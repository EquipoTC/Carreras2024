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
			this.panel1 = new System.Windows.Forms.Panel();
			this.lapListBox = new System.Windows.Forms.ListBox();
			this.panelMain = new System.Windows.Forms.Panel();
			this.panelConfig = new System.Windows.Forms.Panel();
			this.txtAPIUrl = new System.Windows.Forms.TextBox();
			this.labelAPIUrl = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.configIcon = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
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
			this.btnActualizar = new System.Windows.Forms.Button();
			this.configTransition = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.panelConfig.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.configIcon)).BeginInit();
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
			this.MapTimer.Interval = 2000;
			this.MapTimer.Tick += new System.EventHandler(this.Timer_Tick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.lapListBox);
			this.panel1.Controls.Add(this.panelMain);
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
			// panelMain
			// 
			this.panelMain.Controls.Add(this.panelConfig);
			this.panelMain.Controls.Add(this.panel3);
			this.panelMain.Controls.Add(this.txtPotencia);
			this.panelMain.Controls.Add(this.labelPotencia);
			this.panelMain.Controls.Add(this.txtEnergia);
			this.panelMain.Controls.Add(this.labelEnergia);
			this.panelMain.Controls.Add(this.txtTension);
			this.panelMain.Controls.Add(this.labelTension);
			this.panelMain.Controls.Add(this.txtVelGPSPromedio);
			this.panelMain.Controls.Add(this.labelVelGPSProm);
			this.panelMain.Controls.Add(this.txtVelGPS);
			this.panelMain.Controls.Add(this.labelVelGPS);
			this.panelMain.Controls.Add(this.txtCorriente);
			this.panelMain.Controls.Add(this.txtVelDisp);
			this.panelMain.Controls.Add(this.labelCorriente);
			this.panelMain.Controls.Add(this.labelVelDisp);
			this.panelMain.Controls.Add(this.lapBtn);
			this.panelMain.Controls.Add(this.playBtn);
			this.panelMain.Controls.Add(this.cronometroLabel);
			this.panelMain.Controls.Add(this.cronometroTextBox);
			this.panelMain.Controls.Add(this.labelZoom);
			this.panelMain.Controls.Add(this.trackZoom);
			this.panelMain.Controls.Add(this.checkPinPos);
			this.panelMain.Controls.Add(this.comboDisp);
			this.panelMain.Controls.Add(this.labelLatitud);
			this.panelMain.Controls.Add(this.txtLatitud);
			this.panelMain.Controls.Add(this.labelLongitud);
			this.panelMain.Controls.Add(this.txtLongitud);
			this.panelMain.Controls.Add(this.btnActualizar);
			this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelMain.Location = new System.Drawing.Point(0, 0);
			this.panelMain.Name = "panelMain";
			this.panelMain.Size = new System.Drawing.Size(531, 327);
			this.panelMain.TabIndex = 31;
			// 
			// panelConfig
			// 
			this.panelConfig.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panelConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panelConfig.Controls.Add(this.txtAPIUrl);
			this.panelConfig.Controls.Add(this.labelAPIUrl);
			this.panelConfig.Location = new System.Drawing.Point(0, 28);
			this.panelConfig.Name = "panelConfig";
			this.panelConfig.Size = new System.Drawing.Size(531, 48);
			this.panelConfig.TabIndex = 58;
			this.panelConfig.Visible = false;
			// 
			// txtAPIUrl
			// 
			this.txtAPIUrl.Enabled = false;
			this.txtAPIUrl.Location = new System.Drawing.Point(71, 16);
			this.txtAPIUrl.Name = "txtAPIUrl";
			this.txtAPIUrl.Size = new System.Drawing.Size(255, 20);
			this.txtAPIUrl.TabIndex = 1;
			// 
			// labelAPIUrl
			// 
			this.labelAPIUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelAPIUrl.AutoSize = true;
			this.labelAPIUrl.Location = new System.Drawing.Point(13, 19);
			this.labelAPIUrl.Name = "labelAPIUrl";
			this.labelAPIUrl.Size = new System.Drawing.Size(52, 13);
			this.labelAPIUrl.TabIndex = 0;
			this.labelAPIUrl.Text = "API URL:";
			this.labelAPIUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.White;
			this.panel3.Controls.Add(this.configIcon);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(531, 28);
			this.panel3.TabIndex = 57;
			// 
			// configIcon
			// 
			this.configIcon.BackColor = System.Drawing.Color.Transparent;
			this.configIcon.Cursor = System.Windows.Forms.Cursors.Hand;
			this.configIcon.Image = global::Mapa.Properties.Resources.config;
			this.configIcon.Location = new System.Drawing.Point(0, 0);
			this.configIcon.Name = "configIcon";
			this.configIcon.Size = new System.Drawing.Size(29, 28);
			this.configIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.configIcon.TabIndex = 2;
			this.configIcon.TabStop = false;
			this.configIcon.Click += new System.EventHandler(this.config_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(157, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(224, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Carreras | Escuela de Educación Tecnica N°2";
			// 
			// txtPotencia
			// 
			this.txtPotencia.Location = new System.Drawing.Point(332, 202);
			this.txtPotencia.Name = "txtPotencia";
			this.txtPotencia.ReadOnly = true;
			this.txtPotencia.Size = new System.Drawing.Size(100, 20);
			this.txtPotencia.TabIndex = 56;
			// 
			// labelPotencia
			// 
			this.labelPotencia.AutoSize = true;
			this.labelPotencia.Location = new System.Drawing.Point(332, 186);
			this.labelPotencia.Name = "labelPotencia";
			this.labelPotencia.Size = new System.Drawing.Size(49, 13);
			this.labelPotencia.TabIndex = 55;
			this.labelPotencia.Text = "Potencia";
			// 
			// txtEnergia
			// 
			this.txtEnergia.Location = new System.Drawing.Point(226, 202);
			this.txtEnergia.Name = "txtEnergia";
			this.txtEnergia.ReadOnly = true;
			this.txtEnergia.Size = new System.Drawing.Size(100, 20);
			this.txtEnergia.TabIndex = 54;
			// 
			// labelEnergia
			// 
			this.labelEnergia.AutoSize = true;
			this.labelEnergia.Location = new System.Drawing.Point(223, 186);
			this.labelEnergia.Name = "labelEnergia";
			this.labelEnergia.Size = new System.Drawing.Size(45, 13);
			this.labelEnergia.TabIndex = 53;
			this.labelEnergia.Text = "Energía";
			// 
			// txtTension
			// 
			this.txtTension.Location = new System.Drawing.Point(120, 202);
			this.txtTension.Name = "txtTension";
			this.txtTension.ReadOnly = true;
			this.txtTension.Size = new System.Drawing.Size(100, 20);
			this.txtTension.TabIndex = 52;
			// 
			// labelTension
			// 
			this.labelTension.AutoSize = true;
			this.labelTension.Location = new System.Drawing.Point(117, 186);
			this.labelTension.Name = "labelTension";
			this.labelTension.Size = new System.Drawing.Size(45, 13);
			this.labelTension.TabIndex = 51;
			this.labelTension.Text = "Tensión";
			// 
			// txtVelGPSPromedio
			// 
			this.txtVelGPSPromedio.Location = new System.Drawing.Point(120, 155);
			this.txtVelGPSPromedio.Name = "txtVelGPSPromedio";
			this.txtVelGPSPromedio.ReadOnly = true;
			this.txtVelGPSPromedio.Size = new System.Drawing.Size(100, 20);
			this.txtVelGPSPromedio.TabIndex = 50;
			// 
			// labelVelGPSProm
			// 
			this.labelVelGPSProm.AutoSize = true;
			this.labelVelGPSProm.Location = new System.Drawing.Point(118, 126);
			this.labelVelGPSProm.Name = "labelVelGPSProm";
			this.labelVelGPSProm.Size = new System.Drawing.Size(79, 26);
			this.labelVelGPSProm.TabIndex = 49;
			this.labelVelGPSProm.Text = "Velocidad GPS\r\n(Promedio)";
			// 
			// txtVelGPS
			// 
			this.txtVelGPS.Location = new System.Drawing.Point(14, 155);
			this.txtVelGPS.Name = "txtVelGPS";
			this.txtVelGPS.ReadOnly = true;
			this.txtVelGPS.Size = new System.Drawing.Size(100, 20);
			this.txtVelGPS.TabIndex = 48;
			// 
			// labelVelGPS
			// 
			this.labelVelGPS.AutoSize = true;
			this.labelVelGPS.Location = new System.Drawing.Point(13, 139);
			this.labelVelGPS.Name = "labelVelGPS";
			this.labelVelGPS.Size = new System.Drawing.Size(79, 13);
			this.labelVelGPS.TabIndex = 47;
			this.labelVelGPS.Text = "Velocidad GPS";
			// 
			// txtCorriente
			// 
			this.txtCorriente.Location = new System.Drawing.Point(14, 202);
			this.txtCorriente.Name = "txtCorriente";
			this.txtCorriente.ReadOnly = true;
			this.txtCorriente.Size = new System.Drawing.Size(100, 20);
			this.txtCorriente.TabIndex = 46;
			// 
			// txtVelDisp
			// 
			this.txtVelDisp.Location = new System.Drawing.Point(226, 155);
			this.txtVelDisp.Name = "txtVelDisp";
			this.txtVelDisp.ReadOnly = true;
			this.txtVelDisp.Size = new System.Drawing.Size(100, 20);
			this.txtVelDisp.TabIndex = 45;
			// 
			// labelCorriente
			// 
			this.labelCorriente.AutoSize = true;
			this.labelCorriente.Location = new System.Drawing.Point(11, 186);
			this.labelCorriente.Name = "labelCorriente";
			this.labelCorriente.Size = new System.Drawing.Size(49, 13);
			this.labelCorriente.TabIndex = 44;
			this.labelCorriente.Text = "Corriente";
			// 
			// labelVelDisp
			// 
			this.labelVelDisp.AutoSize = true;
			this.labelVelDisp.Location = new System.Drawing.Point(223, 126);
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
			this.labelZoom.Location = new System.Drawing.Point(13, 233);
			this.labelZoom.Name = "labelZoom";
			this.labelZoom.Size = new System.Drawing.Size(37, 13);
			this.labelZoom.TabIndex = 37;
			this.labelZoom.Text = "Zoom:";
			// 
			// trackZoom
			// 
			this.trackZoom.Location = new System.Drawing.Point(56, 233);
			this.trackZoom.Maximum = 18;
			this.trackZoom.Minimum = 6;
			this.trackZoom.Name = "trackZoom";
			this.trackZoom.Size = new System.Drawing.Size(163, 45);
			this.trackZoom.TabIndex = 36;
			this.trackZoom.Value = 18;
			this.trackZoom.ValueChanged += new System.EventHandler(this.zoomTrack_Changed);
			// 
			// checkPinPos
			// 
			this.checkPinPos.AutoSize = true;
			this.checkPinPos.Checked = true;
			this.checkPinPos.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkPinPos.Location = new System.Drawing.Point(223, 98);
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
			this.comboDisp.Location = new System.Drawing.Point(8, 47);
			this.comboDisp.Name = "comboDisp";
			this.comboDisp.Size = new System.Drawing.Size(121, 21);
			this.comboDisp.TabIndex = 34;
			this.comboDisp.ValueMember = "0";
			this.comboDisp.SelectedIndexChanged += new System.EventHandler(this.Combo_Dispositivo_Changed);
			// 
			// labelLatitud
			// 
			this.labelLatitud.AutoSize = true;
			this.labelLatitud.Location = new System.Drawing.Point(12, 79);
			this.labelLatitud.Name = "labelLatitud";
			this.labelLatitud.Size = new System.Drawing.Size(39, 13);
			this.labelLatitud.TabIndex = 33;
			this.labelLatitud.Text = "Latitud";
			// 
			// txtLatitud
			// 
			this.txtLatitud.Location = new System.Drawing.Point(12, 95);
			this.txtLatitud.Name = "txtLatitud";
			this.txtLatitud.ReadOnly = true;
			this.txtLatitud.Size = new System.Drawing.Size(100, 20);
			this.txtLatitud.TabIndex = 32;
			// 
			// labelLongitud
			// 
			this.labelLongitud.AutoSize = true;
			this.labelLongitud.Location = new System.Drawing.Point(118, 79);
			this.labelLongitud.Name = "labelLongitud";
			this.labelLongitud.Size = new System.Drawing.Size(48, 13);
			this.labelLongitud.TabIndex = 31;
			this.labelLongitud.Text = "Longitud";
			// 
			// txtLongitud
			// 
			this.txtLongitud.Location = new System.Drawing.Point(117, 95);
			this.txtLongitud.Name = "txtLongitud";
			this.txtLongitud.ReadOnly = true;
			this.txtLongitud.Size = new System.Drawing.Size(100, 20);
			this.txtLongitud.TabIndex = 30;
			// 
			// btnActualizar
			// 
			this.btnActualizar.Location = new System.Drawing.Point(135, 46);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(73, 23);
			this.btnActualizar.TabIndex = 33;
			this.btnActualizar.Text = "Actualizar";
			this.btnActualizar.UseVisualStyleBackColor = true;
			this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
			// 
			// configTransition
			// 
			this.configTransition.Interval = 10;
			this.configTransition.Tick += new System.EventHandler(this.configTransition_Tick);
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(984, 561);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.gmapControl);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.panel1.ResumeLayout(false);
			this.panelMain.ResumeLayout(false);
			this.panelMain.PerformLayout();
			this.panelConfig.ResumeLayout(false);
			this.panelConfig.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.configIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private System.Windows.Forms.Timer MapTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lapListBox;
        private System.Windows.Forms.Panel panelMain;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox configIcon;
        private System.Windows.Forms.Panel panelConfig;
        private System.Windows.Forms.Label labelAPIUrl;
        private System.Windows.Forms.TextBox txtAPIUrl;
        private System.Windows.Forms.Timer configTransition;
        private System.Windows.Forms.Button btnActualizar;
    }
}

