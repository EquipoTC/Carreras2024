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
			this.resetBtn = new System.Windows.Forms.Button();
			this.panelConfig = new System.Windows.Forms.Panel();
			this.txtAPIUrl = new System.Windows.Forms.TextBox();
			this.labelAPIUrl = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.configIcon = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtVelGPSPromedio = new System.Windows.Forms.TextBox();
			this.labelVelGPSProm = new System.Windows.Forms.Label();
			this.txtVelGPS = new System.Windows.Forms.TextBox();
			this.labelVelGPS = new System.Windows.Forms.Label();
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.panelMain.SuspendLayout();
			this.panelConfig.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.configIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
			this.panel2.SuspendLayout();
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
			this.gmapControl.Size = new System.Drawing.Size(453, 761);
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
			this.panel1.Size = new System.Drawing.Size(531, 761);
			this.panel1.TabIndex = 17;
			// 
			// lapListBox
			// 
			this.lapListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lapListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lapListBox.FormattingEnabled = true;
			this.lapListBox.ItemHeight = 16;
			this.lapListBox.Location = new System.Drawing.Point(0, 278);
			this.lapListBox.Name = "lapListBox";
			this.lapListBox.Size = new System.Drawing.Size(531, 483);
			this.lapListBox.TabIndex = 32;
			// 
			// panelMain
			// 
			this.panelMain.Controls.Add(this.resetBtn);
			this.panelMain.Controls.Add(this.panelConfig);
			this.panelMain.Controls.Add(this.panel3);
			this.panelMain.Controls.Add(this.txtVelGPSPromedio);
			this.panelMain.Controls.Add(this.labelVelGPSProm);
			this.panelMain.Controls.Add(this.txtVelGPS);
			this.panelMain.Controls.Add(this.labelVelGPS);
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
			this.panelMain.Size = new System.Drawing.Size(531, 278);
			this.panelMain.TabIndex = 31;
			// 
			// resetBtn
			// 
			this.resetBtn.Location = new System.Drawing.Point(424, 244);
			this.resetBtn.Name = "resetBtn";
			this.resetBtn.Size = new System.Drawing.Size(75, 23);
			this.resetBtn.TabIndex = 59;
			this.resetBtn.Text = "Reset";
			this.resetBtn.UseVisualStyleBackColor = true;
			this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
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
			// lapBtn
			// 
			this.lapBtn.Location = new System.Drawing.Point(318, 244);
			this.lapBtn.Name = "lapBtn";
			this.lapBtn.Size = new System.Drawing.Size(75, 23);
			this.lapBtn.TabIndex = 42;
			this.lapBtn.Text = "Lap";
			this.lapBtn.UseVisualStyleBackColor = true;
			this.lapBtn.Click += new System.EventHandler(this.lapBtn_Click);
			// 
			// playBtn
			// 
			this.playBtn.Location = new System.Drawing.Point(216, 244);
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
			this.cronometroLabel.Location = new System.Drawing.Point(68, 221);
			this.cronometroLabel.Name = "cronometroLabel";
			this.cronometroLabel.Size = new System.Drawing.Size(61, 13);
			this.cronometroLabel.TabIndex = 40;
			this.cronometroLabel.Text = "Cronometro";
			// 
			// cronometroTextBox
			// 
			this.cronometroTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cronometroTextBox.Location = new System.Drawing.Point(7, 237);
			this.cronometroTextBox.Multiline = true;
			this.cronometroTextBox.Name = "cronometroTextBox";
			this.cronometroTextBox.ReadOnly = true;
			this.cronometroTextBox.Size = new System.Drawing.Size(203, 31);
			this.cronometroTextBox.TabIndex = 39;
			this.cronometroTextBox.Text = "00:00:00:000";
			this.cronometroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelZoom
			// 
			this.labelZoom.AutoSize = true;
			this.labelZoom.Location = new System.Drawing.Point(14, 189);
			this.labelZoom.Name = "labelZoom";
			this.labelZoom.Size = new System.Drawing.Size(37, 13);
			this.labelZoom.TabIndex = 37;
			this.labelZoom.Text = "Zoom:";
			// 
			// trackZoom
			// 
			this.trackZoom.Location = new System.Drawing.Point(57, 189);
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
			// panel2
			// 
			this.panel2.Controls.Add(this.gmapControl);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(453, 761);
			this.panel2.TabIndex = 18;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.ClientSize = new System.Drawing.Size(984, 761);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
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
			this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox configIcon;
        private System.Windows.Forms.Timer configTransition;
        private System.Windows.Forms.Button btnActualizar;
		private System.Windows.Forms.Panel panelConfig;
		private System.Windows.Forms.TextBox txtAPIUrl;
		private System.Windows.Forms.Label labelAPIUrl;
		private System.Windows.Forms.Button resetBtn;
		private System.Windows.Forms.Panel panel2;
	}
}

